using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Mail;

namespace UnitTestDemo
{
    public interface ILoggerSomeDependency
    {
        string GetApplicationDirectory();

        string GetDirectoryForDependencyByLoggerName(string loggerName);

        string GetLoggerInstance { get; }
    }

    public class Logger
    {
        private readonly ILogSaver _logSaver;

        public Logger(ILogSaver logWriter)
        {
            _logSaver = logWriter;
        }

        public void WriteLine(string message)
        {
            _logSaver.Write(message);
        }
    }

    public interface ILogSaver
    {
        string GetLogger();

        void SetLogger(string logger);

        void Write(string message);
    }

    public interface ILogMailer
    {
        void Send(MailMessage mailMessage);
    }

    public class WizzLogger
    {
        private ILogMailer mailer;
        private ILogSaver saver;

        public WizzLogger(ILogSaver s, ILogMailer m)
        {
            mailer = m;
            saver = s;
        }

        public void Send(MailMessage mailMessage)
        {
        }

        public void WriteLine(string message)
        {
            mailer.Send(new MailMessage());
            saver.Write(message);
        }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}