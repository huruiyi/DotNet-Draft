using BankInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace MEFDemo
{
    internal class Program
    {
        [ImportMany(typeof(ICard))]
        public IEnumerable<ICard> cards { get; set; }

        private static void Main(string[] args)
        {
            Program pro = new Program();
            pro.Compose();
            foreach (var c in pro.cards)
            {
                Console.WriteLine(c.GetCountInfo());
            }
            Console.Read();
        }

        private void Compose()
        {
            var catalog = new DirectoryCatalog("Cards");
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }
    }
}