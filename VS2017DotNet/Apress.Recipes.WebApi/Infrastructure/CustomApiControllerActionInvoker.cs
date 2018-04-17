using Apress.Recipes.WebApi.Models;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Apress.Recipes.WebApi.Infrastructure
{
    public class CustomApiControllerActionInvoker : ApiControllerActionInvoker
    {
        public override Task<HttpResponseMessage> InvokeActionAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            var responseMessage = base.InvokeActionAsync(actionContext, cancellationToken);

            if (responseMessage.Exception != null)
            {
                var baseException = responseMessage.Exception.InnerExceptions[0];

                var result = new EWorkResultInfo
                {
                    Message = baseException.Message, //"服务器内部错误",
                    Code = 10001,
                    Entity = responseMessage.Exception
                };

                if (baseException is TimeoutException)
                {
                    result.Code = 10004;
                    //result.Message = "任务超时";
                }

                return Task.Run(() => new HttpResponseMessage()
                {
                    Content = new ObjectContent(typeof(EWorkResultInfo), result, GlobalConfiguration.Configuration.Formatters.JsonFormatter)
                }, cancellationToken);
            }
            return responseMessage;
        }
    }
}