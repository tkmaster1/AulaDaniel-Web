using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDanielEx.Web.UI.Application.DTO
{
    public class ClienteDTO
    {
        public int? Codigo { get; set; }

        public string Nome { get; set; }

        public string Documento { get; set; }

        public string TipoPessoa { get; set; }

        [NotMapped]
        public string DescricaoStatus { get; set; }

        [NotMapped]
        public string CPFCNPJFormatado { get; set; }
    }
}
