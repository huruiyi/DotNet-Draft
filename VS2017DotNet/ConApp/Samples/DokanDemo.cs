using DokanNet;
using System;

namespace ConApp.Samples
{
    internal class DokanDemo
    {
        public static void DokanOperationDemo()
        {
            try
            {
                DokanOperation rfs = new DokanOperation();
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