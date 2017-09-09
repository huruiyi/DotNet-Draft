using System;

namespace ConApp.Model
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true)]
    public class TestAttribute : Attribute
    {
        public TestAttribute(string message)
        {
            throw new Exception("error:" + message);
        }

        public void RunTest()
        {
            Console.WriteLine("TestAttribute here.");
        }
    }
}