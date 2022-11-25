using System;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AstenAssinaturaAPI.Models;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Text;

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
                    var Envelope = new Envelope();

                    var jsonobjeto = JsonConvert.SerializeObject(Envelope);
                    var content = new StringContent(jsonobjeto, Encoding.UTF8, "application/json");

                    var response = client.PostAsync(Connection, content);
                    response.Wait();

                    if (response.Result.IsSuccessStatusCode)
                    {
                        var result = response.Result.Content.ReadAsStringAsync();

                        var envelopeCriado = JsonConvert.DeserializeObject<Envelope>(result.Result);
                        return envelopeCriado;
                    }
                }
            }
            catch(Exception ex)
            {
                throw;
            }

            return NotFound();
        }
    }
}
