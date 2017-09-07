using System.ComponentModel.Composition;

namespace MEFDemo
{
    [Export("MusicBook")]
    public class MusicBook : IBookService
    {
        public string BookName { get; set; }

        public string GetBookName()
        {
            return "MusicBook";
        }
    }

    [Export("MathBook", typeof(IBookService))]
    public class MathBook : IBookService
    {
        public string BookName { get; set; }

        public string GetBookName()
        {
            return "MathBook";
        }
    }

    [Export("HistoryBook", typeof(IBookService))]
    public class HistoryBook : IBookService
    {
        public string BookName { get; set; }

        public string GetBookName()
        {
            return "HistoryBook";
        }
    }
}