using System;
using System.Collections.Generic;
using System.Text;

namespace SF_modul7_results
{
    class Carrier//Перевозчик
    {
        public string NameCompany { get; private set; }
        public CompanyAddress address;
        public Contacts<Contact> contacts = new Contacts<Contact>();
        protected List<Car> Cars = new List<Car>();

        public Carrier(string NameCompany)
        {
            this.NameCompany = NameCompany;
        }

        public void AddCar(Car car)
        {
            Cars.Add(car);
        }

        public bool RemoveCar(Car car)
        {
            return Cars.Remove(car);
        }

        public Car GetCars(int index)
        {
            var car = Cars[index];
            return car;
        }
    }

    struct Car//Автомобиль
    {
        public string Brand { get; set; }//марка
        public Types Type { get; set; }
        public string GosNum { get; set; }
    }

    enum Types : byte
    {
        passenger = 1,//легковой
        cargo//грузовой
    }
}
