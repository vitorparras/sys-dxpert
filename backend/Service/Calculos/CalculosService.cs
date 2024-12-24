using Domain.Calculos;
using Domain.Model;

namespace Service.Calculos
{
    public class CalculosService : ICalculosService
    {
        /* public CalculosService(IGenericRepository<DitMedico> ditMedicosRepository,
             IGenericRepository<VidaInteira> vidaInteiraRepository,
             IGenericRepository<Cadastro> cadastroRepository,
             IGenericRepository<InvalidezAcidenteMajorada> invalidezAcidenteMajoradaRepository,
             IGenericRepository<InvalidezTotalAcidente> invalidezTotalAcidenteRepository,
             IGenericRepository<DoencasGraves> doencasGravesRepository,
             IGenericRepository<DoencasGravesMaster> doencasGravesMasterRepository,
             IGenericRepository<PensaoPorMorte> pensaoPorMorteRepository,
             IGenericRepository<TermLife> termLifeRepository)
         {
             _DitMedicosRepository = ditMedicosRepository;
             _VidaInteiraRepository = vidaInteiraRepository;
             _CadastroRepository = cadastroRepository;
             _InvalidezAcidenteMajoradaRepository = invalidezAcidenteMajoradaRepository;
             _InvalidezTotalAcidenteRepository = invalidezTotalAcidenteRepository;
             _DoencasGravesRepository = doencasGravesRepository;
             _DoencasGravesMasterRepository = doencasGravesMasterRepository;
             _PensaoPorMorteRepository = pensaoPorMorteRepository;
             _TermLifeRepository = termLifeRepository;
         }

         private readonly IGenericRepository<DitMedico> _DitMedicosRepository;
         private readonly IGenericRepository<VidaInteira> _VidaInteiraRepository;
         private readonly IGenericRepository<Cadastro> _CadastroRepository;
         private readonly IGenericRepository<InvalidezAcidenteMajorada> _InvalidezAcidenteMajoradaRepository;
         private readonly IGenericRepository<InvalidezTotalAcidente> _InvalidezTotalAcidenteRepository;
         private readonly IGenericRepository<DoencasGraves> _DoencasGravesRepository;
         private readonly IGenericRepository<DoencasGravesMaster> _DoencasGravesMasterRepository;
         private readonly IGenericRepository<PensaoPorMorte> _PensaoPorMorteRepository;
         private readonly IGenericRepository<TermLife> _TermLifeRepository;

         public async Task<double> RecuperarDidMedico(int idade, double rendaMensalContratar)
         {
             if (rendaMensalContratar == 0)
             {
                 return rendaMensalContratar;
             }
             var did = await _DitMedicosRepository.FirstOrDefaultAsync(x => x.Idade == idade);

             return rendaMensalContratar switch
             {
                 1 => did.V1,
                 2 => did.V2,
                 3 => did.V3,
                 4 => did.V4,
                 5 => did.V5,
                 6 => did.V6,
                 7 => did.V7,
                 8 => did.V8,
                 9 => did.V9,
                 10 => did.V10,
                 11 => did.V11,
                 12 => did.V12,
                 13 => did.V13,
                 14 => did.V14,
                 15 => did.V15,
                 16 => did.V16,
                 17 => did.V17,
                 18 => did.V18,
                 19 => did.V19,
                 20 => did.V20,
                 21 => did.V21,
                 22 => did.V22,
                 23 => did.V23,
                 24 => did.V24,
                 25 => did.V25,
                 26 => did.V26,
                 27 => did.V27,
                 28 => did.V28,
                 29 => did.V29,
                 30 => did.V30,
                 _ => 0,
             };
         }

         public async Task<double> CalcularSugestaoDeProdutos(Cadastro cadastro, string descricao, int idade, double NaPensaoPorMorte, double NaInvalidez, int IdadeMinimaAposentar, int TempoContribuicao)
         {

             double.TryParse(cadastro.RendaBruta, out var renda);
             if (descricao == "SEGURO DE VIDA")
             {
                 var registro = await _VidaInteiraRepository.FirstOrDefaultAsync(x => x.Idade == idade);

                 if (cadastro.Sexo == Sexo.Feminino)
                 {
                     return registro.Mulher;
                 }
                 else
                 {
                     double resultado;
                     if (idade <= 50)
                         resultado = NaPensaoPorMorte * 240;
                     else
                         resultado = NaPensaoPorMorte * 120;

                     return registro.Homem * resultado / 1000;
                 }
             }

             if (descricao == "INVALIDEZ MAJORADA")
             {
                 double resultado;
                 if (idade <= 50)
                     resultado = NaInvalidez * 240;
                 else
                     resultado = NaInvalidez * 180;

                 var registro = await _InvalidezAcidenteMajoradaRepository.FirstOrDefaultAsync(x => x.Idade == idade);
                 return registro.Valor * resultado / 1000;
             }

             if (descricao == "INVALIDEZ TOTAL ")
             {
                 double resultado;
                 if (cadastro.Ocupacao == "Aposentado(a)")
                     resultado = renda * 0.40 * 120;
                 else if (idade <= 50)
                     resultado = NaInvalidez * 240;
                 else
                     resultado = NaInvalidez * 180;

                 var registro = await _InvalidezTotalAcidenteRepository.FirstOrDefaultAsync(x => x.Idade == idade);

                 return registro.Valor * resultado / 1000;
             }

             if (descricao == "DOENÇAS GRAVES")
             {
                 var registro = await _DoencasGravesRepository.FirstOrDefaultAsync(x => x.Idade == idade);
                 double capital = idade <= 50 ? 200000 : 100000;
                 return registro.Plus * capital / 1000;
             }

             if (descricao == "DOENÇAS GRAVES MASTER")
             {
                 if (cadastro.Ocupacao != "Aposentado(a)")
                 {
                     return 0;
                 }

                 var registro = await _DoencasGravesMasterRepository.FirstOrDefaultAsync(x => x.Idade == idade);
                 double capital = IdadeMinimaAposentar <= 50 ? 200000 : 100000;
                 return registro.Valor * capital / 1000;
             }

             if (descricao == "PENSÃO POR MORTE")
             {
                 if (cadastro.Ocupacao == "Aposentado(a)")
                 {
                     var registro = await _PensaoPorMorteRepository.FirstOrDefaultAsync(x => x.Idade == idade);
                     return registro.I10 * renda * 0.20 / 1000;
                 }
             }

             if (descricao == "TERM LIFE")
             {
                 double valor = await CalcularTermLife(TempoContribuicao, idade, cadastro);

                 double resultado;
                 if (idade <= 50)
                     resultado = NaPensaoPorMorte * 240;
                 else
                     resultado = NaPensaoPorMorte * 120;

                 return valor * resultado / 1000;
             }

             return 0;

         }

         public async Task<List<Dictionary<string, string>>> RecuperarInformacoesProduto(List<Dictionary<string, string>> dados, List<Dictionary<string, string>> produtos, int termLife, int id)
         {
             var dadosCadastro = await _CadastroRepository.FirstOrDefaultAsync(x => x.Id == id);

             var ProdutosProntos = new List<Dictionary<string, string>>();

             Dictionary<string, Dictionary<string, string>> lista = new Dictionary<string, Dictionary<string, string>>()
             {
                 {"SEGURO DE VIDA", new Dictionary<string, string>() {{"codigo", "1546"}, {"Recuperacao", "Pensão por Morte"}}},
                 {"INVALIDEZ MAJORADA", new Dictionary<string, string>() {{"codigo", "2278"}, {"Recuperacao", "Invalidez"}}},
                 {"INVALIDEZ TOTAL", new Dictionary<string, string>() {{"codigo", "548"}, {"Recuperacao", "Invalidez"}}},
                 {"DOENÇAS GRAVES", new Dictionary<string, string>() {{"codigo", "2230"}, {"Recuperacao", "Invalidez"}}},
                 {"DOENÇAS GRAVES MASTER", new Dictionary<string, string>() {{"codigo", "2345"}, {"Recuperacao", "Invalidez"}}},
                 {"PENSÃO POR MORTE", new Dictionary<string, string>() {{"codigo", "2390"}, {"Recuperacao", "Pensão por Morte"}}},
                 {"TERM LIFE", new Dictionary<string, string>() {{"codigo", "2395"}, {"Recuperacao", "Pensão por Morte"}}}
             };

             if (dados == null || dados.Count == 0)
             {
                 dados = new List<Dictionary<string, string>>()
                 {
                     new Dictionary<string, string>() {{"Nome", "TERM LIFE"}, {"Capital", "0"}},
                     new Dictionary<string, string>() {{"Nome", "DOENÇAS GRAVES"}, {"Capital", "0"}},
                     new Dictionary<string, string>() {{"Nome", "INVALIDEZ MAJORADA"}, {"Capital", "0"}}
                 };
             }
             foreach (Dictionary<string, string> dado in dados)
             {
                 double v1 = Convert.ToDouble(produtos[0]["Valor1"]);
                 double v2 = Convert.ToDouble(produtos[1]["Valor1"]);

                 string valorFormatado = dado["Capital"].Trim().Replace(".", "").Replace(",", ".").Replace("R$", "").Replace(" ", "");

                 double Procentagem;
                 if (lista[dado["Nome"]]["Recuperacao"] == "Pensão por Morte")
                 {
                     Procentagem = Convert.ToDouble(valorFormatado) > 0 ? Convert.ToDouble(valorFormatado) / v1 : 0;
                 }
                 else
                 {
                     Procentagem = Convert.ToDouble(valorFormatado) > 0 ? Convert.ToDouble(valorFormatado) / v2 : 0;
                 }

                 Procentagem = Procentagem * 100;
                 Procentagem = Math.Round(Procentagem);

                 int idade = CalcularIdade(dadosCadastro.DataNascimento ?? DateTime.MinValue);
                 var perso = await CalcularPersonalizacao(dadosCadastro, dado["Nome"], idade, termLife);

                 var valorFormatadoInt = Convert.ToDouble(valorFormatado);
                 var investimento = perso * valorFormatadoInt / 1000;

                 ProdutosProntos.Add(new Dictionary<string, string>
                 {
                     {"Titulo", lista[dado["Nome"]]["Recuperacao"]},
                     {"Codigo", lista[dado["Nome"]]["codigo"]},
                     { "Capital", dado["Capital"]},
                     { "Nome", dado["Nome"]},
                     { "Investimento", investimento.ToString()},
                     { "Porcentagem", Procentagem.ToString()}
                 });
             }

             return ProdutosProntos;
         }

         public async Task<double> CalcularPersonalizacao(Cadastro cadastro, string produto, int idade, int termLife)
         {
             switch (produto)
             {
                 case "SEGURO DE VIDA":
                     var registro = await _VidaInteiraRepository.FirstOrDefaultAsync(x => x.Idade == idade);
                     return cadastro.Sexo == Sexo.Feminino ? registro.Mulher : registro.Homem;

                 case "INVALIDEZ MAJORADA":
                     var invalidezMajorada = await _InvalidezAcidenteMajoradaRepository.FirstOrDefaultAsync(x => x.Idade == idade);
                     return invalidezMajorada.Valor;

                 case "INVALIDEZ TOTAL":
                     var invalidezTotal = await _InvalidezTotalAcidenteRepository.FirstOrDefaultAsync(x => x.Idade == idade);
                     return invalidezTotal.Valor;

                 case "DOENÇAS GRAVES":
                     var doencasGraves = await _DoencasGravesRepository.FirstOrDefaultAsync(x => x.Idade == idade);
                     if (doencasGraves != null)
                     {
                         return doencasGraves.Plus;
                     }
                     return 0;

                 case "DOENÇAS GRAVES MASTER":
                     var doencasGravesMaster = await _DoencasGravesMasterRepository.FirstOrDefaultAsync(x => x.Idade == idade);
                     return doencasGravesMaster.Valor;

                 case "PENSÃO POR MORTE":
                     var pensaoPorMorte = await _PensaoPorMorteRepository.FirstOrDefaultAsync(x => x.Idade == idade);
                     return pensaoPorMorte.I10;

                 case "TERM LIFE":
                     return await CalcularTermLife(termLife, idade, cadastro);

                 default:
                     return 0;
             }
         }

         public async Task<double> CalcularTermLife(int tempoContribuicao, int idade, Cadastro cadastro)
         {
             if (tempoContribuicao == 0)
             {
                 return 0;
             }

             var lista = new Dictionary<int, int>
                 {
                     { 1, 10 },
                     { 2, 10 },
                     { 3, 10 },
                     { 4, 10 },
                     { 5, 10 },
                     { 6, 10 },
                     { 7, 10 },
                     { 8, 10 },
                     { 9, 10 },
                     { 10, 10 },
                     { 11, 15 },
                     { 12, 15 },
                     { 13, 15 },
                     { 14, 15 },
                     { 15, 15 },
                     { 16, 20 },
                     { 17, 20 },
                     { 18, 20 },
                     { 19, 20 },
                     { 20, 20 },
                     { 21, 25 },
                     { 22, 25 },
                     { 23, 25 },
                     { 24, 25 },
                     { 25, 25 },
                     { 26, 30 },
                     { 27, 30 },
                     { 28, 30 },
                     { 29, 30 },
                     { 30, 30 },
                     { 31, 30 },
                     { 32, 30 },
                     { 33, 30 },
                     { 34, 30 },
                     { 35, 30 },
                     { 36, 30 },
                     { 37, 30 },
                     { 38, 30 },
                     { 39, 30 },
                     { 40, 30 },
                 };

             int tempoSugerido = lista[tempoContribuicao];

             var termLife = await _TermLifeRepository.FirstOrDefaultAsync(x => x.Idade == idade);
             if (termLife == null)
             {
                 return 0;
             }

             if (cadastro.Sexo == Sexo.Masculino)
             {
                 return tempoSugerido switch
                 {
                     10 => termLife.Masculino10,
                     15 => termLife.Masculino15,
                     20 => termLife.Masculino20,
                     25 => termLife.Masculino25,
                     30 => termLife.Masculino30,
                     _ => 0,
                 };
             }
             else
             {
                 return tempoSugerido switch
                 {
                     10 => termLife.Feminino10,
                     15 => termLife.Feminino15,
                     20 => termLife.Feminino20,
                     25 => termLife.Feminino25,
                     30 => termLife.Feminino30,
                     _ => 0,
                 };
             }
         }

         public int CalcularDoencasGraves(int idade, int idadeMinimaAposentar)
         {
             if (idade > 65)
             {
                 return idadeMinimaAposentar <= 50 ? 200000 : 100000;
             }
             else
             {
                 return idade <= 50 ? 200000 : 100000;
             }
         }

         public string CalcularReceberPor(DateTime dataNascConjuge)
         {
             int idadeConjuge = CalcularIdade(dataNascConjuge);

             if (idadeConjuge < 19)
             {
                 return "Data de nascimento do cônjuge inválida. Menor que 19 anos.";
             }

             if (idadeConjuge >= 45)
             {
                 return "Benefício vitalício.";
             }

             int[] duracaoBeneficioPorIdade = { 3, 3, 6, 6, 6, 6, 6, 10, 10, 10, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 20, 20, 20 };
             int indiceArrayDuracaoBeneficio = idadeConjuge - 19;
             int duracaoBeneficio = duracaoBeneficioPorIdade[indiceArrayDuracaoBeneficio];

             return $"{duracaoBeneficio} anos";
         }

         public double CalcularPensaoPorMorte(Cadastro cadastro, double RendaHoje, double BeneficioInvalidez)
         {
             if (cadastro.Ocupacao == "Aposentado(a)")
             {
                 return RendaHoje * 0.6;
             }
             else
             {
                 int filhosMenores = cadastro.QuantidadeFilhosMaiores;

                 if (cadastro.EstadoCivil == "Solteiro" && filhosMenores == 0)
                 {
                     return 0;
                 }
                 else
                 {
                     double percentualDependentes;
                     if (filhosMenores != 0)
                     {
                         if (cadastro.EstadoCivil == "Casado")
                         {
                             percentualDependentes = (1.0 + filhosMenores) / 10.0 + 0.5;
                         }
                         else
                         {
                             percentualDependentes = filhosMenores / 10.0 + 0.5;
                         }
                     }
                     else
                     {
                         percentualDependentes = 0;
                     }
                     return BeneficioInvalidez * percentualDependentes;
                 }
             }
         }

         public double CalcularBeneficioInvalidez(Cadastro cadastro, double RendaHoje)
         {
             double regime = CalcularRegimeContratacao(cadastro, RendaHoje);

             int tempoContribuicao = CalcularTempoContribuicao(cadastro);
             double tempoContribuicaoPercentual = (tempoContribuicao + 60) / 100.0;

             return regime * tempoContribuicaoPercentual;
         }

         public int CalcularTempoContribuicao(Cadastro cadastro)
         {
             if (cadastro.Sexo == Sexo.Masculino)
             {
                 if (cadastro.AnosContribuicao <= 20)
                 {
                     return 0;
                 }
                 else
                 {
                     return (cadastro.AnosContribuicao - 20) * 2;
                 }
             }
             else
             {
                 if (cadastro.AnosContribuicao <= 20)
                 {
                     return 0;
                 }
                 else
                 {
                     return (cadastro.AnosContribuicao - 15) * 2;
                 }
             }
         }



         public int CalcularIdade(DateTime dataDeNascimento)
         {
             DateTime hoje = DateTime.Today;
             int idade = hoje.Year - dataDeNascimento.Year;
             if (dataDeNascimento > hoje.AddYears(-idade))
             {
                 idade--;
             }
             return idade;
         }

         public (int idade, double valor)? CalcularProximaIdade(int idade, double beneficioPorMorte, double beneficioPorInvalidez)
         {
             /*  -De 18 até 35
             -36 anos muda
             -41 anos muda
             -46 anos muda
             -51 anos muda
             -56 anos muda
             -61 anos muda
             -66 anos muda
             A partir daí mudará de ano em ano (66, 67, 68, 69, 70.....100
              */
        /*
             int[] limiaresDeIdade = { 18, 36, 41, 46, 51, 56, 61, 66 };
             int ultimoIndiceLimiar = limiaresDeIdade.Length - 1;

             for (int i = 0; i < ultimoIndiceLimiar; i++)
             {
                 int limiarAtual = limiaresDeIdade[i];
                 int proximoLimiar = limiaresDeIdade[i + 1];

                 if (idade >= limiarAtual && idade < proximoLimiar)
                 {
                     idade = proximoLimiar;
                     break;
                 }
             }

             if (idade >= limiaresDeIdade[ultimoIndiceLimiar])
             {
                 idade++;
             }

             return (idade, RecuperarSeguro(idade, beneficioPorMorte, beneficioPorInvalidez));
         }

         public TaxasPrevcomDTO RecuperarTaxasPrevcom(int idade)
         {
             var lista = new List<TaxasPrevcomDTO>()
             {
                 { new TaxasPrevcomDTO(14 ,0.0000560, 0.0000691) },
                 { new TaxasPrevcomDTO(15 ,0.0000560, 0.0000691) },
                 { new TaxasPrevcomDTO(16 ,0.0000560, 0.0000691) },
                 { new TaxasPrevcomDTO(17 ,0.0000560, 0.0000691) },
                 { new TaxasPrevcomDTO(18 ,0.0000560, 0.0000691) },
                 { new TaxasPrevcomDTO(19 ,0.0000560, 0.0000691) },
                 { new TaxasPrevcomDTO(20 ,0.0000560, 0.0000691) },
                 { new TaxasPrevcomDTO(21 ,0.0000560, 0.0000691) },
                 { new TaxasPrevcomDTO(22 ,0.0000560, 0.0000691) },
                 { new TaxasPrevcomDTO(23 ,0.0000560, 0.0000691) },
                 { new TaxasPrevcomDTO(24 ,0.0000560, 0.0000691) },
                 { new TaxasPrevcomDTO(25 ,0.0000560, 0.0000691) },
                 { new TaxasPrevcomDTO(26 ,0.0000560, 0.0000691) },
                 { new TaxasPrevcomDTO(27 ,0.0000560, 0.0000691) },
                 { new TaxasPrevcomDTO(28 ,0.0000560, 0.0000691) },
                 { new TaxasPrevcomDTO(29 ,0.0000560, 0.0000691) },
                 { new TaxasPrevcomDTO(30 ,0.0000560, 0.0000691) },
                 { new TaxasPrevcomDTO(31 ,0.0000560, 0.0000691) },
                 { new TaxasPrevcomDTO(32 ,0.0000560, 0.0000691) },
                 { new TaxasPrevcomDTO(33 ,0.0000560, 0.0000691) },
                 { new TaxasPrevcomDTO(34 ,0.0000560, 0.0000691) },
                 { new TaxasPrevcomDTO(35 ,0.0000560, 0.0000691) },
                 { new TaxasPrevcomDTO(36 ,0.0000921, 0.0000905) },
                 { new TaxasPrevcomDTO(37 ,0.0000921, 0.0000905) },
                 { new TaxasPrevcomDTO(38 ,0.0000921, 0.0000905) },
                 { new TaxasPrevcomDTO(39 ,0.0000921, 0.0000905) },
                 { new TaxasPrevcomDTO(40 ,0.0000921, 0.0000905) },
                 { new TaxasPrevcomDTO(41 ,0.0001559, 0.0001201) },
                 { new TaxasPrevcomDTO(42 ,0.0001559, 0.0001201) },
                 { new TaxasPrevcomDTO(43 ,0.0001559, 0.0001201) },
                 { new TaxasPrevcomDTO(44 ,0.0001559, 0.0001201) },
                 { new TaxasPrevcomDTO(45 ,0.0001559, 0.0001201) },
                 { new TaxasPrevcomDTO(46 ,0.0002764, 0.0001790) },
                 { new TaxasPrevcomDTO(47 ,0.0002764, 0.0001790) },
                 { new TaxasPrevcomDTO(48 ,0.0002764, 0.0001790) },
                 { new TaxasPrevcomDTO(49 ,0.0002764, 0.0001790) },
                 { new TaxasPrevcomDTO(50 ,0.0002764, 0.0001790) },
                 { new TaxasPrevcomDTO(51 ,0.0004297, 0.0002936) },
                 { new TaxasPrevcomDTO(52 ,0.0004297, 0.0002936) },
                 { new TaxasPrevcomDTO(53 ,0.0004297, 0.0002936) },
                 { new TaxasPrevcomDTO(54 ,0.0004297, 0.0002936) },
                 { new TaxasPrevcomDTO(55 ,0.0004297, 0.0002936) },
                 { new TaxasPrevcomDTO(56 ,0.0006027, 0.0005153) },
                 { new TaxasPrevcomDTO(57 ,0.0006027, 0.0005153) },
                 { new TaxasPrevcomDTO(58 ,0.0006027, 0.0005153) },
                 { new TaxasPrevcomDTO(59 ,0.0006027, 0.0005153) },
                 { new TaxasPrevcomDTO(60 ,0.0006027, 0.0005153) },
                 { new TaxasPrevcomDTO(61 ,0.0008788, 0.0009413) },
                 { new TaxasPrevcomDTO(62 ,0.0008788, 0.0009413) },
                 { new TaxasPrevcomDTO(63 ,0.0008788, 0.0009413) },
                 { new TaxasPrevcomDTO(64 ,0.0008788, 0.0009413) },
                 { new TaxasPrevcomDTO(65 ,0.0008788, 0.0009413) },
                 { new TaxasPrevcomDTO(66 ,0.0011739, 0.0013672) },
                 { new TaxasPrevcomDTO(67 ,0.0012994, 0.0015502) },
                 { new TaxasPrevcomDTO(68 ,0.0014397, 0.0017587) },
                 { new TaxasPrevcomDTO(69 ,0.0015953, 0.0019962) },
                 { new TaxasPrevcomDTO(70 ,0.0017668, 0.0022666) },
                 { new TaxasPrevcomDTO(71 ,0.0019550, 0.0025744) },
                 { new TaxasPrevcomDTO(72 ,0.0021602, 0.0029250) },
                 { new TaxasPrevcomDTO(73 ,0.0023838, 0.0033243) },
                 { new TaxasPrevcomDTO(74 ,0.0026284, 0.0037787) },
                 { new TaxasPrevcomDTO(75 ,0.0028973, 0.0042964) },
                 { new TaxasPrevcomDTO(76 ,0.0031937, 0.0048859) },
                 { new TaxasPrevcomDTO(77 ,0.0035207, 0.0055572) },
                 { new TaxasPrevcomDTO(78 ,0.0038816, 0.0065580) },
                 { new TaxasPrevcomDTO(79 ,0.0042787, 0.0071915) },
                 { new TaxasPrevcomDTO(80 ,0.0047142, 0.0081825) },
                 { new TaxasPrevcomDTO(81 ,0.0051908, 0.0093109) },
                 { new TaxasPrevcomDTO(82 ,0.0057110, 0.0105958) },
                 { new TaxasPrevcomDTO(83 ,0.0062752, 0.0120580) },
                 { new TaxasPrevcomDTO(84 ,0.0068808, 0.0137232) },
                 { new TaxasPrevcomDTO(85 ,0.0075220, 0.0156116) },
                 { new TaxasPrevcomDTO(86 ,0.0081945, 0.0177769) },
                 { new TaxasPrevcomDTO(87 ,0.0088935, 0.0202354) },
                 { new TaxasPrevcomDTO(88 ,0.0096157, 0.0230340) },
                 { new TaxasPrevcomDTO(89 ,0.0103657, 0.0262196) },
                 { new TaxasPrevcomDTO(90 ,0.0111504, 0.0298458) },
                 { new TaxasPrevcomDTO(91 ,0.0119755, 0.1184399) },
                 { new TaxasPrevcomDTO(92 ,0.0128485, 0.1184399) },
                 { new TaxasPrevcomDTO(93 ,0.0137749, 0.1184399) },
                 { new TaxasPrevcomDTO(94 ,0.0147598, 0.1184399) },
                 { new TaxasPrevcomDTO(95 ,0.0158077, 0.1184399) },
                 { new TaxasPrevcomDTO(96 ,0.0169238, 0.1184399) },
                 { new TaxasPrevcomDTO(97 ,0.0181135, 0.1184399) },
                 { new TaxasPrevcomDTO(98 ,0.0194050, 0.1184399) },
                 { new TaxasPrevcomDTO(99 ,0.0208235, 0.1184399) },
                 { new TaxasPrevcomDTO(100, 0.0223957, 0.1184399) },
                 { new TaxasPrevcomDTO(101, 0.0241492, 0.1184399) },
                 { new TaxasPrevcomDTO(102, 0.0261102, 0.1184399) },
                 { new TaxasPrevcomDTO(103, 0.0283060, 0.1184399) },
                 { new TaxasPrevcomDTO(104, 0.0307630, 0.1184399) },
                 { new TaxasPrevcomDTO(105, 0.0335071, 0.1184399) },
                 { new TaxasPrevcomDTO(106, 0.0365662, 0.1184399) },
                 { new TaxasPrevcomDTO(107, 0.0399669, 0.1184399) },
                 { new TaxasPrevcomDTO(108, 0.0437358, 0.1184399) },
                 { new TaxasPrevcomDTO(109, 0.0478994, 0.1184399) },
                 { new TaxasPrevcomDTO(110, 0.0524834, 0.1184399) },
                 { new TaxasPrevcomDTO(111, 0.0575166, 0.1184399) },
                 { new TaxasPrevcomDTO(112, 0.0630267, 0.1184399) },
                 { new TaxasPrevcomDTO(113, 0.0690394, 0.1184399) },
                 { new TaxasPrevcomDTO(114, 0.0755774, 0.1184399) } };

             return lista.FirstOrDefault(x => x.Idade == idade);
         }

         public double CalcularInvalidezMorte(int idade, double valor, string tipo)
         {
             var taxa = RecuperarTaxasPrevcom(idade);
             if (tipo == "Invalidez")
             {
                 return taxa.Invalidez * valor;
             }
             if (tipo == "Morte")
             {
                 return taxa.Morte * valor;
             }
             return 0;
         }

         public double RecuperarSeguro(int idade, double valorMorte, double valorInvalidez)
         {
             var v1 = CalcularInvalidezMorte(idade, valorInvalidez, "Invalidez");
             var v2 = CalcularInvalidezMorte(idade, valorMorte, "Morte");
             return v1 + v2;
         }

         // metodos prontos

         public double CalcularRegimeContratacao(Cadastro cadastro, double RendaHoje)
         {
             if (cadastro.RegimeContratacao == "Integralidade")
             {
                 return RendaHoje;
             }

             if (cadastro.RegimeContratacao == "Limitado ao teto do INSS")
             {
                 double baseTetoINSS = 6433.57;
                 double total = RendaHoje * 0.70 > baseTetoINSS ?
                     baseTetoINSS * 0.80 :
                     RendaHoje * 0.70;
                 return total;
             }

             if (cadastro.RegimeContratacao == "Proporcionalidade")
             {
                 double total = RendaHoje * 0.80;
                 return total;
             }

             return 0;
         }


         */
        public double CalcularBeneficioInvalidez(Cadastro cadastro, double RendaHoje)
        {
            throw new NotImplementedException();
        }

        public int CalcularDoencasGraves(int idade, int idadeMinimaAposentar)
        {
            throw new NotImplementedException();
        }

        public int CalcularIdade(DateTime dataDeNascimento)
        {
            throw new NotImplementedException();
        }

        public double CalcularInvalidezMorte(int idade, double valor, string tipo)
        {
            throw new NotImplementedException();
        }

        public double CalcularPensaoPorMorte(Cadastro cadastro, double RendaHoje, double BeneficioInvalidez)
        {
            throw new NotImplementedException();
        }

        public Task<double> CalcularPersonalizacao(Cadastro cadastro, string produto, int idade, int termLife)
        {
            throw new NotImplementedException();
        }

        public (int idade, double valor)? CalcularProximaIdade(int idade, double beneficioPorMorte, double beneficioPorInvalidez)
        {
            throw new NotImplementedException();
        }

        public string CalcularReceberPor(DateTime dataNascConjuge)
        {
            throw new NotImplementedException();
        }

        public double CalcularRegimeContratacao(Cadastro cadastro, double RendaHoje)
        {
            throw new NotImplementedException();
        }

        public Task<double> CalcularSugestaoDeProdutos(Cadastro cadastro, string descricao, int idade, double NaPensaoPorMorte, double NaInvalidez, int IdadeMinimaAposentar, int TempoContribuicao)
        {
            throw new NotImplementedException();
        }

        public int CalcularTempoContribuicao(Cadastro cadastro)
        {
            throw new NotImplementedException();
        }

        public Task<double> CalcularTermLife(int tempoContribuicao, int idade, Cadastro cadastro)
        {
            throw new NotImplementedException();
        }

        public Task<double> RecuperarDidMedico(int idade, double rendaMensalContratar)
        {
            throw new NotImplementedException();
        }

        public Task<List<Dictionary<string, string>>> RecuperarInformacoesProduto(List<Dictionary<string, string>> dados, List<Dictionary<string, string>> produtos, int termLife, int id)
        {
            throw new NotImplementedException();
        }

        public double RecuperarSeguro(int idade, double valorMorte, double valorInvalidez)
        {
            throw new NotImplementedException();
        }

        public TaxasPrevcomDTO RecuperarTaxasPrevcom(int idade)
        {
            throw new NotImplementedException();
        }
    }
}
