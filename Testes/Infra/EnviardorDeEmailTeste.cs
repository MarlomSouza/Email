using Dominio;
using Xunit;
using Infra;
using Moq;

namespace Testes
{
    public class EnviardorDeEmailTeste
    {
        private Mock<IEnviadorDeEmail> _enviadororDeEmail;

        public EnviardorDeEmailTeste()
        {
            _enviadororDeEmail = new Mock<IEnviadorDeEmail>();
        }

        [Fact]
        public void Deve_enviar_email()
        {
            _enviadororDeEmail.Setup()
            //Given
            var email = EmailBuilder.Novo().ComDestinario("marlomsouza@digix.com.br").ComRemetente("teste@teeste.com").ComMensagem("isso é um teste").Criar();
            //Then
            Assert.True(new EnviadorDeEmail().Enviar(email));
        }
    }
}