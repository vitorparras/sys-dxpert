using Domain.Calculos;
using Domain.Enum;
using Domain.Model;
using Infrastructure.Repository.Interface;
using Service.Calculos;
using Service.Interfaces;

namespace Service
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IGenericRepository<Relatorio> _RelatorioRepository;
        private readonly IGenericRepository<Cadastro> _CadastroRepository;
        private readonly ICalculosService _calculosService;

        public RelatorioService(IGenericRepository<Relatorio> relatorioRepository,
            IGenericRepository<Cadastro> cadastroRepository,
            ICalculosService calculosService)
        {
            _RelatorioRepository = relatorioRepository;
            _CadastroRepository = cadastroRepository;
            _calculosService = calculosService;
        }

        public async Task<Relatorio> GetRelatorio(int idCadastro)
        {
            var cadastro = await _CadastroRepository.FirstOrDefaultAsync(x => x.Id == idCadastro);
            var aposentado = cadastro.Ocupacao == "Aposentado(a)";

            var rendalimpa = cadastro.RendaBruta.Replace("R$ ", "");
            _ = double.TryParse(rendalimpa, out var rendaHoje);

            var idadeMinimaAposentar = cadastro.Sexo == Sexo.Masculino ? 65 : 62;
            var idade = CalcularIdade(cadastro?.DataNascimento ?? DateTime.MinValue);
            var meAposentoAos = (idade + cadastro.AnosContribuicao) <= idadeMinimaAposentar ? idadeMinimaAposentar : (idade + cadastro.AnosContribuicao);
            var aposentadoria = aposentado ? 0 : _calculosService.CalcularRegimeContratacao(cadastro, rendaHoje);

            var beneficioInvalidez = aposentado ? 0 : _calculosService.CalcularBeneficioInvalidez(cadastro, rendaHoje);
            var pensaoPorMorte = aposentado ? 0 : _calculosService.CalcularPensaoPorMorte(cadastro, rendaHoje, beneficioInvalidez);
            var receberaPor = pensaoPorMorte == 0 || cadastro.ConjugeDataNasc == null ? "0" : _calculosService.CalcularReceberPor(cadastro.ConjugeDataNasc ?? DateTime.MaxValue);

            var minhasPercasNaAposentadoria = aposentado ? 0 : rendaHoje - aposentadoria;
            var minhasPercasNaInvalidez = aposentado ? 0 : rendaHoje - beneficioInvalidez;
            var minhasPercasNaPensaoPorMorte = rendaHoje - pensaoPorMorte;

            #region produtosSugestaoParaRecuperar

            var seguroDeVida = CalcularValorDoSeguro(aposentado, rendaHoje, idade, minhasPercasNaPensaoPorMorte);
            var invalidezMajorada = CalcularValorInvalidez(aposentado, rendaHoje, idade, minhasPercasNaInvalidez);
            var doencasGraves = _calculosService.CalcularDoencasGraves(idade, idadeMinimaAposentar);

            var seguroDeVidaValor2 = await _calculosService.CalcularSugestaoDeProdutos(cadastro, CalcularNomeDoProduto(aposentado, idade), idade, minhasPercasNaPensaoPorMorte, minhasPercasNaInvalidez, idadeMinimaAposentar, cadastro.AnosContribuicao);
            var invalidezMajoradaValor2 = await _calculosService.CalcularSugestaoDeProdutos(cadastro, (idade > 60) ? "INVALIDEZ TOTAL " : "INVALIDEZ MAJORADA", idade, minhasPercasNaPensaoPorMorte, minhasPercasNaInvalidez, idadeMinimaAposentar, cadastro.AnosContribuicao);
            var doencasGravesValor2 = await _calculosService.CalcularSugestaoDeProdutos(cadastro, (idade > 65) ? "DOENÇAS GRAVES MASTER" : "DOENÇAS GRAVES", idade, minhasPercasNaPensaoPorMorte, minhasPercasNaInvalidez, idadeMinimaAposentar, cadastro.AnosContribuicao);

            var produtosSugestaoParaRecuperar = new List<ProdutoSugestaoParaRecuperarDTO>()
            {
                new ProdutoSugestaoParaRecuperarDTO()
                {
                    Nome = CalcularNomeDoProduto(aposentado, idade),
                    Valor1 = seguroDeVida.ToString(),
                    Valor2 = seguroDeVidaValor2.ToString(),
                },
                new ProdutoSugestaoParaRecuperarDTO()
                {
                    Nome = (idade > 60) ? "INVALIDEZ TOTAL" : "INVALIDEZ MAJORADA",
                    Valor1 = invalidezMajorada.ToString(),
                    Valor2 = invalidezMajoradaValor2.ToString(),
                },
                new ProdutoSugestaoParaRecuperarDTO()
                {
                    Nome = (idade > 65) ? "DOENÇAS GRAVES MASTER" : "DOENÇAS GRAVES",
                    Valor1 = doencasGraves.ToString(),
                    Valor2 = doencasGravesValor2.ToString(),
                }
            };

            #endregion

            var relatorio = new Relatorio
            {
                Nome = cadastro.Nome,
                Nascimento = cadastro.DataNascimento?.ToString("dd/MM/yyyy"),
                Idade = idade.ToString(),
                QuantidadeFilhos = cadastro.QuantidadeFilhos,
                RendaHoje = cadastro.RendaBruta,
                DespesaTotal = cadastro.DespesaMensal,
                DuracaoReservaDeEmergencia = cadastro.ReservaEmergencia,
                Aposentadoria = aposentadoria.ToString(),
                MeAposentoAos = meAposentoAos.ToString(),

                BeneficioInvalidez = beneficioInvalidez.ToString(),
                PensaoPorMorte = pensaoPorMorte.ToString(),
                ReceberaPor = receberaPor,

                NaInvalidez = minhasPercasNaInvalidez.ToString(),
                NaPensaoPorMorte = minhasPercasNaPensaoPorMorte.ToString(),
                NaAposentadoria = minhasPercasNaAposentadoria.ToString(),

                ProdutosSugestaoParaRecuperar = produtosSugestaoParaRecuperar,
            };
            return relatorio;
        }

        // OUTROS METODOS

        public int CalcularIdade(DateTime dataNascimento)
        {
            int idade = DateTime.Now.Year - dataNascimento.Year;
            if (DateTime.Now.Month < dataNascimento.Month || (DateTime.Now.Month == dataNascimento.Month && DateTime.Now.Day < dataNascimento.Day))
                idade--;

            return idade;
        }

        private double CalcularValorDoSeguro(bool aposentado, double rendaHoje, int idade, double minhasPercasNaPensaoPorMorte)
        {
            return aposentado
                ? rendaHoje * 0.20
                : (idade <= 50 ? minhasPercasNaPensaoPorMorte * 240 : minhasPercasNaPensaoPorMorte * 120);
        }

        private double CalcularValorInvalidez(bool aposentado, double rendaHoje, int idade, double minhasPercasNaInvalidez)
        {
            return aposentado
                ? rendaHoje * 0.40 * 120
                : (idade <= 50 ? minhasPercasNaInvalidez * 240 : minhasPercasNaInvalidez * 180);
        }

        private string CalcularNomeDoProduto(bool aposentado, int idade)
        {
            return aposentado
                ? "PENSÃO POR MORTE"
                : (idade <= 50 ? "TERM LIFE" : "SEGURO DE VIDA");
        }
    }
}
