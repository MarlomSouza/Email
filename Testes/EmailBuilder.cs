using Dominio;

namespace Testes
{
    public class EmailBuilder
    {
        private string _remetente;
        private string _mensagem;
        private string _destinario;

        private EmailBuilder()
        {
            _remetente = "marlom@teste.com";
            _destinario = "destinario@teste.com";
            _mensagem = "Uma mensagem de email";
        }

        public static EmailBuilder Novo()
        {
            return new EmailBuilder();
        }


        public EmailBuilder ComRemetente(string remetente)
        {
            _remetente = remetente;
            return this;
        }

        public EmailBuilder ComMensagem(string mensagem)
        {
            _mensagem = mensagem;
            return this;
        }

        public EmailBuilder ComDestinario(string destinario)
        {
            _destinario = destinario;
            return this;
        }

        public Email Criar()
        {
            return new Email(_remetente, _mensagem, _destinario);
        }
    }
}