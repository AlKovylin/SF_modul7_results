using System;
using System.Collections.Generic;

namespace SF_modul7_results
{
    class Program
    {
        static void Main(string[] args)
        {
            SupplierCompany.NameCompany = "ООО Рост";
            SupplierCompany.companyAddress = new CompanyAddress("СПб", "ул. Карбышева", 4, 211);
            SupplierCompany.companyAddress.PostalCode = "123456";
            SupplierCompany.companyAddress.Block = 1;
            SupplierCompany.companyAddress.Litera = "А";

            Contact contactSC1 = new Contact("Александр", "Гусев", "директор", "232-55-44", "a_gusev@rost.com");
            Contact contactSC2 = new Contact("Наталья", "Григорьева", "маркетолог", "232-55-45", "a_gusev@rost.com");

            SupplierCompany.contacts.Add(contactSC1);
            SupplierCompany.contacts.Add(contactSC2);

            Order<int, HomeDelivery<HomeAddress>> order1 = new Order<int, HomeDelivery<HomeAddress>>(111);

            HomeAddress homeAddress = new HomeAddress("СПб", "пр. Энгельса", 25, 58, 3);
            HomeDelivery<HomeAddress> deliveryOr1 = new HomeDelivery<HomeAddress>(DateTime.Today);
            Contact contactAddress = new Contact("Иван", "Петров", "222-55-77", "ivanpetrov@mail.ru");

            Carrier carrier1 = new Carrier("ООО Т-Групп");

            CompanyAddress companyCarrierAddress = new CompanyAddress("СПб", "ул. Литовская", 22, 5);
            carrier1.address = companyCarrierAddress;

            Contacts<Contact> contactsCarr1 = new Contacts<Contact>();
            Contact contactCarrier1 = new Contact("Егор", "Корнев", "Логист", "333-25-25", "logist1@t-group.ru");
            Contact contactCarrier2 = new Contact("Сергей", "Лавров", "Логист", "333-25-24", "logist2@t-group.ru");
            contactsCarr1.Add(contactCarrier1);
            contactsCarr1.Add(contactCarrier2);
            carrier1.contacts = contactsCarr1;

            Car Car1 = new Car();
            Car1.Brand = "Газель";
            Car1.Type = Types.cargo;
            Car1.GosNum = "В 555 ВВ 198";

            Car Car2 = new Car();
            Car2.Brand = "Ларгус";
            Car2.Type = Types.passenger;
            Car2.GosNum = "А 333 АА 198";
            
            carrier1.AddCar(Car1);
            carrier1.AddCar(Car2);

            ListOfProducts<Product> products = new ListOfProducts<Product>();

            Product product1 = new Product(111, "Ламинат", 5000m);
            Product product2 = new Product(111, "Подложка", 100m);
            Product product3 = new Product(111, "Плинтус", 1500m);
            Product product4 = new Product(111, "Саморезы 100шт.", 300m);
            Product product5 = new Product(111, "Дюбели 100шт.", 200m);

            products.Add(product1);
            products.Add(product2);
            products.Add(product3);
            products.Add(product4);
            products.Add(product5);
            
            deliveryOr1.contact = contactAddress;
            deliveryOr1.address = homeAddress;
            deliveryOr1.сarrier = carrier1;
            deliveryOr1.car = carrier1.GetCars(1);
            deliveryOr1.products = products;
           
            order1.delivery = deliveryOr1;

            Console.WriteLine("\tЗаказ на доставку №: {0}\n", order1.Id);
            Console.WriteLine("Дата доставки: {0}", order1.delivery.Date);
            Console.WriteLine("Адрес доставки : {0}, д. {1}, кв. {2}, {3} этаж", order1.delivery.addr.Street, order1.delivery.addr.Building, order1.delivery.addr.Apartment, 
                                                                                 order1.delivery.addr.Floor);
            Console.WriteLine("Заказчик : {0} {1}, тел. {2}, e-mail: {3}", order1.delivery.contact.Person_.FirstName, order1.delivery.contact.Person_.LastName,
                                                                           order1.delivery.contact.NumberTelefon, order1.delivery.contact.Email);
            Console.WriteLine("\n\tСостав заказа: ");

            List<Product> Prod = order1.delivery.products.GetListProducts();
            for (int i = 0; i < Prod.Count; i++)
            {
                Console.WriteLine("{0}. {1, -15}| {2}", i+1, Prod[i].Name, Prod[i].Price);
            }
            Console.WriteLine("\nВсего: {0} позиций.", order1.delivery.products.ProductsCount());
            Console.WriteLine("\nСтоимость заказа: {0} руб.", order1.delivery.products.GetSumOrder());
            Console.WriteLine("Стоимость доставки: {0} руб.", order1.delivery.PriceDelivery);

            Console.WriteLine("\n\tПеревозчик:\n");
            Console.WriteLine(order1.delivery.сarrier.NameCompany);
            Console.WriteLine("Автомобиль: " + order1.delivery.сarrier.GetCars(1).Brand + ", гос. номер: " + order1.delivery.сarrier.GetCars(1).GosNum);
            Console.WriteLine(order1.delivery.сarrier.address.City + ", д." + order1.delivery.сarrier.address.Building + ", офис " + order1.delivery.сarrier.address.Office);
            Console.WriteLine(order1.delivery.сarrier.contacts.GetContacts()[1].Person_.Position + ": " +
                              order1.delivery.сarrier.contacts.GetContacts()[1].Person_.FirstName + " " +
                              order1.delivery.сarrier.contacts.GetContacts()[1].Person_.LastName + ", тел. " +
                              order1.delivery.сarrier.contacts.GetContacts()[1].NumberTelefon);

            Console.WriteLine("\n\tКомпания продавец:\n");
            Console.WriteLine(SupplierCompany.NameCompany);
            Console.WriteLine(SupplierCompany.companyAddress.PostalCode + ", " + SupplierCompany.companyAddress.City + ", " +
                              SupplierCompany.companyAddress.Street + ", д." + SupplierCompany.companyAddress.Building + ", корп." +
                              SupplierCompany.companyAddress.Block + ", литера " + SupplierCompany.companyAddress.Litera + ", офис " +
                              SupplierCompany.companyAddress.Office);
            Console.WriteLine(SupplierCompany.contacts.GetContacts()[0].Person_.Position + ", " + SupplierCompany.contacts.GetContacts()[0].Person_.FirstName + " " +
                              SupplierCompany.contacts.GetContacts()[0].Person_.LastName + ", тел." + SupplierCompany.contacts.GetContacts()[0].NumberTelefon + ", e-mail: " +
                              SupplierCompany.contacts.GetContacts()[0].Email);
            Console.WriteLine(SupplierCompany.contacts.GetContacts()[1].Person_.Position + ", " + SupplierCompany.contacts.GetContacts()[1].Person_.FirstName + " " +
                              SupplierCompany.contacts.GetContacts()[1].Person_.LastName + ", тел." + SupplierCompany.contacts.GetContacts()[1].NumberTelefon + ", e-mail: " +
                              SupplierCompany.contacts.GetContacts()[1].Email);
        }
    }

    public static class ListProdExtension
    {
        public static int ProductsCount(this ListOfProducts<Product> products)
        {
            int y = 0;
            for (; y < products.GetListProducts().Count; y++) { }
            return y;
        }
    }
}
