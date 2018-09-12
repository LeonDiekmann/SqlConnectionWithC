using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConnectionWithC.Repository
{
    class EmployeeRepository
    {
        public static void selectData()
        {
            using (SqlConnection conn = new SqlConnection(Helper.Config.ConnectionString))
            {
                Console.Clear();

                SqlCommand cmd = new SqlCommand("SELECT Id, FirstName,LastName,Birthday,Job,PostCode,City,Street,HouseNumber,Country FROM [dbo].[viEmployee]", conn);

                SqlDataAdapter adapter = new SqlDataAdapter
                {
                    SelectCommand = cmd
                };

                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                Console.WriteLine(dataTable.Rows[0].ItemArray[0]);
                ////using (SqlDataReader reader = cmd.ExecuteReader())

                //    while (reader.Read())
                //    {
                //        Console.WriteLine("ID: {0} " +
                //                            "\nVorname: {1}" +
                //                            "\nNachname: {2}" +
                //                            "\nGeburtstag: {3}" +
                //                            "\nJob: {4}" +
                //                            "\nPostleitzahl: {5}" +
                //                            "\nWohnort: {6}" +
                //                            "\nStraße: {7}" +
                //                            "\nHausnummer: {8}" +
                //                            "\nLand: {9}\n",
                //                            reader.GetValue(0),
                //                            reader.GetString(1),
                //                            reader.GetString(2),
                //                            reader.GetString(3),
                //                            reader.GetString(4),
                //                            reader.GetValue(5),
                //                            reader.GetString(6),
                //                            reader.GetString(7),
                //                            reader.GetValue(8),
                //                            reader.GetString(9));
                //    }

                if (Debugger.IsAttached)
                {
                    Console.ReadLine();
                }

                return;

                
            }
        }
        public static void AddOrUpdate()
        {
            Console.WriteLine("What do you want to do?");
            using (SqlConnection conn = new SqlConnection(Helper.Config.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.spEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                Console.Clear();
                Console.WriteLine("Insert an Id");
                cmd.Parameters.Add(new SqlParameter("@Id", Console.ReadLine()));
                Console.Clear();
                Console.WriteLine("Insert a firstname");
                cmd.Parameters.Add(new SqlParameter("@FirstName", Console.ReadLine()));
                Console.Clear();
                Console.WriteLine("Insert a lastname");
                cmd.Parameters.Add(new SqlParameter("@LastName", Console.ReadLine()));
                Console.Clear();
                Console.WriteLine("Insert a birthday");
                cmd.Parameters.Add(new SqlParameter("@Birthday", Console.ReadLine()));
                Console.Clear();
                Console.WriteLine("Insert a gender ( 0 = male, 1 = female, 2 = complicated)");
                cmd.Parameters.Add(new SqlParameter("@Gender", Console.ReadLine()));
                Console.Clear();
                Console.WriteLine("Insert a job");
                cmd.Parameters.Add(new SqlParameter("@Job", Console.ReadLine()));
                Console.Clear();
                //Console.WriteLine("Insert a Department");
                //cmd.Parameters.Add(new SqlParameter("@DepartmentId", Convert.ToInt32(Console.ReadLine())));
                //Console.Clear();
                cmd.ExecuteNonQuery();

                Console.WriteLine("Stored procedure executed!");
                if (Debugger.IsAttached)
                {
                    Console.ReadLine();
                }

                return;

            }
        }
    }
}
