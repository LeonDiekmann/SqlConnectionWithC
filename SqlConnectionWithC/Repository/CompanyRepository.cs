using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlConnectionWithC.Model;

namespace SqlConnectionWithC.Repository
{
    class CompanyRepository
    {
        

        public static List<Company> Read ()
        {
            List<Company> companyList = new List<Company>();
            using (SqlConnection conn = new SqlConnection(Helper.Config.ConnectionString))
            {
                
                SqlCommand cmd = new SqlCommand("SELECT Id, Name, PostCode, City, Street, HouseNumber, Country FROM [dbo].[viCompany]", conn);
                SqlDataAdapter adapter = new SqlDataAdapter
                {
                    SelectCommand = cmd
                };
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    companyList.Add(new Company(    (int) row.ItemArray[0],
                                                    (string) row.ItemArray[1], 
                                                    (int) row.ItemArray[2], 
                                                    (string)row.ItemArray[3], 
                                                    (string) row.ItemArray[4], 
                                                    (int) row.ItemArray[5], 
                                                    (string) row.ItemArray[6]));

                }
            }
            return companyList;
        }

        public static Company ReadByID(int id)
        {
            List<Company> companyList = new List<Company>();
            using (SqlConnection conn = new SqlConnection(Helper.Config.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT Id, Name, PostCode, City, Street, HouseNumber, Country FROM [dbo].[viCompany] WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataAdapter adapter = new SqlDataAdapter
                {
                    SelectCommand = cmd
                };
                var dataTable = new DataTable();
                adapter.Fill(dataTable);

                Company company = new Company(  (int) dataTable.Rows[0].ItemArray[0],
                                                (string) dataTable.Rows[0].ItemArray[1],
                                                (int) dataTable.Rows[0].ItemArray[2],
                                                (string) dataTable.Rows[0].ItemArray[3],
                                                (string) dataTable.Rows[0].ItemArray[4],
                                                (int) dataTable.Rows[0].ItemArray[5],
                                                (string )dataTable.Rows[0].ItemArray[6]);
                return company;
                
            }
        }

        public static void AddOrUpdate(int id, string name)
        {
            SqlConnection conn = new SqlConnection(Helper.Config.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("dbo.spCompany", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id", id));
            cmd.Parameters.Add(new SqlParameter("@Name", name));
            cmd.ExecuteNonQuery();
            conn.Close();            
        }
    }
}
