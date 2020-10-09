using GravitonCar.Models;
using GravitonCarLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonCarLibrary.DataAccess
{
    public interface IDataConnection
    {

        //User KYC Log
        void CreateKYCLog(KYCLogModel model);
        int GetCount_USer(int user_id, string date);


        //API
        List<string> GetSearchNameList(string token);
        Task<bool> CreateCarAsync(string token, CarModel car);
        CarModel GetKycDataAPI(string token, string aadhar);
        Task<string> GetComboBoxDataAsync(string token);
        Task<List<string>> GetAadharListAsync(string token);
        Task<List<string>> GetPanListAsync(string token);
        bool DisableUser(string token, int user_id, string username, string password);
        UserModel GetUsermodelAPI(LoginCredentials credentials);
        Task<bool> CreateUserAsync(UserModel user);
        List<UserModel> GetActiveUserAPI(string token);

    }
}
