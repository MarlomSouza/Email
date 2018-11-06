using System;
using System.Text.RegularExpressions;

namespace Dominio
{
    public class Email
    {
        public string Remetente { get; private set; }
        public string Mensagem { get; private set; }
        public string Destinario { get; private set; }

        public Email(string remetente, string mensagem, string destinario)
        {
           ValidarEnderecoDeEmail(remetente);
            ValidarEnderecoDeEmail(destinario);

            Remetente = remetente;
            Mensagem = mensagem;
            Destinario = destinario;
        }

        private static void ValidarEnderecoDeEmail(string endereco)
        {
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            if (string.IsNullOrEmpty(endereco) || !regex.Match(endereco).Success)
                throw new FormatException("Endereço de email inválido");
        }
    }
}
