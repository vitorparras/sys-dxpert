using Domain.Model.Bases;
using Microsoft.EntityFrameworkCore;

namespace Domain.Model.Calculos
{
    public class VidaInteira : BaseEntity
    {
        public int Idade { get; set; }
        public double Homem { get; set; }
        public double Mulher { get; set; }

        public static void InsertData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VidaInteira>().HasData(
                new VidaInteira { Idade = 16, Homem = 0.23, Mulher = 0.21 },
                new VidaInteira { Idade = 17, Homem = 0.23, Mulher = 0.21 },
                new VidaInteira { Idade = 18, Homem = 0.23, Mulher = 0.21 },
                new VidaInteira { Idade = 19, Homem = 0.23, Mulher = 0.21 },
                new VidaInteira { Idade = 20, Homem = 0.23, Mulher = 0.21 },
                new VidaInteira { Idade = 21, Homem = 0.23, Mulher = 0.21 },
                new VidaInteira { Idade = 22, Homem = 0.23, Mulher = 0.21 },
                new VidaInteira { Idade = 23, Homem = 0.23, Mulher = 0.21 },
                new VidaInteira { Idade = 24, Homem = 0.23, Mulher = 0.21 },
                new VidaInteira { Idade = 25, Homem = 0.23, Mulher = 0.21 },
                new VidaInteira { Idade = 26, Homem = 0.23, Mulher = 0.21 },
                new VidaInteira { Idade = 27, Homem = 0.23, Mulher = 0.21 },
                new VidaInteira { Idade = 28, Homem = 0.23, Mulher = 0.21 },
                new VidaInteira { Idade = 29, Homem = 0.23, Mulher = 0.21 },
                new VidaInteira { Idade = 30, Homem = 0.23, Mulher = 0.21 },
                new VidaInteira { Idade = 31, Homem = 0.28, Mulher = 0.25 },
                new VidaInteira { Idade = 32, Homem = 0.28, Mulher = 0.25 },
                new VidaInteira { Idade = 33, Homem = 0.28, Mulher = 0.25 },
                new VidaInteira { Idade = 34, Homem = 0.28, Mulher = 0.25 },
                new VidaInteira { Idade = 35, Homem = 0.28, Mulher = 0.25 },
                new VidaInteira { Idade = 36, Homem = 0.36, Mulher = 0.32 },
                new VidaInteira { Idade = 37, Homem = 0.36, Mulher = 0.32 },
                new VidaInteira { Idade = 38, Homem = 0.36, Mulher = 0.32 },
                new VidaInteira { Idade = 39, Homem = 0.36, Mulher = 0.32 },
                new VidaInteira { Idade = 40, Homem = 0.36, Mulher = 0.32 },
                new VidaInteira { Idade = 41, Homem = 0.54, Mulher = 0.49 },
                new VidaInteira { Idade = 42, Homem = 0.54, Mulher = 0.49 },
                new VidaInteira { Idade = 43, Homem = 0.54, Mulher = 0.49 },
                new VidaInteira { Idade = 44, Homem = 0.54, Mulher = 0.49 },
                new VidaInteira { Idade = 45, Homem = 0.54, Mulher = 0.49 },
                new VidaInteira { Idade = 46, Homem = 0.83, Mulher = 0.75 },
                new VidaInteira { Idade = 47, Homem = 0.83, Mulher = 0.75 },
                new VidaInteira { Idade = 48, Homem = 0.83, Mulher = 0.75 },
                new VidaInteira { Idade = 49, Homem = 0.83, Mulher = 0.75 },
                new VidaInteira { Idade = 50, Homem = 0.83, Mulher = 0.75 },
                new VidaInteira { Idade = 51, Homem = 1.3, Mulher = 1.17 },
                new VidaInteira { Idade = 52, Homem = 1.3, Mulher = 1.17 },
                new VidaInteira { Idade = 53, Homem = 1.3, Mulher = 1.17 },
                new VidaInteira { Idade = 54, Homem = 1.3, Mulher = 1.17 },
                new VidaInteira { Idade = 55, Homem = 1.3, Mulher = 1.17 },
                new VidaInteira { Idade = 56, Homem = 2.03, Mulher = 1.83 },
                new VidaInteira { Idade = 57, Homem = 2.03, Mulher = 1.83 },
                new VidaInteira { Idade = 58, Homem = 2.03, Mulher = 1.83 },
                new VidaInteira { Idade = 59, Homem = 2.03, Mulher = 1.83 },
                new VidaInteira { Idade = 60, Homem = 2.03, Mulher = 1.83 },
                new VidaInteira { Idade = 61, Homem = 2.66, Mulher = 2.39 },
                new VidaInteira { Idade = 62, Homem = 2.91, Mulher = 2.61 },
                new VidaInteira { Idade = 63, Homem = 3.18, Mulher = 2.86 },
                new VidaInteira { Idade = 64, Homem = 3.47, Mulher = 3.12 },
                new VidaInteira { Idade = 65, Homem = 3.79, Mulher = 3.41 },
                new VidaInteira { Idade = 66, Homem = 4.15, Mulher = 3.74 },
                new VidaInteira { Idade = 67, Homem = 4.55, Mulher = 4.09 },
                new VidaInteira { Idade = 68, Homem = 4.98, Mulher = 4.48 },
                new VidaInteira { Idade = 69, Homem = 5.45, Mulher = 4.91 },
                new VidaInteira { Idade = 70, Homem = 5.95, Mulher = 5.35 },
                new VidaInteira { Idade = 71, Homem = 6.47, Mulher = 5.82 },
                new VidaInteira { Idade = 72, Homem = 7.01, Mulher = 6.31 },
                new VidaInteira { Idade = 73, Homem = 7.56, Mulher = 6.8 },
                new VidaInteira { Idade = 74, Homem = 8.14, Mulher = 7.33 },
                new VidaInteira { Idade = 75, Homem = 8.77, Mulher = 7.89 },
                new VidaInteira { Idade = 76, Homem = 9.46, Mulher = 8.52 },
                new VidaInteira { Idade = 77, Homem = 10.24, Mulher = 9.22 },
                new VidaInteira { Idade = 78, Homem = 11.12, Mulher = 10.01 },
                new VidaInteira { Idade = 79, Homem = 12.09, Mulher = 10.88 },
                new VidaInteira { Idade = 80, Homem = 13.14, Mulher = 11.83 },
                new VidaInteira { Idade = 81, Homem = 14.26, Mulher = 12.84 },
                new VidaInteira { Idade = 82, Homem = 15.44, Mulher = 13.89 },
                new VidaInteira { Idade = 83, Homem = 16.66, Mulher = 14.99 },
                new VidaInteira { Idade = 84, Homem = 17.93, Mulher = 16.13 },
                new VidaInteira { Idade = 85, Homem = 19.26, Mulher = 17.33 });
        }
    }
}
