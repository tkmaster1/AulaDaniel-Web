using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoDanielEx.Web.UI.ViewModel
{
    public class ClienteViewModel
    {
        public int? Codigo { get; set; }

        [DisplayName("Nome:")]
        [Required(ErrorMessage = "* O campo {0} é obrigatório")]
        [StringLength(255, ErrorMessage = "O campo {0} precisa ter {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "* O campo {0} é obrigatório")]
        [StringLength(18, ErrorMessage = "O campo {0} precisa ter {1} caracteres", MinimumLength = 11)]
        public string Documento { get; set; }

        [DisplayName("Tipo Pessoa:")]
        [Required(ErrorMessage = "* O campo {0} é obrigatório")]
        public string TipoPessoa { get; set; }

        public bool Status { get; set; }

        public Dictionary<string, string> ListaTipoPessoa { get; set; }

        public string Mensagem { get; set; }

        public EnderecoViewModel Endereco { get; set; }
    }
}
