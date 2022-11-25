namespace AstenAssinaturaAPI.Models
{
    public class ConfigAuxiliar
    {
        private string _urlCarimboTempo = "https://plataforma.astenassinatura.com.br/";

        public string DocumentoComXMLs { get; set; } = "N";
        public string UrlCarimboTempo
        {
            set
            {
                UrlCarimboTempo = _urlCarimboTempo;
            }
        }
    }
}