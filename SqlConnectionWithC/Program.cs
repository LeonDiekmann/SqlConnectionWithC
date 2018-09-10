using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConnectionWithC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please choose the table you want to select.");

            switch (Console.ReadLine())
            {
                case "employee":
                    Console.Clear();
                    Employee();
                    break;
                case "address":
                    Console.Clear();
                    address();
                    break;
            }
        }

        public static void Employee()
        {
            Console.WriteLine("What do you want to do?");
            SqlConnection conn = new SqlConnection("Server=tappqa;Database=Training-LD-CompanyDB;Integrated Security=true");

            if (Console.ReadLine() == "select")
            {
                Console.Clear();
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, FirstName,LastName,Birthday,Job,PostCode,City,Street,HouseNumber,Country FROM [dbo].[viEmployee]", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("ID: {0} \nVorname: {1}\nNachname: {2}\nGeburtstag: {3}\nJob: {4}\nPostleitzahl: {5}\nWohnort: {6}\nStraße: {7}\nHausnummer: {8}\nLand: {9}\n", 
                        reader.GetValue(0),reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetValue(5), reader.GetString(6), reader.GetString(7), reader.GetValue(8), reader.GetString(9));
                }
                reader.Close();
                conn.Close();

                if (Debugger.IsAttached)
                {
                    Console.ReadLine();
                }
            }
            else
            {
                conn.Open();
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
                conn.Close();

                Console.WriteLine("Stored procedure executed!");
                if (Debugger.IsAttached)
                {
                    Console.ReadLine();
                }

            }
        }

        public static void address()
        {
            Console.WriteLine("What do you want to do?");
            SqlConnection conn = new SqlConnection("Server=tappqa;Database=Training-LD-CompanyDB;Integrated Security=true");

            if (Console.ReadLine() == "select")
            {
                Console.Clear();
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, PostCode, City, Street, HouseNumber, Country FROM [dbo].[viAddress]", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("Id: {0} \nPostleitzahl: {1} \nStadt: {2} \nStraße: {3} \nHausnummer: {4} \nLand: {5}\n", reader.GetValue(0), reader.GetValue(1), reader.GetString(2), reader.GetString(3), reader.GetValue(4), reader.GetString(5));
                }
                reader.Close();
                conn.Close();

                if (Debugger.IsAttached)
                {
                    Console.ReadLine();
                }
            }
            else
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.spAddress", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                Console.Clear();
                Console.WriteLine("Insert an Id");
                cmd.Parameters.Add(new SqlParameter("@Id", Console.ReadLine()));
                Console.Clear();
                Console.WriteLine("Insert a post code");
                cmd.Parameters.Add(new SqlParameter("@PostCode", Console.ReadLine()));
                Console.Clear();
                Console.WriteLine("Insert a city");
                cmd.Parameters.Add(new SqlParameter("@City", Console.ReadLine()));
                Console.Clear();
                Console.WriteLine("Insert a street");
                cmd.Parameters.Add(new SqlParameter("@Street", Console.ReadLine()));
                Console.Clear();
                Console.WriteLine("Insert a housenumber");
                cmd.Parameters.Add(new SqlParameter("@HouseNumber", Console.ReadLine()));
                Console.Clear();
                Console.WriteLine("Insert a country");
                cmd.Parameters.Add(new SqlParameter("@Country", Console.ReadLine()));
                Console.Clear();
                cmd.ExecuteNonQuery();
                conn.Close();

                Console.WriteLine("Stored procedure executed!");
                if (Debugger.IsAttached)
                {
                    Console.ReadLine();
                }

            }
        }
    }
}
