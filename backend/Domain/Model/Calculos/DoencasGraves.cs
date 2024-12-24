using Domain.Model.Bases;
using Microsoft.EntityFrameworkCore;

namespace Domain.Model.Calculos
{
    public class DoencasGraves : BaseEntity
    {
        public int Idade { get; set; }
        public double Essencial { get; set; }
        public double Plus { get; set; }
        public double Premium { get; set; }

        public static List<DoencasGraves> GetDados()
        {
            return new List<DoencasGraves>() {
                new DoencasGraves { Idade = 16, Essencial = 0.16, Plus = 0.22, Premium = 0.45 },
                new DoencasGraves { Idade = 17, Essencial = 0.16, Plus = 0.22, Premium = 0.45 },
                new DoencasGraves { Idade = 18, Essencial = 0.16, Plus = 0.22, Premium = 0.45 },
                new DoencasGraves { Idade = 19, Essencial = 0.16, Plus = 0.22, Premium = 0.45 },
                new DoencasGraves { Idade = 20, Essencial = 0.16, Plus = 0.22, Premium = 0.45 },
                new DoencasGraves { Idade = 21, Essencial = 0.16, Plus = 0.22, Premium = 0.45 },
                new DoencasGraves { Idade = 22, Essencial = 0.16, Plus = 0.22, Premium = 0.45 },
                new DoencasGraves { Idade = 23, Essencial = 0.16, Plus = 0.22, Premium = 0.45 },
                new DoencasGraves { Idade = 24, Essencial = 0.16, Plus = 0.22, Premium = 0.45 },
                new DoencasGraves { Idade = 25, Essencial = 0.16, Plus = 0.22, Premium = 0.45 },
                new DoencasGraves { Idade = 26, Essencial = 0.17, Plus = 0.24, Premium = 0.5 },
                new DoencasGraves { Idade = 27, Essencial = 0.17, Plus = 0.24, Premium = 0.5 },
                new DoencasGraves { Idade = 28, Essencial = 0.17, Plus = 0.24, Premium = 0.5 },
                new DoencasGraves { Idade = 29, Essencial = 0.17, Plus = 0.24, Premium = 0.5 },
                new DoencasGraves { Idade = 30, Essencial = 0.17, Plus = 0.24, Premium = 0.5 },
                new DoencasGraves { Idade = 31, Essencial = 0.24, Plus = 0.33, Premium = 0.59 },
                new DoencasGraves { Idade = 32, Essencial = 0.24, Plus = 0.33, Premium = 0.59 },
                new DoencasGraves { Idade = 33, Essencial = 0.24, Plus = 0.33, Premium = 0.59 },
                new DoencasGraves { Idade = 34, Essencial = 0.24, Plus = 0.33, Premium = 0.59 },
                new DoencasGraves { Idade = 35, Essencial = 0.24, Plus = 0.33, Premium = 0.59 },
                new DoencasGraves { Idade = 36, Essencial = 0.3, Plus = 0.43, Premium = 0.68 },
                new DoencasGraves { Idade = 37, Essencial = 0.3, Plus = 0.43, Premium = 0.68 },
                new DoencasGraves { Idade = 38, Essencial = 0.3, Plus = 0.43, Premium = 0.68 },
                new DoencasGraves { Idade = 39, Essencial = 0.3, Plus = 0.43, Premium = 0.68 },
                new DoencasGraves { Idade = 40, Essencial = 0.3, Plus = 0.43, Premium = 0.68 },
                new DoencasGraves { Idade = 41, Essencial = 0.48, Plus = 0.7, Premium = 0.98 },
                new DoencasGraves { Idade = 42, Essencial = 0.48, Plus = 0.7, Premium = 0.98 },
                new DoencasGraves { Idade = 43, Essencial = 0.48, Plus = 0.7, Premium = 0.98 },
                new DoencasGraves { Idade = 44, Essencial = 0.48, Plus = 0.7, Premium = 0.98 },
                new DoencasGraves { Idade = 45, Essencial = 0.48, Plus = 0.7, Premium = 0.98 },
                new DoencasGraves { Idade = 46, Essencial = 0.66, Plus = 0.98, Premium = 1.27 },
                new DoencasGraves { Idade = 47, Essencial = 0.66, Plus = 0.98, Premium = 1.27 },
                new DoencasGraves { Idade = 48, Essencial = 0.66, Plus = 0.98, Premium = 1.27 },
                new DoencasGraves { Idade = 49, Essencial = 0.66, Plus = 0.98, Premium = 1.27 },
                new DoencasGraves { Idade = 50, Essencial = 0.66, Plus = 0.98, Premium = 1.27 },
                new DoencasGraves { Idade = 51, Essencial = 0.96, Plus = 1.52, Premium = 1.86 },
                new DoencasGraves { Idade = 52, Essencial = 0.96, Plus = 1.52, Premium = 1.86 },
                new DoencasGraves { Idade = 53, Essencial = 0.96, Plus = 1.52, Premium = 1.86 },
                new DoencasGraves { Idade = 54, Essencial = 0.96, Plus = 1.52, Premium = 1.86 },
                new DoencasGraves { Idade = 55, Essencial = 0.96, Plus = 1.52, Premium = 1.86 },
                new DoencasGraves { Idade = 56, Essencial = 1.38, Plus = 2.24, Premium = 2.62 },
                new DoencasGraves { Idade = 57, Essencial = 1.38, Plus = 2.24, Premium = 2.62 },
                new DoencasGraves { Idade = 58, Essencial = 1.38, Plus = 2.24, Premium = 2.62 },
                new DoencasGraves { Idade = 59, Essencial = 1.38, Plus = 2.24, Premium = 2.62 },
                new DoencasGraves { Idade = 60, Essencial = 1.38, Plus = 2.24, Premium = 2.62 },
                new DoencasGraves { Idade = 61, Essencial = 1.81, Plus = 3.06, Premium = 3.51 },
                new DoencasGraves { Idade = 62, Essencial = 1.81, Plus = 3.06, Premium = 3.51 },
                new DoencasGraves { Idade = 63, Essencial = 1.81, Plus = 3.06, Premium = 3.51 },
                new DoencasGraves { Idade = 64, Essencial = 1.81, Plus = 3.06, Premium = 3.51 },
                new DoencasGraves { Idade = 65, Essencial = 1.81, Plus = 3.06, Premium = 3.51 }
            };
        }
    }
}
