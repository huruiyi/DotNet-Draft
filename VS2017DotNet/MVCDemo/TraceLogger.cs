using System.ComponentModel.Composition;

namespace MVCDemo
{
    [Export("myTraceLogger", typeof(ILogger))]
    public class TraceLogger : ILogger
    {
        public void Write(string text)
        {
            System.Diagnostics.Trace.WriteLine(text);
        }
    }
}