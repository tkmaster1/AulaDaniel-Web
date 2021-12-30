using Microsoft.AspNetCore.Mvc.Razor;
using System;

namespace ProjetoDanielEx.Web.UI.Util
{
    public static class RazorExtensions
    {
        public static string FormataDocumento(this RazorPage page, string tipoPessoa, string documento)
        {
            return tipoPessoa == "F" ? Convert.ToUInt64(documento).ToString(@"000\.000\.000\-00") : Convert.ToUInt64(documento).ToString(@"00\.000\.000\/0000\-00");
        }

        public static string FormataTipoPessoa(this RazorPage page, string tipoPessoa)
        {
            return tipoPessoa == "F" ? "Física" : "Jurídica";
        }

        public static string FormataStatus(this RazorPage page, bool status)
        {
            return status ? "Ativo" : "Inativo";
        }
    }
}
