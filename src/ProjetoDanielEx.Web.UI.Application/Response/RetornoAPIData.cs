namespace ProjetoDanielEx.Web.UI.Application.Response
{
    public class RetornoAPIData<T> : RetornoAPI
    {
        public T Data { get; set; }
    }
}
