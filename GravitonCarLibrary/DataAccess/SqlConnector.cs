using Dapper;
using GravitonCar.Models;
using GravitonCarLibrary.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Npgsql;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GravitonCarLibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        
        public int GetCount_USer(int user_id, string date)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                int count = connection.ExecuteScalar<int>($"select count(user_id) from user_kyc_log where user_id = {user_id} and kyc_date = '{date}'");
                return count;
            }
        }

        //User KYC Log
        public void CreateKYCLog(KYCLogModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                connection.ExecuteScalar<int>($"insert into user_kyc_log values(default,{model.user_id},'{model.related_aadhar}','{model.related_pan}',default)");
            }
        }

        public UserModel GetUsermodelAPI(LoginCredentials credentials)
        {
            var client = new RestClient($"{GlobalConfig.getApiConnection()}/public/login");
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(credentials);
            request.AddHeader("content-type", "application/json");
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject obj = JObject.Parse(response.Content);
                string tokenName = "token";
                var x = obj[tokenName];

                var jwt = x.ToString();
                //Assume the input is in a control called JwtIn,
                //and the output will be placed in a control called JwtOut
                var jwtHandler = new JwtSecurityTokenHandler();
                var jwtInput = jwt;

                var jwtOut = "";

                //Check if readable token (string is in a JWT format)
                var readableToken = jwtHandler.CanReadToken(jwtInput);

                if (readableToken != true)
                {
                    jwtOut = "The token doesn't seem to be in a proper JWT format.";
                }

                if (readableToken)
                {
                    var token = jwtHandler.ReadJwtToken(jwtInput);

                    var claims = token.Claims;
                    var jwtPayload = "{";
                    foreach (Claim c in claims)
                    {
                        jwtPayload += '"' + c.Type + "\":\"" + c.Value + "\",";
                    }
                    jwtPayload += "}";
                    jwtOut += "\r\nPayload:\r\n" + JToken.Parse(jwtPayload).ToString(Formatting.Indented);

                    JObject obj1 = JObject.Parse(jwtPayload);

                    string enKey = "encryptedPayload";

                    string encryptedPayload = obj1[enKey].ToString();

                    var data = AesEncryption.DecryptStringAES(encryptedPayload);

                    UserModel user = new UserModel();

                    user = JsonConvert.DeserializeObject<UserModel>(data);

                    user.jwtToken = jwt;

                    return user;

                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> CreateUserAsync(UserModel user)
        {
            var client = new RestClient($"{GlobalConfig.getApiConnection()}/public/register");
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(user);
            request.AddHeader("content-type", "application/json");
            var cancellationTokenSource = new CancellationTokenSource();
            IRestResponse response = await client.ExecuteAsync(request, cancellationTokenSource.Token);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets active users list from database
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<UserModel> GetActiveUserAPI(string token)
        {
            List<UserModel> activeUsers = new List<UserModel>();
            var client = new RestClient($"{GlobalConfig.getApiConnection()}/private/logins");
            client.Authenticator = new JwtAuthenticator(token);
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject obj = JObject.Parse(response.Content);
                var userList = obj["users"];
                int userCount = userList.Count();
                for (int i = 0; i < userCount; i++)
                {
                    var user = obj["users"][i];
                    user["permissions"] = user["permissions"].ToString();
                    var user_string = user.ToString();
                    activeUsers.Add(JsonConvert.DeserializeObject<UserModel>(user_string));
                }
                /*if(activeUsers.Count != 0)
                {
                    return activeUsers;
                }
                else
                {
                    return null;
                }*/
                return activeUsers;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> CreateCarAsync(string token, CarModel car)
        {
            var client = new RestClient($"{GlobalConfig.getApiConnection()}/private/CAR/create");
            client.Authenticator = new JwtAuthenticator(token);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(car);
            request.AddHeader("content-type", "application/json");
            var cancellationTokenSource = new CancellationTokenSource();
            IRestResponse response = await client.ExecuteAsync(request, cancellationTokenSource.Token);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<string> GetSearchNameList(string token)
        {
            var client = new RestClient($"{GlobalConfig.getApiConnection()}/private/CAR/getFnameWithAadhar");
            client.Authenticator = new JwtAuthenticator(token);
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JArray array = JArray.Parse(response.Content);
                List<string> list = new List<string>();
                for (int i = 0; i < array.Count; i++)
                {
                    list.Add(array[i].ToString());
                }
                return list;
            }
            else
            {
                return null;
            }
        }

        public CarModel GetKycDataAPI(string token, string aadhar)
        {
            CarModel model = new CarModel();
            var client = new RestClient($"{GlobalConfig.getApiConnection()}/private/CAR/getForUser?aadhar={aadhar}");
            client.Authenticator = new JwtAuthenticator(token);
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject carObj = JObject.Parse(response.Content);
                //model = JsonConvert.DeserializeObject<CarModel>(response.Content);
                model.documentModel = JsonConvert.DeserializeObject<DocumentModel>(carObj["documentModel"][0].ToString());
                model.applicantModel = JsonConvert.DeserializeObject<ApplicantModel>(carObj["applicantModel"][0].ToString());
                var str = carObj["accountModel"][0]["account_inhandsalary"].ToString();
                carObj["accountModel"][0]["account_inhandsalary"] = int.Parse(str);
                model.accountModel = JsonConvert.DeserializeObject<AccountModel>(carObj["accountModel"][0].ToString());
                model.gurantorModel = JsonConvert.DeserializeObject<GurantorModel>(carObj["gurantorModel"][0].ToString());
                model.loanModel = JsonConvert.DeserializeObject<List<LoanModel>>(carObj["loanModel"].ToString());
                return model;
            }
            else
            {
                return null;
            }
        }

        public async Task<string> GetComboBoxDataAsync(string token)
        {
            var client = new RestClient($"{GlobalConfig.getApiConnection()}/private/CAR/getComboBoxData");
            client.Authenticator = new JwtAuthenticator(token);
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            var cancellationTokenSource = new CancellationTokenSource();
            IRestResponse response = await client.ExecuteAsync(request, cancellationTokenSource.Token);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Content;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<string>> GetAadharListAsync(string token)
        {
            var client = new RestClient($"{GlobalConfig.getApiConnection()}/private/CAR/getAllAadhar");
            client.Authenticator = new JwtAuthenticator(token);
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            var cancellationTokenSource = new CancellationTokenSource();
            IRestResponse response = await client.ExecuteAsync(request, cancellationTokenSource.Token);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JArray array = JArray.Parse(response.Content);
                List<string> aadharList = JsonConvert.DeserializeObject<List<string>>(array.ToString());
                return aadharList;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<string>> GetPanListAsync(string token)
        {
            var client = new RestClient($"{GlobalConfig.getApiConnection()}/private/CAR/getAllPan");
            client.Authenticator = new JwtAuthenticator(token);
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            var cancellationTokenSource = new CancellationTokenSource();
            IRestResponse response = await client.ExecuteAsync(request, cancellationTokenSource.Token);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JArray array = JArray.Parse(response.Content);
                List<string> panList = JsonConvert.DeserializeObject<List<string>>(array.ToString());
                return panList;
            }
            else
            {
                return null;
            }
        }

        public bool DisableUser(string token, int user_id, string username, string password)
        {
            var client = new RestClient($"{GlobalConfig.getApiConnection()}/private/User/disableUser?user_id={user_id}&username={username}&password={password}");
            client.Authenticator = new JwtAuthenticator(token);
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            IRestResponse response = client.Execute(request);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
