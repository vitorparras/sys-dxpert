using Domain.Model.Bases;
using Microsoft.EntityFrameworkCore;

namespace Domain.Model.Calculos
{
    public class DoencasGravesMaster : BaseEntity
    {
        public int Idade { get; set; }
        public double Valor { get; set; }

        public static void InsertData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoencasGravesMaster>().HasData(
                new DoencasGravesMaster { Idade = 66, Valor = 3.53 },
                new DoencasGravesMaster { Idade = 67, Valor = 3.69 },
                new DoencasGravesMaster { Idade = 68, Valor = 3.85 },
                new DoencasGravesMaster { Idade = 69, Valor = 4.06 },
                new DoencasGravesMaster { Idade = 70, Valor = 4.27 },
                new DoencasGravesMaster { Idade = 71, Valor = 4.47 },
                new DoencasGravesMaster { Idade = 72, Valor = 4.68 },
                new DoencasGravesMaster { Idade = 73, Valor = 4.88 },
                new DoencasGravesMaster { Idade = 74, Valor = 5.2 },
                new DoencasGravesMaster { Idade = 75, Valor = 5.53 },
                new DoencasGravesMaster { Idade = 76, Valor = 5.85 },
                new DoencasGravesMaster { Idade = 77, Valor = 5.89 },
                new DoencasGravesMaster { Idade = 78, Valor = 6.49 },
                new DoencasGravesMaster { Idade = 79, Valor = 7.16 },
                new DoencasGravesMaster { Idade = 80, Valor = 7.89 },
                new DoencasGravesMaster { Idade = 81, Valor = 8.68 },
                new DoencasGravesMaster { Idade = 82, Valor = 9.55 },
                new DoencasGravesMaster { Idade = 83, Valor = 10.5 },
                new DoencasGravesMaster { Idade = 84, Valor = 11.51 },
                new DoencasGravesMaster { Idade = 85, Valor = 12.58 });
        }
    }
}
