using Domain.Model.Bases;

namespace Domain.Model
{
    public class Beneficiarios : BaseEntity
    {
        public string? Nome { get; set; }
        public string? DataNasc { get; set; }
        public int CadastroId { get; set; }
    }
}
