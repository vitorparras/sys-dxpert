using Domain.Enum;
using Domain.Model.Bases;

namespace Domain.Model
{
    public class Cadastro : BaseEntity
    {
        public string? Nome { get; set; }
        public string? Etapa { get; set; }
        public string? Email { get; set; }
        public string? EstadoCivil { get; set; }
        public DateTime? DataCasamento { get; set; }
        public string? ConjugeNome { get; set; }
        public DateTime? ConjugeDataNasc { get; set; }
        public bool? PossuiFilhos { get; set; }
        public string? Ocupacao { get; set; }
        public string? EmpresaTrabalho { get; set; }
        public string? Categoria { get; set; }
        public string? PoliticamenteExposto { get; set; }
        public string? PresidenteNoBrasil { get; set; }
        public string? RendaBruta { get; set; }
        public string? DespesaMensal { get; set; }
        public string? ObrigacoesFiscaisExterior { get; set; }
        public string? ImpostoDeRenda { get; set; }
        public string? TotalImoveis { get; set; }
        public string? TotalVeiculos { get; set; }
        public string? TotalAplicacoesFinanceiros { get; set; }
        public string? HistoricoSeguradora { get; set; }
        public string? ViagemInternacional { get; set; }
        public string? ProblemasSaude { get; set; }
        public string? UsoMedicamento { get; set; }
        public string? SofreDoencas { get; set; }
        public string? PossuiDeficiencia { get; set; }
        public string? RealizouCirurgia { get; set; }
        public string? PossuiAlgumaAtividade { get; set; }
        public string? Fumante { get; set; }
        public string? TipoSubstancia { get; set; }
        public string? QuantidadeSubstancia { get; set; }
        public string? QuantidadeFilhos { get; set; }
        public string? FilhosMaiores { get; set; }
        public DateTime? DataNascimento { get; set; }
        public Sexo? Sexo { get; set; }
        public string? Celular { get; set; }
        public int QuantidadeFilhosMaiores { get; set; }
        public int AnosContribuicao { get; set; }
        public string? DataPosse { get; set; }
        public string? Profissao { get; set; }
        public string? RegimeContratacao { get; set; }
        public string? ReservaEmergencia { get; set; }
        public string? TempoReserva { get; set; }
        public string? ProblemaSaude { get; set; }
        public string? TomaRemedio { get; set; }
        public string? Fuma { get; set; }
        public string? MaiorPrioridade { get; set; }
        public int IdUsuarioResponsavel { get; set; }
    }
}
