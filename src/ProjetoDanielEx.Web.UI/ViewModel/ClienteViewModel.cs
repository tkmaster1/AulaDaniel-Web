using System.ComponentModel;

namespace ProjetoDanielEx.Web.UI.ViewModel
{
    public class ClienteViewModel
    {
        public int? Codigo { get; set; }

        [DisplayName("Nome:")]
        public string Nome { get; set; }

        public string Documento { get; set; }

        [DisplayName("Tipo Pessoa:")]
        public string TipoPessoa { get; set; }

        [DisplayName("Status:")]
        public string DescricaoStatus { get; set; }

        [DisplayName("CPF / CNPJ:")]
        public string CPFCNPJFormatado { get; set; }
    }
}
