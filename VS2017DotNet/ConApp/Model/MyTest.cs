using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp.Model
{

    [Myself("Emma", 25, Memo = "Emma is my good girl.")]
    public class MyTest
    {
        public void SayHello()
        {
            Console.WriteLine("Hello, my.net world.");
        }
    }
}
