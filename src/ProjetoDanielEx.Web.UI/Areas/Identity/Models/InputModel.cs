using System.ComponentModel.DataAnnotations;

namespace ProjetoDanielEx.Web.UI.Areas.Identity.Models
{
    public class InputLoginModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Lembrar de mim?")]
        public bool RememberMe { get; set; }
    }

    public class InputRegisterModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Nome")]
        public string Username { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(100, ErrorMessage = "O {0} deve ter pelo menos {2} e no máximo {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a Senha")]
        [Compare("Password", ErrorMessage = "A senha e a senha de confirmação não correspondem.")]
        public string ConfirmPassword { get; set; }
    }

    public class InputIndexModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Nome")]
        public string Username { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Phone]
        [Display(Name = "Telefone")]
        public string PhoneNumber { get; set; }
    }

    public class InputChangePasswordModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha atual")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(100, ErrorMessage = "A {0} deve ter pelo menos {2} e no máximo {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova senha")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a nova senha")]
        [Compare("NewPassword", ErrorMessage = "A nova senha e a senha de confirmação não correspondem.")]
        public string ConfirmPassword { get; set; }
    }

    public class InputEmailModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [EmailAddress]
        public string Email { get; set; }
    }

}
