using System;

namespace MyLibs
{
    internal class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public void Work()
        {
            Console.WriteLine("{0}在工作", Name);
        }
    }
}