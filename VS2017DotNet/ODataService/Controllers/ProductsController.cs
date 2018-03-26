using ODataService.Models;
using System.Collections.Generic;
using System.Web.OData;

namespace ODataService.Controllers
{
    public class ProductsController : ODataController
    {
        private List<Product> products = new List<Product>()
        {
            new Product()
            {
                ID = 1,
                Name = "Bread",
            },
            new Product
            {
                ID = 2,
                Name = "Sugar",
            }
        };

        //  /service/Products
        public List<Product> Get()
        {
            return products;
        }
    }
}