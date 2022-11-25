namespace AstenAssinaturaAPI.Models
{
    public class Envelope
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public Repositorio Repositorio { get; set; }
        public string? Mensagem { get; set; }
        public string? MensagemObservadores { get; set; }
        public DateTime? DataExpiracao { get; set; }
        public DateTime? HoraExpiracao { get; set; }
        public bool UsarOrdem { get; set; } = true; 
        public ConfigAuxiliar ConfigAuxiliar { get; set; }
        public List<Documento> Documentos { get; set; }
        public List<SignatarioEnvelope> SignatariosEnvelope { get; set; }
        public List<Observador> Observadores { get; set; }
        public List<Tag> Tags { get; set; }
        public List<InfoAdicional> InfoAdicionais { get; set; }
        public bool IncluirHashTodasPaginas { get; set; } = true;
        public bool PermitirDespachos { get; set; } = true;
        public bool IgnorarNotificacoes { get; set; } = false;
        public bool IgnorarNotificacoesPendentes { get; set; } = false;
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
