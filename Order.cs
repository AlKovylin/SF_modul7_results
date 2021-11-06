using System;
using System.Collections.Generic;
using System.Text;

namespace SF_modul7_results
{
    public abstract class Order//Заказ
    {
      
    }

    class Order<T, R> : Order
    {
        public T Id { get; private set; }

        public Order(T id)
        {
            Id = id;
        }

        public R delivery { get; set; }
    }
}
