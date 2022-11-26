namespace AstenAssinaturaAPI.Models
{
    public class SignatarioEnvelope
    {
        public int Ordem { get; set; }
        public string TagAncoraCampos { get; set; }
        public ConfigAssinatura ConfigAssinatura { get; set; } = new ConfigAssinatura();

    }
}