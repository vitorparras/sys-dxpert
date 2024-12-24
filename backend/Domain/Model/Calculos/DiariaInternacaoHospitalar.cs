using Domain.Model.Bases;
using Microsoft.EntityFrameworkCore;

namespace Domain.Model.Calculos
{
    public class DiariaInternacaoHospitalar : BaseEntity
    {
        public int Idade { get; set; }
        public double T150 { get; set; }
        public double T200 { get; set; }
        public double T250 { get; set; }

        public static void InsertData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiariaInternacaoHospitalar>().HasData(
                new DiariaInternacaoHospitalar { Idade = 16, T150 = 3.07, T200 = 3.17, T250 = 3.33 },
                new DiariaInternacaoHospitalar { Idade = 17, T150 = 3.07, T200 = 3.17, T250 = 3.33 },
                new DiariaInternacaoHospitalar { Idade = 18, T150 = 3.07, T200 = 3.17, T250 = 3.33 },
                new DiariaInternacaoHospitalar { Idade = 19, T150 = 3.07, T200 = 3.17, T250 = 3.33 },
                new DiariaInternacaoHospitalar { Idade = 20, T150 = 4.74, T200 = 5.06, T250 = 5.52 },
                new DiariaInternacaoHospitalar { Idade = 21, T150 = 4.74, T200 = 5.06, T250 = 5.52 },
                new DiariaInternacaoHospitalar { Idade = 22, T150 = 4.74, T200 = 5.06, T250 = 5.52 },
                new DiariaInternacaoHospitalar { Idade = 23, T150 = 4.74, T200 = 5.06, T250 = 5.52 },
                new DiariaInternacaoHospitalar { Idade = 24, T150 = 4.74, T200 = 5.06, T250 = 5.52 },
                new DiariaInternacaoHospitalar { Idade = 25, T150 = 4.74, T200 = 5.06, T250 = 5.52 },
                new DiariaInternacaoHospitalar { Idade = 26, T150 = 4.74, T200 = 5.06, T250 = 5.52 },
                new DiariaInternacaoHospitalar { Idade = 27, T150 = 4.74, T200 = 5.06, T250 = 5.52 },
                new DiariaInternacaoHospitalar { Idade = 28, T150 = 4.74, T200 = 5.06, T250 = 5.52 },
                new DiariaInternacaoHospitalar { Idade = 29, T150 = 4.74, T200 = 5.06, T250 = 5.52 },
                new DiariaInternacaoHospitalar { Idade = 30, T150 = 6.12, T200 = 6.69, T250 = 7.46 },
                new DiariaInternacaoHospitalar { Idade = 31, T150 = 6.12, T200 = 6.69, T250 = 7.46 },
                new DiariaInternacaoHospitalar { Idade = 32, T150 = 6.12, T200 = 6.69, T250 = 7.46 },
                new DiariaInternacaoHospitalar { Idade = 33, T150 = 6.12, T200 = 6.69, T250 = 7.46 },
                new DiariaInternacaoHospitalar { Idade = 34, T150 = 6.12, T200 = 6.69, T250 = 7.46 },
                new DiariaInternacaoHospitalar { Idade = 35, T150 = 6.12, T200 = 6.69, T250 = 7.46 },
                new DiariaInternacaoHospitalar { Idade = 36, T150 = 6.12, T200 = 6.69, T250 = 7.46 },
                new DiariaInternacaoHospitalar { Idade = 37, T150 = 6.12, T200 = 6.69, T250 = 7.46 },
                new DiariaInternacaoHospitalar { Idade = 38, T150 = 6.12, T200 = 6.69, T250 = 7.46 },
                new DiariaInternacaoHospitalar { Idade = 39, T150 = 6.12, T200 = 6.69, T250 = 7.46 },
                new DiariaInternacaoHospitalar { Idade = 40, T150 = 9.07, T200 = 9.95, T250 = 11.12 },
                new DiariaInternacaoHospitalar { Idade = 41, T150 = 9.07, T200 = 9.95, T250 = 11.12 },
                new DiariaInternacaoHospitalar { Idade = 42, T150 = 9.07, T200 = 9.95, T250 = 11.12 },
                new DiariaInternacaoHospitalar { Idade = 43, T150 = 9.07, T200 = 9.95, T250 = 11.12 },
                new DiariaInternacaoHospitalar { Idade = 44, T150 = 9.07, T200 = 9.95, T250 = 11.12 },
                new DiariaInternacaoHospitalar { Idade = 45, T150 = 9.07, T200 = 9.95, T250 = 11.12 },
                new DiariaInternacaoHospitalar { Idade = 46, T150 = 9.07, T200 = 9.95, T250 = 11.12 },
                new DiariaInternacaoHospitalar { Idade = 47, T150 = 9.07, T200 = 9.95, T250 = 11.12 },
                new DiariaInternacaoHospitalar { Idade = 48, T150 = 9.07, T200 = 9.95, T250 = 11.12 },
                new DiariaInternacaoHospitalar { Idade = 49, T150 = 9.07, T200 = 9.95, T250 = 11.12 },
                new DiariaInternacaoHospitalar { Idade = 50, T150 = 11.98, T200 = 13.1, T250 = 14.6 },
                new DiariaInternacaoHospitalar { Idade = 51, T150 = 11.98, T200 = 13.1, T250 = 14.6 },
                new DiariaInternacaoHospitalar { Idade = 52, T150 = 11.98, T200 = 13.1, T250 = 14.6 },
                new DiariaInternacaoHospitalar { Idade = 53, T150 = 11.98, T200 = 13.1, T250 = 14.6 },
                new DiariaInternacaoHospitalar { Idade = 54, T150 = 11.98, T200 = 13.1, T250 = 14.6 },
                new DiariaInternacaoHospitalar { Idade = 55, T150 = 11.98, T200 = 13.1, T250 = 14.6 },
                new DiariaInternacaoHospitalar { Idade = 56, T150 = 11.98, T200 = 13.1, T250 = 14.6 },
                new DiariaInternacaoHospitalar { Idade = 57, T150 = 11.98, T200 = 13.1, T250 = 14.6 },
                new DiariaInternacaoHospitalar { Idade = 58, T150 = 11.98, T200 = 13.1, T250 = 14.6 },
                new DiariaInternacaoHospitalar { Idade = 59, T150 = 11.98, T200 = 13.1, T250 = 14.6 },
                new DiariaInternacaoHospitalar { Idade = 60, T150 = 17.47, T200 = 18.73, T250 = 20.45 },
                new DiariaInternacaoHospitalar { Idade = 61, T150 = 17.47, T200 = 18.73, T250 = 20.45 },
                new DiariaInternacaoHospitalar { Idade = 62, T150 = 17.47, T200 = 18.73, T250 = 20.45 },
                new DiariaInternacaoHospitalar { Idade = 63, T150 = 17.47, T200 = 18.73, T250 = 20.45 },
                new DiariaInternacaoHospitalar { Idade = 64, T150 = 17.47, T200 = 18.73, T250 = 20.45 },
                new DiariaInternacaoHospitalar { Idade = 65, T150 = 17.47, T200 = 18.73, T250 = 20.45 });
        }
    }
}