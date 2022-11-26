using System;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AstenAssinaturaAPI.Models;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Text;
using System.Reflection.Metadata;
using Newtonsoft.Json.Linq;

namespace AstenAssinaturaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EnvelopeController : ControllerBase
    {
        [HttpPost]
        [Route("inserirEnvelope")]
        public ActionResult InserirEnvelope()
        {
            var Connection = "https://plataforma.astenassinatura.com.br/api/inserirEnvelope";

            try
            {
                using (var client = new HttpClient())
                {
                var inserirEnvelope = new InserirEnvelope()
                {
                    Params = new Params()
                    {
                        Envelope = new Envelope()
                        {
                            descricao = "Nova Descricao",
                        }
                    },
                };

                var DocumentoSemXml = new DocumentoMock();
                var _documento = new Documento()
                {
                    nomeArquivo = "Documento.txt",
                    mimeType = "application/txt",
                    conteudo = "JVBERi0xLjUNCiW1t..."
                };

                var _signatario = new SignatarioMock();
                var Signatario = new SignatarioEnvelope()
                {
                    ConfigAssinatura = new ConfigAssinatura()
                    {
                        emailSignatario = "arthurvasconcelosdelunafreire@gmail.com",
                    },
                };


                var SignatarioTecnico = new SignatarioEnvelope()
                {
                    ConfigAssinatura = new ConfigAssinatura()
                    {
                        emailSignatario = "prova.tecnica@avmb.com.br",
                    },
                };

                _signatario.SignatarioEnvelope.Add(Signatario);
                _signatario.SignatarioEnvelope.Add(SignatarioTecnico);
                inserirEnvelope.Params.Envelope.listaSignatariosEnvelope.Add(_signatario);
                DocumentoSemXml.Documento.Add(_documento);
                inserirEnvelope.Params.Envelope.listaDocumentos.Add(DocumentoSemXml);

                    var jsonobjeto = JsonConvert.SerializeObject(inserirEnvelope).Replace("Params","params");
                    var content = new StringContent(jsonobjeto, Encoding.UTF8, "application/json");

                    var response = client.PostAsync(Connection, content);
                    response.Wait();

                    if (response.Result.IsSuccessStatusCode)
                    {
                        var result = response.Result.Content.ReadAsStringAsync();

                        var data = (JObject)JsonConvert.DeserializeObject(result.Result);

                        return Ok(result.Result);
                    }

                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("encaminharEnvelopeParaAssinaturas")]
        public ActionResult encaminharEnvelopeParaAssinaturas(long envelopeId)
        {
            var  Connection = "https://plataforma.astenassinatura.com.br/api/encaminharEnvelopeParaAssinaturas";
            try
            {
                using (var client = new HttpClient())
                {
                    var encaminharEnvelopeAssinaturas = new encaminharEnvelopeParaAssinaturas()
                    {
                        Params = new ParamsId()
                        {
                            EnvelopeId = new EnvelopeId()
                            {
                                id = envelopeId,
                            }
                        },
                    };

                    var jsonobjeto = JsonConvert.SerializeObject(encaminharEnvelopeAssinaturas).Replace("Params", "params");
                    jsonobjeto = jsonobjeto.Replace("EnvelopeId", "Envelope");
                    var content = new StringContent(jsonobjeto, Encoding.UTF8, "application/json");

                    var response = client.PostAsync(Connection, content);
                    response.Wait();

                    if (response.Result.IsSuccessStatusCode)
                    {
                        var result = response.Result.Content.ReadAsStringAsync();

                        var envelopeCriado = JsonConvert.DeserializeObject<Envelope>(result.Result);

                        return Ok(result.Result);
                    }
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("consultarStatusEnvelope")]
        public ActionResult consultarStatusEnvelope(long envelopeId)
        {
            var Connection = "https://plataforma.astenassinatura.com.br/api/getDadosEnvelope";
            try
            {
                using (var client = new HttpClient())
                {
                    var consultarStatusEnvelope = new consultarStatusEnvelope()
                    {
                       Params = new ParamStatus()
                       {
                           idEnvelope = envelopeId,
                       }
                    };

                    var jsonobjeto = JsonConvert.SerializeObject(consultarStatusEnvelope).Replace("Params", "params");


                    var content = new StringContent(jsonobjeto, Encoding.UTF8, "application/json");

                    var response = client.PostAsync(Connection, content);
                    response.Wait();

                    if (response.Result.IsSuccessStatusCode)
                    {
                        var result = response.Result.Content.ReadAsStringAsync();
                        var data = (JObject)JsonConvert.DeserializeObject(result.Result);

                        var status = data.SelectToken("response.status").Value<int>();

                        if(status == 4)
                        {

                        }

                        return Ok(result.Result);
                    }
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
