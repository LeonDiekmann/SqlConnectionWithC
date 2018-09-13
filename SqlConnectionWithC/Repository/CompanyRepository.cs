using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlConnectionWithC.Model;
using Dapper;

namespace SqlConnectionWithC.Repository
{
    class CompanyRepository
    {
        public static List<Company> Read ()
        {
            using (SqlConnection conn = new SqlConnection(Helper.Config.ConnectionString))
            {
                string query = @"   SELECT Id, 
                                    Name, 
                                    PostCode, 
                                    City, 
                                    Street, 
                                    HouseNumber, 
                                    Country FROM [dbo].[viCompany]";

                var companyList = conn.Query<Company>(query).ToList();
                return companyList;
            }
            
        }

        public static Company ReadByID(int id)
        {
            using (SqlConnection conn = new SqlConnection(Helper.Config.ConnectionString))
            {
                string query = @"   SELECT Id, 
                                    Name, 
                                    PostCode, 
                                    City, 
                                    Street, 
                                    HouseNumber, 
                                    Country FROM [dbo].[viCompany] WHERE Id = @Id";
                var param = new DynamicParameters();
                param.Add("@Id",id);

                var company = conn.QueryFirstOrDefault<Company>(query,param);

                return company;
            }
        }

        public static int AddOrUpdate(int id, string name)
        {
            SqlConnection conn = new SqlConnection(Helper.Config.ConnectionString);
            //conn.Open();
            //SqlCommand cmd = new SqlCommand("dbo.spCompany", conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add(new SqlParameter("@Id", id));
            //cmd.Parameters.Add(new SqlParameter("@Name", name));
            //cmd.ExecuteNonQuery();
            //conn.Close();

            string companySelect = "spCompany";

            var param = new DynamicParameters();
            param.Add("@Id", id);
            param.Add("@Name", name);

            var company = conn.Execute(companySelect, param, null, null, CommandType.StoredProcedure);

            return company;
            
            
        }
    }
}
