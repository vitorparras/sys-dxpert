using Domain.Model.Bases;
using Microsoft.EntityFrameworkCore;

namespace Domain.Model.Calculos
{
    public class SafSuperLuxo : BaseEntity
    {
        public int Idade { get; set; }
        public double Individual { get; set; }
        public double Familiar { get; set; }

        public static void InsertData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SafSuperLuxo>().HasData(
                new SafSuperLuxo { Idade = 16, Individual = 1.99, Familiar = 6.38 },
                new SafSuperLuxo { Idade = 17, Individual = 1.99, Familiar = 6.38 },
                new SafSuperLuxo { Idade = 18, Individual = 1.99, Familiar = 6.38 },
                new SafSuperLuxo { Idade = 19, Individual = 1.99, Familiar = 6.38 },
                new SafSuperLuxo { Idade = 20, Individual = 1.99, Familiar = 6.38 },
                new SafSuperLuxo { Idade = 21, Individual = 1.99, Familiar = 6.38 },
                new SafSuperLuxo { Idade = 22, Individual = 1.99, Familiar = 6.38 },
                new SafSuperLuxo { Idade = 23, Individual = 1.99, Familiar = 6.38 },
                new SafSuperLuxo { Idade = 24, Individual = 1.99, Familiar = 6.38 },
                new SafSuperLuxo { Idade = 25, Individual = 1.99, Familiar = 6.38 },
                new SafSuperLuxo { Idade = 26, Individual = 1.99, Familiar = 6.38 },
                new SafSuperLuxo { Idade = 27, Individual = 1.99, Familiar = 6.38 },
                new SafSuperLuxo { Idade = 28, Individual = 1.99, Familiar = 6.38 },
                new SafSuperLuxo { Idade = 29, Individual = 1.99, Familiar = 6.38 },
                new SafSuperLuxo { Idade = 30, Individual = 1.99, Familiar = 6.38 },
                new SafSuperLuxo { Idade = 31, Individual = 1.99, Familiar = 6.38 },
                new SafSuperLuxo { Idade = 32, Individual = 1.99, Familiar = 6.38 },
                new SafSuperLuxo { Idade = 33, Individual = 1.99, Familiar = 6.38 },
                new SafSuperLuxo { Idade = 34, Individual = 1.99, Familiar = 6.38 },
                new SafSuperLuxo { Idade = 35, Individual = 1.99, Familiar = 6.38 },
                new SafSuperLuxo { Idade = 36, Individual = 3.02, Familiar = 8.61 },
                new SafSuperLuxo { Idade = 37, Individual = 3.02, Familiar = 8.61 },
                new SafSuperLuxo { Idade = 38, Individual = 3.02, Familiar = 8.61 },
                new SafSuperLuxo { Idade = 39, Individual = 3.02, Familiar = 8.61 },
                new SafSuperLuxo { Idade = 40, Individual = 3.02, Familiar = 8.61 },
                new SafSuperLuxo { Idade = 41, Individual = 4.53, Familiar = 12.52 },
                new SafSuperLuxo { Idade = 42, Individual = 4.53, Familiar = 12.52 },
                new SafSuperLuxo { Idade = 43, Individual = 4.53, Familiar = 12.52 },
                new SafSuperLuxo { Idade = 44, Individual = 4.53, Familiar = 12.52 },
                new SafSuperLuxo { Idade = 45, Individual = 4.53, Familiar = 12.52 },
                new SafSuperLuxo { Idade = 46, Individual = 6.72, Familiar = 16.2 },
                new SafSuperLuxo { Idade = 47, Individual = 6.72, Familiar = 16.2 },
                new SafSuperLuxo { Idade = 48, Individual = 6.72, Familiar = 16.2 },
                new SafSuperLuxo { Idade = 49, Individual = 6.72, Familiar = 16.2 },
                new SafSuperLuxo { Idade = 50, Individual = 6.72, Familiar = 16.2 },
                new SafSuperLuxo { Idade = 51, Individual = 10.2, Familiar = 22.11 },
                new SafSuperLuxo { Idade = 52, Individual = 10.2, Familiar = 22.11 },
                new SafSuperLuxo { Idade = 53, Individual = 10.2, Familiar = 22.11 },
                new SafSuperLuxo { Idade = 54, Individual = 10.2, Familiar = 22.11 },
                new SafSuperLuxo { Idade = 55, Individual = 10.2, Familiar = 22.11 },
                new SafSuperLuxo { Idade = 56, Individual = 15.92, Familiar = 33.12 },
                new SafSuperLuxo { Idade = 57, Individual = 15.92, Familiar = 33.12 },
                new SafSuperLuxo { Idade = 58, Individual = 15.92, Familiar = 33.12 },
                new SafSuperLuxo { Idade = 59, Individual = 15.92, Familiar = 33.12 },
                new SafSuperLuxo { Idade = 60, Individual = 15.92, Familiar = 33.12 },
                new SafSuperLuxo { Idade = 61, Individual = 20.54, Familiar = 42.5 },
                new SafSuperLuxo { Idade = 62, Individual = 22.47, Familiar = 46.31 },
                new SafSuperLuxo { Idade = 63, Individual = 24.66, Familiar = 50.57 },
                new SafSuperLuxo { Idade = 64, Individual = 27.1, Familiar = 55.35 },
                new SafSuperLuxo { Idade = 65, Individual = 29.77, Familiar = 60.58 },
                new SafSuperLuxo { Idade = 66, Individual = 32.62, Familiar = 66.34 },
                new SafSuperLuxo { Idade = 67, Individual = 35.65, Familiar = 72.56 },
                new SafSuperLuxo { Idade = 68, Individual = 38.87, Familiar = 79.3 },
                new SafSuperLuxo { Idade = 69, Individual = 42.36, Familiar = 86.5 },
                new SafSuperLuxo { Idade = 70, Individual = 46.27, Familiar = 94.38 },
                new SafSuperLuxo { Idade = 71, Individual = 50.71, Familiar = 103.02 },
                new SafSuperLuxo { Idade = 72, Individual = 55.8, Familiar = 112.71 },
                new SafSuperLuxo { Idade = 73, Individual = 61.65, Familiar = 123.63 },
                new SafSuperLuxo { Idade = 74, Individual = 68.15, Familiar = 135.95 },
                new SafSuperLuxo { Idade = 75, Individual = 75.17, Familiar = 149.62 },
                new SafSuperLuxo { Idade = 76, Individual = 82.6, Familiar = 164.64 },
                new SafSuperLuxo { Idade = 77, Individual = 90.32, Familiar = 180.85 },
                new SafSuperLuxo { Idade = 78, Individual = 98.26, Familiar = 197.95 },
                new SafSuperLuxo { Idade = 79, Individual = 106.63, Familiar = 216.07 },
                new SafSuperLuxo { Idade = 80, Individual = 115.75, Familiar = 235.32 },
                new SafSuperLuxo { Idade = 81, Individual = 125.87, Familiar = 236.3 },
                new SafSuperLuxo { Idade = 82, Individual = 137.31, Familiar = 257.21 },
                new SafSuperLuxo { Idade = 83, Individual = 150.21, Familiar = 263.11 },
                new SafSuperLuxo { Idade = 84, Individual = 164.25, Familiar = 287.14 },
                new SafSuperLuxo { Idade = 85, Individual = 179.12, Familiar = 292.72 });
        }
    }
}
