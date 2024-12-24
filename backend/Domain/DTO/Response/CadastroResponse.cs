using Domain.Model;

namespace Domain.DTO.Response
{
    public class CadastroResponse
    {
        public Cadastro? Cadastro { get; set; }
    }

    public class CadastroListResponse
    {
        public IEnumerable<Cadastro> Cadastros { get; set; }
    }
}
