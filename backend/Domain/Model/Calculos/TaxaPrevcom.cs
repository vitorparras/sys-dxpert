﻿using Domain.Model.Bases;
using Microsoft.EntityFrameworkCore;

namespace Domain.Model.Calculos
{
    public class TaxaPrevcom : BaseEntity
    {
        public int Idade { get; set; }
        public double Morte { get; set; }
        public double Invalidez { get; set; }
        public double PercentualReajusteMorte { get; set; }
        public double PercentualReajusteInvalidez { get; set; }

        public static List<TaxaPrevcom> GetDados()
        {
            return new List<TaxaPrevcom>() {
                new TaxaPrevcom { Idade = 14, Morte = 0.0000560, Invalidez = 0.0000691, PercentualReajusteMorte = 0, PercentualReajusteInvalidez = 0 },
                new TaxaPrevcom { Idade = 15, Morte = 0.0000560, Invalidez = 0.0000691, PercentualReajusteMorte = 0, PercentualReajusteInvalidez = 0 },
                new TaxaPrevcom { Idade = 16, Morte = 0.0000560, Invalidez = 0.0000691, PercentualReajusteMorte = 0, PercentualReajusteInvalidez = 0 },
                new TaxaPrevcom { Idade = 17, Morte = 0.0000560, Invalidez = 0.0000691, PercentualReajusteMorte = 0, PercentualReajusteInvalidez = 0 },
                new TaxaPrevcom { Idade = 18, Morte = 0.0000560, Invalidez = 0.0000691, PercentualReajusteMorte = 0, PercentualReajusteInvalidez = 0 },
                new TaxaPrevcom { Idade = 19, Morte = 0.0000560, Invalidez = 0.0000691, PercentualReajusteMorte = 0, PercentualReajusteInvalidez = 0 },
                new TaxaPrevcom { Idade = 20, Morte = 0.0000560, Invalidez = 0.0000691, PercentualReajusteMorte = 0, PercentualReajusteInvalidez = 0 },
                new TaxaPrevcom { Idade = 21, Morte = 0.0000560, Invalidez = 0.0000691, PercentualReajusteMorte = 0, PercentualReajusteInvalidez = 0 },
                new TaxaPrevcom { Idade = 22, Morte = 0.0000560, Invalidez = 0.0000691, PercentualReajusteMorte = 0, PercentualReajusteInvalidez = 0 },
                new TaxaPrevcom { Idade = 23, Morte = 0.0000560, Invalidez = 0.0000691, PercentualReajusteMorte = 0, PercentualReajusteInvalidez = 0 },
                new TaxaPrevcom { Idade = 24, Morte = 0.0000560, Invalidez = 0.0000691, PercentualReajusteMorte = 0, PercentualReajusteInvalidez = 0 },
                new TaxaPrevcom { Idade = 25, Morte = 0.0000560, Invalidez = 0.0000691, PercentualReajusteMorte = 0, PercentualReajusteInvalidez = 0 },
                new TaxaPrevcom { Idade = 26, Morte = 0.0000560, Invalidez = 0.0000691, PercentualReajusteMorte = 0, PercentualReajusteInvalidez = 0 },
                new TaxaPrevcom { Idade = 27, Morte = 0.0000560, Invalidez = 0.0000691, PercentualReajusteMorte = 0, PercentualReajusteInvalidez = 0 },
                new TaxaPrevcom { Idade = 28, Morte = 0.0000560, Invalidez = 0.0000691, PercentualReajusteMorte = 0, PercentualReajusteInvalidez = 0 },
                new TaxaPrevcom { Idade = 29, Morte = 0.0000560, Invalidez = 0.0000691, PercentualReajusteMorte = 0, PercentualReajusteInvalidez = 0 },
                new TaxaPrevcom { Idade = 30, Morte = 0.0000560, Invalidez = 0.0000691, PercentualReajusteMorte = 0, PercentualReajusteInvalidez = 0 },
                new TaxaPrevcom { Idade = 31, Morte = 0.0000560, Invalidez = 0.0000691, PercentualReajusteMorte = 0, PercentualReajusteInvalidez = 0 },
                new TaxaPrevcom { Idade = 32, Morte = 0.0000560, Invalidez = 0.0000691, PercentualReajusteMorte = 0, PercentualReajusteInvalidez = 0 },
                new TaxaPrevcom { Idade = 33, Morte = 0.0000560, Invalidez = 0.0000691, PercentualReajusteMorte = 0, PercentualReajusteInvalidez = 0 },
                new TaxaPrevcom { Idade = 34, Morte = 0.0000560, Invalidez = 0.0000691, PercentualReajusteMorte = 0, PercentualReajusteInvalidez = 0 },
                new TaxaPrevcom { Idade = 35, Morte = 0.0000560, Invalidez = 0.0000691, PercentualReajusteMorte = 0, PercentualReajusteInvalidez = 0 },
                new TaxaPrevcom { Idade = 36, Morte = 0.0000921, Invalidez = 0.0000905, PercentualReajusteMorte = 64.55, PercentualReajusteInvalidez = 31.05 },
                new TaxaPrevcom { Idade = 37, Morte = 0.0000921, Invalidez = 0.0000905, PercentualReajusteMorte = 64.55, PercentualReajusteInvalidez = 31.05 },
                new TaxaPrevcom { Idade = 38, Morte = 0.0000921, Invalidez = 0.0000905, PercentualReajusteMorte = 64.55, PercentualReajusteInvalidez = 31.05 },
                new TaxaPrevcom { Idade = 39, Morte = 0.0000921, Invalidez = 0.0000905, PercentualReajusteMorte = 64.55, PercentualReajusteInvalidez = 31.05 },
                new TaxaPrevcom { Idade = 40, Morte = 0.0000921, Invalidez = 0.0000905, PercentualReajusteMorte = 64.55, PercentualReajusteInvalidez = 31.05 },
                new TaxaPrevcom { Idade = 41, Morte = 0.0001559, Invalidez = 0.0001201, PercentualReajusteMorte = 69.30, PercentualReajusteInvalidez = 32.72 },
                new TaxaPrevcom { Idade = 42, Morte = 0.0001559, Invalidez = 0.0001201, PercentualReajusteMorte = 69.30, PercentualReajusteInvalidez = 32.72 },
                new TaxaPrevcom { Idade = 43, Morte = 0.0001559, Invalidez = 0.0001201, PercentualReajusteMorte = 69.30, PercentualReajusteInvalidez = 32.72 },
                new TaxaPrevcom { Idade = 44, Morte = 0.0001559, Invalidez = 0.0001201, PercentualReajusteMorte = 69.30, PercentualReajusteInvalidez = 32.72 },
                new TaxaPrevcom { Idade = 45, Morte = 0.0001559, Invalidez = 0.0001201, PercentualReajusteMorte = 69.30, PercentualReajusteInvalidez = 32.72 },
                new TaxaPrevcom { Idade = 46, Morte = 0.0002764, Invalidez = 0.0001790, PercentualReajusteMorte = 77.25, PercentualReajusteInvalidez = 49.01 },
                new TaxaPrevcom { Idade = 47, Morte = 0.0002764, Invalidez = 0.0001790, PercentualReajusteMorte = 77.25, PercentualReajusteInvalidez = 49.01 },
                new TaxaPrevcom { Idade = 48, Morte = 0.0002764, Invalidez = 0.0001790, PercentualReajusteMorte = 77.25, PercentualReajusteInvalidez = 49.01 },
                new TaxaPrevcom { Idade = 49, Morte = 0.0002764, Invalidez = 0.0001790, PercentualReajusteMorte = 77.25, PercentualReajusteInvalidez = 49.01 },
                new TaxaPrevcom { Idade = 50, Morte = 0.0002764, Invalidez = 0.0001790, PercentualReajusteMorte = 77.25, PercentualReajusteInvalidez = 49.01 },
                new TaxaPrevcom { Idade = 51, Morte = 0.0004297, Invalidez = 0.0002936, PercentualReajusteMorte = 55.49, PercentualReajusteInvalidez = 64.06 },
                new TaxaPrevcom { Idade = 52, Morte = 0.0004297, Invalidez = 0.0002936, PercentualReajusteMorte = 55.49, PercentualReajusteInvalidez = 64.06 },
                new TaxaPrevcom { Idade = 53, Morte = 0.0004297, Invalidez = 0.0002936, PercentualReajusteMorte = 55.49, PercentualReajusteInvalidez = 64.06 },
                new TaxaPrevcom { Idade = 54, Morte = 0.0004297, Invalidez = 0.0002936, PercentualReajusteMorte = 55.49, PercentualReajusteInvalidez = 64.06 },
                new TaxaPrevcom { Idade = 55, Morte = 0.0004297, Invalidez = 0.0002936, PercentualReajusteMorte = 55.49, PercentualReajusteInvalidez = 64.06 },
                new TaxaPrevcom { Idade = 56, Morte = 0.0006027, Invalidez = 0.0005153, PercentualReajusteMorte = 40.25, PercentualReajusteInvalidez = 75.47 },
                new TaxaPrevcom { Idade = 57, Morte = 0.0006027, Invalidez = 0.0005153, PercentualReajusteMorte = 40.25, PercentualReajusteInvalidez = 75.47 },
                new TaxaPrevcom { Idade = 58, Morte = 0.0006027, Invalidez = 0.0005153, PercentualReajusteMorte = 40.25, PercentualReajusteInvalidez = 75.47 },
                new TaxaPrevcom { Idade = 59, Morte = 0.0006027, Invalidez = 0.0005153, PercentualReajusteMorte = 40.25, PercentualReajusteInvalidez = 75.47 },
                new TaxaPrevcom { Idade = 60, Morte = 0.0006027, Invalidez = 0.0005153, PercentualReajusteMorte = 40.25, PercentualReajusteInvalidez = 75.47 },
                new TaxaPrevcom { Idade = 61, Morte = 0.0008788, Invalidez = 0.0009413, PercentualReajusteMorte = 45.82, PercentualReajusteInvalidez = 82.69 },
                new TaxaPrevcom { Idade = 62, Morte = 0.0008788, Invalidez = 0.0009413, PercentualReajusteMorte = 45.82, PercentualReajusteInvalidez = 82.69 },
                new TaxaPrevcom { Idade = 63, Morte = 0.0008788, Invalidez = 0.0009413, PercentualReajusteMorte = 45.82, PercentualReajusteInvalidez = 82.69 },
                new TaxaPrevcom { Idade = 64, Morte = 0.0008788, Invalidez = 0.0009413, PercentualReajusteMorte = 45.82, PercentualReajusteInvalidez = 82.69 },
                new TaxaPrevcom { Idade = 65, Morte = 0.0008788, Invalidez = 0.0009413, PercentualReajusteMorte = 45.82, PercentualReajusteInvalidez = 82.69 },
                new TaxaPrevcom { Idade = 66, Morte = 0.0011739, Invalidez = 0.0013672, PercentualReajusteMorte = 33.57, PercentualReajusteInvalidez = 45.24 },
                new TaxaPrevcom { Idade = 67, Morte = 0.0012994, Invalidez = 0.0015502, PercentualReajusteMorte = 10.69, PercentualReajusteInvalidez = 13.39 },
                new TaxaPrevcom { Idade = 68, Morte = 0.0014397, Invalidez = 0.0017587, PercentualReajusteMorte = 10.80, PercentualReajusteInvalidez = 13.45 },
                new TaxaPrevcom { Idade = 69, Morte = 0.0015953, Invalidez = 0.0019962, PercentualReajusteMorte = 10.81, PercentualReajusteInvalidez = 13.50 },
                new TaxaPrevcom { Idade = 70, Morte = 0.0017668, Invalidez = 0.0022666, PercentualReajusteMorte = 10.82, PercentualReajusteInvalidez = 13.56 },
                new TaxaPrevcom { Idade = 71, Morte = 0.0019550, Invalidez = 0.0025755, PercentualReajusteMorte = 10.83, PercentualReajusteInvalidez = 13.61 },
                new TaxaPrevcom { Idade = 72, Morte = 0.0021609, Invalidez = 0.0029322, PercentualReajusteMorte = 10.84, PercentualReajusteInvalidez = 13.67 },
                new TaxaPrevcom { Idade = 73, Morte = 0.0023856, Invalidez = 0.0033465, PercentualReajusteMorte = 10.85, PercentualReajusteInvalidez = 13.72 },
                new TaxaPrevcom { Idade = 74, Morte = 0.0026304, Invalidez = 0.0038302, PercentualReajusteMorte = 10.86, PercentualReajusteInvalidez = 13.78 },
                new TaxaPrevcom { Idade = 75, Morte = 0.0028968, Invalidez = 0.0043975, PercentualReajusteMorte = 10.87, PercentualReajusteInvalidez = 13.83 },
                new TaxaPrevcom { Idade = 76, Morte = 0.0031862, Invalidez = 0.0050660, PercentualReajusteMorte = 10.88, PercentualReajusteInvalidez = 13.89 },
                new TaxaPrevcom { Idade = 77, Morte = 0.0035005, Invalidez = 0.0058569, PercentualReajusteMorte = 10.89, PercentualReajusteInvalidez = 13.94 },
                new TaxaPrevcom { Idade = 78, Morte = 0.0038417, Invalidez = 0.0067953, PercentualReajusteMorte = 10.90, PercentualReajusteInvalidez = 14.00 },
                new TaxaPrevcom { Idade = 79, Morte = 0.0042124, Invalidez = 0.0079105, PercentualReajusteMorte = 10.91, PercentualReajusteInvalidez = 14.05 },
                new TaxaPrevcom { Idade = 80, Morte = 0.0046153, Invalidez = 0.0092357, PercentualReajusteMorte = 10.92, PercentualReajusteInvalidez = 14.11 },
                new TaxaPrevcom { Idade = 80, Morte = 0.0046153, Invalidez = 0.0092357, PercentualReajusteMorte = 10.92, PercentualReajusteInvalidez = 14.11 },
                new TaxaPrevcom { Idade = 81, Morte = 0.0050640, Invalidez = 0.0109974, PercentualReajusteMorte = 10.93, PercentualReajusteInvalidez = 14.16 },
                new TaxaPrevcom { Idade = 82, Morte = 0.0055639, Invalidez = 0.0129153, PercentualReajusteMorte = 10.94, PercentualReajusteInvalidez = 14.22 },
                new TaxaPrevcom { Idade = 83, Morte = 0.0061222, Invalidez = 0.0150052, PercentualReajusteMorte = 10.95, PercentualReajusteInvalidez = 14.28 },
                new TaxaPrevcom { Idade = 84, Morte = 0.0067468, Invalidez = 0.0172843, PercentualReajusteMorte = 10.96, PercentualReajusteInvalidez = 14.34 },
                new TaxaPrevcom { Idade = 85, Morte = 0.0074454, Invalidez = 0.0197691, PercentualReajusteMorte = 10.97, PercentualReajusteInvalidez = 14.40 },
                new TaxaPrevcom { Idade = 86, Morte = 0.0082265, Invalidez = 0.0224771, PercentualReajusteMorte = 10.98, PercentualReajusteInvalidez = 14.46 },
                new TaxaPrevcom { Idade = 87, Morte = 0.0090995, Invalidez = 0.0254262, PercentualReajusteMorte = 10.99, PercentualReajusteInvalidez = 14.52 },
                new TaxaPrevcom { Idade = 88, Morte = 0.0100742, Invalidez = 0.0286353, PercentualReajusteMorte = 11.00, PercentualReajusteInvalidez = 14.58 },
                new TaxaPrevcom { Idade = 89, Morte = 0.0111616, Invalidez = 0.0321241, PercentualReajusteMorte = 11.01, PercentualReajusteInvalidez = 14.64 },
                new TaxaPrevcom { Idade = 90, Morte = 0.0123725, Invalidez = 0.0359136, PercentualReajusteMorte = 11.02, PercentualReajusteInvalidez = 14.70 },
                new TaxaPrevcom { Idade = 91, Morte = 0.0137191, Invalidez = 0.0400249, PercentualReajusteMorte = 11.03, PercentualReajusteInvalidez = 14.76 },
                new TaxaPrevcom { Idade = 92, Morte = 0.0152139, Invalidez = 0.0444790, PercentualReajusteMorte = 11.04, PercentualReajusteInvalidez = 14.82 },
                new TaxaPrevcom { Idade = 93, Morte = 0.0168693, Invalidez = 0.0492975, PercentualReajusteMorte = 11.05, PercentualReajusteInvalidez = 14.88 },
                new TaxaPrevcom { Idade = 94, Morte = 0.0186988, Invalidez = 0.0545029, PercentualReajusteMorte = 11.06, PercentualReajusteInvalidez = 14.94 },
                new TaxaPrevcom { Idade = 95, Morte = 0.0207167, Invalidez = 0.0601179, PercentualReajusteMorte = 11.07, PercentualReajusteInvalidez = 15.00 },
                new TaxaPrevcom { Idade = 96, Morte = 0.0229384, Invalidez = 0.0661641, PercentualReajusteMorte = 11.08, PercentualReajusteInvalidez = 15.06 },
                new TaxaPrevcom { Idade = 97, Morte = 0.0253806, Invalidez = 0.0726630, PercentualReajusteMorte = 11.09, PercentualReajusteInvalidez = 15.12 },
                new TaxaPrevcom { Idade = 98, Morte = 0.0280592, Invalidez = 0.0796353, PercentualReajusteMorte = 11.10, PercentualReajusteInvalidez = 15.18 },
                new TaxaPrevcom { Idade = 99, Morte = 0.0309904, Invalidez = 0.0871006, PercentualReajusteMorte = 11.11, PercentualReajusteInvalidez = 15.24 },
                new TaxaPrevcom { Idade = 100, Morte = 0.0341896, Invalidez = 0.0950778, PercentualReajusteMorte = 11.12, PercentualReajusteInvalidez = 15.30 },
                new TaxaPrevcom { Idade = 101, Morte = 0.0376726, Invalidez = 0.1035830, PercentualReajusteMorte = 11.13, PercentualReajusteInvalidez = 15.36 },
                new TaxaPrevcom { Idade = 102, Morte = 0.0414541, Invalidez = 0.1126310, PercentualReajusteMorte = 11.14, PercentualReajusteInvalidez = 15.42 },
                new TaxaPrevcom { Idade = 103, Morte = 0.0455483, Invalidez = 0.1222369, PercentualReajusteMorte = 11.15, PercentualReajusteInvalidez = 15.48 },
                new TaxaPrevcom { Idade = 104, Morte = 0.0499681, Invalidez = 0.1324138, PercentualReajusteMorte = 11.16, PercentualReajusteInvalidez = 15.54 },
                new TaxaPrevcom { Idade = 105, Morte = 0.0547258, Invalidez = 0.1431735, PercentualReajusteMorte = 11.17, PercentualReajusteInvalidez = 15.60 },
                new TaxaPrevcom { Idade = 106, Morte = 0.0598327, Invalidez = 0.1545269, PercentualReajusteMorte = 11.18, PercentualReajusteInvalidez = 15.66 },
                new TaxaPrevcom { Idade = 107, Morte = 0.0652998, Invalidez = 0.1664838, PercentualReajusteMorte = 11.19, PercentualReajusteInvalidez = 15.72 },
                new TaxaPrevcom { Idade = 108, Morte = 0.0711372, Invalidez = 0.1790530, PercentualReajusteMorte = 11.20, PercentualReajusteInvalidez = 15.78 },
                new TaxaPrevcom { Idade = 109, Morte = 0.0773541, Invalidez = 0.1922429, PercentualReajusteMorte = 11.21, PercentualReajusteInvalidez = 15.84 },
                new TaxaPrevcom { Idade = 110, Morte = 0.0839597, Invalidez = 0.2060610, PercentualReajusteMorte = 11.22, PercentualReajusteInvalidez = 15.90 },
                new TaxaPrevcom { Idade = 111, Morte = 0.0909634, Invalidez = 0.2205148, PercentualReajusteMorte = 11.23, PercentualReajusteInvalidez = 15.96 },
                new TaxaPrevcom { Idade = 112, Morte = 0.0983739, Invalidez = 0.2356117, PercentualReajusteMorte = 11.24, PercentualReajusteInvalidez = 16.02 },
                new TaxaPrevcom { Idade = 113, Morte = 0.1062007, Invalidez = 0.2513588, PercentualReajusteMorte = 11.25, PercentualReajusteInvalidez = 16.08 },
                new TaxaPrevcom { Idade = 114, Morte = 0.1144529, Invalidez = 0.2677636, PercentualReajusteMorte = 11.26, PercentualReajusteInvalidez = 16.14 }
            };
        }

    }
}
