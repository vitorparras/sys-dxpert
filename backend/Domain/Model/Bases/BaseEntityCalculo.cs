using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Model
{
    public class BaseEntityCalculo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DataCriacao { get; set; } = DateTime.Now;


        [ConcurrencyCheck]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DataAlteracao { get; set; }
    }
}
