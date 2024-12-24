using Domain.Model.Bases;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Domain.Model.Calculos
{
    public class SafSuperLuxoPorIdade : BaseEntity
    {
        public int IdadeMinima { get; set; }
        public int IdadeMaxima { get; set; }
        public double Individual { get; set; }
        public double Familiar { get; set; }

        public static void InsertData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SafSuperLuxoPorIdade>().HasData(
                new SafSuperLuxoPorIdade { IdadeMinima = 16, IdadeMaxima = 35, Individual = 1.99, Familiar = 6.38 },
                new SafSuperLuxoPorIdade { IdadeMinima = 36, IdadeMaxima = 40, Individual = 3.02, Familiar = 8.61 },
                new SafSuperLuxoPorIdade { IdadeMinima = 41, IdadeMaxima = 45, Individual = 4.53, Familiar = 1.52 },
                new SafSuperLuxoPorIdade { IdadeMinima = 46, IdadeMaxima = 50, Individual = 6.72, Familiar = 16.20 },
                new SafSuperLuxoPorIdade { IdadeMinima = 51, IdadeMaxima = 55, Individual = 10.20, Familiar = 22.11 },
                new SafSuperLuxoPorIdade { IdadeMinima = 56, IdadeMaxima = 60, Individual = 15.92, Familiar = 33.12 },
                new SafSuperLuxoPorIdade { IdadeMinima = 61, IdadeMaxima = 61, Individual = 20.54, Familiar = 42.50 },
                new SafSuperLuxoPorIdade { IdadeMinima = 62, IdadeMaxima = 62, Individual = 22.47, Familiar = 46.31 },
                new SafSuperLuxoPorIdade { IdadeMinima = 63, IdadeMaxima = 63, Individual = 24.66, Familiar = 50.57 },
                new SafSuperLuxoPorIdade { IdadeMinima = 64, IdadeMaxima = 64, Individual = 27.10, Familiar = 55.35 },
                new SafSuperLuxoPorIdade { IdadeMinima = 65, IdadeMaxima = 65, Individual = 29.77, Familiar = 60.58 },
                new SafSuperLuxoPorIdade { IdadeMinima = 66, IdadeMaxima = 66, Individual = 32.62, Familiar = 66.34 },
                new SafSuperLuxoPorIdade { IdadeMinima = 67, IdadeMaxima = 67, Individual = 35.65, Familiar = 72.56 },
                new SafSuperLuxoPorIdade { IdadeMinima = 68, IdadeMaxima = 68, Individual = 38.87, Familiar = 79.30 },
                new SafSuperLuxoPorIdade { IdadeMinima = 69, IdadeMaxima = 69, Individual = 42.36, Familiar = 86.50 },
                new SafSuperLuxoPorIdade { IdadeMinima = 70, IdadeMaxima = 70, Individual = 46.27, Familiar = 94.38 },
                new SafSuperLuxoPorIdade { IdadeMinima = 71, IdadeMaxima = 71, Individual = 50.71, Familiar = 103.02 },
                new SafSuperLuxoPorIdade { IdadeMinima = 72, IdadeMaxima = 72, Individual = 55.80, Familiar = 112.71 },
                new SafSuperLuxoPorIdade { IdadeMinima = 73, IdadeMaxima = 73, Individual = 61.65, Familiar = 123.63 },
                new SafSuperLuxoPorIdade { IdadeMinima = 74, IdadeMaxima = 74, Individual = 68.15, Familiar = 135.95 },
                new SafSuperLuxoPorIdade { IdadeMinima = 75, IdadeMaxima = 75, Individual = 75.17, Familiar = 149.62 },
                new SafSuperLuxoPorIdade { IdadeMinima = 76, IdadeMaxima = 76, Individual = 82.60, Familiar = 164.64 },
                new SafSuperLuxoPorIdade { IdadeMinima = 77, IdadeMaxima = 77, Individual = 90.32, Familiar = 180.85 },
                new SafSuperLuxoPorIdade { IdadeMinima = 78, IdadeMaxima = 78, Individual = 98.26, Familiar = 197.95 },
                new SafSuperLuxoPorIdade { IdadeMinima = 79, IdadeMaxima = 79, Individual = 106.63, Familiar = 216.07 },
                new SafSuperLuxoPorIdade { IdadeMinima = 80, IdadeMaxima = 80, Individual = 115.75, Familiar = 235.32 },
                new SafSuperLuxoPorIdade { IdadeMinima = 81, IdadeMaxima = 81, Individual = 125.87, Familiar = 236.30 },
                new SafSuperLuxoPorIdade { IdadeMinima = 82, IdadeMaxima = 82, Individual = 137.31, Familiar = 257.21 },
                new SafSuperLuxoPorIdade { IdadeMinima = 83, IdadeMaxima = 83, Individual = 150.21, Familiar = 263.11 },
                new SafSuperLuxoPorIdade { IdadeMinima = 84, IdadeMaxima = 84, Individual = 164.25, Familiar = 287.14 },
                new SafSuperLuxoPorIdade { IdadeMinima = 85, IdadeMaxima = 85, Individual = 179.12, Familiar = 292.72 });
        }
    }
}
