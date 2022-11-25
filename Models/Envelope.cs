namespace AstenAssinaturaAPI.Models
{
    public class Envelope
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public Repositorio Repositorio { get; set; } = new Repositorio();
        public string? Mensagem { get; set; }
        public string? MensagemObservadores { get; set; }
        public DateTime? DataExpiracao { get; set; }
        public DateTime? HoraExpiracao { get; set; }
        public string UsarOrdem { get; set; } = "S"; 
        public ConfigAuxiliar ConfigAuxiliar { get; set; } = new ConfigAuxiliar();
        public List<Documento> Documentos { get; set; } = new List<Documento>();
        public List<SignatarioEnvelope> SignatariosEnvelope { get; set; } = new List<SignatarioEnvelope>(); 
        public List<Observador> Observadores { get; set; } = new List<Observador>();
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public List<InfoAdicional> InfoAdicionais { get; set; } = new List<InfoAdicional>();
        public string IncluirHashTodasPaginas { get; set; } = "S";
        public string PermitirDespachos { get; set; } = "S";
        public string IgnorarNotificacoes { get; set; } = "N";
        public string IgnorarNotificacoesPendentes { get; set; } = "N";
        public double? QrCodePosLeft { get; set; }
        public double? QrCodePosTop { get; set; }
        public DateTime? DataIniContrato { get; set; }
        public DateTime? DataFimContrato { get; set; }
        public string? ObjetoContrato { get; set; }
        public decimal? ValorContrato { get; set; }
        public string? DescricaoContratante { get; set; }
        public string? DescricaoContratado { get; set; }
    }
}
