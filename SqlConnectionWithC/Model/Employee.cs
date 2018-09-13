using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConnectionWithC.Model
{
    class Employee
    {
        public static int Id { get; set; }
        public static string FirstName { get; set; }
        public static string LasttName { get; set; }
        public static string Birthday { get; set; }
        public static string Gender { get; set; }
        public static string Job { get; set; }
        public static int DepartmentId { get; set; }
        public static int PostCode { get; set; }
        public static string City { get; set; }
        public static string Street { get; set; }

        public Employee(int id, string firstName, string lastName, string birthday, string gender, string job, int departmentId, int postCode, string city, string street)
        {
            Id = id;
            FirstName = firstName;
            LasttName = lastName;
            Birthday = birthday;
            Gender = gender;
            Job = job;
            DepartmentId = departmentId;
            PostCode = postCode;
            City = city;
            Street = street;
        }
    }
}
