using Xunit;

namespace Testes
{
    public class EnviardorDeEmailTeste
    {
        public EnviardorDeEmailTeste()
        {
        }

        [Fact]
        public void Deve_enviar_email()
        {
            //Given
            var email = EmailBuilder.Novo().ComDestinario("marlomsouza@digix.com.br").ComMensagem("Teste").Criar();
            //When
            bool foiEnviado = new EnviadorDeEmail(email).Enviar();
            //Then
            Assert.True(foiEnviado);
        }
    }
}