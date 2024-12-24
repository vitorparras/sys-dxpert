using Domain.Model.Bases;

namespace Domain.Model
{
    public class Endereco : BaseEntity
    {
        public string? Cep { get; set; }
        public string? Cidade { get; set; }
        public string? Logadouro { get; set; }
        public string? Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Complemento { get; set; }
        public int CadastroId { get; set; }
    }
}
