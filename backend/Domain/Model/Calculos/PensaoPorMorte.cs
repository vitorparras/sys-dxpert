using Domain.Model.Bases;
using Microsoft.EntityFrameworkCore;

namespace Domain.Model.Calculos
{
    public class PensaoPorMorte : BaseEntity
    {
        public int Idade { get; set; }
        public double I10 { get; set; }
        public double I15 { get; set; }
        public double I20 { get; set; }

        public static List<PensaoPorMorte> GetDados()
        {
            return new List<PensaoPorMorte>() {
                new PensaoPorMorte { Idade = 16, I10 = 24.62, I15 = 34.83, I20 = 43.85 },
                new PensaoPorMorte { Idade = 17, I10 = 24.62, I15 = 34.83, I20 = 43.85 },
                new PensaoPorMorte { Idade = 18, I10 = 24.62, I15 = 34.83, I20 = 43.85 },
                new PensaoPorMorte { Idade = 19, I10 = 24.62, I15 = 34.83, I20 = 43.85 },
                new PensaoPorMorte { Idade = 20, I10 = 24.62, I15 = 34.83, I20 = 43.85 },
                new PensaoPorMorte { Idade = 21, I10 = 24.62, I15 = 34.83, I20 = 43.85 },
                new PensaoPorMorte { Idade = 22, I10 = 24.62, I15 = 34.83, I20 = 43.85 },
                new PensaoPorMorte { Idade = 23, I10 = 24.62, I15 = 34.83, I20 = 43.85 },
                new PensaoPorMorte { Idade = 24, I10 = 24.62, I15 = 34.83, I20 = 43.85 },
                new PensaoPorMorte { Idade = 25, I10 = 24.62, I15 = 34.83, I20 = 43.85 },
                new PensaoPorMorte { Idade = 26, I10 = 24.62, I15 = 34.83, I20 = 43.85 },
                new PensaoPorMorte { Idade = 27, I10 = 24.62, I15 = 34.83, I20 = 43.85 },
                new PensaoPorMorte { Idade = 28, I10 = 24.62, I15 = 34.83, I20 = 43.85 },
                new PensaoPorMorte { Idade = 29, I10 = 24.62, I15 = 34.83, I20 = 43.85 },
                new PensaoPorMorte { Idade = 30, I10 = 24.62, I15 = 34.83, I20 = 43.85 },
                new PensaoPorMorte { Idade = 31, I10 = 29.35, I15 = 41.52, I20 = 52.28 },
                new PensaoPorMorte { Idade = 32, I10 = 29.35, I15 = 41.52, I20 = 52.28 },
                new PensaoPorMorte { Idade = 33, I10 = 29.35, I15 = 41.52, I20 = 52.28 },
                new PensaoPorMorte { Idade = 34, I10 = 29.35, I15 = 41.52, I20 = 52.28 },
                new PensaoPorMorte { Idade = 35, I10 = 29.35, I15 = 41.52, I20 = 52.28 },
                new PensaoPorMorte { Idade = 36, I10 = 35.89, I15 = 50.77, I20 = 63.92 },
                new PensaoPorMorte { Idade = 37, I10 = 35.89, I15 = 50.77, I20 = 63.92 },
                new PensaoPorMorte { Idade = 38, I10 = 35.89, I15 = 50.77, I20 = 63.92 },
                new PensaoPorMorte { Idade = 39, I10 = 35.89, I15 = 50.77, I20 = 63.92 },
                new PensaoPorMorte { Idade = 40, I10 = 35.89, I15 = 50.77, I20 = 63.92 },
                new PensaoPorMorte { Idade = 41, I10 = 53.83, I15 = 76.16, I20 = 95.89 },
                new PensaoPorMorte { Idade = 42, I10 = 53.83, I15 = 76.16, I20 = 95.89 },
                new PensaoPorMorte { Idade = 43, I10 = 53.83, I15 = 76.16, I20 = 95.89 },
                new PensaoPorMorte { Idade = 44, I10 = 53.83, I15 = 76.16, I20 = 95.89 },
                new PensaoPorMorte { Idade = 45, I10 = 53.83, I15 = 76.16, I20 = 95.89 },
                new PensaoPorMorte { Idade = 46, I10 = 79.84, I15 = 112.95, I20 = 142.22 },
                new PensaoPorMorte { Idade = 47, I10 = 79.84, I15 = 112.95, I20 = 142.22 },
                new PensaoPorMorte { Idade = 48, I10 = 79.84, I15 = 112.95, I20 = 142.22 },
                new PensaoPorMorte { Idade = 49, I10 = 79.84, I15 = 112.95, I20 = 142.22 },
                new PensaoPorMorte { Idade = 50, I10 = 79.84, I15 = 112.95, I20 = 142.22 },
                new PensaoPorMorte { Idade = 51, I10 = 121.16, I15 = 171.4, I20 = 215.81 },
                new PensaoPorMorte { Idade = 52, I10 = 121.16, I15 = 171.4, I20 = 215.81 },
                new PensaoPorMorte { Idade = 53, I10 = 121.16, I15 = 171.4, I20 = 215.81 },
                new PensaoPorMorte { Idade = 54, I10 = 121.16, I15 = 171.4, I20 = 215.81 },
                new PensaoPorMorte { Idade = 55, I10 = 121.16, I15 = 171.4, I20 = 215.81 },
                new PensaoPorMorte { Idade = 56, I10 = 189.04, I15 = 267.43, I20 = 336.72 },
                new PensaoPorMorte { Idade = 57, I10 = 189.04, I15 = 267.43, I20 = 336.72 },
                new PensaoPorMorte { Idade = 58, I10 = 189.04, I15 = 267.43, I20 = 336.72 },
                new PensaoPorMorte { Idade = 59, I10 = 189.04, I15 = 267.43, I20 = 336.72 },
                new PensaoPorMorte { Idade = 60, I10 = 189.04, I15 = 267.43, I20 = 336.72 },
                new PensaoPorMorte { Idade = 61, I10 = 243.98, I15 = 345.16, I20 = 434.58 },
                new PensaoPorMorte { Idade = 62, I10 = 266.94, I15 = 377.63, I20 = 475.46 },
                new PensaoPorMorte { Idade = 63, I10 = 292.95, I15 = 414.43, I20 = 521.8 },
                new PensaoPorMorte { Idade = 64, I10 = 321.88, I15 = 455.36, I20 = 573.33 },
                new PensaoPorMorte { Idade = 65, I10 = 353.6, I15 = 500.22, I20 = 629.82 },
                new PensaoPorMorte { Idade = 66, I10 = 387.4, I15 = 548.04, I20 = 690.03 },
                new PensaoPorMorte { Idade = 67, I10 = 423.42, I15 = 599.01, I20 = 754.2 },
                new PensaoPorMorte { Idade = 68, I10 = 461.68, I15 = 653.13, I20 = 822.34 },
                new PensaoPorMorte { Idade = 69, I10 = 503.13, I15 = 711.77, I20 = 896.17 },
                new PensaoPorMorte { Idade = 70, I10 = 549.59, I15 = 777.49, I20 = 978.93 },
                new PensaoPorMorte { Idade = 71, I10 = 602.31, I15 = 852.07, I20 = 1072.73 },
                new PensaoPorMorte { Idade = 72, I10 = 662.82, I15 = 937.68, I20 = 1180.61 },
                new PensaoPorMorte { Idade = 73, I10 = 732.23, I15 = 1035.87, I20 = 1304.25 },
                new PensaoPorMorte { Idade = 74, I10 = 809.43, I15 = 1145.09, I20 = 1441.76 },
                new PensaoPorMorte { Idade = 75, I10 = 892.89, I15 = 1263.16, I20 = 1590.42 },
                new PensaoPorMorte { Idade = 76, I10 = 981.08, I15 = 1387.92, I20 = 1747.5 },
                new PensaoPorMorte { Idade = 77, I10 = 1072.75, I15 = 1517.6, I20 = 1910.78 },
                new PensaoPorMorte { Idade = 78, I10 = 1167.06, I15 = 1651.02, I20 = 2078.77 },
                new PensaoPorMorte { Idade = 79, I10 = 1266.52, I15 = 1791.72, I20 = 2255.92 },
                new PensaoPorMorte { Idade = 80, I10 = 1374.88, I15 = 1945.01, I20 = 2448.93 }
            };
        }
    }
}
