namespace AstenAssinaturaAPI.Models
{
    public class ConfigAssinatura
    {
        public string EmailSignatario { get; set; }
        public string NomeSignatario { get; set; }
        public string CelularSignatario { get; set; }
        public int TipoAssinatura { get; set; }
        public  bool PermitirDelegar { get; set; }
        public bool ApenasCelular { get; set; }
        public bool ExigirLogin { get; set; }
        public bool ExigirCodigo { get; set; }  
        public bool ExigirDadosIdentif { get; set; }
        public bool AssinaturaPresencial { get; set; }
        public string? NomeSignPresencial { get; set; }
        public string? CpfSignPresencial { get; set; }
        public bool IgnorarRecusa { get; set; }
        public int CodigoExigido { get; set; }
        public bool IncluirImagensAutentEnvelope { get; set; }
        public bool AnalisarFaceImagem { get; set; }
        public int PercenturalPrecisaoFace { get; set; }
    }
}