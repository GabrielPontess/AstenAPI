namespace AstenAssinaturaAPI.Models
{
    public class XMLSignatario
    {
        public long Id { get; set; }
        public string? EmailSignatario { get; set; }
        public long? IdNodeAssinatura { get; set; }  
        public bool? RestringirPessoaFisica { get; set; }
        public bool? RestringirPessoaJuridica { get; set; }  
    }
}