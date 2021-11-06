using System;

namespace SF_modul7_results
{
    abstract class Address
    {
        private string postalCode;//индекс
        public string City { get; private set; }//город
        public string Street { get; private set; }//улица
        public UInt16 Building { get; private set; }//номер дома
        public UInt16 Block { get; set; }//корпус
        public string Litera { get; set; }//литера здания

        public Address(string city, string street, UInt16 building)
        {
            City = city;
            Street = street;
            Building = building;
        }

        public string PostalCode
        {
            get { return postalCode; }
            set
            {
                string temp = value;
                int i;
                postalCode = int.TryParse(temp, out i) && (temp.Length == 6) ? value : null;
            }
        }
    }

    class HomeAddress : Address
    {
        public UInt16 Apartment { get; private set; }
        public UInt16 Floor { get; private set; }

        public HomeAddress(string city, string street, UInt16 building, UInt16 apartment, UInt16 floor) : base(city, street, building)
        {
            Apartment = apartment;
            Floor = floor;
        }
    }

    class CompanyAddress : Address
    {
        public UInt16 Office { get; private set; }

        public CompanyAddress(string city, string street, UInt16 building, UInt16 office) : base(city, street, building)
        {
            Office = office;
        }
    }
}
