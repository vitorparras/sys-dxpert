using Domain.Model.Bases;
using Microsoft.EntityFrameworkCore;

namespace Domain.Model.Calculos
{
    public class MortePorAcidente : BaseEntity
    {
        public int Idade { get; set; }
        public double Valor { get; set; }

        public static List<MortePorAcidente> GetDados()
        {
            return new List<MortePorAcidente>() {
                new MortePorAcidente { Idade = 16, Valor = 0.18 },
                new MortePorAcidente { Idade = 17, Valor = 0.18 },
                new MortePorAcidente { Idade = 18, Valor = 0.18 },
                new MortePorAcidente { Idade = 19, Valor = 0.18 },
                new MortePorAcidente { Idade = 20, Valor = 0.18 },
                new MortePorAcidente { Idade = 21, Valor = 0.18 },
                new MortePorAcidente { Idade = 22, Valor = 0.18 },
                new MortePorAcidente { Idade = 23, Valor = 0.18 },
                new MortePorAcidente { Idade = 24, Valor = 0.18 },
                new MortePorAcidente { Idade = 25, Valor = 0.18 },
                new MortePorAcidente { Idade = 26, Valor = 0.15 },
                new MortePorAcidente { Idade = 27, Valor = 0.15 },
                new MortePorAcidente { Idade = 28, Valor = 0.15 },
                new MortePorAcidente { Idade = 29, Valor = 0.15 },
                new MortePorAcidente { Idade = 30, Valor = 0.15 },
                new MortePorAcidente { Idade = 31, Valor = 0.15 },
                new MortePorAcidente { Idade = 32, Valor = 0.15 },
                new MortePorAcidente { Idade = 33, Valor = 0.15 },
                new MortePorAcidente { Idade = 34, Valor = 0.15 },
                new MortePorAcidente { Idade = 35, Valor = 0.15 },
                new MortePorAcidente { Idade = 36, Valor = 0.15 },
                new MortePorAcidente { Idade = 37, Valor = 0.15 },
                new MortePorAcidente { Idade = 38, Valor = 0.15 },
                new MortePorAcidente { Idade = 39, Valor = 0.15 },
                new MortePorAcidente { Idade = 40, Valor = 0.15 },
                new MortePorAcidente { Idade = 41, Valor = 0.13 },
                new MortePorAcidente { Idade = 42, Valor = 0.13 },
                new MortePorAcidente { Idade = 43, Valor = 0.13 },
                new MortePorAcidente { Idade = 44, Valor = 0.13 },
                new MortePorAcidente { Idade = 45, Valor = 0.13 },
                new MortePorAcidente { Idade = 46, Valor = 0.13 },
                new MortePorAcidente { Idade = 47, Valor = 0.13 },
                new MortePorAcidente { Idade = 48, Valor = 0.13 },
                new MortePorAcidente { Idade = 49, Valor = 0.13 },
                new MortePorAcidente { Idade = 50, Valor = 0.13 },
                new MortePorAcidente { Idade = 51, Valor = 0.13 },
                new MortePorAcidente { Idade = 52, Valor = 0.13 },
                new MortePorAcidente { Idade = 53, Valor = 0.13 },
                new MortePorAcidente { Idade = 54, Valor = 0.13 },
                new MortePorAcidente { Idade = 55, Valor = 0.13 },
                new MortePorAcidente { Idade = 56, Valor = 0.13 },
                new MortePorAcidente { Idade = 57, Valor = 0.13 },
                new MortePorAcidente { Idade = 58, Valor = 0.13 },
                new MortePorAcidente { Idade = 59, Valor = 0.13 },
                new MortePorAcidente { Idade = 60, Valor = 0.13 },
                new MortePorAcidente { Idade = 61, Valor = 0.13 },
                new MortePorAcidente { Idade = 62, Valor = 0.13 },
                new MortePorAcidente { Idade = 63, Valor = 0.13 },
                new MortePorAcidente { Idade = 64, Valor = 0.13 },
                new MortePorAcidente { Idade = 65, Valor = 0.13 },
                new MortePorAcidente { Idade = 66, Valor = 0.13 },
                new MortePorAcidente { Idade = 67, Valor = 0.13 },
                new MortePorAcidente { Idade = 68, Valor = 0.13 },
                new MortePorAcidente { Idade = 69, Valor = 0.13 },
                new MortePorAcidente { Idade = 70, Valor = 0.13 },
                new MortePorAcidente { Idade = 71, Valor = 0.13 },
                new MortePorAcidente { Idade = 72, Valor = 0.13 },
                new MortePorAcidente { Idade = 73, Valor = 0.13 },
                new MortePorAcidente { Idade = 74, Valor = 0.13 },
                new MortePorAcidente { Idade = 75, Valor = 0.13 },
                new MortePorAcidente { Idade = 76, Valor = 0.13 },
                new MortePorAcidente { Idade = 77, Valor = 0.13 },
                new MortePorAcidente { Idade = 78, Valor = 0.13 },
                new MortePorAcidente { Idade = 79, Valor = 0.13 },
                new MortePorAcidente { Idade = 80, Valor = 0.13 }
            };
        }
    }
}
