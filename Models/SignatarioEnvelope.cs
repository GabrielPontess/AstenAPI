namespace AstenAssinaturaAPI.Models
{
    public class SignatarioEnvelope
    {
        public Envelope Id { get; set; }
        public int Ordem { get; set; }
        public string TagAncoraCampos { get; set; }
        public ConfigAssinatura ConfigAssinatura { get; set; }

    }
}