using Domain.Model.Bases;
using Microsoft.EntityFrameworkCore;

namespace Domain.Model.Calculos
{
    public class RendaInvalidez : BaseEntity
    {
        public int Idade { get; set; }
        public double I20 { get; set; }
        public double I30 { get; set; }

        public static List<RendaInvalidez> GetDados()
        {
            return new List<RendaInvalidez>() {
                new RendaInvalidez { Idade = 16, I20 = 14.14, I30 = 18.87 },
                new RendaInvalidez { Idade = 17, I20 = 14.14, I30 = 18.87 },
                new RendaInvalidez { Idade = 18, I20 = 14.14, I30 = 18.87 },
                new RendaInvalidez { Idade = 19, I20 = 14.14, I30 = 18.87 },
                new RendaInvalidez { Idade = 20, I20 = 14.14, I30 = 18.87 },
                new RendaInvalidez { Idade = 21, I20 = 14.14, I30 = 18.87 },
                new RendaInvalidez { Idade = 22, I20 = 14.14, I30 = 18.87 },
                new RendaInvalidez { Idade = 23, I20 = 14.14, I30 = 18.87 },
                new RendaInvalidez { Idade = 24, I20 = 14.14, I30 = 18.87 },
                new RendaInvalidez { Idade = 25, I20 = 14.14, I30 = 18.87 },
                new RendaInvalidez { Idade = 26, I20 = 14.14, I30 = 18.87 },
                new RendaInvalidez { Idade = 27, I20 = 14.14, I30 = 18.87 },
                new RendaInvalidez { Idade = 28, I20 = 14.14, I30 = 18.87 },
                new RendaInvalidez { Idade = 29, I20 = 14.14, I30 = 18.87 },
                new RendaInvalidez { Idade = 30, I20 = 14.14, I30 = 18.87 },
                new RendaInvalidez { Idade = 31, I20 = 15.76, I30 = 20.89 },
                new RendaInvalidez { Idade = 32, I20 = 15.76, I30 = 20.89 },
                new RendaInvalidez { Idade = 33, I20 = 15.76, I30 = 20.89 },
                new RendaInvalidez { Idade = 34, I20 = 15.76, I30 = 20.89 },
                new RendaInvalidez { Idade = 35, I20 = 15.76, I30 = 20.89 },
                new RendaInvalidez { Idade = 36, I20 = 18.6, I30 = 24.5 },
                new RendaInvalidez { Idade = 37, I20 = 18.6, I30 = 24.5 },
                new RendaInvalidez { Idade = 38, I20 = 18.6, I30 = 24.5 },
                new RendaInvalidez { Idade = 39, I20 = 18.6, I30 = 24.5 },
                new RendaInvalidez { Idade = 40, I20 = 18.6, I30 = 24.5 },
                new RendaInvalidez { Idade = 41, I20 = 24.41, I30 = 31.84 },
                new RendaInvalidez { Idade = 42, I20 = 24.41, I30 = 31.84 },
                new RendaInvalidez { Idade = 43, I20 = 24.41, I30 = 31.84 },
                new RendaInvalidez { Idade = 44, I20 = 24.41, I30 = 31.84 },
                new RendaInvalidez { Idade = 45, I20 = 24.41, I30 = 31.84 },
                new RendaInvalidez { Idade = 46, I20 = 35.81, I30 = 45.95 },
                new RendaInvalidez { Idade = 47, I20 = 35.81, I30 = 45.95 },
                new RendaInvalidez { Idade = 48, I20 = 35.81, I30 = 45.95 },
                new RendaInvalidez { Idade = 49, I20 = 35.81, I30 = 45.95 },
                new RendaInvalidez { Idade = 50, I20 = 35.81, I30 = 45.95 },
                new RendaInvalidez { Idade = 51, I20 = 57.46, I30 = 71.87 },
                new RendaInvalidez { Idade = 52, I20 = 57.46, I30 = 71.87 },
                new RendaInvalidez { Idade = 53, I20 = 57.46, I30 = 71.87 },
                new RendaInvalidez { Idade = 54, I20 = 57.46, I30 = 71.87 },
                new RendaInvalidez { Idade = 55, I20 = 57.46, I30 = 71.87 },
                new RendaInvalidez { Idade = 56, I20 = 97.25, I30 = 117.28 },
                new RendaInvalidez { Idade = 57, I20 = 97.25, I30 = 117.28 },
                new RendaInvalidez { Idade = 58, I20 = 97.25, I30 = 117.28 },
                new RendaInvalidez { Idade = 59, I20 = 97.25, I30 = 117.28 },
                new RendaInvalidez { Idade = 60, I20 = 97.25, I30 = 117.28 }
            };
        }
    }
}
