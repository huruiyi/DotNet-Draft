using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Token.Models
{
    public class ProductResultMsg : HttpResponseMsg
    {
        public Product Result
        {
            get
            {
                if (StatusCode == (int)StatusCodeEnum.Success)
                {
                    return JsonConvert.DeserializeObject<Product>(Data.ToString());
                }

                return null;
            }
        }
    }
}
