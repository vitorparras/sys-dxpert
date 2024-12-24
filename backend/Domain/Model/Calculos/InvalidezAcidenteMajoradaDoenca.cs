using Domain.Model.Bases;
using Microsoft.EntityFrameworkCore;

namespace Domain.Model.Calculos
{
    public class InvalidezAcidenteMajoradaDoenca : BaseEntity
    {
        public int Idade { get; set; }
        public double Valor { get; set; }

        public static void InsertData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvalidezAcidenteMajoradaDoenca>().HasData(
                new InvalidezAcidenteMajoradaDoenca { Idade = 16, Valor = 0.12 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 17, Valor = 0.12 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 18, Valor = 0.12 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 19, Valor = 0.12 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 20, Valor = 0.12 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 21, Valor = 0.12 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 22, Valor = 0.12 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 23, Valor = 0.12 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 24, Valor = 0.12 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 25, Valor = 0.12 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 26, Valor = 0.13 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 27, Valor = 0.13 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 28, Valor = 0.13 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 29, Valor = 0.13 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 30, Valor = 0.13 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 31, Valor = 0.13 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 32, Valor = 0.13 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 33, Valor = 0.13 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 34, Valor = 0.13 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 35, Valor = 0.13 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 36, Valor = 0.15 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 37, Valor = 0.15 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 38, Valor = 0.15 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 39, Valor = 0.15 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 40, Valor = 0.15 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 41, Valor = 0.2 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 42, Valor = 0.2 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 43, Valor = 0.2 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 44, Valor = 0.2 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 45, Valor = 0.2 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 46, Valor = 0.26 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 47, Valor = 0.26 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 48, Valor = 0.26 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 49, Valor = 0.26 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 50, Valor = 0.26 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 51, Valor = 0.41 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 52, Valor = 0.41 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 53, Valor = 0.41 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 54, Valor = 0.41 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 55, Valor = 0.41 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 56, Valor = 0.69 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 57, Valor = 0.69 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 58, Valor = 0.69 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 59, Valor = 0.69 },
                new InvalidezAcidenteMajoradaDoenca { Idade = 60, Valor = 0.69 });
        }
    }
}
