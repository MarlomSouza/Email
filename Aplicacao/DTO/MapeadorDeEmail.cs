using Dominio;

namespace Aplicacao.DTO
{
    public class MapeadorDeEmail : IMapeadorDeEmail
    {
        public Email Mapear(EmailDto emailDto)
        {
            return new Email(emailDto.Remetente, emailDto.Mensagem, emailDto.Destinatario);
        }
    }
}