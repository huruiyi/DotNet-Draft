using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace MEFDemo
{
    internal class Program
    {
        [ImportMany("MusicBook")]
        public IEnumerable<object> Services { get; set; }

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