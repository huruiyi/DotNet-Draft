using JavaScriptDemo.Models;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace JavaScriptDemo.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        private static Dictionary<string, int> stock = new Dictionary<string, int>();

        static HomeController()
        {
            stock.Add("001", 20);
            stock.Add("002", 30);
            stock.Add("003", 40);
        }

        public ActionResult Index()
        {
            var cart = new ShoppingCart
            {
                new ShoppingCartItem {Id = "001", Quantity = 1, Name = "商品A"},
                new ShoppingCartItem {Id = "002", Quantity = 1, Name = "商品B"},
                new ShoppingCartItem {Id = "003", Quantity = 1, Name = "商品C"}
            };
            return View(cart);
        }

        public ActionResult ProcessOrder(ShoppingCart cart)
        {
            var sb = new StringBuilder();
            foreach (var cartItem in cart)
            {
                if (!CheckStock(cartItem.Id, cartItem.Quantity))
                {
                    sb.Append(string.Format("{0}: {1};", cartItem.Name, stock[cartItem.Id]));
                }
            }
            if (string.IsNullOrEmpty(sb.ToString()))
            {
                return Content("alert('购物订单成功处理！');", "text/javascript");
            }
            string script = string.Format("alert('库存不足! ({0})');", sb.ToString().TrimEnd(';'));
            return JavaScript(script);
        }

        private bool CheckStock(string id, int quantity)
        {
            return stock[id] >= quantity;
        }
    }
}