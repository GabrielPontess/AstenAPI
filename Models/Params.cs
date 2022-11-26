namespace AstenAssinaturaAPI.Models
{
    public class Params
    {
        public Envelope Envelope { get; set; }

    }
    public class ParamsId
    {
        public EnvelopeId EnvelopeId { get; set; }
    }
    public class ParamStatus
    {
        public long idEnvelope { get; set; }
        public string getLobs { get; set; } = "N";
    }
    public class ParamsPdfDownload
    {
        public long idEnvelope { get; set; }
        public string incluirDocs { get; set; } = "N";
        public string versaoSemCertificado { get; set; }
    }
}