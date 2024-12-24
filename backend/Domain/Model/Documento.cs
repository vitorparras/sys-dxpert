using Domain.Model.Bases;

namespace Domain.Model
{
    public class Documento : BaseEntity
    {
        public string? Tipo { get; set; }
        public string? Numero { get; set; }
        public string? OrgaoExpedidor { get; set; }
        public DateTime? DataExpedicao { get; set; }
        public int CadastroId { get; set; }
    }
}
