using Domain.Model.Bases;
using Microsoft.EntityFrameworkCore;

namespace Domain.Model.Calculos
{
    public class PrazoCerto : BaseEntity
    {
        public int Idade { get; set; }
        public double I5 { get; set; }
        public double I10 { get; set; }
        public double I15 { get; set; }
        public double I20 { get; set; }

        public static void InsertData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrazoCerto>().HasData(
                new PrazoCerto { Idade = 16, I5 = 0.2, I10 = 0.21, I15 = 0.23, I20 = 0.26 },
                new PrazoCerto { Idade = 17, I5 = 0.2, I10 = 0.21, I15 = 0.23, I20 = 0.26 },
                new PrazoCerto { Idade = 18, I5 = 0.2, I10 = 0.21, I15 = 0.23, I20 = 0.26 },
                new PrazoCerto { Idade = 19, I5 = 0.2, I10 = 0.21, I15 = 0.23, I20 = 0.26 },
                new PrazoCerto { Idade = 20, I5 = 0.2, I10 = 0.21, I15 = 0.23, I20 = 0.26 },
                new PrazoCerto { Idade = 21, I5 = 0.2, I10 = 0.21, I15 = 0.23, I20 = 0.26 },
                new PrazoCerto { Idade = 22, I5 = 0.2, I10 = 0.21, I15 = 0.23, I20 = 0.26 },
                new PrazoCerto { Idade = 23, I5 = 0.2, I10 = 0.21, I15 = 0.23, I20 = 0.26 },
                new PrazoCerto { Idade = 24, I5 = 0.2, I10 = 0.21, I15 = 0.23, I20 = 0.26 },
                new PrazoCerto { Idade = 25, I5 = 0.2, I10 = 0.21, I15 = 0.23, I20 = 0.26 },
                new PrazoCerto { Idade = 26, I5 = 0.2, I10 = 0.21, I15 = 0.23, I20 = 0.26 },
                new PrazoCerto { Idade = 27, I5 = 0.2, I10 = 0.21, I15 = 0.23, I20 = 0.26 },
                new PrazoCerto { Idade = 28, I5 = 0.2, I10 = 0.21, I15 = 0.23, I20 = 0.26 },
                new PrazoCerto { Idade = 29, I5 = 0.2, I10 = 0.21, I15 = 0.23, I20 = 0.26 },
                new PrazoCerto { Idade = 30, I5 = 0.2, I10 = 0.21, I15 = 0.23, I20 = 0.26 },
                new PrazoCerto { Idade = 31, I5 = 0.25, I10 = 0.3, I15 = 0.36, I20 = 0.43 },
                new PrazoCerto { Idade = 32, I5 = 0.25, I10 = 0.3, I15 = 0.36, I20 = 0.43 },
                new PrazoCerto { Idade = 33, I5 = 0.25, I10 = 0.3, I15 = 0.36, I20 = 0.43 },
                new PrazoCerto { Idade = 34, I5 = 0.25, I10 = 0.3, I15 = 0.36, I20 = 0.43 },
                new PrazoCerto { Idade = 35, I5 = 0.25, I10 = 0.3, I15 = 0.36, I20 = 0.43 },
                new PrazoCerto { Idade = 36, I5 = 0.35, I10 = 0.43, I15 = 0.53, I20 = 0.65 },
                new PrazoCerto { Idade = 37, I5 = 0.35, I10 = 0.43, I15 = 0.53, I20 = 0.65 },
                new PrazoCerto { Idade = 38, I5 = 0.35, I10 = 0.43, I15 = 0.53, I20 = 0.65 },
                new PrazoCerto { Idade = 39, I5 = 0.35, I10 = 0.43, I15 = 0.53, I20 = 0.65 },
                new PrazoCerto { Idade = 40, I5 = 0.35, I10 = 0.43, I15 = 0.53, I20 = 0.65 },
                new PrazoCerto { Idade = 41, I5 = 0.53, I10 = 0.65, I15 = 0.8, I20 = 0.98 },
                new PrazoCerto { Idade = 42, I5 = 0.53, I10 = 0.65, I15 = 0.8, I20 = 0.98 },
                new PrazoCerto { Idade = 43, I5 = 0.53, I10 = 0.65, I15 = 0.8, I20 = 0.98 },
                new PrazoCerto { Idade = 44, I5 = 0.53, I10 = 0.65, I15 = 0.8, I20 = 0.98 },
                new PrazoCerto { Idade = 45, I5 = 0.53, I10 = 0.65, I15 = 0.8, I20 = 0.98 },
                new PrazoCerto { Idade = 46, I5 = 0.79, I10 = 0.98, I15 = 1.21, I20 = 1.5 },
                new PrazoCerto { Idade = 47, I5 = 0.79, I10 = 0.98, I15 = 1.21, I20 = 1.5 },
                new PrazoCerto { Idade = 48, I5 = 0.79, I10 = 0.98, I15 = 1.21, I20 = 1.5 },
                new PrazoCerto { Idade = 49, I5 = 0.79, I10 = 0.98, I15 = 1.21, I20 = 1.5 },
                new PrazoCerto { Idade = 50, I5 = 0.79, I10 = 0.98, I15 = 1.21, I20 = 1.5 },
                new PrazoCerto { Idade = 51, I5 = 1.23, I10 = 1.52, I15 = 1.88, I20 = 0 },
                new PrazoCerto { Idade = 52, I5 = 1.23, I10 = 1.52, I15 = 1.88, I20 = 0 },
                new PrazoCerto { Idade = 53, I5 = 1.23, I10 = 1.52, I15 = 1.88, I20 = 0 },
                new PrazoCerto { Idade = 54, I5 = 1.23, I10 = 1.52, I15 = 1.88, I20 = 0 },
                new PrazoCerto { Idade = 55, I5 = 1.23, I10 = 1.52, I15 = 1.88, I20 = 0 },
                new PrazoCerto { Idade = 56, I5 = 1.89, I10 = 2.36, I15 = 0, I20 = 0 },
                new PrazoCerto { Idade = 57, I5 = 1.89, I10 = 2.36, I15 = 0, I20 = 0 },
                new PrazoCerto { Idade = 58, I5 = 1.89, I10 = 2.36, I15 = 0, I20 = 0 },
                new PrazoCerto { Idade = 59, I5 = 1.89, I10 = 2.36, I15 = 0, I20 = 0 },
                new PrazoCerto { Idade = 60, I5 = 1.89, I10 = 2.36, I15 = 0, I20 = 0 });
        }
    }
}
