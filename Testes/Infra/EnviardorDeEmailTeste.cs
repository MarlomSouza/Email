using Xunit;
using Infra;

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
            var email = EmailBuilder.Novo().ComDestinario("marlomsouza@digix.com.br").ComRemetente("teste@teeste.com").ComMensagem("isso é um teste").Criar();
            //When
            bool foiEnviado = new EnviadorDeEmail().Enviar(email);
            //Then
            Assert.True(foiEnviado);
        }
    }
}