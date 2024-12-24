using Domain.Model.Bases;
using Microsoft.EntityFrameworkCore;

namespace Domain.Model.Calculos
{
    public class SafLuxo : BaseEntity
    {
        public int Idade { get; set; }
        public double Individual { get; set; }
        public double Familiar { get; set; }

        public static void InsertData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SafLuxo>().HasData(
                new SafLuxo { Idade = 16, Individual = 1.56, Familiar = 5.01 },
                new SafLuxo { Idade = 17, Individual = 1.56, Familiar = 5.01 },
                new SafLuxo { Idade = 18, Individual = 1.56, Familiar = 5.01 },
                new SafLuxo { Idade = 19, Individual = 1.56, Familiar = 5.01 },
                new SafLuxo { Idade = 20, Individual = 1.56, Familiar = 5.01 },
                new SafLuxo { Idade = 21, Individual = 1.56, Familiar = 5.01 },
                new SafLuxo { Idade = 22, Individual = 1.56, Familiar = 5.01 },
                new SafLuxo { Idade = 23, Individual = 1.56, Familiar = 5.01 },
                new SafLuxo { Idade = 24, Individual = 1.56, Familiar = 5.01 },
                new SafLuxo { Idade = 25, Individual = 1.56, Familiar = 5.01 },
                new SafLuxo { Idade = 26, Individual = 1.56, Familiar = 5.01 },
                new SafLuxo { Idade = 27, Individual = 1.56, Familiar = 5.01 },
                new SafLuxo { Idade = 28, Individual = 1.56, Familiar = 5.01 },
                new SafLuxo { Idade = 29, Individual = 1.56, Familiar = 5.01 },
                new SafLuxo { Idade = 30, Individual = 1.56, Familiar = 5.01 },
                new SafLuxo { Idade = 31, Individual = 1.56, Familiar = 5.01 },
                new SafLuxo { Idade = 32, Individual = 1.56, Familiar = 5.01 },
                new SafLuxo { Idade = 33, Individual = 1.56, Familiar = 5.01 },
                new SafLuxo { Idade = 34, Individual = 1.56, Familiar = 5.01 },
                new SafLuxo { Idade = 35, Individual = 1.56, Familiar = 5.01 },
                new SafLuxo { Idade = 36, Individual = 2.37, Familiar = 6.76 },
                new SafLuxo { Idade = 37, Individual = 2.37, Familiar = 6.76 },
                new SafLuxo { Idade = 38, Individual = 2.37, Familiar = 6.76 },
                new SafLuxo { Idade = 39, Individual = 2.37, Familiar = 6.76 },
                new SafLuxo { Idade = 40, Individual = 2.37, Familiar = 6.76 },
                new SafLuxo { Idade = 41, Individual = 3.56, Familiar = 9.84 },
                new SafLuxo { Idade = 42, Individual = 3.56, Familiar = 9.84 },
                new SafLuxo { Idade = 43, Individual = 3.56, Familiar = 9.84 },
                new SafLuxo { Idade = 44, Individual = 3.56, Familiar = 9.84 },
                new SafLuxo { Idade = 45, Individual = 3.56, Familiar = 9.84 },
                new SafLuxo { Idade = 46, Individual = 5.28, Familiar = 12.73 },
                new SafLuxo { Idade = 47, Individual = 5.28, Familiar = 12.73 },
                new SafLuxo { Idade = 48, Individual = 5.28, Familiar = 12.73 },
                new SafLuxo { Idade = 49, Individual = 5.28, Familiar = 12.73 },
                new SafLuxo { Idade = 50, Individual = 5.28, Familiar = 12.73 },
                new SafLuxo { Idade = 51, Individual = 8.01, Familiar = 17.37 },
                new SafLuxo { Idade = 52, Individual = 8.01, Familiar = 17.37 },
                new SafLuxo { Idade = 53, Individual = 8.01, Familiar = 17.37 },
                new SafLuxo { Idade = 54, Individual = 8.01, Familiar = 17.37 },
                new SafLuxo { Idade = 55, Individual = 8.01, Familiar = 17.37 },
                new SafLuxo { Idade = 56, Individual = 12.5, Familiar = 26.02 },
                new SafLuxo { Idade = 57, Individual = 12.5, Familiar = 26.02 },
                new SafLuxo { Idade = 58, Individual = 12.5, Familiar = 26.02 },
                new SafLuxo { Idade = 59, Individual = 12.5, Familiar = 26.02 },
                new SafLuxo { Idade = 60, Individual = 12.5, Familiar = 26.02 },
                new SafLuxo { Idade = 61, Individual = 16.14, Familiar = 33.39 },
                new SafLuxo { Idade = 62, Individual = 17.66, Familiar = 36.38 },
                new SafLuxo { Idade = 63, Individual = 19.38, Familiar = 39.73 },
                new SafLuxo { Idade = 64, Individual = 21.29, Familiar = 43.49 },
                new SafLuxo { Idade = 65, Individual = 23.39, Familiar = 47.6 },
                new SafLuxo { Idade = 66, Individual = 25.63, Familiar = 52.13 },
                new SafLuxo { Idade = 67, Individual = 28.01, Familiar = 57.01 },
                new SafLuxo { Idade = 68, Individual = 30.54, Familiar = 62.3 },
                new SafLuxo { Idade = 69, Individual = 33.28, Familiar = 67.96 },
                new SafLuxo { Idade = 70, Individual = 36.36, Familiar = 74.15 },
                new SafLuxo { Idade = 71, Individual = 39.84, Familiar = 80.95 },
                new SafLuxo { Idade = 72, Individual = 43.85, Familiar = 88.56 },
                new SafLuxo { Idade = 73, Individual = 48.44, Familiar = 97.14 },
                new SafLuxo { Idade = 74, Individual = 53.54, Familiar = 106.82 },
                new SafLuxo { Idade = 75, Individual = 59.06, Familiar = 117.56 },
                new SafLuxo { Idade = 76, Individual = 64.9, Familiar = 129.36 },
                new SafLuxo { Idade = 77, Individual = 70.96, Familiar = 142.1 },
                new SafLuxo { Idade = 78, Individual = 77.2, Familiar = 155.53 },
                new SafLuxo { Idade = 79, Individual = 83.78, Familiar = 169.77 },
                new SafLuxo { Idade = 80, Individual = 90.95, Familiar = 184.89 },
                new SafLuxo { Idade = 81, Individual = 98.9, Familiar = 185.67 },
                new SafLuxo { Idade = 82, Individual = 107.89, Familiar = 202.09 },
                new SafLuxo { Idade = 83, Individual = 118.02, Familiar = 206.73 },
                new SafLuxo { Idade = 84, Individual = 129.05, Familiar = 225.61 },
                new SafLuxo { Idade = 85, Individual = 140.74, Familiar = 230 });
        }
    }
}
