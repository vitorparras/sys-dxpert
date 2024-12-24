using Domain.Model.Bases;

namespace Domain.Model
{
    public class AuthToken : BaseEntity
    {
        public string? Token { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
