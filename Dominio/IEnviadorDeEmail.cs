namespace Dominio
{
    public interface IEnviadorDeEmail
    {
        bool Enviar(Email email);
    }
}