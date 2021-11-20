using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDanielEx.Web.UI.Application.DTO
{
    public class ClienteDTO
    {
        public int? Codigo { get; set; }

        public string Nome { get; set; }

        public string Documento { get; set; }

        public string TipoPessoa { get; set; }

        public string TipoPessoaFormatado { get; set; }

        public string DescricaoStatus { get; set; }

        public string CPFCNPJFormatado { get; set; }
    }
}
