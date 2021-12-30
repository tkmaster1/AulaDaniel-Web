using System.Collections.Generic;

namespace ProjetoDanielEx.Web.UI.Application.Response
{
    public class RetornoAPIDataList<T> : RetornoAPI
    {
        public List<T> Data { get; set; }
    }
}
