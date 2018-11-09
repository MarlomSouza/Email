using System;
using Dominio;
using Moq;
using Xunit;

namespace Testes.Dominio
{
    public class ArmazenadorDeEmailTeste
    {
        private readonly Mock<IEmailRepository> _emailRepository;
        private readonly ArmazenadorDeEmail _armazenadorDeEmail;

        public ArmazenadorDeEmailTeste()
        {
            _emailRepository = new Mock<IEmailRepository>();
            _armazenadorDeEmail = new ArmazenadorDeEmail(_emailRepository.Object);
        }

        [Fact]
        public void Deve_armazenar_um_email()
        {
            
            var email = EmailBuilder.Novo().Criar();

            _armazenadorDeEmail.Salvar(email);

            _emailRepository.Verify(repository => repository.Salvar(email), Times.Once);
        }

        [Fact]
        public void Nao_deve_armazenar_um_email_com_as_mesmas_informacoes()
        {
            var email = EmailBuilder.Novo().Criar();
            const string mensagemEsperada = "Email já enviado!";
            _emailRepository.Setup(repo => repo.ObterPor(email.Destinario, email.Remetente, email.Mensagem))
                .Returns(email);
            

            void Action() => _armazenadorDeEmail.Salvar(email); ;

            var mensagem = Assert.Throws<Exception>((Action)Action).Message;
            Assert.Equal(mensagemEsperada, mensagem);
            _emailRepository.Verify(repository => repository.Salvar(email), Times.Never);
        }
    }
}