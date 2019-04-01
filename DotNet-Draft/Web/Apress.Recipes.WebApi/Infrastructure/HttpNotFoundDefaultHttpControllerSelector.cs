using Apress.Recipes.WebApi.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Apress.Recipes.WebApi.Infrastructure
{
    public class HttpNotFoundDefaultHttpControllerSelector : DefaultHttpControllerSelector
    {
        public HttpNotFoundDefaultHttpControllerSelector(HttpConfiguration configuration)
            : base(configuration)
        {
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            HttpControllerDescriptor decriptor = null;
            try
            {
                decriptor = base.SelectController(request);
            }
            catch (HttpResponseException ex)
            {
                var code = ex.Response.StatusCode;
                var result = new EWorkResultInfo
                {
                    Code = 10006,
                    Entity = ex.Response.Content.ReadAsAsync<object>().Result
                };
                if (code == HttpStatusCode.NotFound || code == HttpStatusCode.MethodNotAllowed)
                {
                    ex.Response.Content = new ObjectContent(typeof(EWorkResultInfo), result, GlobalConfiguration.Configuration.Formatters.JsonFormatter);
                }

                throw;
            }

            return decriptor;
        }
    }
}