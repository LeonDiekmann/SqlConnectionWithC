using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using SqlConnectionWithC.Controller;

namespace SqlConnectionWithC
{
    class Program
    {
        static void Main(string[] args)
        {
            Helper.Config.ConnectionString = "Data Source=tappqa;Initial Catalog=Training-LD-CompanyDB;Integrated Security=True";
            Console.WriteLine("Please choose the table you want to select.");

            switch (Console.ReadLine().ToLower())
            {
                case "company read":
                    Console.Clear();
                    CompanyController.Read();
                    Console.ReadLine();
                    break;
                case "company addorupdate":
                    Console.Clear();
                    CompanyController.AddOrUpdate();
                    Console.ReadLine();
                    break;
                case "company readbyid":
                    Console.Clear();
                    CompanyController.ReadById();
                    Console.ReadLine();
                    break;
            }
        }
    }
}
