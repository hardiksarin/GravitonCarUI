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
        public ApplicantModel CreateApplicant(ApplicantModel model)
        {
            /*using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                int id = connection.ExecuteScalar<int>($"insert into bank_details values(default,'{}','{}','{}') returning aaplicant_Id");
                //model.bank_id = id;
                return model;
            }*/
            return model;
        }

        public List<MarriedStatusModel> GetMarried_All()
        {
            List<MarriedStatusModel> output = new List<MarriedStatusModel>();
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                output = connection.Query<MarriedStatusModel>("select * from maritalstatus").ToList();
                return output;
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

        public List<CasteModel> GetCaste_All()
        {
            List<CasteModel> output = new List<CasteModel>();
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                output = connection.Query<CasteModel>("select * from caste").ToList();
                return output;
            }
        }

        public List<CategoryModel> GetCategory_All()
        {
            List<CategoryModel> output = new List<CategoryModel>();
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                output = connection.Query<CategoryModel>("select * from category").ToList();
                return output;
            }
        }

       
    }
}
