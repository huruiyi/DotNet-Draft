namespace Artech.MiniMvc
{
    public interface IController
    {
        void Execute(RequestContext requestContext);
    }
}