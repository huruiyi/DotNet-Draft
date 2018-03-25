using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace ASP.NETCore.Controllers
{
    public class RedisController : Controller
    {
        private static readonly Lazy<ConnectionMultiplexer> LazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect("localhost,abortConnect=false"));

        private static ConnectionMultiplexer Connection => LazyConnection.Value;

        private IDatabase Db { get; set; }

        /// <summary>
        /// Key name of the list in the Redis database.
        /// </summary>
        private static string ListKeyName = "MessageList";

        public RedisController()
        {
            Db = Connection.GetDatabase();
            if (Db.IsConnected(ListKeyName) && (!Db.KeyExists(ListKeyName) || !Db.KeyType(ListKeyName).Equals(RedisType.List)))
            {
                //Add sample data.
                Db.KeyDelete(ListKeyName);
                //Push data from the left
                Db.ListLeftPush(ListKeyName, "TestMsg1");
                Db.ListLeftPush(ListKeyName, "TestMsg2");
                Db.ListLeftPush(ListKeyName, "TestMsg3");
                Db.ListLeftPush(ListKeyName, "TestMsg4");
            }
        }

        public IActionResult Index()
        {
            //Get the latest 5 messages.
            if (Db.IsConnected(ListKeyName))
            {
                //get 5 items from the left
                List<string> messageList = Db.ListRange(ListKeyName, 0, 4).Select(o => (string)o).ToList();
                ViewData["MessageList"] = messageList;
                return View(messageList);
            }
            ViewData["Error"] = "Multiplexer not connected";
            return View();
        }

        [HttpPost]
        public ActionResult SendMessage(string message)
        {
            //Add message to the list from left
            if (Db.IsConnected(ListKeyName))
            {
                Db.ListLeftPush(ListKeyName, message);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}