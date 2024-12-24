namespace Domain.Calculos
{
    public class TaxasPrevcomDTO
    {
        public TaxasPrevcomDTO() { }

        public TaxasPrevcomDTO(int idade, double morte, double invalidez)
        {
            Idade = idade;
            Morte = morte;
            Invalidez = invalidez;
        }

        public int Idade { get; set; }
        public double Morte { get; set; }
        public double Invalidez { get; set; }

    }
}
