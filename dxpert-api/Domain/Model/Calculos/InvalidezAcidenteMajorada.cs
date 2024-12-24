using Domain.Model.Bases;
using Microsoft.EntityFrameworkCore;

namespace Domain.Model.Calculos
{
    public class InvalidezAcidenteMajorada : BaseEntity
    {
        public int Idade { get; set; }
        public double Valor { get; set; }

        public static void InsertData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvalidezAcidenteMajorada>().HasData(
                new InvalidezAcidenteMajorada { Idade = 16, Valor = 0.12 },
                new InvalidezAcidenteMajorada { Idade = 17, Valor = 0.12 },
                new InvalidezAcidenteMajorada { Idade = 18, Valor = 0.12 },
                new InvalidezAcidenteMajorada { Idade = 19, Valor = 0.12 },
                new InvalidezAcidenteMajorada { Idade = 20, Valor = 0.19 },
                new InvalidezAcidenteMajorada { Idade = 21, Valor = 0.19 },
                new InvalidezAcidenteMajorada { Idade = 22, Valor = 0.19 },
                new InvalidezAcidenteMajorada { Idade = 23, Valor = 0.19 },
                new InvalidezAcidenteMajorada { Idade = 24, Valor = 0.19 },
                new InvalidezAcidenteMajorada { Idade = 25, Valor = 0.19 },
                new InvalidezAcidenteMajorada { Idade = 26, Valor = 0.19 },
                new InvalidezAcidenteMajorada { Idade = 27, Valor = 0.19 },
                new InvalidezAcidenteMajorada { Idade = 28, Valor = 0.19 },
                new InvalidezAcidenteMajorada { Idade = 29, Valor = 0.19 },
                new InvalidezAcidenteMajorada { Idade = 30, Valor = 0.17 },
                new InvalidezAcidenteMajorada { Idade = 31, Valor = 0.17 },
                new InvalidezAcidenteMajorada { Idade = 32, Valor = 0.17 },
                new InvalidezAcidenteMajorada { Idade = 33, Valor = 0.17 },
                new InvalidezAcidenteMajorada { Idade = 34, Valor = 0.17 },
                new InvalidezAcidenteMajorada { Idade = 35, Valor = 0.17 },
                new InvalidezAcidenteMajorada { Idade = 36, Valor = 0.17 },
                new InvalidezAcidenteMajorada { Idade = 37, Valor = 0.17 },
                new InvalidezAcidenteMajorada { Idade = 38, Valor = 0.17 },
                new InvalidezAcidenteMajorada { Idade = 39, Valor = 0.17 },
                new InvalidezAcidenteMajorada { Idade = 40, Valor = 0.29 },
                new InvalidezAcidenteMajorada { Idade = 41, Valor = 0.29 },
                new InvalidezAcidenteMajorada { Idade = 42, Valor = 0.29 },
                new InvalidezAcidenteMajorada { Idade = 43, Valor = 0.29 },
                new InvalidezAcidenteMajorada { Idade = 44, Valor = 0.29 },
                new InvalidezAcidenteMajorada { Idade = 45, Valor = 0.29 },
                new InvalidezAcidenteMajorada { Idade = 46, Valor = 0.29 },
                new InvalidezAcidenteMajorada { Idade = 47, Valor = 0.29 },
                new InvalidezAcidenteMajorada { Idade = 48, Valor = 0.29 },
                new InvalidezAcidenteMajorada { Idade = 49, Valor = 0.29 },
                new InvalidezAcidenteMajorada { Idade = 50, Valor = 0.56 },
                new InvalidezAcidenteMajorada { Idade = 51, Valor = 0.56 },
                new InvalidezAcidenteMajorada { Idade = 52, Valor = 0.56 },
                new InvalidezAcidenteMajorada { Idade = 53, Valor = 0.56 },
                new InvalidezAcidenteMajorada { Idade = 54, Valor = 0.56 },
                new InvalidezAcidenteMajorada { Idade = 55, Valor = 0.56 },
                new InvalidezAcidenteMajorada { Idade = 56, Valor = 0.56 },
                new InvalidezAcidenteMajorada { Idade = 57, Valor = 0.56 },
                new InvalidezAcidenteMajorada { Idade = 58, Valor = 0.56 },
                new InvalidezAcidenteMajorada { Idade = 59, Valor = 0.56 },
                new InvalidezAcidenteMajorada { Idade = 60, Valor = 1.09 },
                new InvalidezAcidenteMajorada { Idade = 61, Valor = 1.09 },
                new InvalidezAcidenteMajorada { Idade = 62, Valor = 1.09 },
                new InvalidezAcidenteMajorada { Idade = 63, Valor = 1.09 },
                new InvalidezAcidenteMajorada { Idade = 64, Valor = 1.09 },
                new InvalidezAcidenteMajorada { Idade = 65, Valor = 1.09 });
        }
    }
}
