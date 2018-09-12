using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlConnectionWithC.Repository;

namespace SqlConnectionWithC.Controller
{
    public class CompanyController
    {
        public static void Read()
        {
            var result  = CompanyRepository.Read();

            Console.Clear();
            foreach (var item in result)
            {
                Console.WriteLine("ID: " + item.Id);
                Console.WriteLine("Name: " + item.Name);
                Console.WriteLine("Post Code: " + item.PostCode);
                Console.WriteLine("City: " + item.City);
                Console.WriteLine("Street: " + item.Street);
                Console.WriteLine("HouseNumber" + item.HouseNumber);
                Console.WriteLine("Country: " + item.Country);
                Console.WriteLine("");
            }
            

        }
        public static void AddOrUpdate()
        {
            Console.WriteLine("Insert an Id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Insert a company name");
            string name = Console.ReadLine();
            Console.Clear();
            CompanyRepository.AddOrUpdate(id, name);
        }
        public static void ReadById()
        {
            Console.WriteLine("Insert an Id");
            int id = Convert.ToInt32(Console.ReadLine());
            var result = CompanyRepository.ReadByID(id);

            Console.Clear();
            Console.WriteLine("ID: " + result.Id);
            Console.WriteLine("Name: " + result.Name);
            Console.WriteLine("Post Code: " + result.PostCode);
            Console.WriteLine("City: "  + result.City);
            Console.WriteLine("Street: " + result.Street);
            Console.WriteLine("HouseNumber" + result.HouseNumber);
            Console.WriteLine("Country: " + result.Country);
        }
    }
}
