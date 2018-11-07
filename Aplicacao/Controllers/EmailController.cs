using System;
using Aplicacao.DTO;
using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Controllers
{
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly IEnviadorDeEmail _enviadorDeEmail;
        private readonly IMapeadorDeEmail _mapeadorDeEmail;
        public EmailController(IEnviadorDeEmail enviadorDeEmail, IMapeadorDeEmail mapeadorDeEmail)
        {
            _enviadorDeEmail = enviadorDeEmail;
            _mapeadorDeEmail = mapeadorDeEmail;
        }

        [HttpPost]
        public void Post([FromBody]EmailDto emailDto)
        {
            var email = _mapeadorDeEmail.Mapear(emailDto);
            var enviado = _enviadorDeEmail.Enviar(email);
            if (!enviado)
                throw new Exception("Email não enviado");
        }

    }
}
