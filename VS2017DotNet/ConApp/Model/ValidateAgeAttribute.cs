using System;

namespace ConApp.Model
{
    public class ValidateAgeAttribute : Attribute
    {
        public int MaxAge { get; set; }

        public void IsRight(int age)
        {
            Console.WriteLine(age > 100 ? "你是鬼吗...." : "你是人吗");
        }
    }
}