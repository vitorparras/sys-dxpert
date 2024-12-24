using Domain.Model.Bases;
using Microsoft.EntityFrameworkCore;

namespace Domain.Model.Calculos
{
    public class TermLife : BaseEntity
    {
        public int Idade { get; set; }
        public double Masculino10 { get; set; }
        public double Masculino15 { get; set; }
        public double Masculino20 { get; set; }
        public double Masculino25 { get; set; }
        public double Masculino30 { get; set; }
        public double Feminino10 { get; set; }
        public double Feminino15 { get; set; }
        public double Feminino20 { get; set; }
        public double Feminino25 { get; set; }
        public double Feminino30 { get; set; }

        public static List<TermLife> GetDados()
        {
            return new List<TermLife>() {
                    new TermLife { Idade = 25, Masculino10 = 0.0974, Masculino15 = 0.1047, Masculino20 = 0.1169, Masculino25 = 0.13763, Masculino30 = 0.17086, Feminino10 = 0.04355, Feminino15 = 0.05132, Feminino20 = 0.06272, Feminino25 = 0.08008, Feminino30 = 0.10271 },
                    new TermLife { Idade = 26, Masculino10 = 0.09868, Masculino15 = 0.1074, Masculino20 = 0.12149, Masculino25 = 0.14528, Masculino30 = 0.18266, Feminino10 = 0.04597, Feminino15 = 0.05454, Feminino20 = 0.06726, Feminino25 = 0.08653, Feminino30 = 0.11099 },
                    new TermLife { Idade = 27, Masculino10 = 0.10048, Masculino15 = 0.11076, Masculino20 = 0.12686, Masculino25 = 0.15423, Masculino30 = 0.19579, Feminino10 = 0.04868, Feminino15 = 0.05829, Feminino20 = 0.07231, Feminino25 = 0.09363, Feminino30 = 0.12013 },
                    new TermLife { Idade = 28, Masculino10 = 0.10313, Masculino15 = 0.115, Masculino20 = 0.13315, Masculino25 = 0.16467, Masculino30 = 0.2105, Feminino10 = 0.0517, Feminino15 = 0.06256, Feminino20 = 0.07797, Feminino25 = 0.10135, Feminino30 = 0.13019 },
                    new TermLife { Idade = 29, Masculino10 = 0.10647, Masculino15 = 0.12004, Masculino20 = 0.14058, Masculino25 = 0.17669, Masculino30 = 0.22661, Feminino10 = 0.05498, Feminino15 = 0.06733, Feminino20 = 0.0843, Feminino25 = 0.10969, Feminino30 = 0.14124 },
                    new TermLife { Idade = 30, Masculino10 = 0.1102, Masculino15 = 0.12579, Masculino20 = 0.14897, Masculino25 = 0.18991, Masculino30 = 0.24465, Feminino10 = 0.05864, Feminino15 = 0.07255, Feminino20 = 0.09136, Feminino25 = 0.11877, Feminino30 = 0.15336 },
                    new TermLife { Idade = 31, Masculino10 = 0.11447, Masculino15 = 0.13229, Masculino20 = 0.15877, Masculino25 = 0.20475, Masculino30 = 0.26455, Feminino10 = 0.06275, Feminino15 = 0.07828, Feminino20 = 0.09913, Feminino25 = 0.12873, Feminino30 = 0.16668 },
                    new TermLife { Idade = 32, Masculino10 = 0.1195, Masculino15 = 0.13968, Masculino20 = 0.17007, Masculino25 = 0.22112, Masculino30 = 0.28651, Feminino10 = 0.06751, Feminino15 = 0.08458, Feminino20 = 0.10765, Feminino25 = 0.13969, Feminino30 = 0.18126 },
                    new TermLife { Idade = 33, Masculino10 = 0.12549, Masculino15 = 0.14805, Masculino20 = 0.18306, Masculino25 = 0.23932, Masculino30 = 0.31028, Feminino10 = 0.07291, Feminino15 = 0.09162, Feminino20 = 0.11687, Feminino25 = 0.15174, Feminino30 = 0.19722 },
                    new TermLife { Idade = 34, Masculino10 = 0.13217, Masculino15 = 0.15764, Masculino20 = 0.19778, Masculino25 = 0.25904, Masculino30 = 0.33624, Feminino10 = 0.0789, Feminino15 = 0.09947, Feminino20 = 0.12682, Feminino25 = 0.16495, Feminino30 = 0.21452 },
                    new TermLife { Idade = 35, Masculino10 = 0.13977, Masculino15 = 0.16845, Masculino20 = 0.21398, Masculino25 = 0.28111, Masculino30 = 0.36476, Feminino10 = 0.08541, Feminino15 = 0.1082, Feminino20 = 0.13761, Feminino25 = 0.17943, Feminino30 = 0.23327 },
                    new TermLife { Idade = 36, Masculino10 = 0.14836, Masculino15 = 0.18111, Masculino20 = 0.23217, Masculino25 = 0.30547, Masculino30 = 0.39577, Feminino10 = 0.0925, Feminino15 = 0.11779, Feminino20 = 0.14942, Feminino25 = 0.19533, Feminino30 = 0.25347 },
                    new TermLife { Idade = 37, Masculino10 = 0.15805, Masculino15 = 0.19568, Masculino20 = 0.2522, Masculino25 = 0.33234, Masculino30 = 0.42943, Feminino10 = 0.10034, Feminino15 = 0.12833, Feminino20 = 0.16246, Feminino25 = 0.21277, Feminino30 = 0.27535 },
                    new TermLife { Idade = 38, Masculino10 = 0.1687, Masculino15 = 0.21223, Masculino20 = 0.27429, Masculino25 = 0.36124, Masculino30 = 0.46544, Feminino10 = 0.10918, Feminino15 = 0.13974, Feminino20 = 0.17681, Feminino25 = 0.23188, Feminino30 = 0.29903 },
                    new TermLife { Idade = 39, Masculino10 = 0.18106, Masculino15 = 0.23108, Masculino20 = 0.29828, Masculino25 = 0.39287, Masculino30 = 0.50485, Feminino10 = 0.11918, Feminino15 = 0.1521, Feminino20 = 0.19261, Feminino25 = 0.25264, Feminino30 = 0.32484 },
                    new TermLife { Idade = 40, Masculino10 = 0.1951, Masculino15 = 0.25185, Masculino20 = 0.32519, Masculino25 = 0.42769, Masculino30 = 0.54757, Feminino10 = 0.13034, Feminino15 = 0.16547, Feminino20 = 0.20994, Feminino25 = 0.27515, Feminino30 = 0.35291 },
                    new TermLife { Idade = 41, Masculino10 = 0.21159, Masculino15 = 0.27512, Masculino20 = 0.35488, Masculino25 = 0.46552, Masculino30 = 0.59447, Feminino10 = 0.14251, Feminino15 = 0.18008, Feminino20 = 0.22893, Feminino25 = 0.29937, Feminino30 = 0.38347 },
                    new TermLife { Idade = 42, Masculino10 = 0.23051, Masculino15 = 0.30059, Masculino20 = 0.38753, Masculino25 = 0.50651, Masculino30 = 0.64607, Feminino10 = 0.15556, Feminino15 = 0.19596, Feminino20 = 0.24958, Feminino25 = 0.32547, Feminino30 = 0.41648 },
                    new TermLife { Idade = 43, Masculino10 = 0.25197, Masculino15 = 0.32861, Masculino20 = 0.4226, Masculino25 = 0.55033, Masculino30 = 0.70335, Feminino10 = 0.16938, Feminino15 = 0.21328, Feminino20 = 0.27209, Feminino25 = 0.35363, Feminino30 = 0.45235 },
                    new TermLife { Idade = 44, Masculino10 = 0.27647, Masculino15 = 0.35891, Masculino20 = 0.46095, Masculino25 = 0.59832, Masculino30 = 0.76709, Feminino10 = 0.18411, Feminino15 = 0.23223, Feminino20 = 0.29644, Feminino25 = 0.38425, Feminino30 = 0.49123 },
                    new TermLife { Idade = 45, Masculino10 = 0.30317, Masculino15 = 0.39278, Masculino20 = 0.50307, Masculino25 = 0.65028, Masculino30 = 0.83709, Feminino10 = 0.20006, Feminino15 = 0.25306, Feminino20 = 0.3229, Feminino25 = 0.41761, Feminino30 = 0.53425 },
                    new TermLife { Idade = 46, Masculino10 = 0.33314, Masculino15 = 0.4301, Masculino20 = 0.54885, Masculino25 = 0.70736, Masculino30 = 0.91163, Feminino10 = 0.2176, Feminino15 = 0.27602, Feminino20 = 0.35143, Feminino25 = 0.45404, Feminino30 = 0.58173 },
                    new TermLife { Idade = 47, Masculino10 = 0.36594, Masculino15 = 0.47119, Masculino20 = 0.59849, Masculino25 = 0.77027, Masculino30 = 0.99261, Feminino10 = 0.23693, Feminino15 = 0.30119, Feminino20 = 0.38232, Feminino25 = 0.49353, Feminino30 = 0.63434 },
                    new TermLife { Idade = 48, Masculino10 = 0.4022, Masculino15 = 0.51537, Masculino20 = 0.65169, Masculino25 = 0.84032, Masculino30 = 1.08068, Feminino10 = 0.25797, Feminino15 = 0.32859, Feminino20 = 0.41562, Feminino25 = 0.53643, Feminino30 = 0.69173 },
                    new TermLife { Idade = 49, Masculino10 = 0.44067, Masculino15 = 0.56323, Masculino20 = 0.70966, Masculino25 = 0.91812, Masculino30 = 1.17714, Feminino10 = 0.28079, Feminino15 = 0.35807, Feminino20 = 0.45176, Feminino25 = 0.58285, Feminino30 = 0.75489 },
                    new TermLife { Idade = 50, Masculino10 = 0.4837, Masculino15 = 0.61573, Masculino20 = 0.77242, Masculino25 = 1.00363, Masculino30 = 1.28021, Feminino10 = 0.30555, Feminino15 = 0.38983, Feminino20 = 0.49096, Feminino25 = 0.63411, Feminino30 = 0.82442 },
                    new TermLife { Idade = 51, Masculino10 = 0.52994, Masculino15 = 0.67188, Masculino20 = 0.84075, Masculino25 = 1.09411, Masculino30 = 1.39275, Feminino10 = 0.33277, Feminino15 = 0.42392, Feminino20 = 0.5337, Feminino25 = 0.69068, Feminino30 = 0.9014 },
                    new TermLife { Idade = 52, Masculino10 = 0.57986, Masculino15 = 0.73199, Masculino20 = 0.9155, Masculino25 = 1.19198, Masculino30 = 1.51433, Feminino10 = 0.36262, Feminino15 = 0.46078, Feminino20 = 0.58001, Feminino25 = 0.75344, Feminino30 = 0.98689 },
                    new TermLife { Idade = 53, Masculino10 = 0.63209, Masculino15 = 0.79541, Masculino20 = 0.99818, Masculino25 = 1.29796, Masculino30 = 1.64597, Feminino10 = 0.39567, Feminino15 = 0.50086, Feminino20 = 0.63059, Feminino25 = 0.82218, Feminino30 = 1.08221 },
                    new TermLife { Idade = 54, Masculino10 = 0.68795, Masculino15 = 0.86414, Masculino20 = 1.08981, Masculino25 = 1.41393, Masculino30 = 1.78603, Feminino10 = 0.43179, Feminino15 = 0.54482, Feminino20 = 0.68563, Feminino25 = 0.89823, Feminino30 = 1.18781 },
                    new TermLife { Idade = 55, Masculino10 = 0.74966, Masculino15 = 0.93873, Masculino20 = 1.19083, Masculino25 = 1.53794, Masculino30 = 1.93541, Feminino10 = 0.47111, Feminino15 = 0.59293, Feminino20 = 0.74674, Feminino25 = 0.98224, Feminino30 = 1.30358 },
                    new TermLife { Idade = 56, Masculino10 = 0.81559, Masculino15 = 1.02021, Masculino20 = 1.29766, Masculino25 = 1.67368, Masculino30 = 0, Feminino10 = 0.5131, Feminino15 = 0.64536, Feminino20 = 0.81414, Feminino25 = 1.07532, Feminino30 = 0 },
                    new TermLife { Idade = 57, Masculino10 = 0.88684, Masculino15 = 1.11016, Masculino20 = 1.41377, Masculino25 = 1.82094, Masculino30 = 0, Feminino10 = 0.55817, Feminino15 = 0.70185, Feminino20 = 0.88877, Feminino25 = 1.17867, Feminino30 = 0 },
                    new TermLife { Idade = 58, Masculino10 = 0.96403, Masculino15 = 1.20967, Masculino20 = 1.54678, Masculino25 = 2.00162, Masculino30 = 0, Feminino10 = 0.60667, Feminino15 = 0.76273, Feminino20 = 0.9712, Feminino25 = 1.29196, Feminino30 = 0 },
                    new TermLife { Idade = 59, Masculino10 = 1.04749, Masculino15 = 1.31945, Masculino20 = 1.69342, Masculino25 = 2.19235, Masculino30 = 0, Feminino10 = 0.65909, Feminino15 = 0.82938, Feminino20 = 1.06098, Feminino25 = 1.41415, Feminino30 = 0 },
                    new TermLife { Idade = 60, Masculino10 = 1.13776, Masculino15 = 1.44177, Masculino20 = 1.85784, Masculino25 = 2.40891, Masculino30 = 0, Feminino10 = 0.71592, Feminino15 = 0.90051, Feminino20 = 1.15364, Feminino25 = 1.54642, Feminino30 = 0 },
                    new TermLife { Idade = 61, Masculino10 = 1.22991, Masculino15 = 1.57536, Masculino20 = 1.98696, Masculino25 = 0, Masculino30 = 0, Feminino10 = 0.77712, Feminino15 = 0.98147, Feminino20 = 1.26666, Feminino25 = 0, Feminino30 = 0 },
                    new TermLife { Idade = 62, Masculino10 = 1.33569, Masculino15 = 1.71465, Masculino20 = 2.16068, Masculino25 = 0, Masculino30 = 0, Feminino10 = 0.84262, Feminino15 = 1.06973, Feminino20 = 1.387, Feminino25 = 0, Feminino30 = 0 },
                    new TermLife { Idade = 63, Masculino10 = 1.45584, Masculino15 = 1.86646, Masculino20 = 2.34979, Masculino25 = 0, Masculino30 = 0, Feminino10 = 0.91282, Feminino15 = 1.16526, Feminino20 = 1.52049, Feminino25 = 0, Feminino30 = 0 },
                    new TermLife { Idade = 64, Masculino10 = 1.59051, Masculino15 = 2.03262, Masculino20 = 2.55024, Masculino25 = 0, Masculino30 = 0, Feminino10 = 0.98806, Feminino15 = 1.2703, Feminino20 = 1.66777, Feminino25 = 0, Feminino30 = 0 },
                    new TermLife { Idade = 65, Masculino10 = 1.73719, Masculino15 = 2.2069, Masculino20 = 2.76131, Masculino25 = 0, Masculino30 = 0, Feminino10 = 1.07133, Feminino15 = 1.38548, Feminino20 = 1.82809, Feminino25 = 0, Feminino30 = 0 },
                    new TermLife { Idade = 66, Masculino10 = 1.88921, Masculino15 = 2.39707, Masculino20 = 0, Masculino25 = 0, Masculino30 = 0, Feminino10 = 1.16335, Feminino15 = 1.51271, Feminino20 = 0, Feminino25 = 0, Feminino30 = 0 },
                    new TermLife { Idade = 67, Masculino10 = 2.05208, Masculino15 = 2.6008, Masculino20 = 0, Masculino25 = 0, Masculino30 = 0, Feminino10 = 1.26501, Feminino15 = 1.65301, Feminino20 = 0, Feminino25 = 0, Feminino30 = 0 },
                    new TermLife { Idade = 68, Masculino10 = 2.22818, Masculino15 = 2.82061, Masculino20 = 0, Masculino25 = 0, Masculino30 = 0, Feminino10 = 1.37394, Feminino15 = 1.80774, Feminino20 = 0, Feminino25 = 0, Feminino30 = 0 },
                    new TermLife { Idade = 69, Masculino10 = 2.41683, Masculino15 = 3.04771, Masculino20 = 0, Masculino25 = 0, Masculino30 = 0, Feminino10 = 1.4912, Feminino15 = 1.97565, Feminino20 = 0, Feminino25 = 0, Feminino30 = 0 },
                    new TermLife { Idade = 70, Masculino10 = 2.60939, Masculino15 = 3.2815, Masculino20 = 0, Masculino25 = 0, Masculino30 = 0, Feminino10 = 1.61653, Feminino15 = 2.15429, Feminino20 = 0, Feminino25 = 0, Feminino30 = 0 },
                    new TermLife { Idade = 71, Masculino10 = 2.86828, Masculino15 = 0, Masculino20 = 0, Masculino25 = 0, Masculino30 = 0, Feminino10 = 1.78593, Feminino15 = 0, Feminino20 = 0, Feminino25 = 0, Feminino30 = 0 },
                    new TermLife { Idade = 72, Masculino10 = 3.15272, Masculino15 = 0, Masculino20 = 0, Masculino25 = 0, Masculino30 = 0, Feminino10 = 1.98053, Feminino15 = 0, Feminino20 = 0, Feminino25 = 0, Feminino30 = 0 },
                    new TermLife { Idade = 73, Masculino10 = 3.46399, Masculino15 = 0, Masculino20 = 0, Masculino25 = 0, Masculino30 = 0, Feminino10 = 2.2046, Feminino15 = 0, Feminino20 = 0, Feminino25 = 0, Feminino30 = 0 },
                    new TermLife { Idade = 74, Masculino10 = 3.79505, Masculino15 = 0, Masculino20 = 0, Masculino25 = 0, Masculino30 = 0, Feminino10 = 2.46169, Feminino15 = 0, Feminino20 = 0, Feminino25 = 0, Feminino30 = 0 },
                    new TermLife { Idade = 75, Masculino10 = 4.15114, Masculino15 = 0, Masculino20 = 0, Masculino25 = 0, Masculino30 = 0, Feminino10 = 2.749, Feminino15 = 0, Feminino20 = 0, Feminino25 = 0, Feminino30 = 0 }
            };
        }
    }
}
