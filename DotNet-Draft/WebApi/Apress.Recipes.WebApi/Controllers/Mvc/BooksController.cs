using Apress.Recipes.WebApi.Filters;
using Apress.Recipes.WebApi.Models;
using System.Linq;
using System.Web.Mvc;

namespace Apress.Recipes.WebApi.Controllers.Mvc
{
    public class BooksController : Controller
    {
        public ActionResult Details(int id)
        {
            var book = Books.List.FirstOrDefault(x => x.Id == id);
            if (book == null) return new HttpNotFoundResult();

            return View(book);
        }

        public ActionResult Index()
        {
            return View(Books.List);
        }

        [AcceptReturnType("type1")]
        [ActionName("List")]
        public ActionResult List()
        {
            return Content("List type1");
        }

        [AcceptReturnType("type2")]
        [ActionName("List")]
        public ActionResult JqList()
        {
            return Content("List type2");
        }
    }
}