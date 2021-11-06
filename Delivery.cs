using System;
using System.Collections.Generic;
using System.Text;

namespace SF_modul7_results
{
    abstract class Delivery//Доставка
    {
        public DateTime Date { get; private set; }
        public virtual Address address { get; set; }
        public Contact contact { get; set; }
        public Carrier сarrier { get; set; }
        public Car car { get; set; }
        public ListOfProducts<Product> products { get; set; }
        public virtual decimal PriceDelivery { get; set; } = 0;

        public Delivery(DateTime date)
        {
            Date = date;
        }

        public virtual decimal SummProducts(decimal price) { return price; }
    }

    class HomeDelivery<Taddr> : Delivery where Taddr : HomeAddress//На дом
    {
        public Taddr addr;

        public override Address address 
        {
            get { return addr; }
            set { addr = (Taddr)value; } 
        }

        public HomeDelivery(DateTime date) : base(date) { }

        private protected decimal priceDelivery;
        public override decimal PriceDelivery
        {
            get { return priceDelivery; }
            set 
            {
                priceDelivery = (SummProducts(products.GetSumOrder()) > 1000) ? 0 : 300;
            } 
        }

        public override sealed decimal SummProducts(decimal price)
        {
            return price + 100;
        }
    }

    class PickPointDelivery<Taddr> : Delivery where Taddr : CompanyAddress//В пункт выдачи
    {
        public Taddr addr;

        public override Address address
        {
            get { return addr; }
            set { addr = (Taddr)value; }
        }

        public PickPointDelivery(DateTime date) : base(date) { }

        private decimal priceDelivery;
        public override decimal PriceDelivery
        {
            get { return priceDelivery; }
            set
            {
                priceDelivery = SummProducts(products.GetSumOrder()) / 10;
            }
        }

        public override sealed decimal SummProducts(decimal price)
        {
            return price / 1.2m;
        }
    }

    class ShopDelivery : PickPointDelivery<CompanyAddress>//В магазин
    {
        public ShopDelivery(DateTime date) : base(date) { }

        private decimal priceDelivery;
        public override decimal PriceDelivery
        {
            get { return priceDelivery; }
            set
            {
                priceDelivery = SummProducts(products.GetSumOrder()) / 5;
            }
        }
    }

    class PostOffice : PickPointDelivery<CompanyAddress>//В отделение почты
    {
        public PostOffice(DateTime date) : base(date) { }
        public override decimal PriceDelivery 
        { 
            get => base.PriceDelivery; 
            set => base.PriceDelivery = value + 2; 
        }
    }
}
