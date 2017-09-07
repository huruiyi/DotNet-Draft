using System.Collections.Generic;

namespace JavaScriptDemo.Models
{
    public class ShoppingCart : List<ShoppingCartItem>
    {
    }

    public class ShoppingCartItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}