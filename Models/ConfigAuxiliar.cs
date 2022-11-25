namespace AstenAssinaturaAPI.Models
{
    public class ConfigAuxiliar
    {
        private string _urlCarimboTempo = "https://plataforma.astenassinatura.com.br/";

        public bool DocumentoComXMLs { get; set; } = false;
        public string UrlCarimboTempo
        {
            set
            {
                UrlCarimboTempo = _urlCarimboTempo;
            }
        }
    }
}