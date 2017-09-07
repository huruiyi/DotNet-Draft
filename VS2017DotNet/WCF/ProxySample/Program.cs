using System;
using System.Security.Permissions;

namespace ProxySample
{
    internal class Program
    {
        [PermissionSet(SecurityAction.LinkDemand)]
        private static void Main(string[] args)
        {
            //  ChannelServices.RegisterChannel(new HttpChannel());

            Console.WriteLine("Remoting Sample:");

            Console.WriteLine("Generate a new MyProxy using the Type");
            Type myType = typeof(Service1Client);
            string myUrl1 = "http://localhost:20133/Service1.svc";
            MyProxy myProxy = new MyProxy(myType, myUrl1);

            Console.WriteLine("Obtain the transparent proxy from myProxy");
            Service1Client myService = (Service1Client)myProxy.GetTransparentProxy();

            Console.WriteLine("Calling the Proxy");
            string myReturnString = myService.GetData(21345879);

            Console.WriteLine("Checking result : {0}", myReturnString);

            if (myReturnString == "Hi there bill, you are using .NET Remoting")
            {
                Console.WriteLine("myService.HelloMethod PASSED : returned {0}", myReturnString);
            }
            else
            {
                Console.WriteLine("myService.HelloMethod FAILED : returned {0}", myReturnString);
            }
        }
    }
}