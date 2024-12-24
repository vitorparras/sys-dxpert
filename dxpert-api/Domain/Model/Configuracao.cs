using Domain.Model.Bases;

namespace Domain.Model
{
    public class Configuracao : BaseEntity
    {
        public string? Nome { get; set; }
        public string? Tipo { get; set; }
        public string? Valor { get; set; }
    }
}
