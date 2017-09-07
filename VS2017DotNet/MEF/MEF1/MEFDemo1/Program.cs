using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace MEFDemo
{
    internal class Program
    {
        [ImportMany("MathBook")]
        public IEnumerable<object> Services { get; set; }

        //导入属性，这里不区分public还是private
        [ImportMany]
        public List<string> InputString { get; set; }

        //导入无参数方法
        [Import]
        public Func<string> methodWithoutPara { get; set; }

        //导入有参数方法
        [Import]
        public Func<int, string> methodWithPara { get; set; }

        private static void Main(string[] args)
        {
            Program pro = new Program();
            pro.Compose();
            if (pro.Services != null)
            {
                foreach (var s in pro.Services)
                {
                    var ss = (IBookService)s;
                    Console.WriteLine(ss.GetBookName());
                }
            }
            foreach (var str in pro.InputString)
            {
                Console.WriteLine(str);
            }

            //调用无参数方法
            if (pro.methodWithoutPara != null)
            {
                Console.WriteLine(pro.methodWithoutPara());
            }
            //调用有参数方法
            if (pro.methodWithPara != null)
            {
                Console.WriteLine(pro.methodWithPara(3000));
            }

            Console.Read();
        }

        private void Compose()
        {
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            CompositionContainer container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }
    }
}