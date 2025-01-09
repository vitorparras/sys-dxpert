using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Configurations")]
    public class Configuration
    {
        [Key]
        public Guid Id { get; private set; }

        [Required(ErrorMessage = "Key is required.")]
        [MaxLength(100, ErrorMessage = "Key must be at most 100 characters.")]
        public string Key { get; private set; }

        [Required(ErrorMessage = "Value is required.")]
        [MaxLength(500, ErrorMessage = "Value must be at most 500 characters.")]
        public string Value { get; private set; }

        [Required]
        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        private Configuration() { }

        public Configuration(string key, string value)
        {
            Id = Guid.NewGuid();
            Key = key;
            Value = value;
            CreatedAt = DateTime.UtcNow;
        }

        public void Update(string key, string value)
        {
            Key = key;
            Value = value;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
