namespace AstenAssinaturaAPI.Models
{
    public class XMLAuxiliar
    {
        public long Id { get; set; }
        public string? NomeArquivo { get; set; }
        public string? ConteudoXML { get; set; } 
        public List<XMLSignatario>? XMLSignatarios { get; set; }
    }
}