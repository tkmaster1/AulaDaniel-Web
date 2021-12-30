namespace ProjetoDanielEx.Web.UI.Application.DTO
{
    public class ClienteDTO
    {
        public int? Codigo { get; set; }

        public string Nome { get; set; }

        public string Documento { get; set; }

        public string TipoPessoa { get; set; }

        public bool  Status { get; set; }

        public virtual EnderecoDTO Endereco { get; set; }
    }
}
