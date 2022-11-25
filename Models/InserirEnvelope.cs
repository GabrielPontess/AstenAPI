namespace AstenAssinaturaAPI.Models
{
    public class InserirEnvelope
    {
        public String Token { get; set; } 
        public Params Params { get; set; } = new Params();
        public string GerarTags { get; set; } = "S";
        public string EncaminharImediatamente { get; set; } = "N";
        public string DetectarCampos { get; set; } = "N";

    }
}
