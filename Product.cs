using System;
using System.Collections.Generic;
using System.Text;

namespace SF_modul7_results
{
    public class Product
    {
        public int ArticleNumber { get; private set; } = 0;
        public string Name { get; private set; }
        public decimal Price { get; private set; } = 0;

        public Product(int articleNumber, string name, decimal price)
        {
            ArticleNumber = articleNumber;
            Name = name;
            Price = price;
        }

        public static decimal operator +(Product x, Product y)
        {
            var price = x.Price + y.Price;
            return price;
        }
    }

    public class ListOfProducts<Tprod> where Tprod : Product
    {
        private decimal SumOrder = 0;
        protected List<Tprod> ListProducts = new List<Tprod>();

        public void Add(Tprod item)
        {
            ListProducts.Add(item);
            SumOrder += item.Price;
        }

        public bool Remove(Tprod item)
        {
            return ListProducts.Remove(item);
        }

        public List<Tprod> GetListProducts()
        {
            return ListProducts;
        }

        public decimal GetSumOrder()
        {
            return SumOrder;
        }
    }
}
