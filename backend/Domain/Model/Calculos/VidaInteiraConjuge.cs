using Domain.Model.Bases;
using Microsoft.EntityFrameworkCore;

namespace Domain.Model.Calculos
{
    public class VidaInteiraConjuge : BaseEntity
    {
        public int Idade { get; set; }
        public double Homem { get; set; }
        public double Mulher { get; set; }

        public static void InsertData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VidaInteiraConjuge>().HasData(
                new VidaInteiraConjuge { Idade = 16, Homem = 0.19, Mulher = 0.17 },
                new VidaInteiraConjuge { Idade = 17, Homem = 0.19, Mulher = 0.17 },
                new VidaInteiraConjuge { Idade = 18, Homem = 0.19, Mulher = 0.17 },
                new VidaInteiraConjuge { Idade = 19, Homem = 0.19, Mulher = 0.17 },
                new VidaInteiraConjuge { Idade = 20, Homem = 0.19, Mulher = 0.17 },
                new VidaInteiraConjuge { Idade = 21, Homem = 0.19, Mulher = 0.17 },
                new VidaInteiraConjuge { Idade = 22, Homem = 0.19, Mulher = 0.17 },
                new VidaInteiraConjuge { Idade = 23, Homem = 0.19, Mulher = 0.17 },
                new VidaInteiraConjuge { Idade = 24, Homem = 0.19, Mulher = 0.17 },
                new VidaInteiraConjuge { Idade = 25, Homem = 0.19, Mulher = 0.17 },
                new VidaInteiraConjuge { Idade = 26, Homem = 0.19, Mulher = 0.17 },
                new VidaInteiraConjuge { Idade = 27, Homem = 0.19, Mulher = 0.17 },
                new VidaInteiraConjuge { Idade = 28, Homem = 0.19, Mulher = 0.17 },
                new VidaInteiraConjuge { Idade = 29, Homem = 0.19, Mulher = 0.17 },
                new VidaInteiraConjuge { Idade = 30, Homem = 0.19, Mulher = 0.17 },
                new VidaInteiraConjuge { Idade = 31, Homem = 0.23, Mulher = 0.2 },
                new VidaInteiraConjuge { Idade = 32, Homem = 0.23, Mulher = 0.2 },
                new VidaInteiraConjuge { Idade = 33, Homem = 0.23, Mulher = 0.2 },
                new VidaInteiraConjuge { Idade = 34, Homem = 0.23, Mulher = 0.2 },
                new VidaInteiraConjuge { Idade = 35, Homem = 0.23, Mulher = 0.2 },
                new VidaInteiraConjuge { Idade = 36, Homem = 0.3, Mulher = 0.27 },
                new VidaInteiraConjuge { Idade = 37, Homem = 0.3, Mulher = 0.27 },
                new VidaInteiraConjuge { Idade = 38, Homem = 0.3, Mulher = 0.27 },
                new VidaInteiraConjuge { Idade = 39, Homem = 0.3, Mulher = 0.27 },
                new VidaInteiraConjuge { Idade = 40, Homem = 0.3, Mulher = 0.27 },
                new VidaInteiraConjuge { Idade = 41, Homem = 0.44, Mulher = 0.4 },
                new VidaInteiraConjuge { Idade = 42, Homem = 0.44, Mulher = 0.4 },
                new VidaInteiraConjuge { Idade = 43, Homem = 0.44, Mulher = 0.4 },
                new VidaInteiraConjuge { Idade = 44, Homem = 0.44, Mulher = 0.4 },
                new VidaInteiraConjuge { Idade = 45, Homem = 0.44, Mulher = 0.4 },
                new VidaInteiraConjuge { Idade = 46, Homem = 0.68, Mulher = 0.61 },
                new VidaInteiraConjuge { Idade = 47, Homem = 0.68, Mulher = 0.61 },
                new VidaInteiraConjuge { Idade = 48, Homem = 0.68, Mulher = 0.61 },
                new VidaInteiraConjuge { Idade = 49, Homem = 0.68, Mulher = 0.61 },
                new VidaInteiraConjuge { Idade = 50, Homem = 0.68, Mulher = 0.61 },
                new VidaInteiraConjuge { Idade = 51, Homem = 1.07, Mulher = 0.96 },
                new VidaInteiraConjuge { Idade = 52, Homem = 1.07, Mulher = 0.96 },
                new VidaInteiraConjuge { Idade = 53, Homem = 1.07, Mulher = 0.96 },
                new VidaInteiraConjuge { Idade = 54, Homem = 1.07, Mulher = 0.96 },
                new VidaInteiraConjuge { Idade = 55, Homem = 1.07, Mulher = 0.96 },
                new VidaInteiraConjuge { Idade = 56, Homem = 1.67, Mulher = 1.5 },
                new VidaInteiraConjuge { Idade = 57, Homem = 1.67, Mulher = 1.5 },
                new VidaInteiraConjuge { Idade = 58, Homem = 1.67, Mulher = 1.5 },
                new VidaInteiraConjuge { Idade = 59, Homem = 1.67, Mulher = 1.5 },
                new VidaInteiraConjuge { Idade = 60, Homem = 1.67, Mulher = 1.5 },
                new VidaInteiraConjuge { Idade = 61, Homem = 2.18, Mulher = 1.96 },
                new VidaInteiraConjuge { Idade = 62, Homem = 2.38, Mulher = 2.15 },
                new VidaInteiraConjuge { Idade = 63, Homem = 2.6, Mulher = 2.34 },
                new VidaInteiraConjuge { Idade = 64, Homem = 2.85, Mulher = 2.56 },
                new VidaInteiraConjuge { Idade = 65, Homem = 3.11, Mulher = 2.8 },
                new VidaInteiraConjuge { Idade = 66, Homem = 3.41, Mulher = 3.07 },
                new VidaInteiraConjuge { Idade = 67, Homem = 3.73, Mulher = 3.36 },
                new VidaInteiraConjuge { Idade = 68, Homem = 4.09, Mulher = 3.68 },
                new VidaInteiraConjuge { Idade = 69, Homem = 4.47, Mulher = 4.02 },
                new VidaInteiraConjuge { Idade = 70, Homem = 4.88, Mulher = 4.39 },
                new VidaInteiraConjuge { Idade = 71, Homem = 5.31, Mulher = 4.78 },
                new VidaInteiraConjuge { Idade = 72, Homem = 5.75, Mulher = 5.17 },
                new VidaInteiraConjuge { Idade = 73, Homem = 6.2, Mulher = 5.78 },
                new VidaInteiraConjuge { Idade = 74, Homem = 6.68, Mulher = 6.01 },
                new VidaInteiraConjuge { Idade = 75, Homem = 7.19, Mulher = 6.47 },
                new VidaInteiraConjuge { Idade = 76, Homem = 7.76, Mulher = 6.99 },
                new VidaInteiraConjuge { Idade = 77, Homem = 8.4, Mulher = 7.56 },
                new VidaInteiraConjuge { Idade = 78, Homem = 9.12, Mulher = 8.21 },
                new VidaInteiraConjuge { Idade = 79, Homem = 9.92, Mulher = 8.93 },
                new VidaInteiraConjuge { Idade = 80, Homem = 10.78, Mulher = 9.7 },
                new VidaInteiraConjuge { Idade = 81, Homem = 11.7, Mulher = 10.53 },
                new VidaInteiraConjuge { Idade = 82, Homem = 12.66, Mulher = 11.4 },
                new VidaInteiraConjuge { Idade = 83, Homem = 13.66, Mulher = 12.3 },
                new VidaInteiraConjuge { Idade = 84, Homem = 14.71, Mulher = 13.24 },
                new VidaInteiraConjuge { Idade = 85, Homem = 15.8, Mulher = 14.22 });
        }
    }
}
