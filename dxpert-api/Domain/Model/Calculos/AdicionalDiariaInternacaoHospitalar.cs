using Domain.Model.Bases;
using Microsoft.EntityFrameworkCore;

namespace Domain.Model.Calculos
{
    public class AdicionalDiariaInternacaoHospitalar : BaseEntity
    {
        public int Idade { get; set; }
        public double Valor { get; set; }

        public static void InsertData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdicionalDiariaInternacaoHospitalar>().HasData(
                new AdicionalDiariaInternacaoHospitalar { Idade = 16, Valor = 0.12 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 17, Valor = 0.12 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 18, Valor = 0.12 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 19, Valor = 0.12 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 20, Valor = 0.19 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 21, Valor = 0.19 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 22, Valor = 0.19 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 23, Valor = 0.19 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 24, Valor = 0.19 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 25, Valor = 0.19 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 26, Valor = 0.19 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 27, Valor = 0.19 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 28, Valor = 0.19 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 29, Valor = 0.19 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 30, Valor = 0.17 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 31, Valor = 0.17 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 32, Valor = 0.17 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 33, Valor = 0.17 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 34, Valor = 0.17 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 35, Valor = 0.17 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 36, Valor = 0.17 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 37, Valor = 0.17 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 38, Valor = 0.17 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 39, Valor = 0.17 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 40, Valor = 0.29 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 41, Valor = 0.29 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 42, Valor = 0.29 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 43, Valor = 0.29 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 44, Valor = 0.29 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 45, Valor = 0.29 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 46, Valor = 0.29 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 47, Valor = 0.29 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 48, Valor = 0.29 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 49, Valor = 0.29 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 50, Valor = 0.56 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 51, Valor = 0.56 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 52, Valor = 0.56 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 53, Valor = 0.56 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 54, Valor = 0.56 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 55, Valor = 0.56 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 56, Valor = 0.56 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 57, Valor = 0.56 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 58, Valor = 0.56 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 59, Valor = 0.56 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 60, Valor = 1.09 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 61, Valor = 1.09 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 62, Valor = 1.09 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 63, Valor = 1.09 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 64, Valor = 1.09 },
                new AdicionalDiariaInternacaoHospitalar { Idade = 65, Valor = 1.09 });
        }
    }
}
