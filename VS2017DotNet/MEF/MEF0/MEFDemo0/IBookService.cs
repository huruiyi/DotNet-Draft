namespace MEFDemo
{
    public interface IBookService
    {
        string BookName { get; set; }

        string GetBookName();
    }
}