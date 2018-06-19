using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Mvc.Interfaces
{
    public interface ILogger
    {
        void Write(string text);
    }

    [Export("myTraceLogger", typeof(ILogger))]
    public class TraceLogger : ILogger
    {
        public void Write(string text)
        {
            System.Diagnostics.Trace.WriteLine(text);
        }
    }
}
