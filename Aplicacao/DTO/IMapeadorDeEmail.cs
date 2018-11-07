using Dominio;

namespace Aplicacao.DTO
{
    public interface IMapeadorDeEmail
    {
        Email Mapear(EmailDto emailDto);
    }
}