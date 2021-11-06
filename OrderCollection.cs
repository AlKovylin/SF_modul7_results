using System;
using System.Collections.Generic;
using System.Text;

namespace SF_modul7_results
{
    public class OrderCollection
    {
        int index = 0;
        public static Dictionary<int, Order> OrderColl = new Dictionary<int, Order>();

        public void Add(Order order)
        {
            OrderColl.Add(index, order);
            index++;
        }
    }
}
