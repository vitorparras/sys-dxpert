using Domain.Model.Bases;
using Microsoft.EntityFrameworkCore;

namespace Domain.Model.Calculos
{
    public class InvalidezTotalAcidente : BaseEntity
    {
        public int Idade { get; set; }
        public double Valor { get; set; }

        public static List<InvalidezTotalAcidente> GetDados()
        {
            return new List<InvalidezTotalAcidente>() {
                new InvalidezTotalAcidente { Idade = 61, Valor = 0.07 },
                new InvalidezTotalAcidente { Idade = 62, Valor = 0.07 },
                new InvalidezTotalAcidente { Idade = 63, Valor = 0.07 },
                new InvalidezTotalAcidente { Idade = 64, Valor = 0.07 },
                new InvalidezTotalAcidente { Idade = 65, Valor = 0.07 },
                new InvalidezTotalAcidente { Idade = 66, Valor = 0.07 },
                new InvalidezTotalAcidente { Idade = 67, Valor = 0.07 },
                new InvalidezTotalAcidente { Idade = 68, Valor = 0.07 },
                new InvalidezTotalAcidente { Idade = 69, Valor = 0.07 },
                new InvalidezTotalAcidente { Idade = 70, Valor = 0.07 },
                new InvalidezTotalAcidente { Idade = 71, Valor = 0.07 },
                new InvalidezTotalAcidente { Idade = 72, Valor = 0.07 },
                new InvalidezTotalAcidente { Idade = 73, Valor = 0.07 },
                new InvalidezTotalAcidente { Idade = 74, Valor = 0.07 },
                new InvalidezTotalAcidente { Idade = 75, Valor = 0.07 },
                new InvalidezTotalAcidente { Idade = 76, Valor = 0.07 },
                new InvalidezTotalAcidente { Idade = 77, Valor = 0.07 },
                new InvalidezTotalAcidente { Idade = 78, Valor = 0.07 },
                new InvalidezTotalAcidente { Idade = 79, Valor = 0.07 },
                new InvalidezTotalAcidente { Idade = 80, Valor = 0.07 }
            };
        }
    }
}
