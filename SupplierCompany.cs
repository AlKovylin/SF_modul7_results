using System;
using System.Collections.Generic;
using System.Text;

namespace SF_modul7_results
{
    static class SupplierCompany
    {
        static public string NameCompany { get; set; }
        static public CompanyAddress companyAddress { get; set; }
        static public Contacts<Contact> contacts = new Contacts<Contact>();//{ get; set; }
    }
}
