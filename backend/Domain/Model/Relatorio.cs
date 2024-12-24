using Domain.Calculos;
using Domain.Model.Bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Model
{
    public class Relatorio : BaseEntity
    {

        public string? Nome { get; set; }


        public string? Nascimento { get; set; }


        public string? Idade { get; set; }


        public string? QuantidadeFilhos { get; set; }


        public string? RendaHoje { get; set; }


        public string? DespesaTotal { get; set; }


        public string? DuracaoReservaDeEmergencia { get; set; }


        public string? Aposentadoria { get; set; }


        public string? MeAposentoAos { get; set; }


        public string? Ocupacao { get; set; }


        public string? BeneficioInvalidez { get; set; }


        public string? PensaoPorMorte { get; set; }


        public string? ReceberaPor { get; set; }


        public string? NaAposentadoria { get; set; }


        public string? NaInvalidez { get; set; }


        public string? NaPensaoPorMorte { get; set; }


        public string? PrazoParaTermLife { get; set; }


        public string? IsMedico { get; set; }


        public string? RendaMensalContratar { get; set; }


        public string? ValorDidMedico { get; set; }


        public string? ContribuicaoParaAPrevidenciaSocial { get; set; }


        public string? IdademinimaParaMeAposentar { get; set; }


        public string? DevoContribuirPeloMenosMais { get; set; }


        public string? BeneficioPorInvalidez { get; set; }


        public string? BeneficioPorInvalidezValor2 { get; set; }


        public string? BeneficioPorMorte { get; set; }


        public string? BeneficioPorMorteValor2 { get; set; }


        public string? TotalInvestidoEmSegurosDuranteEssePeriodo { get; set; }

        public bool? Ativo { get; set; }


        public List<ProdutoSugestaoParaRecuperarDTO>? ProdutosSugestaoParaRecuperar { get; set; }



        [ForeignKey("Cadastro")]
        public int CadastroId { get; set; }

        public virtual Cadastro Cadastro { get; set; }
    }
}
