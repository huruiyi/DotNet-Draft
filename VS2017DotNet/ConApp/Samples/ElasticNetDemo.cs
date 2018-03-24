using ConApp.Model;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp.Samples
{
    class ElasticNetDemo
    {

        public static void ElasticNet()
        {
            var node = new Uri("http://127.0.0.1:9200");
            var settings = new ConnectionSettings(node);
            var client = new ElasticClient(settings);

            Tweet tweet = new Tweet
            {
                Id = 1,
                User = "kimchy",
                PostDate = new DateTime(2009, 11, 15),
                Message = "Trying out NEST, so far so good?"
            };

            var response = client.Index(tweet, idx => idx.Index("mytweetindex")); //or specify index via settings.DefaultIndex("mytweetindex");
        }

    }
}
