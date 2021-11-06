using System.Collections.Generic;

namespace SF_modul7_results
{
    class Contact
    {
        public Person Person_ = new Person();
        public string NumberTelefon { get; set; }//телофон
        public string Email { get; set; }

        public Contact(string FirstName, string LastName, string NumberTelefon, string Email)
        {
            Person_.FirstName = FirstName;
            Person_.LastName = LastName;
            this.NumberTelefon = NumberTelefon;
            this.Email = Email;
        }

        public Contact(string FirstName, string LastName, string Position, string NumberTelefon, string Email)
        {
            Person_.FirstName = FirstName;
            Person_.LastName = LastName;
            Person_.Position = Position;
            this.NumberTelefon = NumberTelefon;
            this.Email = Email;
        }
    }

    class Contacts<Tcont> where Tcont : Contact //Контакты
    {
        protected List<Tcont> contacts = new List<Tcont>();

        public void Add(Tcont item)
        {
            contacts.Add(item);
        }

        public bool Remove(Tcont item)
        {
            return contacts.Remove(item);
        }

        public List<Tcont> GetContacts()
        {
            return contacts;
        }
    }

    class Person//Личность
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }//должность
    }
}
