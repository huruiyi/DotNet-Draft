using System;
using DokanNet;
using RegistryFS;

namespace ConApp02
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var rfs = new RFS();
                rfs.Mount("r:\\", DokanOptions.DebugMode | DokanOptions.StderrOutput);
                Console.WriteLine(@"Success");
            }
            catch (DokanException ex)
            {
                Console.WriteLine(@"Error: " + ex.Message);
            }
        }
    }
}
