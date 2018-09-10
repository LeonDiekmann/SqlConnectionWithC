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
                SqlCommand cmd = new SqlCommand("SELECT FirstName,LastName,Birthday,Job,PostCode,City,Street,HouseNumber,Country FROM [dbo].[viEmployee]", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("Vorname: {0},\nNachname: {1},\nGeburtstag: {2},\nJob: {3},\nPostleitzahl: {4},\nWohnort: {5},\nStraße: {6},\nHausnummer: {7},\nLand: {8}\n", reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetValue(4), reader.GetString(5), reader.GetString(6), reader.GetValue(7), reader.GetString(8));
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
    }
}
