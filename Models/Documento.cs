namespace AstenAssinaturaAPI.Models
{
    public class Documento
    {
        public long Id { get; set; }
        public string NomeDocumento { get; set; }
        public string MimeType { get; set; }
        public string Conteudo { get; set; }
        public List<XMLAuxiliar> XMLAuxiliar { get; set; } = new List<XMLAuxiliar>();
    }
}