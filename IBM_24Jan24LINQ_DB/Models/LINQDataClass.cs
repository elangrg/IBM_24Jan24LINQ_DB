using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBM_24Jan24LINQ_DB.Models
{




    public enum Countries
    {
        USA,
        Italy,
    }
    public class Customer
    {
        public string Name;
        public string City;
        public Countries Country;

        public Order[] Orders;
    }

    public class Order
    {
        public int Quantity;
        public bool Shipped;
        public string Month;
        public int IdProduct;
    }

    public class Product
    {
        public int IdProduct;
        public decimal Price;
    }


}
