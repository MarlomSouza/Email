using System;
using Testes;

namespace Dominio
{
    public class ArmazenadorDeEmail
    {
        private readonly IEmailRepository _emailRepository;

        public ArmazenadorDeEmail(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }

        public void Salvar(Email email)
        {
            var emailEncontrado = _emailRepository.ObterPor(email.Destinario, email.Remetente, email.Mensagem);

            if(emailEncontrado != null)
                throw new Exception("Email já enviado!");

            _emailRepository.Salvar(email);
        }
    }
}