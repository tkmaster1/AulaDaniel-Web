namespace ProjetoDanielEx.Web.UI.Util
{
    public class Mensagens
    {
        public static string MSG_SUCESSO
        {
            get { return "{1} {0} com sucesso"; }
        }

        public static string MSG_FALHA
        {
            get { return "Ocorreu uma falha ao {0} {1} "; }
        }

        public static string MSG_VALIDARCPFCNPJ_FALHA
        {
            get { return "{0} inválido!"; }
        }

        public static string MSG_NOME_CLIENTE
        {
            get { return "Nome do cliente já existente - {0} ."; }
        }

        public static string MSG_DOCUMENTO_CLIENTE
        {
            get { return "Documento já existente - {0} ."; }
        }
    }
}
