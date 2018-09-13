using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConnectionWithC.Model
{
    class Address
    {
        public static int Id { get; set; }
        public static int PostCode { get; set; }
        public static string City { get; set; }
        public static string Street { get; set; }
        public static int HouseNumber { get; set; }
        public static string Country { get; set; }

        public Address(int id, int postCode, string city, string street, int houseNumber, string country)
        {
            Id = id;
            PostCode = postCode;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
            Country = country;
        }
    }
}
