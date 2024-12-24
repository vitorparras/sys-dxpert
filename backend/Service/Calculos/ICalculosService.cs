using Domain.Calculos;
using Domain.Model;

namespace Service.Calculos
{
    public interface ICalculosService
    {
        Task<double> RecuperarDidMedico(int idade, double rendaMensalContratar);

        Task<double> CalcularSugestaoDeProdutos(Cadastro cadastro, string descricao, int idade, double NaPensaoPorMorte, double NaInvalidez, int IdadeMinimaAposentar, int TempoContribuicao);

        Task<List<Dictionary<string, string>>> RecuperarInformacoesProduto(List<Dictionary<string, string>> dados, List<Dictionary<string, string>> produtos, int termLife, int id);

        Task<double> CalcularPersonalizacao(Cadastro cadastro, string produto, int idade, int termLife);

        Task<double> CalcularTermLife(int tempoContribuicao, int idade, Cadastro cadastro);

        int CalcularDoencasGraves(int idade, int idadeMinimaAposentar);

        string CalcularReceberPor(DateTime dataNascConjuge);

        double CalcularPensaoPorMorte(Cadastro cadastro, double RendaHoje, double BeneficioInvalidez);

        double CalcularBeneficioInvalidez(Cadastro cadastro, double RendaHoje);

        int CalcularTempoContribuicao(Cadastro cadastro);

        int CalcularIdade(DateTime dataDeNascimento);

        (int idade, double valor)? CalcularProximaIdade(int idade, double beneficioPorMorte, double beneficioPorInvalidez);

        TaxasPrevcomDTO RecuperarTaxasPrevcom(int idade);

        double CalcularInvalidezMorte(int idade, double valor, string tipo);

        double RecuperarSeguro(int idade, double valorMorte, double valorInvalidez);

        double CalcularRegimeContratacao(Cadastro cadastro, double RendaHoje);
    }
}
