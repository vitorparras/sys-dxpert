using Domain.Model;
using Domain.Model.Calculos;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DxContext : DbContext
    {
        public DxContext(DbContextOptions<DxContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var conexao = "Server=localhost;Port=3333;User Id=root;Password=root;Database=DXPERT_BANCO";
                optionsBuilder
                  .UseMySql(conexao, ServerVersion.AutoDetect(conexao))
                  .EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AdicionalDiariaInternacaoHospitalar.InsertData(modelBuilder);
            DiariaIncapacidadeTemporariaAcidente.InsertData(modelBuilder);
            DiariaInternacaoHospitalar.InsertData(modelBuilder);
            DitMedico.InsertData(modelBuilder);
            DoencasGraves.InsertData(modelBuilder);
            DoencasGravesMaster.InsertData(modelBuilder);
            InvalidezAcidenteMajorada.InsertData(modelBuilder);
            InvalidezAcidenteMajoradaDoenca.InsertData(modelBuilder);
            InvalidezTotalAcidente.InsertData(modelBuilder);
            MortePorAcidente.InsertData(modelBuilder);
            PensaoPorMorte.InsertData(modelBuilder);
            PrazoCerto.InsertData(modelBuilder);
            RendaInvalidez.InsertData(modelBuilder);
            SafLuxo.InsertData(modelBuilder);
            SafSuperLuxo.InsertData(modelBuilder);
            SafSuperLuxoPorIdade.InsertData(modelBuilder);
            TaxaPrevcom.InsertData(modelBuilder);
            TermLife.InsertData(modelBuilder);
            VidaInteira.InsertData(modelBuilder);
            VidaInteiraConjuge.InsertData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        #region Sistema
        public DbSet<Configuracao> Configuracoes { get; set; }

        public DbSet<AuthToken> AuthToken { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Documento> Documentos { get; set; }

        public DbSet<Cadastro> Cadastros { get; set; }

        public DbSet<Beneficiarios> Beneficiarios { get; set; }

        #endregion

        #region Calculos
        public DbSet<VidaInteiraConjuge> Calculo_VidaInteiraConjuge { get; set; }

        public DbSet<VidaInteira> Calculo_VidaInteira { get; set; }

        public DbSet<TermLife> Calculo_TermLife { get; set; }

        public DbSet<TaxaPrevcom> Calculo_TaxaPrevcom { get; set; }

        public DbSet<SafSuperLuxo> Calculo_SafSuperLuxo { get; set; }

        public DbSet<SafSuperLuxoPorIdade> Calculo_SafSuperLuxoPorIdade { get; set; }

        public DbSet<SafLuxo> Calculo_SafLuxo { get; set; }

        public DbSet<RendaInvalidez> Calculo_RendaInvalidez { get; set; }

        public DbSet<PrazoCerto> Calculo_PrazoCerto { get; set; }

        public DbSet<PensaoPorMorte> Calculo_PensaoPorMorte { get; set; }

        public DbSet<MortePorAcidente> Calculo_MortePorAcidente { get; set; }

        public DbSet<InvalidezTotalAcidente> Calculo_InvalidezTotalAcidente { get; set; }

        public DbSet<InvalidezAcidenteMajoradaDoenca> Calculo_InvalidezAcidenteMajoradaDoenca { get; set; }

        public DbSet<InvalidezAcidenteMajorada> Calculo_InvalidezAcidenteMajorada { get; set; }

        public DbSet<DoencasGravesMaster> Calculo_DoencasGravesMaster { get; set; }

        public DbSet<DoencasGraves> Calculo_DoencasGraves { get; set; }

        public DbSet<DitMedico> Calculo_DitMedico { get; set; }

        public DbSet<DiariaInternacaoHospitalar> Calculo_DiariaInternacaoHospitalar { get; set; }

        public DbSet<DiariaIncapacidadeTemporariaAcidente> Calculo_DiariaIncapacidadeTemporariaAcidente { get; set; }

        public DbSet<AdicionalDiariaInternacaoHospitalar> Calculo_AdicionalDiariaInternacaoHospitalar { get; set; }
        #endregion
    }
}
