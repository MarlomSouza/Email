using Dominio;

namespace Testes
{
    public interface IEmailRepository
    {
        void Salvar(Email email);
        Email ObterPor(string emailDestinario, string emailRemetente, string emailMensagem);
    }
}