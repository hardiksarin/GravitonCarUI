using Dapper;
using GravitonCarLibrary.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonCarLibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        //Account
        public AccountModel CreateAccount(AccountModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                int id = connection.ExecuteScalar<int>($"insert into account values('{model.account_bankname}','{model.account_ifsc}','{model.account_number}','{model.account_inhandsalary}','{model.account_realtedpan}','{model.account_realtedaadhar}')");
                return model;
            }
        }

        public void UpdateAccount(AccountModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                connection.ExecuteScalar($"update account set account_bankname = '{model.account_bankname}', account_ifsc = '{model.account_ifsc}', account_number = {model.account_number}, account_inhandsalary = {model.account_inhandsalary}, account_relatedpan = {model.account_realtedpan}, account_relatedaadhar = '{model.account_realtedaadhar}'");
            }
        }

        public List<AccountModel> GetAccounts_All()
        {
            List<AccountModel> output = new List<AccountModel>();
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                output = connection.Query<AccountModel>("select * from account").ToList();
                return output;
            }
        }
        //Account


        //Acquaintance
      
        public AcquaintanceModel CreateAcquaintance(AcquaintanceModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                int id = connection.ExecuteScalar<int>($"insert into acquaintance values(default,'{model.acquaintance_id}','{model.acquaintance_name}')");
                return model;
            }
        }

        public void UpdateAcquaintance(AcquaintanceModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                connection.ExecuteScalar($"update acquaintance set acquaintance_id = '{model.acquaintance_id}', acquaintance_name = '{model.acquaintance_name}'");
            }
        }
        public List<AcquaintanceModel> GetAcquaintance_All()
        {
            List<AcquaintanceModel> output = new List<AcquaintanceModel>();
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                output = connection.Query<AcquaintanceModel>("select * from acquaintance").ToList();
                return output;
            }
        }
        //Acquaintance


        //Applicant

        public ApplicantModel CreateApplicant(ApplicantModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                int id = connection.ExecuteScalar<int>($"insert into applicant values('{model.applicant_firstname}','{model.applicant_middlename}','{model.applicant_lastname}','{model.applicant_acquaintancename}'," +
                    $"'{model.applicant_dob}','{model.applicant_state}','{model.applicant_district}','{model.applicant_pincode}','{model.applicant_currentaddress}','{model.applicant_mobile}','{model.applicant_officeno}'," +
                    $"'{model.applicant_desgination}','{model.applicant_education}','{model.applicant_employername}','{model.applicant_officeaddress}','{model.applicant_nearestbranch}','{model.applicant_distance}'," +
                    $"'{model.applicant_acquaintanceid}','{model.applicant_maritalstatusid}','{model.applicant_casteid}','{model.applicant_categoryid}','{model.applicant_pan}','{model.applicant_aadhar}')");
                return model;
            }
        }
        public List<ApplicantModel> GetApplicant_All()
        {
            List<ApplicantModel> output = new List<ApplicantModel>();
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                output = connection.Query<ApplicantModel>("select * from applicant").ToList();
                return output;
            }
        }

        public void UpdateApplicant(ApplicantModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                connection.ExecuteScalar($"update applicant set applicant_firstname = '{model.applicant_firstname}', applicant_middlename = '{model.applicant_middlename}', applicant_lastname = '{model.applicant_lastname}', applicant_acquaintancename = '{model.applicant_acquaintancename}', applicant_dob = '{model.applicant_dob}', applicant_state = '{model.applicant_state}', applicant_district = '{model.applicant_district}', applicant_pincode = '{model.applicant_pincode}', applicant_currentaddress = '{model.applicant_currentaddress}', applicant_mobile = '{model.applicant_mobile}', applicant_officeno = '{model.applicant_officeno}', applicant_desgination = '{model.applicant_desgination}', applicant_education = '{model.applicant_education}',applicant_employername = '{model.applicant_employername}', applicant_officeaddress = '{model.applicant_officeaddress}', applicant_nearestbranch = '{model.applicant_nearestbranch}', applicant_distance = '{model.applicant_distance}', applicant_acquaintanceid = '{model.applicant_acquaintanceid}', applicant_officeaddress = '{model.applicant_categoryid}', applicant_nearestbranch = '{model.applicant_casteid}', applicant_maritalstatusid = '{model.applicant_maritalstatusid}', applicant_pan = '{model.applicant_pan}', applicant_aadhar = '{model.applicant_aadhar}'");
            }
        }

        //Applicant



        //Caste

        public List<CasteModel> GetCaste_All()
        {
            List<CasteModel> output = new List<CasteModel>();
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                output = connection.Query<CasteModel>("select * from caste").ToList();
                return output;
            }
        }

        public void UpdateCaste(CasteModel model)
        {

            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                connection.ExecuteScalar($"update caste set caste_id = '{model.caste_id}', caste_name = '{model.caste_name}'");
            }
        }

        public CasteModel CreateCaste(CasteModel model)
        {

            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                int id = connection.ExecuteScalar<int>($"insert into caste values(default,'{model.caste_id}','{model.caste_name}')");
                return model;
            }
        }
        //Caste


        //Category
        public List<CategoryModel> GetCategory_All()
        {
            List<CategoryModel> output = new List<CategoryModel>();
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                output = connection.Query<CategoryModel>("select * from category").ToList();
                return output;
            }
        }

        public void UpdateCategory(CategoryModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                connection.ExecuteScalar($"update category set category_id = '{model.category_id}', category_name = '{model.category_name}'");
            }
        }

        public CategoryModel CreateCategory(CategoryModel model)
        {

            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                int id = connection.ExecuteScalar<int>($"insert into category values(default,'{model.category_id}','{model.category_name}')");
                return model;
            }
        }

        //Category


        //Document

        public List<DocumentModel> GetDocument_All()
        {
            List<DocumentModel> output = new List<DocumentModel>();
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                output = connection.Query<DocumentModel>("select * from document").ToList();
                return output;
            }
        }

        public void UpdateDocument(DocumentModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                connection.ExecuteScalar($"update document set document_pan = '{model.document_pan}', document_aadhar = '{model.document_aadhar}',document_optional = '{model.document_optional}', document_cibil = '{model.document_cibil}',document_remark = '{model.document_remark}', document_id = '{model.document_id}', progress_id = '{model.progress_id}'");
            }
        }

        public DocumentModel CreateDocument(DocumentModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                int id = connection.ExecuteScalar<int>($"insert into document values('{model.document_pan}','{model.document_aadhar}','{model.document_optional}',{model.document_cibil},'{model.document_remark}',{model.document_id})");
                return model;
            }
        }

        //Document


        //DocumentType
        public List<DocumentTypeModel> GetDocumentType_All()
        {
            List<DocumentTypeModel> output = new List<DocumentTypeModel>();
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                output = connection.Query<DocumentTypeModel>("select * from documenttype").ToList();
                return output;
            }
        }

        public void UpdateDocumentType(DocumentTypeModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                connection.ExecuteScalar($"update documenttype set documenttype_id = '{model.documenttype_id}', documenttype_name = '{model.documenttype_name}'");
            }
        }

        public DocumentTypeModel CreateDocumentType(DocumentTypeModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                int id = connection.ExecuteScalar<int>($"insert into documenttype values(default,'{model.documenttype_id}','{model.documenttype_name}')");
                return model;
            }
        }


        //DocumentType

        //Gurantor
        public List<GurantorModel> GetGurantor_All()
        {
            List<GurantorModel> output = new List<GurantorModel>();
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                output = connection.Query<GurantorModel>("select * from gurantor").ToList();
                return output;
            }
        }

        public void UpdateGurantor(GurantorModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                connection.ExecuteScalar($"update gurantor set gurantor_firstname = '{model.gurantor_firstname}', gurantor_middlename = '{model.gurantor_middlename}',gurantor_lastname = '{model.gurantor_lastname}', gurantor_currentaddress = '{model.gurantor_currentaddress}',gurantor_mobile = '{model.gurantor_mobile}', gurantor_relation = '{model.gurantor_relation}', gurantor_realtedpan = '{model.gurantor_realtedpan}', gurantor_realtedaadhar = '{model.gurantor_realtedaadhar}', gurantortype_id = '{model.gurantortype_id}'");
            }
        }

        public GurantorModel CreateGurantor(GurantorModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                int id = connection.ExecuteScalar<int>($"insert into gurantor values('{model.gurantor_firstname}','{model.gurantor_middlename}','{model.gurantor_lastname}','{model.gurantor_currentaddress}','{model.gurantor_mobile}','{model.gurantor_relation}','{model.gurantor_realtedpan}','{model.gurantor_realtedaadhar}',{model.gurantortype_id})");
                return model;
            }
        }

        //Gurantor

        //GurantorType
        public List<GurantorTypeModel> GetGurantorType_All()
        {
            List<GurantorTypeModel> output = new List<GurantorTypeModel>();
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                output = connection.Query<GurantorTypeModel>("select * from gurantortype").ToList();
                return output;
            }
        }

        public void UpdateGurantorType(GurantorTypeModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                connection.ExecuteScalar($"update gurantortype set gurantortype_id = '{model.gurantortype_id}', gurantortype_name = '{model.gurantortype_name}'");
            }
        }

        public GurantorTypeModel CreateGurantorType(GurantorTypeModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                int id = connection.ExecuteScalar<int>($"insert into gurantortype values(default,'{model.gurantortype_id}','{model.gurantortype_name}')");
                return model;
            }
        }

        //GurantorType

        //Loan
        public List<LoanModel> GetLoan_All()
        {
            List<LoanModel> output = new List<LoanModel>();
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                output = connection.Query<LoanModel>("select * from loan").ToList();
                return output;
            }
        }

        public void UpdateLoan(LoanModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                connection.ExecuteScalar($"update loan set loan_id = '{model.loan_id}', loan_bankname = '{model.loan_bankname}',loan_amount = '{model.loan_amount}', loan_emi = '{model.loan_emi}',loan_closuredate = '{model.loan_closuredate}', loan_type = '{model.loan_type}', loan_relatedpan = '{model.account_realtedpan}', loan_relatedaadhar = '{model.account_realtedaadhar}'");
            }
        }

        public LoanModel CreateLoan(LoanModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                int id = connection.ExecuteScalar<int>($"insert into loan values(default,'{model.loan_bankname}',{model.loan_amount},{model.loan_emi},'2020-06-30',{model.loan_type},'{model.account_realtedpan}','{model.account_realtedaadhar}')");
                return model;
            }
        }
        //Loan

        //LoanType

        public List<LoanTypeModel> GetLoanType_All()
        {
            List<LoanTypeModel> output = new List<LoanTypeModel>();
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                output = connection.Query<LoanTypeModel>("select * from loantype").ToList();
                return output;
            }
        }

        public void UpdateLoanType(LoanTypeModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                connection.ExecuteScalar($"update loantype set loantype_id = '{model.loantype_id}', loantype_name = '{model.loantype_name}'");
            }
        }

        public LoanTypeModel CreateLoanType(LoanTypeModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                int id = connection.ExecuteScalar<int>($"insert into loantype values(default,'{model.loantype_id}','{model.loantype_name}'");
                return model;
            }
        }

        //LoanType

        //MarriedStatus


        public List<MarriedStatusModel> GetMarried_All()
        {
            List<MarriedStatusModel> output = new List<MarriedStatusModel>();
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                output = connection.Query<MarriedStatusModel>("select * from maritalstatus").ToList();
                return output;
            }
        }

        public void UpdateMarriedStatus(MarriedStatusModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                connection.ExecuteScalar($"update maritalstatus set maritalstatus_id = '{model.maritalstatus_id}', maritalstatus_name = '{model.maritalstatus_name}'");
            }
        }

        public MarriedStatusModel CreateMarriedStatusModel(MarriedStatusModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                int id = connection.ExecuteScalar<int>($"insert into maritalstatus values(default,'{model.maritalstatus_id}','{model.maritalstatus_name}'");
                return model;
            }
        }

        //MarriedStatus

        //Progress
        public List<ProgressModel> GetProgress_All()
        {
            List<ProgressModel> output = new List<ProgressModel>();
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                output = connection.Query<ProgressModel>("select * from progress").ToList();
                return output;
            }
        }

        public void UpdateProgress(ProgressModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                connection.ExecuteScalar($"update progress set progress_id = '{model.progress_id}', progress_name = '{model.progress_name}'");
            }
        }

        public ProgressModel CreateProgress(ProgressModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                int id = connection.ExecuteScalar<int>($"insert into progress values(default,'{model.progress_id}','{model.progress_name}'");
                return model;
            }
        }


        //CAR
        public void CreateCar(CarModel model, UserModel user)
        {
            CreateDocument(model.documentModel);
            CreateApplicant(model.applicantModel);
            CreateGurantor(model.gurantorModel);
            CreateAccount(model.accountModel);

            foreach (LoanModel loan in model.loanModel)
            {
                CreateLoan(loan);
            }

            KYCLogModel log = new KYCLogModel();
            log.user_id = user.user_id;
            log.related_pan = model.documentModel.document_pan;
            log.related_aadhar = model.documentModel.document_aadhar;

            CreateKYCLog(log);
        }

        public CarModel GetCar_ById(string aadhar, string pan)
        {
            CarModel model = new CarModel();
            model.documentModel = GetDocument_ById(aadhar, pan)[0];
            model.applicantModel = GetApplicant_ById(aadhar, pan)[0];
            model.gurantorModel = GetGurantor_ById(aadhar, pan)[0];
            model.accountModel = GetAccount_ById(aadhar, pan);
            model.loanModel = GetLoan_ById(aadhar, pan);
            return model;
        }

        public AccountModel GetAccount_ById(string aadhar, string pan)
        {
            List<AccountModel> output = new List<AccountModel>();
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                output = connection.Query<AccountModel>($"select * from account where account_realtedpan = '{pan}' and account_realtedaadhar = '{aadhar}'").ToList();
                return output[0];
            }
        }

        public List<DocumentModel> GetDocument_ById(string aadhar, string pan)
        {
            List<DocumentModel> output = new List<DocumentModel>();
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                output = connection.Query<DocumentModel>($"select * from document where document_pan = '{pan}' and document_aadhar = '{aadhar}'").ToList();
                return output;
            }
        }

        public List<ApplicantModel> GetApplicant_ById(string aadhar, string pan)
        {
            List<ApplicantModel> output = new List<ApplicantModel>();
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                output = connection.Query<ApplicantModel>($"select * from applicant where applicant_pan = '{pan}' and applicant_aadhar = '{aadhar}'").ToList();
                return output;
            }
        }

        public List<GurantorModel> GetGurantor_ById(string aadhar, string pan)
        {
            List<GurantorModel> output = new List<GurantorModel>();
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                output = connection.Query<GurantorModel>($"select * from gurantor where gurantor_realtedpan = '{pan}' and gurantor_realtedaadhar = '{aadhar}'").ToList();
                return output;
            }
        }

        public List<LoanModel> GetLoan_ById(string aadhar, string pan)
        {
            List<LoanModel> output = new List<LoanModel>();
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                output = connection.Query<LoanModel>($"select * from loan where account_realtedpan = '{pan}' and account_realtedaadhar = '{aadhar}'").ToList();
                return output;
            }
        }


        //User

        public UserModel GetUserModel(string username, string password)
        {
            List<UserModel> output = new List<UserModel>();
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                output = connection.Query<UserModel>($"select * from login where username = '{username}' and password = '{password}'").ToList();
                if(output.Count != 0)
                {
                    return output[0];
                }
                return null;
            }
        }

        public List<UserModel> GetUser_All()
        {
            List<UserModel> output = new List<UserModel>();
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                output = connection.Query<UserModel>($"select * from login").ToList();
                return output;
            }
        }

        public UserModel CreateUser(UserModel user)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                int id = connection.ExecuteScalar<int>($"insert into login values(default,'{user.full_name}','{user.username}','{user.designation}','{user.user_dob}','{user.password}','{user.permissions}'");
                return user;
            }
        }

        public void DeleteUser(UserModel user)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                connection.ExecuteScalar<int>($"delete from login where user_id = {user.user_id}");
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

        public int GetCount_USer(int user_id, string date)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                int count =  connection.ExecuteScalar<int>($"select count(user_id) from user_kyc_log where user_id = {user_id} and kyc_date = '{date}'");
                return count;
            }
        }

        public void UpdateUserPassword(UserModel user)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                connection.ExecuteScalar($"update login set full_name = '{user.full_name}', username = '{user.username}', designation = '{user.designation}', user_dob = '{user.user_dob}', password = '{user.password}', permissions = '{user.permissions}' where user_id = {user.user_id}");
            }
        }
    }
}
