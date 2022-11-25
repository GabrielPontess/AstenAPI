using System;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AstenAssinaturaAPI.Models;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Text;
using System.Reflection.Metadata;

namespace AstenAssinaturaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EnvelopeController : ControllerBase
    {
        [HttpPost]
        public ActionResult InserirEnvelope()
        {
            string Connection = "https://plataforma.astenassinatura.com.br/api/inserirEnvelope";

            try
            {
                using (var client = new HttpClient())
                {
                    var inserirEnvelope = new InserirEnvelope()
                    {
                        Token = "GYtZ6+1SZRx5QypP2huHk2OOJfr1FyeQ79p1tt3JCiIoH93GbnkwxF6S60yFQoZwYCzUwZVb-Lk9KvOx1EDnve3c9kCXhw84MFRT-Zj7IojmKvbK7pyRIsKdVqJAEyE5Lr4sMM5c0mzbUt0ZrLpsF1vZ9rPNAn-5-4rlgk2N-8RZjs8R5BbKuU",
                        Params = new Params()
                        {
                            Envelope = new Envelope()
                            {
                                Descricao = "Nova Descricao",
                            }
                        },
                    };

                    var Signatario = new SignatarioEnvelope()
                    {
                        ConfigAssinatura = new ConfigAssinatura()
                        {
                            EmailSignatario = "arthurvasconcelosdelunafreire@gmail.com",
                        },
                    };


                    var SignatarioTecnico = new SignatarioEnvelope()
                    {
                        ConfigAssinatura = new ConfigAssinatura()
                        {
                            EmailSignatario = "prova.tecnica@avmb.com.br",
                        },
                    };

                    inserirEnvelope.Params.Envelope.SignatariosEnvelope.Add(Signatario);
                    inserirEnvelope.Params.Envelope.SignatariosEnvelope.Add(SignatarioTecnico);

                    var jsonobjeto = JsonConvert.SerializeObject(inserirEnvelope);
                    var content = new StringContent(jsonobjeto, Encoding.UTF8, "application/json");

                    var response = client.PostAsync(Connection, content);
                    response.Wait();

                    if (response.Result.IsSuccessStatusCode)
                    {
                        var result = response.Result.Content.ReadAsStringAsync();

                        var envelopeCriado = JsonConvert.DeserializeObject<Envelope>(result.Result);

                        return Ok(envelopeCriado);
                    }

                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

    }
}
