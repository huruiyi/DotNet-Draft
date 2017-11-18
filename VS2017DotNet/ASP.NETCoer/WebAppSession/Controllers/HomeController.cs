using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAppSession.Controllers
{
    public class HomeController : Controller
    {
        private const string SessionKeyName = "_Name";
        private const string SessionKeyYearsMember = "_YearsMember";
        private const string SessionKeyDate = "_Date";

        public IActionResult Index()
        {
            // Requires using Microsoft.AspNetCore.Http;
            HttpContext.Session.SetString(SessionKeyName, "Rick");
            HttpContext.Session.SetInt32(SessionKeyYearsMember, 3);
            return RedirectToAction("SessionNameYears");
        }

        public IActionResult SessionNameYears()
        {
            string name = HttpContext.Session.GetString(SessionKeyName);
            int? yearsMember = HttpContext.Session.GetInt32(SessionKeyYearsMember);

            return Content($"Name: \"{name}\",  Membership years: \"{yearsMember}\"");
        }

        public IActionResult SetDate()
        {
            // Requires you add the Set extension method mentioned in the article.
            HttpContext.Session.Set<DateTime>(SessionKeyDate, DateTime.Now);
            return RedirectToAction("GetDate");
        }

        public IActionResult GetDate()
        {
            // Requires you add the Get extension method mentioned in the article.
            DateTime date = HttpContext.Session.Get<DateTime>(SessionKeyDate);
            string sessionTime = date.TimeOfDay.ToString();
            string currentTime = DateTime.Now.TimeOfDay.ToString();

            return Content($"Current time: {currentTime} - session time: {sessionTime}");
        }
    }
}