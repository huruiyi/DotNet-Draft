using System;
using System.Collections.Generic;

namespace ODataService.Controllers
{
    public class Customer
    {
        public int CustomerId { get; set; } // structural property, primitive type, key
        public Address Location { get; set; } // structural property, complex type
        public IList<Order> Orders { get; set; } // navigation property, entity type
    }

    public class VipCustomer : Customer
    {
        public Color FavoriteColor { get; set; } // structural property, primitive type
    }

    public class Order
    {
        public int OrderId { get; set; } // structural property, primitive type, key
        public Guid Token { get; set; } // structural property, primitive type
    }

    public class Address
    {
        public string Country { get; set; }
        public string City { get; set; }
    }

    public class SubAddress : Address
    {
        public string Street { get; set; }
    }

    public enum Color
    {
        Red,
        Blue,
        Green
    }
}