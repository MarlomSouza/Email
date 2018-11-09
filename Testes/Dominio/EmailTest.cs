using System;
using Dominio;
using Xunit;

namespace Testes
{
    public class EmailTest
    {
        [Fact]
        public void Deve_criar_um_email_com_remetente()
        {
            const string enderecoEsperado = "marlom@email.com";

            var email = EmailBuilder.Novo().ComRemetente(enderecoEsperado).Criar();
            var novoEmail = new Email(email.Remetente, email.Mensagem, email.Destinario);

            Assert.Equal(enderecoEsperado, email.Remetente);
        }

        [Fact]
        public void Deve_criar_um_email_com_mensagem()
        {
            const string mensagemEsperada = "Texto para o email.";

            var email = EmailBuilder.Novo().ComMensagem(mensagemEsperada).Criar();
            var novoEmail = new Email(email.Remetente, email.Mensagem, email.Destinario);

            Assert.Equal(mensagemEsperada, email.Mensagem);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("marlom")]
        [InlineData("marlom.com")]
        [InlineData("marlom@teste")]
        public void Nao_deve_criar_email_com_endereco_invalido(string remetente)
        {
            const string mensagemEsperada = "Endereço de email inválido";

            void Action() => EmailBuilder.Novo().ComRemetente(remetente).Criar();

            var mensagem = Assert.Throws<FormatException>((Action)Action).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Fact]
        public void Deve_criar_email_com_destinaratio()
        {
            const string emailDestinario = "teste@teste.com";

            var email = EmailBuilder.Novo().ComDestinario(emailDestinario).Criar();

            Assert.Equal(emailDestinario, email.Destinario);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("destinario")]
        [InlineData("destinario.com")]
        [InlineData("destinario@teste")]
        public void Nao_deve_criar_email_com_destinario_invalido(string destinarioInvalido)
        {
            const string mensagemEsperada = "Endereço de email inválido";

            var mensagem = Assert.Throws<FormatException>(() => EmailBuilder.Novo().ComDestinario(destinarioInvalido).Criar()).Message;

            Assert.Equal(mensagemEsperada, mensagem);
        }
    }
}
