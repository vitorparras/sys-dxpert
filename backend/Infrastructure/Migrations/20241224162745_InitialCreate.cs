using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AuthToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Token = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExpiryDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthToken", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Beneficiarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataNasc = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CadastroId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiarios", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cadastros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Etapa = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EstadoCivil = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataCasamento = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ConjugeNome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConjugeDataNasc = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PossuiFilhos = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Ocupacao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmpresaTrabalho = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Categoria = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PoliticamenteExposto = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PresidenteNoBrasil = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RendaBruta = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DespesaMensal = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ObrigacoesFiscaisExterior = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImpostoDeRenda = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TotalImoveis = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TotalVeiculos = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TotalAplicacoesFinanceiros = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HistoricoSeguradora = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ViagemInternacional = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProblemasSaude = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsoMedicamento = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SofreDoencas = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PossuiDeficiencia = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RealizouCirurgia = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PossuiAlgumaAtividade = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fumante = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoSubstancia = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QuantidadeSubstancia = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QuantidadeFilhos = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FilhosMaiores = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataNascimento = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Sexo = table.Column<int>(type: "int", nullable: true),
                    Celular = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QuantidadeFilhosMaiores = table.Column<int>(type: "int", nullable: false),
                    AnosContribuicao = table.Column<int>(type: "int", nullable: false),
                    DataPosse = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Profissao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RegimeContratacao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReservaEmergencia = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TempoReserva = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProblemaSaude = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TomaRemedio = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fuma = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MaiorPrioridade = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdUsuarioResponsavel = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadastros", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Calculo_AdicionalDiariaInternacaoHospitalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<double>(type: "double", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculo_AdicionalDiariaInternacaoHospitalar", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Calculo_DiariaIncapacidadeTemporariaAcidente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RendaMensal = table.Column<double>(type: "double", nullable: false),
                    MorteAcidental = table.Column<double>(type: "double", nullable: false),
                    InvalidezAcidentalMajorada = table.Column<double>(type: "double", nullable: false),
                    I13a30 = table.Column<double>(type: "double", nullable: false),
                    I31a35 = table.Column<double>(type: "double", nullable: false),
                    I36a40 = table.Column<double>(type: "double", nullable: false),
                    I41a45 = table.Column<double>(type: "double", nullable: false),
                    I46a50 = table.Column<double>(type: "double", nullable: false),
                    I51a55 = table.Column<double>(type: "double", nullable: false),
                    I56a60 = table.Column<double>(type: "double", nullable: false),
                    I61a65 = table.Column<double>(type: "double", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculo_DiariaIncapacidadeTemporariaAcidente", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Calculo_DiariaInternacaoHospitalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    T150 = table.Column<double>(type: "double", nullable: false),
                    T200 = table.Column<double>(type: "double", nullable: false),
                    T250 = table.Column<double>(type: "double", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculo_DiariaInternacaoHospitalar", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Calculo_DitMedico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    V1 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    V2 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    V3 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    V4 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    V5 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    V6 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    V7 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    V8 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    V9 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    V10 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    V11 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    V12 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    V13 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    V14 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    V15 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    V16 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    V17 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    V18 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    V19 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    V20 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    V21 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    V22 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    V23 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    V24 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    V25 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    V26 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    V27 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    V28 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    V29 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    V30 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculo_DitMedico", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Calculo_DoencasGraves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Essencial = table.Column<double>(type: "double", nullable: false),
                    Plus = table.Column<double>(type: "double", nullable: false),
                    Premium = table.Column<double>(type: "double", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculo_DoencasGraves", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Calculo_DoencasGravesMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<double>(type: "double", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculo_DoencasGravesMaster", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Calculo_InvalidezAcidenteMajorada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<double>(type: "double", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculo_InvalidezAcidenteMajorada", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Calculo_InvalidezAcidenteMajoradaDoenca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<double>(type: "double", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculo_InvalidezAcidenteMajoradaDoenca", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Calculo_InvalidezTotalAcidente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<double>(type: "double", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculo_InvalidezTotalAcidente", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Calculo_MortePorAcidente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<double>(type: "double", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculo_MortePorAcidente", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Calculo_PensaoPorMorte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    I10 = table.Column<double>(type: "double", nullable: false),
                    I15 = table.Column<double>(type: "double", nullable: false),
                    I20 = table.Column<double>(type: "double", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculo_PensaoPorMorte", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Calculo_PrazoCerto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    I5 = table.Column<double>(type: "double", nullable: false),
                    I10 = table.Column<double>(type: "double", nullable: false),
                    I15 = table.Column<double>(type: "double", nullable: false),
                    I20 = table.Column<double>(type: "double", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculo_PrazoCerto", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Calculo_RendaInvalidez",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    I20 = table.Column<double>(type: "double", nullable: false),
                    I30 = table.Column<double>(type: "double", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculo_RendaInvalidez", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Calculo_SafLuxo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Individual = table.Column<double>(type: "double", nullable: false),
                    Familiar = table.Column<double>(type: "double", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculo_SafLuxo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Calculo_SafSuperLuxo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Individual = table.Column<double>(type: "double", nullable: false),
                    Familiar = table.Column<double>(type: "double", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculo_SafSuperLuxo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Calculo_SafSuperLuxoPorIdade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdadeMinima = table.Column<int>(type: "int", nullable: false),
                    IdadeMaxima = table.Column<int>(type: "int", nullable: false),
                    Individual = table.Column<double>(type: "double", nullable: false),
                    Familiar = table.Column<double>(type: "double", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculo_SafSuperLuxoPorIdade", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Calculo_TaxaPrevcom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Morte = table.Column<double>(type: "double", nullable: false),
                    Invalidez = table.Column<double>(type: "double", nullable: false),
                    PercentualReajusteMorte = table.Column<double>(type: "double", nullable: false),
                    PercentualReajusteInvalidez = table.Column<double>(type: "double", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculo_TaxaPrevcom", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Calculo_TermLife",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Masculino10 = table.Column<double>(type: "double", nullable: false),
                    Masculino15 = table.Column<double>(type: "double", nullable: false),
                    Masculino20 = table.Column<double>(type: "double", nullable: false),
                    Masculino25 = table.Column<double>(type: "double", nullable: false),
                    Masculino30 = table.Column<double>(type: "double", nullable: false),
                    Feminino10 = table.Column<double>(type: "double", nullable: false),
                    Feminino15 = table.Column<double>(type: "double", nullable: false),
                    Feminino20 = table.Column<double>(type: "double", nullable: false),
                    Feminino25 = table.Column<double>(type: "double", nullable: false),
                    Feminino30 = table.Column<double>(type: "double", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculo_TermLife", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Calculo_VidaInteira",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Homem = table.Column<double>(type: "double", nullable: false),
                    Mulher = table.Column<double>(type: "double", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculo_VidaInteira", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Calculo_VidaInteiraConjuge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Homem = table.Column<double>(type: "double", nullable: false),
                    Mulher = table.Column<double>(type: "double", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculo_VidaInteiraConjuge", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Configuracoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tipo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Valor = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuracoes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrgaoExpedidor = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataExpedicao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CadastroId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cep = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cidade = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Logadouro = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bairro = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Complemento = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CadastroId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Permissao = table.Column<int>(type: "int", nullable: false),
                    Senha = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Calculo_AdicionalDiariaInternacaoHospitalar",
                columns: new[] { "Id", "Idade", "Valor" },
                values: new object[,]
                {
                    { 1, 16, 0.12 },
                    { 2, 17, 0.12 },
                    { 3, 18, 0.12 },
                    { 4, 19, 0.12 },
                    { 5, 20, 0.19 },
                    { 6, 21, 0.19 },
                    { 7, 22, 0.19 },
                    { 8, 23, 0.19 },
                    { 9, 24, 0.19 },
                    { 10, 25, 0.19 },
                    { 11, 26, 0.19 },
                    { 12, 27, 0.19 },
                    { 13, 28, 0.19 },
                    { 14, 29, 0.19 },
                    { 15, 30, 0.17000000000000001 },
                    { 16, 31, 0.17000000000000001 },
                    { 17, 32, 0.17000000000000001 },
                    { 18, 33, 0.17000000000000001 },
                    { 19, 34, 0.17000000000000001 },
                    { 20, 35, 0.17000000000000001 },
                    { 21, 36, 0.17000000000000001 },
                    { 22, 37, 0.17000000000000001 },
                    { 23, 38, 0.17000000000000001 },
                    { 24, 39, 0.17000000000000001 },
                    { 25, 40, 0.28999999999999998 },
                    { 26, 41, 0.28999999999999998 },
                    { 27, 42, 0.28999999999999998 },
                    { 28, 43, 0.28999999999999998 },
                    { 29, 44, 0.28999999999999998 },
                    { 30, 45, 0.28999999999999998 },
                    { 31, 46, 0.28999999999999998 },
                    { 32, 47, 0.28999999999999998 },
                    { 33, 48, 0.28999999999999998 },
                    { 34, 49, 0.28999999999999998 },
                    { 35, 50, 0.56000000000000005 },
                    { 36, 51, 0.56000000000000005 },
                    { 37, 52, 0.56000000000000005 },
                    { 38, 53, 0.56000000000000005 },
                    { 39, 54, 0.56000000000000005 },
                    { 40, 55, 0.56000000000000005 },
                    { 41, 56, 0.56000000000000005 },
                    { 42, 57, 0.56000000000000005 },
                    { 43, 58, 0.56000000000000005 },
                    { 44, 59, 0.56000000000000005 },
                    { 45, 60, 1.0900000000000001 },
                    { 46, 61, 1.0900000000000001 },
                    { 47, 62, 1.0900000000000001 },
                    { 48, 63, 1.0900000000000001 },
                    { 49, 64, 1.0900000000000001 },
                    { 50, 65, 1.0900000000000001 }
                });

            migrationBuilder.InsertData(
                table: "Calculo_DiariaIncapacidadeTemporariaAcidente",
                columns: new[] { "Id", "I13a30", "I31a35", "I36a40", "I41a45", "I46a50", "I51a55", "I56a60", "I61a65", "InvalidezAcidentalMajorada", "MorteAcidental", "RendaMensal" },
                values: new object[,]
                {
                    { 1, 15.5, 16.77, 18.030000000000001, 19.600000000000001, 21.68, 24.100000000000001, 26.309999999999999, 28.379999999999999, 50000.0, 50000.0, 750.0 },
                    { 2, 21.07, 22.34, 23.600000000000001, 25.18, 27.25, 29.670000000000002, 31.879999999999999, 33.960000000000001, 75000.0, 75000.0, 750.0 },
                    { 3, 16.960000000000001, 18.649999999999999, 20.329999999999998, 22.43, 25.199999999999999, 28.420000000000002, 31.370000000000001, 34.130000000000003, 50000.0, 50000.0, 1000.0 },
                    { 4, 28.100000000000001, 29.789999999999999, 31.469999999999999, 33.57, 36.340000000000003, 39.560000000000002, 42.509999999999998, 45.270000000000003, 100000.0, 100000.0, 1000.0 },
                    { 5, 16.079999999999998, 19.469999999999999, 22.829999999999998, 27.02, 32.560000000000002, 39.009999999999998, 44.899999999999999, 50.439999999999998, 20000.0, 20000.0, 2000.0 },
                    { 6, 20.539999999999999, 23.93, 27.289999999999999, 31.48, 37.020000000000003, 43.460000000000001, 49.359999999999999, 54.890000000000001, 40000.0, 40000.0, 2000.0 },
                    { 7, 33.909999999999997, 37.299999999999997, 40.659999999999997, 44.850000000000001, 50.390000000000001, 56.829999999999998, 62.729999999999997, 68.260000000000005, 100000.0, 100000.0, 2000.0 },
                    { 8, 56.200000000000003, 59.579999999999998, 62.939999999999998, 67.140000000000001, 72.680000000000007, 79.120000000000005, 85.010000000000005, 90.549999999999997, 200000.0, 200000.0, 2000.0 },
                    { 9, 24.129999999999999, 29.210000000000001, 34.25, 40.539999999999999, 48.850000000000001, 58.509999999999998, 67.349999999999994, 75.650000000000006, 30000.0, 30000.0, 3000.0 },
                    { 10, 30.809999999999999, 35.890000000000001, 40.93, 47.219999999999999, 55.530000000000001, 65.200000000000003, 74.040000000000006, 82.340000000000003, 60000.0, 60000.0, 3000.0 },
                    { 11, 50.869999999999997, 55.950000000000003, 60.990000000000002, 67.280000000000001, 75.590000000000003, 85.25, 94.099999999999994, 102.39, 150000.0, 150000.0, 3000.0 },
                    { 12, 84.290000000000006, 89.370000000000005, 94.420000000000002, 100.7, 109.02, 118.68000000000001, 127.52, 135.81999999999999, 300000.0, 300000.0, 3000.0 },
                    { 13, 32.170000000000002, 38.939999999999998, 45.670000000000002, 54.049999999999997, 65.129999999999995, 78.010000000000005, 89.810000000000002, 100.87, 40000.0, 40000.0, 4000.0 },
                    { 14, 41.079999999999998, 47.859999999999999, 54.579999999999998, 62.960000000000001, 74.040000000000006, 86.930000000000007, 98.719999999999999, 109.78, 80000.0, 80000.0, 4000.0 },
                    { 15, 67.819999999999993, 74.599999999999994, 81.319999999999993, 89.700000000000003, 100.78, 113.67, 125.45999999999999, 136.53, 200000.0, 200000.0, 4000.0 },
                    { 16, 112.39, 119.17, 125.89, 134.27000000000001, 145.34999999999999, 158.24000000000001, 170.03, 181.09, 400000.0, 400000.0, 4000.0 },
                    { 17, 40.210000000000001, 48.68, 57.079999999999998, 67.560000000000002, 81.409999999999997, 97.519999999999996, 112.26000000000001, 126.09, 50000.0, 50000.0, 5000.0 },
                    { 18, 51.350000000000001, 59.82, 68.219999999999999, 78.700000000000003, 92.549999999999997, 108.66, 123.40000000000001, 137.22999999999999, 100000.0, 100000.0, 5000.0 },
                    { 19, 84.780000000000001, 93.25, 101.65000000000001, 112.13, 125.98, 142.09, 156.83000000000001, 170.66, 250000.0, 250000.0, 5000.0 },
                    { 20, 140.49000000000001, 148.96000000000001, 157.36000000000001, 167.84, 181.69, 197.80000000000001, 212.53999999999999, 226.37, 500000.0, 500000.0, 5000.0 },
                    { 21, 48.25, 58.409999999999997, 68.5, 81.069999999999993, 97.689999999999998, 117.02, 134.71000000000001, 151.31, 60000.0, 60000.0, 6000.0 },
                    { 22, 61.619999999999997, 71.780000000000001, 81.870000000000005, 94.439999999999998, 111.06999999999999, 130.38999999999999, 148.08000000000001, 164.68000000000001, 120000.0, 120000.0, 6000.0 },
                    { 23, 101.73, 111.90000000000001, 121.98, 134.55000000000001, 151.18000000000001, 170.5, 188.19, 204.78999999999999, 300000.0, 300000.0, 6000.0 },
                    { 24, 168.59, 178.75, 188.83000000000001, 201.41, 218.03, 237.36000000000001, 255.03999999999999, 271.63999999999999, 600000.0, 600000.0, 6000.0 },
                    { 25, 56.289999999999999, 68.150000000000006, 79.909999999999997, 94.579999999999998, 113.98, 136.52000000000001, 157.16, 176.52000000000001, 70000.0, 70000.0, 7000.0 },
                    { 26, 71.890000000000001, 83.75, 95.510000000000005, 110.18000000000001, 129.58000000000001, 152.12, 172.75999999999999, 192.12, 140000.0, 140000.0, 7000.0 },
                    { 27, 118.69, 130.53999999999999, 142.31, 156.97999999999999, 176.37, 198.91999999999999, 219.56, 238.91999999999999, 350000.0, 350000.0, 7000.0 },
                    { 28, 196.68000000000001, 208.53999999999999, 220.31, 234.97, 254.37, 276.92000000000002, 297.55000000000001, 316.92000000000002, 700000.0, 700000.0, 7000.0 },
                    { 29, 64.329999999999998, 77.879999999999995, 91.329999999999998, 108.09, 130.25999999999999, 156.03, 179.61000000000001, 201.74000000000001, 80000.0, 80000.0, 8000.0 },
                    { 30, 82.159999999999997, 95.709999999999994, 109.16, 125.92, 148.09, 173.84999999999999, 197.44, 219.56999999999999, 160000.0, 160000.0, 8000.0 },
                    { 31, 135.63999999999999, 149.19, 162.63999999999999, 179.40000000000001, 201.56999999999999, 227.34, 250.91999999999999, 273.05000000000001, 400000.0, 400000.0, 8000.0 },
                    { 32, 224.78, 238.33000000000001, 251.78, 268.54000000000002, 290.70999999999998, 316.47000000000003, 340.06, 362.19, 800000.0, 800000.0, 8000.0 },
                    { 33, 72.379999999999995, 87.620000000000005, 102.75, 121.61, 146.53999999999999, 175.53, 202.06, 226.96000000000001, 90000.0, 90000.0, 9000.0 },
                    { 34, 92.430000000000007, 107.68000000000001, 122.8, 141.66, 166.59999999999999, 195.59, 222.12, 247.00999999999999, 180000.0, 180000.0, 9000.0 },
                    { 35, 152.59999999999999, 167.84, 182.97, 201.83000000000001, 226.77000000000001, 255.75, 282.29000000000002, 307.18000000000001, 450000.0, 450000.0, 9000.0 },
                    { 36, 252.88, 268.12, 283.25, 302.11000000000001, 327.05000000000001, 356.02999999999997, 382.56, 407.45999999999998, 900000.0, 900000.0, 9000.0 },
                    { 37, 80.420000000000002, 97.349999999999994, 114.16, 135.12, 162.81999999999999, 195.03, 224.50999999999999, 252.18000000000001, 100000.0, 100000.0, 10000.0 },
                    { 38, 102.7, 119.64, 136.44999999999999, 157.40000000000001, 185.11000000000001, 217.31999999999999, 246.80000000000001, 274.45999999999998, 200000.0, 200000.0, 10000.0 },
                    { 39, 169.55000000000001, 186.49000000000001, 203.30000000000001, 224.25, 251.96000000000001, 284.17000000000002, 313.64999999999998, 341.31, 500000.0, 500000.0, 10000.0 },
                    { 40, 280.98000000000002, 297.91000000000003, 314.72000000000003, 335.68000000000001, 363.38, 395.58999999999997, 425.06999999999999, 452.74000000000001, 1000000.0, 1000000.0, 10000.0 },
                    { 41, 88.459999999999994, 107.09, 125.58, 148.63, 179.11000000000001, 214.53999999999999, 246.96000000000001, 277.38999999999999, 110000.0, 110000.0, 11000.0 },
                    { 42, 112.97, 131.59999999999999, 150.09, 173.13999999999999, 203.62, 239.05000000000001, 271.48000000000002, 301.91000000000003, 220000.0, 220000.0, 11000.0 },
                    { 43, 186.50999999999999, 205.13999999999999, 223.63, 246.68000000000001, 277.16000000000003, 312.58999999999997, 345.01999999999998, 375.44999999999999, 550000.0, 550000.0, 11000.0 },
                    { 44, 309.06999999999999, 327.70999999999998, 346.19999999999999, 369.24000000000001, 399.72000000000003, 435.14999999999998, 467.57999999999998, 498.00999999999999, 1100000.0, 1100000.0, 11000.0 },
                    { 45, 96.5, 116.83, 137.0, 162.13999999999999, 195.38999999999999, 234.03999999999999, 269.42000000000002, 302.61000000000001, 120000.0, 120000.0, 12000.0 },
                    { 46, 123.23999999999999, 143.56999999999999, 163.74000000000001, 188.88, 222.13, 260.77999999999997, 296.16000000000003, 329.35000000000002, 240000.0, 240000.0, 12000.0 },
                    { 47, 203.47, 223.78999999999999, 243.96000000000001, 269.11000000000001, 302.35000000000002, 341.00999999999999, 376.38, 409.57999999999998, 600000.0, 600000.0, 12000.0 },
                    { 48, 337.17000000000002, 357.5, 377.67000000000002, 402.81, 436.06, 474.70999999999998, 510.08999999999997, 543.27999999999997, 1200000.0, 1200000.0, 12000.0 },
                    { 49, 104.54000000000001, 126.56, 148.41, 175.65000000000001, 211.66999999999999, 253.53999999999999, 291.87, 327.82999999999998, 130000.0, 130000.0, 13000.0 },
                    { 50, 133.50999999999999, 155.53, 177.38, 204.62, 240.63999999999999, 282.50999999999999, 320.83999999999997, 356.80000000000001, 260000.0, 260000.0, 13000.0 },
                    { 51, 220.41999999999999, 242.44, 264.29000000000002, 291.52999999999997, 327.55000000000001, 369.42000000000002, 407.75, 443.70999999999998, 650000.0, 650000.0, 13000.0 },
                    { 52, 365.26999999999998, 387.29000000000002, 409.13999999999999, 436.38, 472.39999999999998, 514.26999999999998, 552.59000000000003, 588.55999999999995, 1300000.0, 1300000.0, 13000.0 },
                    { 53, 112.58, 136.30000000000001, 159.83000000000001, 189.16, 227.94999999999999, 273.05000000000001, 314.31999999999999, 353.05000000000001, 140000.0, 140000.0, 14000.0 },
                    { 54, 143.78, 167.49000000000001, 191.03, 220.36000000000001, 259.14999999999998, 304.25, 345.51999999999998, 384.25, 280000.0, 280000.0, 14000.0 },
                    { 55, 237.38, 261.08999999999997, 284.62, 313.95999999999998, 352.75, 397.83999999999997, 439.11000000000001, 477.83999999999997, 700000.0, 700000.0, 14000.0 },
                    { 56, 393.37, 417.07999999999998, 440.61000000000001, 469.94999999999999, 508.74000000000001, 553.83000000000004, 595.10000000000002, 633.83000000000004, 1400000.0, 1400000.0, 14000.0 },
                    { 57, 120.63, 146.03, 171.25, 202.68000000000001, 244.24000000000001, 292.55000000000001, 336.76999999999998, 378.25999999999999, 150000.0, 150000.0, 15000.0 },
                    { 58, 154.05000000000001, 179.46000000000001, 204.66999999999999, 236.09999999999999, 277.66000000000003, 325.98000000000002, 370.19999999999999, 411.69, 300000.0, 300000.0, 15000.0 },
                    { 59, 254.33000000000001, 279.74000000000001, 304.94999999999999, 336.38, 377.94, 426.25999999999999, 470.48000000000002, 511.97000000000003, 750000.0, 750000.0, 15000.0 },
                    { 60, 421.45999999999998, 446.87, 472.07999999999998, 503.50999999999999, 545.08000000000004, 593.38999999999999, 637.61000000000001, 679.10000000000002, 1500000.0, 1500000.0, 15000.0 },
                    { 61, 128.66999999999999, 155.77000000000001, 182.66, 216.19, 260.51999999999998, 312.05000000000001, 359.22000000000003, 403.48000000000002, 160000.0, 160000.0, 16000.0 },
                    { 62, 164.31999999999999, 191.41999999999999, 218.31999999999999, 251.84, 296.17000000000002, 347.70999999999998, 394.88, 439.13999999999999, 320000.0, 320000.0, 16000.0 },
                    { 63, 271.29000000000002, 298.38999999999999, 325.27999999999997, 358.81, 403.13999999999999, 454.67000000000002, 501.83999999999997, 546.10000000000002, 800000.0, 800000.0, 16000.0 },
                    { 64, 449.56, 476.66000000000003, 503.56, 537.08000000000004, 581.40999999999997, 632.95000000000005, 680.12, 724.38, 1600000.0, 1600000.0, 16000.0 },
                    { 65, 136.71000000000001, 165.5, 194.08000000000001, 229.69999999999999, 276.80000000000001, 331.56, 381.67000000000002, 428.69999999999999, 170000.0, 170000.0, 17000.0 },
                    { 66, 174.59, 203.38999999999999, 231.96000000000001, 267.57999999999998, 314.69, 369.44, 419.56, 466.57999999999998, 340000.0, 340000.0, 17000.0 },
                    { 67, 288.24000000000001, 317.04000000000002, 345.61000000000001, 381.23000000000002, 428.33999999999997, 483.08999999999997, 533.21000000000004, 580.23000000000002, 850000.0, 850000.0, 17000.0 },
                    { 68, 477.66000000000003, 506.44999999999999, 535.02999999999997, 570.64999999999998, 617.75, 672.50999999999999, 722.62, 769.64999999999998, 1700000.0, 1700000.0, 17000.0 },
                    { 69, 144.75, 175.24000000000001, 205.49000000000001, 243.21000000000001, 293.07999999999998, 351.06, 404.12, 453.92000000000002, 180000.0, 180000.0, 18000.0 },
                    { 70, 184.86000000000001, 215.34999999999999, 245.61000000000001, 283.31999999999999, 333.19999999999999, 391.17000000000002, 444.24000000000001, 494.02999999999997, 360000.0, 360000.0, 18000.0 },
                    { 71, 305.19999999999999, 335.69, 365.94, 403.66000000000003, 453.52999999999997, 511.50999999999999, 564.57000000000005, 614.37, 900000.0, 900000.0, 18000.0 },
                    { 72, 505.75999999999999, 536.25, 566.5, 604.22000000000003, 654.09000000000003, 712.07000000000005, 765.13, 814.91999999999996, 1800000.0, 1800000.0, 18000.0 },
                    { 73, 152.78999999999999, 184.97, 216.91, 256.72000000000003, 309.37, 370.56999999999999, 426.56999999999999, 479.13999999999999, 190000.0, 190000.0, 19000.0 },
                    { 74, 195.13, 227.31, 259.25, 299.06, 351.70999999999998, 412.91000000000003, 468.91000000000003, 521.48000000000002, 380000.0, 380000.0, 19000.0 },
                    { 75, 322.14999999999998, 354.33999999999997, 386.26999999999998, 426.07999999999998, 478.73000000000002, 539.92999999999995, 595.94000000000005, 648.5, 950000.0, 950000.0, 19000.0 },
                    { 76, 533.85000000000002, 566.03999999999996, 597.97000000000003, 637.77999999999997, 690.42999999999995, 751.63, 807.63999999999999, 860.20000000000005, 1900000.0, 1900000.0, 19000.0 },
                    { 77, 160.83000000000001, 194.71000000000001, 228.33000000000001, 270.23000000000002, 325.64999999999998, 390.06999999999999, 449.02999999999997, 504.35000000000002, 200000.0, 200000.0, 20000.0 },
                    { 78, 205.40000000000001, 239.28, 272.89999999999998, 314.80000000000001, 370.22000000000003, 434.63999999999999, 493.58999999999997, 548.91999999999996, 400000.0, 400000.0, 20000.0 },
                    { 79, 339.11000000000001, 372.98000000000002, 406.60000000000002, 448.50999999999999, 503.92000000000002, 568.34000000000003, 627.29999999999995, 682.63, 1000000.0, 1000000.0, 20000.0 },
                    { 80, 561.95000000000005, 595.83000000000004, 629.45000000000005, 671.35000000000002, 726.76999999999998, 791.19000000000005, 850.13999999999999, 905.47000000000003, 2000000.0, 2000000.0, 20000.0 },
                    { 81, 168.88, 204.44999999999999, 239.74000000000001, 283.75, 341.93000000000001, 409.56999999999999, 471.48000000000002, 529.57000000000005, 210000.0, 210000.0, 21000.0 },
                    { 82, 215.66999999999999, 251.24000000000001, 286.54000000000002, 330.54000000000002, 388.73000000000002, 456.37, 518.26999999999998, 576.37, 420000.0, 420000.0, 21000.0 },
                    { 83, 356.06, 391.63, 426.93000000000001, 470.93000000000001, 529.12, 596.75999999999999, 658.66999999999996, 716.75999999999999, 1050000.0, 1050000.0, 21000.0 },
                    { 84, 590.04999999999995, 625.62, 660.91999999999996, 704.91999999999996, 763.11000000000001, 830.75, 892.64999999999998, 950.75, 2100000.0, 2100000.0, 21000.0 },
                    { 85, 176.91999999999999, 214.18000000000001, 251.16, 297.25999999999999, 358.20999999999998, 429.07999999999998, 493.93000000000001, 554.78999999999996, 220000.0, 220000.0, 22000.0 },
                    { 86, 225.94, 263.20999999999998, 300.19, 346.27999999999997, 407.24000000000001, 478.10000000000002, 542.95000000000005, 603.80999999999995, 440000.0, 440000.0, 22000.0 },
                    { 87, 373.01999999999998, 410.27999999999997, 447.25999999999999, 493.36000000000001, 554.32000000000005, 625.17999999999995, 690.02999999999997, 750.88999999999999, 1100000.0, 1100000.0, 22000.0 },
                    { 88, 618.14999999999998, 655.40999999999997, 692.38999999999999, 738.49000000000001, 799.44000000000005, 870.30999999999995, 935.15999999999997, 996.01999999999998, 2200000.0, 2200000.0, 22000.0 },
                    { 89, 184.96000000000001, 223.91999999999999, 262.57999999999998, 310.76999999999998, 374.5, 448.57999999999998, 516.38, 580.00999999999999, 230000.0, 230000.0, 23000.0 },
                    { 90, 236.21000000000001, 275.17000000000002, 313.82999999999998, 362.01999999999998, 425.75, 499.82999999999998, 567.63, 631.25999999999999, 460000.0, 460000.0, 23000.0 },
                    { 91, 389.97000000000003, 428.93000000000001, 467.58999999999997, 515.78999999999996, 579.50999999999999, 653.59000000000003, 721.39999999999998, 785.01999999999998, 1150000.0, 1150000.0, 23000.0 },
                    { 92, 646.24000000000001, 685.20000000000005, 723.86000000000001, 772.05999999999995, 835.77999999999997, 909.86000000000001, 977.66999999999996, 1041.29, 2300000.0, 2300000.0, 23000.0 },
                    { 93, 193.0, 233.65000000000001, 273.99000000000001, 324.27999999999997, 390.77999999999997, 468.07999999999998, 538.83000000000004, 605.22000000000003, 240000.0, 240000.0, 24000.0 },
                    { 94, 246.47999999999999, 287.13, 327.48000000000002, 377.75999999999999, 444.25999999999999, 521.55999999999995, 592.30999999999995, 658.71000000000004, 480000.0, 480000.0, 24000.0 },
                    { 95, 406.93000000000001, 447.57999999999998, 487.92000000000002, 538.21000000000004, 604.71000000000004, 682.00999999999999, 752.75999999999999, 819.14999999999998, 1200000.0, 1200000.0, 24000.0 },
                    { 96, 674.34000000000003, 714.99000000000001, 755.34000000000003, 805.62, 872.12, 949.41999999999996, 1020.17, 1086.5699999999999, 2400000.0, 2400000.0, 24000.0 },
                    { 97, 201.03999999999999, 243.38999999999999, 285.41000000000003, 337.79000000000002, 407.06, 487.58999999999997, 561.27999999999997, 630.44000000000005, 250000.0, 250000.0, 25000.0 },
                    { 98, 256.75, 299.10000000000002, 341.12, 393.5, 462.76999999999998, 543.29999999999995, 616.99000000000001, 686.14999999999998, 500000.0, 500000.0, 25000.0 },
                    { 99, 423.88999999999999, 466.23000000000002, 508.25, 560.63999999999999, 629.90999999999997, 710.42999999999995, 784.13, 853.28999999999996, 1250000.0, 1250000.0, 25000.0 },
                    { 100, 702.44000000000005, 744.78999999999996, 786.80999999999995, 839.19000000000005, 908.46000000000004, 988.98000000000002, 1062.6800000000001, 1131.8399999999999, 2500000.0, 2500000.0, 25000.0 },
                    { 101, 209.08000000000001, 253.12, 296.82999999999998, 351.30000000000001, 423.33999999999997, 507.08999999999997, 583.73000000000002, 655.65999999999997, 260000.0, 260000.0, 26000.0 },
                    { 102, 267.01999999999998, 311.06, 354.75999999999999, 409.24000000000001, 481.27999999999997, 565.02999999999997, 641.66999999999996, 713.60000000000002, 520000.0, 520000.0, 26000.0 },
                    { 103, 440.83999999999997, 484.88, 528.58000000000004, 583.05999999999995, 655.10000000000002, 738.85000000000002, 815.49000000000001, 887.41999999999996, 1300000.0, 1300000.0, 26000.0 },
                    { 104, 730.53999999999996, 774.58000000000004, 818.27999999999997, 872.75999999999999, 944.79999999999995, 1028.54, 1105.1900000000001, 1177.1099999999999, 2600000.0, 2600000.0, 26000.0 },
                    { 105, 217.13, 262.86000000000001, 308.24000000000001, 364.81999999999999, 439.63, 526.59000000000003, 606.17999999999995, 680.88, 270000.0, 270000.0, 27000.0 },
                    { 106, 277.29000000000002, 323.02999999999997, 368.41000000000003, 424.98000000000002, 499.79000000000002, 586.75999999999999, 666.35000000000002, 741.03999999999996, 540000.0, 540000.0, 27000.0 },
                    { 107, 457.80000000000001, 503.52999999999997, 548.90999999999997, 605.49000000000001, 680.29999999999995, 767.25999999999999, 846.86000000000001, 921.54999999999995, 1350000.0, 1350000.0, 27000.0 },
                    { 108, 758.63999999999999, 804.37, 849.75, 906.33000000000004, 981.13999999999999, 1068.0999999999999, 1147.6900000000001, 1222.3900000000001, 2700000.0, 2700000.0, 27000.0 },
                    { 109, 225.16999999999999, 272.58999999999997, 319.66000000000003, 378.32999999999998, 455.91000000000003, 546.10000000000002, 628.63999999999999, 706.09000000000003, 280000.0, 280000.0, 28000.0 },
                    { 110, 287.56, 334.99000000000001, 382.05000000000001, 440.72000000000003, 518.30999999999995, 608.49000000000001, 691.02999999999997, 768.49000000000001, 560000.0, 560000.0, 28000.0 },
                    { 111, 474.75, 522.17999999999995, 569.24000000000001, 627.90999999999997, 705.49000000000001, 795.67999999999995, 878.22000000000003, 955.67999999999995, 1400000.0, 1400000.0, 28000.0 },
                    { 112, 786.73000000000002, 834.15999999999997, 881.22000000000003, 939.88999999999999, 1017.47, 1107.6600000000001, 1190.2, 1267.6600000000001, 2800000.0, 2800000.0, 28000.0 },
                    { 113, 233.21000000000001, 282.32999999999998, 331.06999999999999, 391.83999999999997, 472.19, 565.60000000000002, 651.09000000000003, 731.30999999999995, 290000.0, 290000.0, 29000.0 },
                    { 114, 297.82999999999998, 346.94999999999999, 395.69999999999999, 456.45999999999998, 536.82000000000005, 630.22000000000003, 715.71000000000004, 795.94000000000005, 580000.0, 580000.0, 29000.0 },
                    { 115, 491.70999999999998, 540.83000000000004, 589.57000000000005, 650.34000000000003, 730.69000000000005, 824.10000000000002, 909.59000000000003, 989.80999999999995, 1450000.0, 1450000.0, 29000.0 },
                    { 116, 814.83000000000004, 863.95000000000005, 912.70000000000005, 973.46000000000004, 1053.8099999999999, 1147.22, 1232.71, 1312.9300000000001, 2900000.0, 2900000.0, 29000.0 },
                    { 117, 241.25, 292.06, 342.49000000000001, 405.35000000000002, 488.47000000000003, 585.10000000000002, 673.53999999999996, 756.52999999999997, 300000.0, 300000.0, 30000.0 },
                    { 118, 308.10000000000002, 358.92000000000002, 409.33999999999997, 472.19999999999999, 555.33000000000004, 651.96000000000004, 740.38999999999999, 823.38, 600000.0, 600000.0, 30000.0 },
                    { 119, 508.66000000000003, 559.48000000000002, 609.89999999999998, 672.75999999999999, 755.88999999999999, 852.50999999999999, 940.95000000000005, 1023.9400000000001, 1500000.0, 1500000.0, 30000.0 }
                });

            migrationBuilder.InsertData(
                table: "Calculo_DiariaInternacaoHospitalar",
                columns: new[] { "Id", "Idade", "T150", "T200", "T250" },
                values: new object[,]
                {
                    { 1, 16, 3.0699999999999998, 3.1699999999999999, 3.3300000000000001 },
                    { 2, 17, 3.0699999999999998, 3.1699999999999999, 3.3300000000000001 },
                    { 3, 18, 3.0699999999999998, 3.1699999999999999, 3.3300000000000001 },
                    { 4, 19, 3.0699999999999998, 3.1699999999999999, 3.3300000000000001 },
                    { 5, 20, 4.7400000000000002, 5.0599999999999996, 5.5199999999999996 },
                    { 6, 21, 4.7400000000000002, 5.0599999999999996, 5.5199999999999996 },
                    { 7, 22, 4.7400000000000002, 5.0599999999999996, 5.5199999999999996 },
                    { 8, 23, 4.7400000000000002, 5.0599999999999996, 5.5199999999999996 },
                    { 9, 24, 4.7400000000000002, 5.0599999999999996, 5.5199999999999996 },
                    { 10, 25, 4.7400000000000002, 5.0599999999999996, 5.5199999999999996 },
                    { 11, 26, 4.7400000000000002, 5.0599999999999996, 5.5199999999999996 },
                    { 12, 27, 4.7400000000000002, 5.0599999999999996, 5.5199999999999996 },
                    { 13, 28, 4.7400000000000002, 5.0599999999999996, 5.5199999999999996 },
                    { 14, 29, 4.7400000000000002, 5.0599999999999996, 5.5199999999999996 },
                    { 15, 30, 6.1200000000000001, 6.6900000000000004, 7.46 },
                    { 16, 31, 6.1200000000000001, 6.6900000000000004, 7.46 },
                    { 17, 32, 6.1200000000000001, 6.6900000000000004, 7.46 },
                    { 18, 33, 6.1200000000000001, 6.6900000000000004, 7.46 },
                    { 19, 34, 6.1200000000000001, 6.6900000000000004, 7.46 },
                    { 20, 35, 6.1200000000000001, 6.6900000000000004, 7.46 },
                    { 21, 36, 6.1200000000000001, 6.6900000000000004, 7.46 },
                    { 22, 37, 6.1200000000000001, 6.6900000000000004, 7.46 },
                    { 23, 38, 6.1200000000000001, 6.6900000000000004, 7.46 },
                    { 24, 39, 6.1200000000000001, 6.6900000000000004, 7.46 },
                    { 25, 40, 9.0700000000000003, 9.9499999999999993, 11.119999999999999 },
                    { 26, 41, 9.0700000000000003, 9.9499999999999993, 11.119999999999999 },
                    { 27, 42, 9.0700000000000003, 9.9499999999999993, 11.119999999999999 },
                    { 28, 43, 9.0700000000000003, 9.9499999999999993, 11.119999999999999 },
                    { 29, 44, 9.0700000000000003, 9.9499999999999993, 11.119999999999999 },
                    { 30, 45, 9.0700000000000003, 9.9499999999999993, 11.119999999999999 },
                    { 31, 46, 9.0700000000000003, 9.9499999999999993, 11.119999999999999 },
                    { 32, 47, 9.0700000000000003, 9.9499999999999993, 11.119999999999999 },
                    { 33, 48, 9.0700000000000003, 9.9499999999999993, 11.119999999999999 },
                    { 34, 49, 9.0700000000000003, 9.9499999999999993, 11.119999999999999 },
                    { 35, 50, 11.98, 13.1, 14.6 },
                    { 36, 51, 11.98, 13.1, 14.6 },
                    { 37, 52, 11.98, 13.1, 14.6 },
                    { 38, 53, 11.98, 13.1, 14.6 },
                    { 39, 54, 11.98, 13.1, 14.6 },
                    { 40, 55, 11.98, 13.1, 14.6 },
                    { 41, 56, 11.98, 13.1, 14.6 },
                    { 42, 57, 11.98, 13.1, 14.6 },
                    { 43, 58, 11.98, 13.1, 14.6 },
                    { 44, 59, 11.98, 13.1, 14.6 },
                    { 45, 60, 17.469999999999999, 18.73, 20.449999999999999 },
                    { 46, 61, 17.469999999999999, 18.73, 20.449999999999999 },
                    { 47, 62, 17.469999999999999, 18.73, 20.449999999999999 },
                    { 48, 63, 17.469999999999999, 18.73, 20.449999999999999 },
                    { 49, 64, 17.469999999999999, 18.73, 20.449999999999999 },
                    { 50, 65, 17.469999999999999, 18.73, 20.449999999999999 }
                });

            migrationBuilder.InsertData(
                table: "Calculo_DitMedico",
                columns: new[] { "Id", "Idade", "V1", "V10", "V11", "V12", "V13", "V14", "V15", "V16", "V17", "V18", "V19", "V2", "V20", "V21", "V22", "V23", "V24", "V25", "V26", "V27", "V28", "V29", "V3", "V30", "V4", "V5", "V6", "V7", "V8", "V9" },
                values: new object[,]
                {
                    { 1, 16, "11.68", "116.84", "128.52", "140.20", "151.89", "163.57", "175.25", "186.94", "198.62", "210.31", "221.99", "23.37", "233.67", "245.36", "257.04", "268.72", "280.41", "292.09", "303.77", "315.46", "327.14", "338.83", "35.05", "350.51", "46.73", "58.42", "70.10", "81.79", "93.47", "105.15" },
                    { 2, 17, "11.68", "116.84", "128.52", "140.20", "151.89", "163.57", "175.25", "186.94", "198.62", "210.31", "221.99", "23.37", "233.67", "245.36", "257.04", "268.72", "280.41", "292.09", "303.77", "315.46", "327.14", "338.83", "35.05", "350.51", "46.73", "58.42", "70.10", "81.79", "93.47", "105.15" },
                    { 3, 18, "11.68", "116.84", "128.52", "140.20", "151.89", "163.57", "175.25", "186.94", "198.62", "210.31", "221.99", "23.37", "233.67", "245.36", "257.04", "268.72", "280.41", "292.09", "303.77", "315.46", "327.14", "338.83", "35.05", "350.51", "46.73", "58.42", "70.10", "81.79", "93.47", "105.15" },
                    { 4, 19, "11.68", "116.84", "128.52", "140.20", "151.89", "163.57", "175.25", "186.94", "198.62", "210.31", "221.99", "23.37", "233.67", "245.36", "257.04", "268.72", "280.41", "292.09", "303.77", "315.46", "327.14", "338.83", "35.05", "350.51", "46.73", "58.42", "70.10", "81.79", "93.47", "105.15" },
                    { 5, 20, "11.68", "116.84", "128.52", "140.20", "151.89", "163.57", "175.25", "186.94", "198.62", "210.31", "221.99", "23.37", "233.67", "245.36", "257.04", "268.72", "280.41", "292.09", "303.77", "315.46", "327.14", "338.83", "35.05", "350.51", "46.73", "58.42", "70.10", "81.79", "93.47", "105.15" },
                    { 6, 21, "11.68", "116.84", "128.52", "140.20", "151.89", "163.57", "175.25", "186.94", "198.62", "210.31", "221.99", "23.37", "233.67", "245.36", "257.04", "268.72", "280.41", "292.09", "303.77", "315.46", "327.14", "338.83", "35.05", "350.51", "46.73", "58.42", "70.10", "81.79", "93.47", "105.15" },
                    { 7, 22, "11.68", "116.84", "128.52", "140.20", "151.89", "163.57", "175.25", "186.94", "198.62", "210.31", "221.99", "23.37", "233.67", "245.36", "257.04", "268.72", "280.41", "292.09", "303.77", "315.46", "327.14", "338.83", "35.05", "350.51", "46.73", "58.42", "70.10", "81.79", "93.47", "105.15" },
                    { 8, 23, "11.68", "116.84", "128.52", "140.20", "151.89", "163.57", "175.25", "186.94", "198.62", "210.31", "221.99", "23.37", "233.67", "245.36", "257.04", "268.72", "280.41", "292.09", "303.77", "315.46", "327.14", "338.83", "35.05", "350.51", "46.73", "58.42", "70.10", "81.79", "93.47", "105.15" },
                    { 9, 24, "11.68", "116.84", "128.52", "140.20", "151.89", "163.57", "175.25", "186.94", "198.62", "210.31", "221.99", "23.37", "233.67", "245.36", "257.04", "268.72", "280.41", "292.09", "303.77", "315.46", "327.14", "338.83", "35.05", "350.51", "46.73", "58.42", "70.10", "81.79", "93.47", "105.15" },
                    { 10, 25, "11.68", "116.84", "128.52", "140.20", "151.89", "163.57", "175.25", "186.94", "198.62", "210.31", "221.99", "23.37", "233.67", "245.36", "257.04", "268.72", "280.41", "292.09", "303.77", "315.46", "327.14", "338.83", "35.05", "350.51", "46.73", "58.42", "70.10", "81.79", "93.47", "105.15" },
                    { 11, 26, "11.68", "116.84", "128.52", "140.20", "151.89", "163.57", "175.25", "186.94", "198.62", "210.31", "221.99", "23.37", "233.67", "245.36", "257.04", "268.72", "280.41", "292.09", "303.77", "315.46", "327.14", "338.83", "35.05", "350.51", "46.73", "58.42", "70.10", "81.79", "93.47", "105.15" },
                    { 12, 27, "11.68", "116.84", "128.52", "140.20", "151.89", "163.57", "175.25", "186.94", "198.62", "210.31", "221.99", "23.37", "233.67", "245.36", "257.04", "268.72", "280.41", "292.09", "303.77", "315.46", "327.14", "338.83", "35.05", "350.51", "46.73", "58.42", "70.10", "81.79", "93.47", "105.15" },
                    { 13, 28, "11.68", "116.84", "128.52", "140.20", "151.89", "163.57", "175.25", "186.94", "198.62", "210.31", "221.99", "23.37", "233.67", "245.36", "257.04", "268.72", "280.41", "292.09", "303.77", "315.46", "327.14", "338.83", "35.05", "350.51", "46.73", "58.42", "70.10", "81.79", "93.47", "105.15" },
                    { 14, 29, "11.68", "116.84", "128.52", "140.20", "151.89", "163.57", "175.25", "186.94", "198.62", "210.31", "221.99", "23.37", "233.67", "245.36", "257.04", "268.72", "280.41", "292.09", "303.77", "315.46", "327.14", "338.83", "35.05", "350.51", "46.73", "58.42", "70.10", "81.79", "93.47", "105.15" },
                    { 15, 30, "11.68", "116.84", "128.52", "140.20", "151.89", "163.57", "175.25", "186.94", "198.62", "210.31", "221.99", "23.37", "233.67", "245.36", "257.04", "268.72", "280.41", "292.09", "303.77", "315.46", "327.14", "338.83", "35.05", "350.51", "46.73", "58.42", "70.10", "81.79", "93.47", "105.15" },
                    { 16, 31, "14.57", "145.68", "160.25", "174.82", "189.39", "203.96", "218.53", "233.09", "247.66", "262.23", "276.80", "29.14", "291.37", "305.94", "320.50", "335.07", "349.64", "364.21", "378.78", "393.35", "407.91", "422.48", "43.71", "437.05", "58.27", "72.84", "87.41", "101.98", "116.55", "131.12" },
                    { 17, 32, "14.57", "145.68", "160.25", "174.82", "189.39", "203.96", "218.53", "233.09", "247.66", "262.23", "276.80", "29.14", "291.37", "305.94", "320.50", "335.07", "349.64", "364.21", "378.78", "393.35", "407.91", "422.48", "43.71", "437.05", "58.27", "72.84", "87.41", "101.98", "116.55", "131.12" },
                    { 18, 33, "14.57", "145.68", "160.25", "174.82", "189.39", "203.96", "218.53", "233.09", "247.66", "262.23", "276.80", "29.14", "291.37", "305.94", "320.50", "335.07", "349.64", "364.21", "378.78", "393.35", "407.91", "422.48", "43.71", "437.05", "58.27", "72.84", "87.41", "101.98", "116.55", "131.12" },
                    { 19, 34, "14.57", "145.68", "160.25", "174.82", "189.39", "203.96", "218.53", "233.09", "247.66", "262.23", "276.80", "29.14", "291.37", "305.94", "320.50", "335.07", "349.64", "364.21", "378.78", "393.35", "407.91", "422.48", "43.71", "437.05", "58.27", "72.84", "87.41", "101.98", "116.55", "131.12" },
                    { 20, 35, "14.57", "145.68", "160.25", "174.82", "189.39", "203.96", "218.53", "233.09", "247.66", "262.23", "276.80", "29.14", "291.37", "305.94", "320.50", "335.07", "349.64", "364.21", "378.78", "393.35", "407.91", "422.48", "43.71", "437.05", "58.27", "72.84", "87.41", "101.98", "116.55", "131.12" },
                    { 21, 36, "17.43", "174.31", "191.74", "209.17", "226.60", "244.04", "261.47", "278.90", "296.33", "313.76", "331.19", "34.86", "348.62", "366.05", "383.48", "400.92", "418.35", "435.78", "453.21", "470.64", "488.07", "505.50", "52.29", "522.93", "69.72", "87.16", "104.59", "122.02", "139.45", "156.88" },
                    { 22, 37, "17.43", "174.31", "191.74", "209.17", "226.60", "244.04", "261.47", "278.90", "296.33", "313.76", "331.19", "34.86", "348.62", "366.05", "383.48", "400.92", "418.35", "435.78", "453.21", "470.64", "488.07", "505.50", "52.29", "522.93", "69.72", "87.16", "104.59", "122.02", "139.45", "156.88" },
                    { 23, 38, "17.43", "174.31", "191.74", "209.17", "226.60", "244.04", "261.47", "278.90", "296.33", "313.76", "331.19", "34.86", "348.62", "366.05", "383.48", "400.92", "418.35", "435.78", "453.21", "470.64", "488.07", "505.50", "52.29", "522.93", "69.72", "87.16", "104.59", "122.02", "139.45", "156.88" },
                    { 24, 39, "17.43", "174.31", "191.74", "209.17", "226.60", "244.04", "261.47", "278.90", "296.33", "313.76", "331.19", "34.86", "348.62", "366.05", "383.48", "400.92", "418.35", "435.78", "453.21", "470.64", "488.07", "505.50", "52.29", "522.93", "69.72", "87.16", "104.59", "122.02", "139.45", "156.88" },
                    { 25, 40, "17.43", "174.31", "191.74", "209.17", "226.60", "244.04", "261.47", "278.90", "296.33", "313.76", "331.19", "34.86", "348.62", "366.05", "383.48", "400.92", "418.35", "435.78", "453.21", "470.64", "488.07", "505.50", "52.29", "522.93", "69.72", "87.16", "104.59", "122.02", "139.45", "156.88" },
                    { 26, 41, "21.00", "210.00", "231.00", "252.00", "273.00", "294.00", "315.00", "335.99", "356.99", "377.99", "398.99", "42.00", "419.99", "440.99", "461.99", "482.99", "503.99", "524.99", "545.99", "566.99", "587.99", "608.99", "63.00", "629.99", "84.00", "105.00", "126.00", "147.00", "168.00", "189.00" },
                    { 27, 42, "21.00", "210.00", "231.00", "252.00", "273.00", "294.00", "315.00", "335.99", "356.99", "377.99", "398.99", "42.00", "419.99", "440.99", "461.99", "482.99", "503.99", "524.99", "545.99", "566.99", "587.99", "608.99", "63.00", "629.99", "84.00", "105.00", "126.00", "147.00", "168.00", "189.00" },
                    { 28, 43, "21.00", "210.00", "231.00", "252.00", "273.00", "294.00", "315.00", "335.99", "356.99", "377.99", "398.99", "42.00", "419.99", "440.99", "461.99", "482.99", "503.99", "524.99", "545.99", "566.99", "587.99", "608.99", "63.00", "629.99", "84.00", "105.00", "126.00", "147.00", "168.00", "189.00" },
                    { 29, 44, "21.00", "210.00", "231.00", "252.00", "273.00", "294.00", "315.00", "335.99", "356.99", "377.99", "398.99", "42.00", "419.99", "440.99", "461.99", "482.99", "503.99", "524.99", "545.99", "566.99", "587.99", "608.99", "63.00", "629.99", "84.00", "105.00", "126.00", "147.00", "168.00", "189.00" },
                    { 30, 45, "21.00", "210.00", "231.00", "252.00", "273.00", "294.00", "315.00", "335.99", "356.99", "377.99", "398.99", "42.00", "419.99", "440.99", "461.99", "482.99", "503.99", "524.99", "545.99", "566.99", "587.99", "608.99", "63.00", "629.99", "84.00", "105.00", "126.00", "147.00", "168.00", "189.00" },
                    { 31, 46, "25.72", "257.19", "282.90", "308.62", "334.34", "360.06", "385.78", "411.50", "437.22", "462.93", "488.65", "51.44", "514.37", "540.09", "565.81", "591.53", "617.25", "642.96", "668.68", "694.40", "720.12", "745.84", "77.16", "771.56", "102.87", "128.59", "154.31", "180.03", "205.75", "231.47" },
                    { 32, 47, "25.72", "257.19", "282.90", "308.62", "334.34", "360.06", "385.78", "411.50", "437.22", "462.93", "488.65", "51.44", "514.37", "540.09", "565.81", "591.53", "617.25", "642.96", "668.68", "694.40", "720.12", "745.84", "77.16", "771.56", "102.87", "128.59", "154.31", "180.03", "205.75", "231.47" },
                    { 33, 48, "25.72", "257.19", "282.90", "308.62", "334.34", "360.06", "385.78", "411.50", "437.22", "462.93", "488.65", "51.44", "514.37", "540.09", "565.81", "591.53", "617.25", "642.96", "668.68", "694.40", "720.12", "745.84", "77.16", "771.56", "102.87", "128.59", "154.31", "180.03", "205.75", "231.47" },
                    { 34, 49, "25.72", "257.19", "282.90", "308.62", "334.34", "360.06", "385.78", "411.50", "437.22", "462.93", "488.65", "51.44", "514.37", "540.09", "565.81", "591.53", "617.25", "642.96", "668.68", "694.40", "720.12", "745.84", "77.16", "771.56", "102.87", "128.59", "154.31", "180.03", "205.75", "231.47" },
                    { 35, 50, "25.72", "257.19", "282.90", "308.62", "334.34", "360.06", "385.78", "411.50", "437.22", "462.93", "488.65", "51.44", "514.37", "540.09", "565.81", "591.53", "617.25", "642.96", "668.68", "694.40", "720.12", "745.84", "77.16", "771.56", "102.87", "128.59", "154.31", "180.03", "205.75", "231.47" },
                    { 36, 51, "31.20", "312.04", "343.25", "374.45", "405.66", "436.86", "468.06", "499.27", "530.47", "561.68", "592.88", "62.41", "624.08", "655.29", "686.49", "717.70", "748.90", "780.11", "811.31", "842.51", "873.72", "904.92", "93.61", "936.13", "124.82", "156.02", "187.23", "218.43", "249.63", "280.84" },
                    { 37, 52, "31.20", "312.04", "343.25", "374.45", "405.66", "436.86", "468.06", "499.27", "530.47", "561.68", "592.88", "62.41", "624.08", "655.29", "686.49", "717.70", "748.90", "780.11", "811.31", "842.51", "873.72", "904.92", "93.61", "936.13", "124.82", "156.02", "187.23", "218.43", "249.63", "280.84" },
                    { 38, 53, "31.20", "312.04", "343.25", "374.45", "405.66", "436.86", "468.06", "499.27", "530.47", "561.68", "592.88", "62.41", "624.08", "655.29", "686.49", "717.70", "748.90", "780.11", "811.31", "842.51", "873.72", "904.92", "93.61", "936.13", "124.82", "156.02", "187.23", "218.43", "249.63", "280.84" },
                    { 39, 54, "31.20", "312.04", "343.25", "374.45", "405.66", "436.86", "468.06", "499.27", "530.47", "561.68", "592.88", "62.41", "624.08", "655.29", "686.49", "717.70", "748.90", "780.11", "811.31", "842.51", "873.72", "904.92", "93.61", "936.13", "124.82", "156.02", "187.23", "218.43", "249.63", "280.84" },
                    { 40, 55, "31.20", "312.04", "343.25", "374.45", "405.66", "436.86", "468.06", "499.27", "530.47", "561.68", "592.88", "62.41", "624.08", "655.29", "686.49", "717.70", "748.90", "780.11", "811.31", "842.51", "873.72", "904.92", "93.61", "936.13", "124.82", "156.02", "187.23", "218.43", "249.63", "280.84" },
                    { 41, 56, "36.22", "362.25", "398.47", "434.70", "470.92", "507.15", "543.37", "579.60", "615.82", "652.05", "688.27", "72.45", "724.50", "760.72", "796.95", "833.17", "869.39", "905.62", "941.84", "978.07", "1.014.29", "1.050.52", "108.67", "1.086.74", "144.90", "181.12", "217.35", "253.57", "289.80", "326.02" },
                    { 42, 57, "36.22", "362.25", "398.47", "434.70", "470.92", "507.15", "543.37", "579.60", "615.82", "652.05", "688.27", "72.45", "724.50", "760.72", "796.95", "833.17", "869.39", "905.62", "941.84", "978.07", "1.014.29", "1.050.52", "108.67", "1.086.74", "144.90", "181.12", "217.35", "253.57", "289.80", "326.02" },
                    { 43, 58, "36.22", "362.25", "398.47", "434.70", "470.92", "507.15", "543.37", "579.60", "615.82", "652.05", "688.27", "72.45", "724.50", "760.72", "796.95", "833.17", "869.39", "905.62", "941.84", "978.07", "1.014.29", "1.050.52", "108.67", "1.086.74", "144.90", "181.12", "217.35", "253.57", "289.80", "326.02" },
                    { 44, 59, "36.22", "362.25", "398.47", "434.70", "470.92", "507.15", "543.37", "579.60", "615.82", "652.05", "688.27", "72.45", "724.50", "760.72", "796.95", "833.17", "869.39", "905.62", "941.84", "978.07", "1.014.29", "1.050.52", "108.67", "1.086.74", "144.90", "181.12", "217.35", "253.57", "289.80", "326.02" },
                    { 45, 60, "36.22", "362.25", "398.47", "434.70", "470.92", "507.15", "543.37", "579.60", "615.82", "652.05", "688.27", "72.45", "724.50", "760.72", "796.95", "833.17", "869.39", "905.62", "941.84", "978.07", "1.014.29", "1.050.52", "108.67", "1.086.74", "144.90", "181.12", "217.35", "253.57", "289.80", "326.02" },
                    { 46, 61, "40.94", "409.36", "450.30", "491.23", "532.17", "573.11", "614.04", "654.98", "695.92", "736.85", "777.79", "81.87", "818.72", "859.66", "900.60", "941.53", "982.47", "1.023.40", "1.064.34", "1.105.28", "1.146.21", "1.187.15", "122.81", "1.228.09", "163.74", "204.68", "245.62", "286.55", "327.49", "368.43" },
                    { 47, 62, "40.94", "409.36", "450.30", "491.23", "532.17", "573.11", "614.04", "654.98", "695.92", "736.85", "777.79", "81.87", "818.72", "859.66", "900.60", "941.53", "982.47", "1.023.40", "1.064.34", "1.105.28", "1.146.21", "1.187.15", "122.81", "1.228.09", "163.74", "204.68", "245.62", "286.55", "327.49", "368.43" },
                    { 48, 63, "40.94", "409.36", "450.30", "491.23", "532.17", "573.11", "614.04", "654.98", "695.92", "736.85", "777.79", "81.87", "818.72", "859.66", "900.60", "941.53", "982.47", "1.023.40", "1.064.34", "1.105.28", "1.146.21", "1.187.15", "122.81", "1.228.09", "163.74", "204.68", "245.62", "286.55", "327.49", "368.43" },
                    { 49, 64, "40.94", "409.36", "450.30", "491.23", "532.17", "573.11", "614.04", "654.98", "695.92", "736.85", "777.79", "81.87", "818.72", "859.66", "900.60", "941.53", "982.47", "1.023.40", "1.064.34", "1.105.28", "1.146.21", "1.187.15", "122.81", "1.228.09", "163.74", "204.68", "245.62", "286.55", "327.49", "368.43" },
                    { 50, 65, "40.94", "409.36", "450.30", "491.23", "532.17", "573.11", "614.04", "654.98", "695.92", "736.85", "777.79", "81.87", "818.72", "859.66", "900.60", "941.53", "982.47", "1.023.40", "1.064.34", "1.105.28", "1.146.21", "1.187.15", "122.81", "1.228.09", "163.74", "204.68", "245.62", "286.55", "327.49", "368.43" },
                    { 51, 66, "42.82", "428.20", "471.03", "513.85", "556.67", "599.49", "642.31", "685.13", "727.95", "770.77", "813.59", "85.64", "856.41", "899.23", "942.05", "984.87", "1.027.69", "1.070.51", "1.113.33", "1.156.15", "1.198.97", "1.241.79", "128.46", "1.284.61", "171.28", "214.10", "256.92", "299.74", "342.56", "385.38" },
                    { 52, 67, "42.82", "428.20", "471.03", "513.85", "556.67", "599.49", "642.31", "685.13", "727.95", "770.77", "813.59", "85.64", "856.41", "899.23", "942.05", "984.87", "1.027.69", "1.070.51", "1.113.33", "1.156.15", "1.198.97", "1.241.79", "128.46", "1.284.61", "171.28", "214.10", "256.92", "299.74", "342.56", "385.38" },
                    { 53, 68, "42.82", "428.20", "471.03", "513.85", "556.67", "599.49", "642.31", "685.13", "727.95", "770.77", "813.59", "85.64", "856.41", "899.23", "942.05", "984.87", "1.027.69", "1.070.51", "1.113.33", "1.156.15", "1.198.97", "1.241.79", "128.46", "1.284.61", "171.28", "214.10", "256.92", "299.74", "342.56", "385.38" },
                    { 54, 69, "42.82", "428.20", "471.03", "513.85", "556.67", "599.49", "642.31", "685.13", "727.95", "770.77", "813.59", "85.64", "856.41", "899.23", "942.05", "984.87", "1.027.69", "1.070.51", "1.113.33", "1.156.15", "1.198.97", "1.241.79", "128.46", "1.284.61", "171.28", "214.10", "256.92", "299.74", "342.56", "385.38" },
                    { 55, 70, "42.82", "428.20", "471.03", "513.85", "556.67", "599.49", "642.31", "685.13", "727.95", "770.77", "813.59", "85.64", "856.41", "899.23", "942.05", "984.87", "1.027.69", "1.070.51", "1.113.33", "1.156.15", "1.198.97", "1.241.79", "128.46", "1.284.61", "171.28", "214.10", "256.92", "299.74", "342.56", "385.38" },
                    { 56, 71, "47.22", "472.24", "519.46", "566.69", "613.91", "661.13", "708.36", "755.58", "802.80", "850.03", "897.25", "94.45", "944.48", "991.70", "1.038.92", "1.086.15", "1.133.37", "1.180.59", "1.227.82", "1.275.04", "1.322.27", "1.369.49", "141.67", "1.416.71", "188.90", "236.12", "283.34", "330.57", "377.79", "425.01" },
                    { 57, 72, "47.22", "472.24", "519.46", "566.69", "613.91", "661.13", "708.36", "755.58", "802.80", "850.03", "897.25", "94.45", "944.48", "991.70", "1.038.92", "1.086.15", "1.133.37", "1.180.59", "1.227.82", "1.275.04", "1.322.27", "1.369.49", "141.67", "1.416.71", "188.90", "236.12", "283.34", "330.57", "377.79", "425.01" },
                    { 58, 73, "47.22", "472.24", "519.46", "566.69", "613.91", "661.13", "708.36", "755.58", "802.80", "850.03", "897.25", "94.45", "944.48", "991.70", "1.038.92", "1.086.15", "1.133.37", "1.180.59", "1.227.82", "1.275.04", "1.322.27", "1.369.49", "141.67", "1.416.71", "188.90", "236.12", "283.34", "330.57", "377.79", "425.01" },
                    { 59, 74, "47.22", "472.24", "519.46", "566.69", "613.91", "661.13", "708.36", "755.58", "802.80", "850.03", "897.25", "94.45", "944.48", "991.70", "1.038.92", "1.086.15", "1.133.37", "1.180.59", "1.227.82", "1.275.04", "1.322.27", "1.369.49", "141.67", "1.416.71", "188.90", "236.12", "283.34", "330.57", "377.79", "425.01" },
                    { 60, 75, "47.22", "472.24", "519.46", "566.69", "613.91", "661.13", "708.36", "755.58", "802.80", "850.03", "897.25", "94.45", "944.48", "991.70", "1.038.92", "1.086.15", "1.133.37", "1.180.59", "1.227.82", "1.275.04", "1.322.27", "1.369.49", "141.67", "1.416.71", "188.90", "236.12", "283.34", "330.57", "377.79", "425.01" }
                });

            migrationBuilder.InsertData(
                table: "Calculo_DoencasGraves",
                columns: new[] { "Id", "Essencial", "Idade", "Plus", "Premium" },
                values: new object[,]
                {
                    { 1, 0.16, 16, 0.22, 0.45000000000000001 },
                    { 2, 0.16, 17, 0.22, 0.45000000000000001 },
                    { 3, 0.16, 18, 0.22, 0.45000000000000001 },
                    { 4, 0.16, 19, 0.22, 0.45000000000000001 },
                    { 5, 0.16, 20, 0.22, 0.45000000000000001 },
                    { 6, 0.16, 21, 0.22, 0.45000000000000001 },
                    { 7, 0.16, 22, 0.22, 0.45000000000000001 },
                    { 8, 0.16, 23, 0.22, 0.45000000000000001 },
                    { 9, 0.16, 24, 0.22, 0.45000000000000001 },
                    { 10, 0.16, 25, 0.22, 0.45000000000000001 },
                    { 11, 0.17000000000000001, 26, 0.23999999999999999, 0.5 },
                    { 12, 0.17000000000000001, 27, 0.23999999999999999, 0.5 },
                    { 13, 0.17000000000000001, 28, 0.23999999999999999, 0.5 },
                    { 14, 0.17000000000000001, 29, 0.23999999999999999, 0.5 },
                    { 15, 0.17000000000000001, 30, 0.23999999999999999, 0.5 },
                    { 16, 0.23999999999999999, 31, 0.33000000000000002, 0.58999999999999997 },
                    { 17, 0.23999999999999999, 32, 0.33000000000000002, 0.58999999999999997 },
                    { 18, 0.23999999999999999, 33, 0.33000000000000002, 0.58999999999999997 },
                    { 19, 0.23999999999999999, 34, 0.33000000000000002, 0.58999999999999997 },
                    { 20, 0.23999999999999999, 35, 0.33000000000000002, 0.58999999999999997 },
                    { 21, 0.29999999999999999, 36, 0.42999999999999999, 0.68000000000000005 },
                    { 22, 0.29999999999999999, 37, 0.42999999999999999, 0.68000000000000005 },
                    { 23, 0.29999999999999999, 38, 0.42999999999999999, 0.68000000000000005 },
                    { 24, 0.29999999999999999, 39, 0.42999999999999999, 0.68000000000000005 },
                    { 25, 0.29999999999999999, 40, 0.42999999999999999, 0.68000000000000005 },
                    { 26, 0.47999999999999998, 41, 0.69999999999999996, 0.97999999999999998 },
                    { 27, 0.47999999999999998, 42, 0.69999999999999996, 0.97999999999999998 },
                    { 28, 0.47999999999999998, 43, 0.69999999999999996, 0.97999999999999998 },
                    { 29, 0.47999999999999998, 44, 0.69999999999999996, 0.97999999999999998 },
                    { 30, 0.47999999999999998, 45, 0.69999999999999996, 0.97999999999999998 },
                    { 31, 0.66000000000000003, 46, 0.97999999999999998, 1.27 },
                    { 32, 0.66000000000000003, 47, 0.97999999999999998, 1.27 },
                    { 33, 0.66000000000000003, 48, 0.97999999999999998, 1.27 },
                    { 34, 0.66000000000000003, 49, 0.97999999999999998, 1.27 },
                    { 35, 0.66000000000000003, 50, 0.97999999999999998, 1.27 },
                    { 36, 0.95999999999999996, 51, 1.52, 1.8600000000000001 },
                    { 37, 0.95999999999999996, 52, 1.52, 1.8600000000000001 },
                    { 38, 0.95999999999999996, 53, 1.52, 1.8600000000000001 },
                    { 39, 0.95999999999999996, 54, 1.52, 1.8600000000000001 },
                    { 40, 0.95999999999999996, 55, 1.52, 1.8600000000000001 },
                    { 41, 1.3799999999999999, 56, 2.2400000000000002, 2.6200000000000001 },
                    { 42, 1.3799999999999999, 57, 2.2400000000000002, 2.6200000000000001 },
                    { 43, 1.3799999999999999, 58, 2.2400000000000002, 2.6200000000000001 },
                    { 44, 1.3799999999999999, 59, 2.2400000000000002, 2.6200000000000001 },
                    { 45, 1.3799999999999999, 60, 2.2400000000000002, 2.6200000000000001 },
                    { 46, 1.8100000000000001, 61, 3.0600000000000001, 3.5099999999999998 },
                    { 47, 1.8100000000000001, 62, 3.0600000000000001, 3.5099999999999998 },
                    { 48, 1.8100000000000001, 63, 3.0600000000000001, 3.5099999999999998 },
                    { 49, 1.8100000000000001, 64, 3.0600000000000001, 3.5099999999999998 },
                    { 50, 1.8100000000000001, 65, 3.0600000000000001, 3.5099999999999998 }
                });

            migrationBuilder.InsertData(
                table: "Calculo_DoencasGravesMaster",
                columns: new[] { "Id", "Idade", "Valor" },
                values: new object[,]
                {
                    { 1, 66, 3.5299999999999998 },
                    { 2, 67, 3.6899999999999999 },
                    { 3, 68, 3.8500000000000001 },
                    { 4, 69, 4.0599999999999996 },
                    { 5, 70, 4.2699999999999996 },
                    { 6, 71, 4.4699999999999998 },
                    { 7, 72, 4.6799999999999997 },
                    { 8, 73, 4.8799999999999999 },
                    { 9, 74, 5.2000000000000002 },
                    { 10, 75, 5.5300000000000002 },
                    { 11, 76, 5.8499999999999996 },
                    { 12, 77, 5.8899999999999997 },
                    { 13, 78, 6.4900000000000002 },
                    { 14, 79, 7.1600000000000001 },
                    { 15, 80, 7.8899999999999997 },
                    { 16, 81, 8.6799999999999997 },
                    { 17, 82, 9.5500000000000007 },
                    { 18, 83, 10.5 },
                    { 19, 84, 11.51 },
                    { 20, 85, 12.58 }
                });

            migrationBuilder.InsertData(
                table: "Calculo_InvalidezAcidenteMajorada",
                columns: new[] { "Id", "Idade", "Valor" },
                values: new object[,]
                {
                    { 1, 16, 0.12 },
                    { 2, 17, 0.12 },
                    { 3, 18, 0.12 },
                    { 4, 19, 0.12 },
                    { 5, 20, 0.19 },
                    { 6, 21, 0.19 },
                    { 7, 22, 0.19 },
                    { 8, 23, 0.19 },
                    { 9, 24, 0.19 },
                    { 10, 25, 0.19 },
                    { 11, 26, 0.19 },
                    { 12, 27, 0.19 },
                    { 13, 28, 0.19 },
                    { 14, 29, 0.19 },
                    { 15, 30, 0.17000000000000001 },
                    { 16, 31, 0.17000000000000001 },
                    { 17, 32, 0.17000000000000001 },
                    { 18, 33, 0.17000000000000001 },
                    { 19, 34, 0.17000000000000001 },
                    { 20, 35, 0.17000000000000001 },
                    { 21, 36, 0.17000000000000001 },
                    { 22, 37, 0.17000000000000001 },
                    { 23, 38, 0.17000000000000001 },
                    { 24, 39, 0.17000000000000001 },
                    { 25, 40, 0.28999999999999998 },
                    { 26, 41, 0.28999999999999998 },
                    { 27, 42, 0.28999999999999998 },
                    { 28, 43, 0.28999999999999998 },
                    { 29, 44, 0.28999999999999998 },
                    { 30, 45, 0.28999999999999998 },
                    { 31, 46, 0.28999999999999998 },
                    { 32, 47, 0.28999999999999998 },
                    { 33, 48, 0.28999999999999998 },
                    { 34, 49, 0.28999999999999998 },
                    { 35, 50, 0.56000000000000005 },
                    { 36, 51, 0.56000000000000005 },
                    { 37, 52, 0.56000000000000005 },
                    { 38, 53, 0.56000000000000005 },
                    { 39, 54, 0.56000000000000005 },
                    { 40, 55, 0.56000000000000005 },
                    { 41, 56, 0.56000000000000005 },
                    { 42, 57, 0.56000000000000005 },
                    { 43, 58, 0.56000000000000005 },
                    { 44, 59, 0.56000000000000005 },
                    { 45, 60, 1.0900000000000001 },
                    { 46, 61, 1.0900000000000001 },
                    { 47, 62, 1.0900000000000001 },
                    { 48, 63, 1.0900000000000001 },
                    { 49, 64, 1.0900000000000001 },
                    { 50, 65, 1.0900000000000001 }
                });

            migrationBuilder.InsertData(
                table: "Calculo_InvalidezAcidenteMajoradaDoenca",
                columns: new[] { "Id", "Idade", "Valor" },
                values: new object[,]
                {
                    { 1, 16, 0.12 },
                    { 2, 17, 0.12 },
                    { 3, 18, 0.12 },
                    { 4, 19, 0.12 },
                    { 5, 20, 0.12 },
                    { 6, 21, 0.12 },
                    { 7, 22, 0.12 },
                    { 8, 23, 0.12 },
                    { 9, 24, 0.12 },
                    { 10, 25, 0.12 },
                    { 11, 26, 0.13 },
                    { 12, 27, 0.13 },
                    { 13, 28, 0.13 },
                    { 14, 29, 0.13 },
                    { 15, 30, 0.13 },
                    { 16, 31, 0.13 },
                    { 17, 32, 0.13 },
                    { 18, 33, 0.13 },
                    { 19, 34, 0.13 },
                    { 20, 35, 0.13 },
                    { 21, 36, 0.14999999999999999 },
                    { 22, 37, 0.14999999999999999 },
                    { 23, 38, 0.14999999999999999 },
                    { 24, 39, 0.14999999999999999 },
                    { 25, 40, 0.14999999999999999 },
                    { 26, 41, 0.20000000000000001 },
                    { 27, 42, 0.20000000000000001 },
                    { 28, 43, 0.20000000000000001 },
                    { 29, 44, 0.20000000000000001 },
                    { 30, 45, 0.20000000000000001 },
                    { 31, 46, 0.26000000000000001 },
                    { 32, 47, 0.26000000000000001 },
                    { 33, 48, 0.26000000000000001 },
                    { 34, 49, 0.26000000000000001 },
                    { 35, 50, 0.26000000000000001 },
                    { 36, 51, 0.40999999999999998 },
                    { 37, 52, 0.40999999999999998 },
                    { 38, 53, 0.40999999999999998 },
                    { 39, 54, 0.40999999999999998 },
                    { 40, 55, 0.40999999999999998 },
                    { 41, 56, 0.68999999999999995 },
                    { 42, 57, 0.68999999999999995 },
                    { 43, 58, 0.68999999999999995 },
                    { 44, 59, 0.68999999999999995 },
                    { 45, 60, 0.68999999999999995 }
                });

            migrationBuilder.InsertData(
                table: "Calculo_InvalidezTotalAcidente",
                columns: new[] { "Id", "Idade", "Valor" },
                values: new object[,]
                {
                    { 1, 61, 0.070000000000000007 },
                    { 2, 62, 0.070000000000000007 },
                    { 3, 63, 0.070000000000000007 },
                    { 4, 64, 0.070000000000000007 },
                    { 5, 65, 0.070000000000000007 },
                    { 6, 66, 0.070000000000000007 },
                    { 7, 67, 0.070000000000000007 },
                    { 8, 68, 0.070000000000000007 },
                    { 9, 69, 0.070000000000000007 },
                    { 10, 70, 0.070000000000000007 },
                    { 11, 71, 0.070000000000000007 },
                    { 12, 72, 0.070000000000000007 },
                    { 13, 73, 0.070000000000000007 },
                    { 14, 74, 0.070000000000000007 },
                    { 15, 75, 0.070000000000000007 },
                    { 16, 76, 0.070000000000000007 },
                    { 17, 77, 0.070000000000000007 },
                    { 18, 78, 0.070000000000000007 },
                    { 19, 79, 0.070000000000000007 },
                    { 20, 80, 0.070000000000000007 }
                });

            migrationBuilder.InsertData(
                table: "Calculo_MortePorAcidente",
                columns: new[] { "Id", "Idade", "Valor" },
                values: new object[,]
                {
                    { 1, 16, 0.17999999999999999 },
                    { 2, 17, 0.17999999999999999 },
                    { 3, 18, 0.17999999999999999 },
                    { 4, 19, 0.17999999999999999 },
                    { 5, 20, 0.17999999999999999 },
                    { 6, 21, 0.17999999999999999 },
                    { 7, 22, 0.17999999999999999 },
                    { 8, 23, 0.17999999999999999 },
                    { 9, 24, 0.17999999999999999 },
                    { 10, 25, 0.17999999999999999 },
                    { 11, 26, 0.14999999999999999 },
                    { 12, 27, 0.14999999999999999 },
                    { 13, 28, 0.14999999999999999 },
                    { 14, 29, 0.14999999999999999 },
                    { 15, 30, 0.14999999999999999 },
                    { 16, 31, 0.14999999999999999 },
                    { 17, 32, 0.14999999999999999 },
                    { 18, 33, 0.14999999999999999 },
                    { 19, 34, 0.14999999999999999 },
                    { 20, 35, 0.14999999999999999 },
                    { 21, 36, 0.14999999999999999 },
                    { 22, 37, 0.14999999999999999 },
                    { 23, 38, 0.14999999999999999 },
                    { 24, 39, 0.14999999999999999 },
                    { 25, 40, 0.14999999999999999 },
                    { 26, 41, 0.13 },
                    { 27, 42, 0.13 },
                    { 28, 43, 0.13 },
                    { 29, 44, 0.13 },
                    { 30, 45, 0.13 },
                    { 31, 46, 0.13 },
                    { 32, 47, 0.13 },
                    { 33, 48, 0.13 },
                    { 34, 49, 0.13 },
                    { 35, 50, 0.13 },
                    { 36, 51, 0.13 },
                    { 37, 52, 0.13 },
                    { 38, 53, 0.13 },
                    { 39, 54, 0.13 },
                    { 40, 55, 0.13 },
                    { 41, 56, 0.13 },
                    { 42, 57, 0.13 },
                    { 43, 58, 0.13 },
                    { 44, 59, 0.13 },
                    { 45, 60, 0.13 },
                    { 46, 61, 0.13 },
                    { 47, 62, 0.13 },
                    { 48, 63, 0.13 },
                    { 49, 64, 0.13 },
                    { 50, 65, 0.13 },
                    { 51, 66, 0.13 },
                    { 52, 67, 0.13 },
                    { 53, 68, 0.13 },
                    { 54, 69, 0.13 },
                    { 55, 70, 0.13 },
                    { 56, 71, 0.13 },
                    { 57, 72, 0.13 },
                    { 58, 73, 0.13 },
                    { 59, 74, 0.13 },
                    { 60, 75, 0.13 },
                    { 61, 76, 0.13 },
                    { 62, 77, 0.13 },
                    { 63, 78, 0.13 },
                    { 64, 79, 0.13 },
                    { 65, 80, 0.13 }
                });

            migrationBuilder.InsertData(
                table: "Calculo_PensaoPorMorte",
                columns: new[] { "Id", "I10", "I15", "I20", "Idade" },
                values: new object[,]
                {
                    { 1, 24.620000000000001, 34.829999999999998, 43.850000000000001, 16 },
                    { 2, 24.620000000000001, 34.829999999999998, 43.850000000000001, 17 },
                    { 3, 24.620000000000001, 34.829999999999998, 43.850000000000001, 18 },
                    { 4, 24.620000000000001, 34.829999999999998, 43.850000000000001, 19 },
                    { 5, 24.620000000000001, 34.829999999999998, 43.850000000000001, 20 },
                    { 6, 24.620000000000001, 34.829999999999998, 43.850000000000001, 21 },
                    { 7, 24.620000000000001, 34.829999999999998, 43.850000000000001, 22 },
                    { 8, 24.620000000000001, 34.829999999999998, 43.850000000000001, 23 },
                    { 9, 24.620000000000001, 34.829999999999998, 43.850000000000001, 24 },
                    { 10, 24.620000000000001, 34.829999999999998, 43.850000000000001, 25 },
                    { 11, 24.620000000000001, 34.829999999999998, 43.850000000000001, 26 },
                    { 12, 24.620000000000001, 34.829999999999998, 43.850000000000001, 27 },
                    { 13, 24.620000000000001, 34.829999999999998, 43.850000000000001, 28 },
                    { 14, 24.620000000000001, 34.829999999999998, 43.850000000000001, 29 },
                    { 15, 24.620000000000001, 34.829999999999998, 43.850000000000001, 30 },
                    { 16, 29.350000000000001, 41.520000000000003, 52.280000000000001, 31 },
                    { 17, 29.350000000000001, 41.520000000000003, 52.280000000000001, 32 },
                    { 18, 29.350000000000001, 41.520000000000003, 52.280000000000001, 33 },
                    { 19, 29.350000000000001, 41.520000000000003, 52.280000000000001, 34 },
                    { 20, 29.350000000000001, 41.520000000000003, 52.280000000000001, 35 },
                    { 21, 35.890000000000001, 50.770000000000003, 63.920000000000002, 36 },
                    { 22, 35.890000000000001, 50.770000000000003, 63.920000000000002, 37 },
                    { 23, 35.890000000000001, 50.770000000000003, 63.920000000000002, 38 },
                    { 24, 35.890000000000001, 50.770000000000003, 63.920000000000002, 39 },
                    { 25, 35.890000000000001, 50.770000000000003, 63.920000000000002, 40 },
                    { 26, 53.829999999999998, 76.159999999999997, 95.890000000000001, 41 },
                    { 27, 53.829999999999998, 76.159999999999997, 95.890000000000001, 42 },
                    { 28, 53.829999999999998, 76.159999999999997, 95.890000000000001, 43 },
                    { 29, 53.829999999999998, 76.159999999999997, 95.890000000000001, 44 },
                    { 30, 53.829999999999998, 76.159999999999997, 95.890000000000001, 45 },
                    { 31, 79.840000000000003, 112.95, 142.22, 46 },
                    { 32, 79.840000000000003, 112.95, 142.22, 47 },
                    { 33, 79.840000000000003, 112.95, 142.22, 48 },
                    { 34, 79.840000000000003, 112.95, 142.22, 49 },
                    { 35, 79.840000000000003, 112.95, 142.22, 50 },
                    { 36, 121.16, 171.40000000000001, 215.81, 51 },
                    { 37, 121.16, 171.40000000000001, 215.81, 52 },
                    { 38, 121.16, 171.40000000000001, 215.81, 53 },
                    { 39, 121.16, 171.40000000000001, 215.81, 54 },
                    { 40, 121.16, 171.40000000000001, 215.81, 55 },
                    { 41, 189.03999999999999, 267.43000000000001, 336.72000000000003, 56 },
                    { 42, 189.03999999999999, 267.43000000000001, 336.72000000000003, 57 },
                    { 43, 189.03999999999999, 267.43000000000001, 336.72000000000003, 58 },
                    { 44, 189.03999999999999, 267.43000000000001, 336.72000000000003, 59 },
                    { 45, 189.03999999999999, 267.43000000000001, 336.72000000000003, 60 },
                    { 46, 243.97999999999999, 345.16000000000003, 434.57999999999998, 61 },
                    { 47, 266.94, 377.63, 475.45999999999998, 62 },
                    { 48, 292.94999999999999, 414.43000000000001, 521.79999999999995, 63 },
                    { 49, 321.88, 455.36000000000001, 573.33000000000004, 64 },
                    { 50, 353.60000000000002, 500.22000000000003, 629.82000000000005, 65 },
                    { 51, 387.39999999999998, 548.03999999999996, 690.02999999999997, 66 },
                    { 52, 423.42000000000002, 599.00999999999999, 754.20000000000005, 67 },
                    { 53, 461.68000000000001, 653.13, 822.34000000000003, 68 },
                    { 54, 503.13, 711.76999999999998, 896.16999999999996, 69 },
                    { 55, 549.59000000000003, 777.49000000000001, 978.92999999999995, 70 },
                    { 56, 602.30999999999995, 852.07000000000005, 1072.73, 71 },
                    { 57, 662.82000000000005, 937.67999999999995, 1180.6099999999999, 72 },
                    { 58, 732.23000000000002, 1035.8699999999999, 1304.25, 73 },
                    { 59, 809.42999999999995, 1145.0899999999999, 1441.76, 74 },
                    { 60, 892.88999999999999, 1263.1600000000001, 1590.4200000000001, 75 },
                    { 61, 981.08000000000004, 1387.9200000000001, 1747.5, 76 },
                    { 62, 1072.75, 1517.5999999999999, 1910.78, 77 },
                    { 63, 1167.0599999999999, 1651.02, 2078.77, 78 },
                    { 64, 1266.52, 1791.72, 2255.9200000000001, 79 },
                    { 65, 1374.8800000000001, 1945.01, 2448.9299999999998, 80 }
                });

            migrationBuilder.InsertData(
                table: "Calculo_PrazoCerto",
                columns: new[] { "Id", "I10", "I15", "I20", "I5", "Idade" },
                values: new object[,]
                {
                    { 1, 0.20999999999999999, 0.23000000000000001, 0.26000000000000001, 0.20000000000000001, 16 },
                    { 2, 0.20999999999999999, 0.23000000000000001, 0.26000000000000001, 0.20000000000000001, 17 },
                    { 3, 0.20999999999999999, 0.23000000000000001, 0.26000000000000001, 0.20000000000000001, 18 },
                    { 4, 0.20999999999999999, 0.23000000000000001, 0.26000000000000001, 0.20000000000000001, 19 },
                    { 5, 0.20999999999999999, 0.23000000000000001, 0.26000000000000001, 0.20000000000000001, 20 },
                    { 6, 0.20999999999999999, 0.23000000000000001, 0.26000000000000001, 0.20000000000000001, 21 },
                    { 7, 0.20999999999999999, 0.23000000000000001, 0.26000000000000001, 0.20000000000000001, 22 },
                    { 8, 0.20999999999999999, 0.23000000000000001, 0.26000000000000001, 0.20000000000000001, 23 },
                    { 9, 0.20999999999999999, 0.23000000000000001, 0.26000000000000001, 0.20000000000000001, 24 },
                    { 10, 0.20999999999999999, 0.23000000000000001, 0.26000000000000001, 0.20000000000000001, 25 },
                    { 11, 0.20999999999999999, 0.23000000000000001, 0.26000000000000001, 0.20000000000000001, 26 },
                    { 12, 0.20999999999999999, 0.23000000000000001, 0.26000000000000001, 0.20000000000000001, 27 },
                    { 13, 0.20999999999999999, 0.23000000000000001, 0.26000000000000001, 0.20000000000000001, 28 },
                    { 14, 0.20999999999999999, 0.23000000000000001, 0.26000000000000001, 0.20000000000000001, 29 },
                    { 15, 0.20999999999999999, 0.23000000000000001, 0.26000000000000001, 0.20000000000000001, 30 },
                    { 16, 0.29999999999999999, 0.35999999999999999, 0.42999999999999999, 0.25, 31 },
                    { 17, 0.29999999999999999, 0.35999999999999999, 0.42999999999999999, 0.25, 32 },
                    { 18, 0.29999999999999999, 0.35999999999999999, 0.42999999999999999, 0.25, 33 },
                    { 19, 0.29999999999999999, 0.35999999999999999, 0.42999999999999999, 0.25, 34 },
                    { 20, 0.29999999999999999, 0.35999999999999999, 0.42999999999999999, 0.25, 35 },
                    { 21, 0.42999999999999999, 0.53000000000000003, 0.65000000000000002, 0.34999999999999998, 36 },
                    { 22, 0.42999999999999999, 0.53000000000000003, 0.65000000000000002, 0.34999999999999998, 37 },
                    { 23, 0.42999999999999999, 0.53000000000000003, 0.65000000000000002, 0.34999999999999998, 38 },
                    { 24, 0.42999999999999999, 0.53000000000000003, 0.65000000000000002, 0.34999999999999998, 39 },
                    { 25, 0.42999999999999999, 0.53000000000000003, 0.65000000000000002, 0.34999999999999998, 40 },
                    { 26, 0.65000000000000002, 0.80000000000000004, 0.97999999999999998, 0.53000000000000003, 41 },
                    { 27, 0.65000000000000002, 0.80000000000000004, 0.97999999999999998, 0.53000000000000003, 42 },
                    { 28, 0.65000000000000002, 0.80000000000000004, 0.97999999999999998, 0.53000000000000003, 43 },
                    { 29, 0.65000000000000002, 0.80000000000000004, 0.97999999999999998, 0.53000000000000003, 44 },
                    { 30, 0.65000000000000002, 0.80000000000000004, 0.97999999999999998, 0.53000000000000003, 45 },
                    { 31, 0.97999999999999998, 1.21, 1.5, 0.79000000000000004, 46 },
                    { 32, 0.97999999999999998, 1.21, 1.5, 0.79000000000000004, 47 },
                    { 33, 0.97999999999999998, 1.21, 1.5, 0.79000000000000004, 48 },
                    { 34, 0.97999999999999998, 1.21, 1.5, 0.79000000000000004, 49 },
                    { 35, 0.97999999999999998, 1.21, 1.5, 0.79000000000000004, 50 },
                    { 36, 1.52, 1.8799999999999999, 0.0, 1.23, 51 },
                    { 37, 1.52, 1.8799999999999999, 0.0, 1.23, 52 },
                    { 38, 1.52, 1.8799999999999999, 0.0, 1.23, 53 },
                    { 39, 1.52, 1.8799999999999999, 0.0, 1.23, 54 },
                    { 40, 1.52, 1.8799999999999999, 0.0, 1.23, 55 },
                    { 41, 2.3599999999999999, 0.0, 0.0, 1.8899999999999999, 56 },
                    { 42, 2.3599999999999999, 0.0, 0.0, 1.8899999999999999, 57 },
                    { 43, 2.3599999999999999, 0.0, 0.0, 1.8899999999999999, 58 },
                    { 44, 2.3599999999999999, 0.0, 0.0, 1.8899999999999999, 59 },
                    { 45, 2.3599999999999999, 0.0, 0.0, 1.8899999999999999, 60 }
                });

            migrationBuilder.InsertData(
                table: "Calculo_RendaInvalidez",
                columns: new[] { "Id", "I20", "I30", "Idade" },
                values: new object[,]
                {
                    { 1, 14.140000000000001, 18.870000000000001, 16 },
                    { 2, 14.140000000000001, 18.870000000000001, 17 },
                    { 3, 14.140000000000001, 18.870000000000001, 18 },
                    { 4, 14.140000000000001, 18.870000000000001, 19 },
                    { 5, 14.140000000000001, 18.870000000000001, 20 },
                    { 6, 14.140000000000001, 18.870000000000001, 21 },
                    { 7, 14.140000000000001, 18.870000000000001, 22 },
                    { 8, 14.140000000000001, 18.870000000000001, 23 },
                    { 9, 14.140000000000001, 18.870000000000001, 24 },
                    { 10, 14.140000000000001, 18.870000000000001, 25 },
                    { 11, 14.140000000000001, 18.870000000000001, 26 },
                    { 12, 14.140000000000001, 18.870000000000001, 27 },
                    { 13, 14.140000000000001, 18.870000000000001, 28 },
                    { 14, 14.140000000000001, 18.870000000000001, 29 },
                    { 15, 14.140000000000001, 18.870000000000001, 30 },
                    { 16, 15.76, 20.890000000000001, 31 },
                    { 17, 15.76, 20.890000000000001, 32 },
                    { 18, 15.76, 20.890000000000001, 33 },
                    { 19, 15.76, 20.890000000000001, 34 },
                    { 20, 15.76, 20.890000000000001, 35 },
                    { 21, 18.600000000000001, 24.5, 36 },
                    { 22, 18.600000000000001, 24.5, 37 },
                    { 23, 18.600000000000001, 24.5, 38 },
                    { 24, 18.600000000000001, 24.5, 39 },
                    { 25, 18.600000000000001, 24.5, 40 },
                    { 26, 24.41, 31.84, 41 },
                    { 27, 24.41, 31.84, 42 },
                    { 28, 24.41, 31.84, 43 },
                    { 29, 24.41, 31.84, 44 },
                    { 30, 24.41, 31.84, 45 },
                    { 31, 35.810000000000002, 45.950000000000003, 46 },
                    { 32, 35.810000000000002, 45.950000000000003, 47 },
                    { 33, 35.810000000000002, 45.950000000000003, 48 },
                    { 34, 35.810000000000002, 45.950000000000003, 49 },
                    { 35, 35.810000000000002, 45.950000000000003, 50 },
                    { 36, 57.460000000000001, 71.870000000000005, 51 },
                    { 37, 57.460000000000001, 71.870000000000005, 52 },
                    { 38, 57.460000000000001, 71.870000000000005, 53 },
                    { 39, 57.460000000000001, 71.870000000000005, 54 },
                    { 40, 57.460000000000001, 71.870000000000005, 55 },
                    { 41, 97.25, 117.28, 56 },
                    { 42, 97.25, 117.28, 57 },
                    { 43, 97.25, 117.28, 58 },
                    { 44, 97.25, 117.28, 59 },
                    { 45, 97.25, 117.28, 60 }
                });

            migrationBuilder.InsertData(
                table: "Calculo_SafLuxo",
                columns: new[] { "Id", "Familiar", "Idade", "Individual" },
                values: new object[,]
                {
                    { 1, 5.0099999999999998, 16, 1.5600000000000001 },
                    { 2, 5.0099999999999998, 17, 1.5600000000000001 },
                    { 3, 5.0099999999999998, 18, 1.5600000000000001 },
                    { 4, 5.0099999999999998, 19, 1.5600000000000001 },
                    { 5, 5.0099999999999998, 20, 1.5600000000000001 },
                    { 6, 5.0099999999999998, 21, 1.5600000000000001 },
                    { 7, 5.0099999999999998, 22, 1.5600000000000001 },
                    { 8, 5.0099999999999998, 23, 1.5600000000000001 },
                    { 9, 5.0099999999999998, 24, 1.5600000000000001 },
                    { 10, 5.0099999999999998, 25, 1.5600000000000001 },
                    { 11, 5.0099999999999998, 26, 1.5600000000000001 },
                    { 12, 5.0099999999999998, 27, 1.5600000000000001 },
                    { 13, 5.0099999999999998, 28, 1.5600000000000001 },
                    { 14, 5.0099999999999998, 29, 1.5600000000000001 },
                    { 15, 5.0099999999999998, 30, 1.5600000000000001 },
                    { 16, 5.0099999999999998, 31, 1.5600000000000001 },
                    { 17, 5.0099999999999998, 32, 1.5600000000000001 },
                    { 18, 5.0099999999999998, 33, 1.5600000000000001 },
                    { 19, 5.0099999999999998, 34, 1.5600000000000001 },
                    { 20, 5.0099999999999998, 35, 1.5600000000000001 },
                    { 21, 6.7599999999999998, 36, 2.3700000000000001 },
                    { 22, 6.7599999999999998, 37, 2.3700000000000001 },
                    { 23, 6.7599999999999998, 38, 2.3700000000000001 },
                    { 24, 6.7599999999999998, 39, 2.3700000000000001 },
                    { 25, 6.7599999999999998, 40, 2.3700000000000001 },
                    { 26, 9.8399999999999999, 41, 3.5600000000000001 },
                    { 27, 9.8399999999999999, 42, 3.5600000000000001 },
                    { 28, 9.8399999999999999, 43, 3.5600000000000001 },
                    { 29, 9.8399999999999999, 44, 3.5600000000000001 },
                    { 30, 9.8399999999999999, 45, 3.5600000000000001 },
                    { 31, 12.73, 46, 5.2800000000000002 },
                    { 32, 12.73, 47, 5.2800000000000002 },
                    { 33, 12.73, 48, 5.2800000000000002 },
                    { 34, 12.73, 49, 5.2800000000000002 },
                    { 35, 12.73, 50, 5.2800000000000002 },
                    { 36, 17.370000000000001, 51, 8.0099999999999998 },
                    { 37, 17.370000000000001, 52, 8.0099999999999998 },
                    { 38, 17.370000000000001, 53, 8.0099999999999998 },
                    { 39, 17.370000000000001, 54, 8.0099999999999998 },
                    { 40, 17.370000000000001, 55, 8.0099999999999998 },
                    { 41, 26.02, 56, 12.5 },
                    { 42, 26.02, 57, 12.5 },
                    { 43, 26.02, 58, 12.5 },
                    { 44, 26.02, 59, 12.5 },
                    { 45, 26.02, 60, 12.5 },
                    { 46, 33.390000000000001, 61, 16.140000000000001 },
                    { 47, 36.380000000000003, 62, 17.66 },
                    { 48, 39.729999999999997, 63, 19.379999999999999 },
                    { 49, 43.490000000000002, 64, 21.289999999999999 },
                    { 50, 47.600000000000001, 65, 23.390000000000001 },
                    { 51, 52.130000000000003, 66, 25.629999999999999 },
                    { 52, 57.009999999999998, 67, 28.010000000000002 },
                    { 53, 62.299999999999997, 68, 30.539999999999999 },
                    { 54, 67.959999999999994, 69, 33.280000000000001 },
                    { 55, 74.150000000000006, 70, 36.359999999999999 },
                    { 56, 80.950000000000003, 71, 39.840000000000003 },
                    { 57, 88.560000000000002, 72, 43.850000000000001 },
                    { 58, 97.140000000000001, 73, 48.439999999999998 },
                    { 59, 106.81999999999999, 74, 53.539999999999999 },
                    { 60, 117.56, 75, 59.060000000000002 },
                    { 61, 129.36000000000001, 76, 64.900000000000006 },
                    { 62, 142.09999999999999, 77, 70.959999999999994 },
                    { 63, 155.53, 78, 77.200000000000003 },
                    { 64, 169.77000000000001, 79, 83.780000000000001 },
                    { 65, 184.88999999999999, 80, 90.950000000000003 },
                    { 66, 185.66999999999999, 81, 98.900000000000006 },
                    { 67, 202.09, 82, 107.89 },
                    { 68, 206.72999999999999, 83, 118.02 },
                    { 69, 225.61000000000001, 84, 129.05000000000001 },
                    { 70, 230.0, 85, 140.74000000000001 }
                });

            migrationBuilder.InsertData(
                table: "Calculo_SafSuperLuxo",
                columns: new[] { "Id", "Familiar", "Idade", "Individual" },
                values: new object[,]
                {
                    { 1, 6.3799999999999999, 16, 1.99 },
                    { 2, 6.3799999999999999, 17, 1.99 },
                    { 3, 6.3799999999999999, 18, 1.99 },
                    { 4, 6.3799999999999999, 19, 1.99 },
                    { 5, 6.3799999999999999, 20, 1.99 },
                    { 6, 6.3799999999999999, 21, 1.99 },
                    { 7, 6.3799999999999999, 22, 1.99 },
                    { 8, 6.3799999999999999, 23, 1.99 },
                    { 9, 6.3799999999999999, 24, 1.99 },
                    { 10, 6.3799999999999999, 25, 1.99 },
                    { 11, 6.3799999999999999, 26, 1.99 },
                    { 12, 6.3799999999999999, 27, 1.99 },
                    { 13, 6.3799999999999999, 28, 1.99 },
                    { 14, 6.3799999999999999, 29, 1.99 },
                    { 15, 6.3799999999999999, 30, 1.99 },
                    { 16, 6.3799999999999999, 31, 1.99 },
                    { 17, 6.3799999999999999, 32, 1.99 },
                    { 18, 6.3799999999999999, 33, 1.99 },
                    { 19, 6.3799999999999999, 34, 1.99 },
                    { 20, 6.3799999999999999, 35, 1.99 },
                    { 21, 8.6099999999999994, 36, 3.02 },
                    { 22, 8.6099999999999994, 37, 3.02 },
                    { 23, 8.6099999999999994, 38, 3.02 },
                    { 24, 8.6099999999999994, 39, 3.02 },
                    { 25, 8.6099999999999994, 40, 3.02 },
                    { 26, 12.52, 41, 4.5300000000000002 },
                    { 27, 12.52, 42, 4.5300000000000002 },
                    { 28, 12.52, 43, 4.5300000000000002 },
                    { 29, 12.52, 44, 4.5300000000000002 },
                    { 30, 12.52, 45, 4.5300000000000002 },
                    { 31, 16.199999999999999, 46, 6.7199999999999998 },
                    { 32, 16.199999999999999, 47, 6.7199999999999998 },
                    { 33, 16.199999999999999, 48, 6.7199999999999998 },
                    { 34, 16.199999999999999, 49, 6.7199999999999998 },
                    { 35, 16.199999999999999, 50, 6.7199999999999998 },
                    { 36, 22.109999999999999, 51, 10.199999999999999 },
                    { 37, 22.109999999999999, 52, 10.199999999999999 },
                    { 38, 22.109999999999999, 53, 10.199999999999999 },
                    { 39, 22.109999999999999, 54, 10.199999999999999 },
                    { 40, 22.109999999999999, 55, 10.199999999999999 },
                    { 41, 33.119999999999997, 56, 15.92 },
                    { 42, 33.119999999999997, 57, 15.92 },
                    { 43, 33.119999999999997, 58, 15.92 },
                    { 44, 33.119999999999997, 59, 15.92 },
                    { 45, 33.119999999999997, 60, 15.92 },
                    { 46, 42.5, 61, 20.539999999999999 },
                    { 47, 46.310000000000002, 62, 22.469999999999999 },
                    { 48, 50.57, 63, 24.66 },
                    { 49, 55.350000000000001, 64, 27.100000000000001 },
                    { 50, 60.579999999999998, 65, 29.77 },
                    { 51, 66.340000000000003, 66, 32.619999999999997 },
                    { 52, 72.560000000000002, 67, 35.649999999999999 },
                    { 53, 79.299999999999997, 68, 38.869999999999997 },
                    { 54, 86.5, 69, 42.359999999999999 },
                    { 55, 94.379999999999995, 70, 46.270000000000003 },
                    { 56, 103.02, 71, 50.710000000000001 },
                    { 57, 112.70999999999999, 72, 55.799999999999997 },
                    { 58, 123.63, 73, 61.649999999999999 },
                    { 59, 135.94999999999999, 74, 68.150000000000006 },
                    { 60, 149.62, 75, 75.170000000000002 },
                    { 61, 164.63999999999999, 76, 82.599999999999994 },
                    { 62, 180.84999999999999, 77, 90.319999999999993 },
                    { 63, 197.94999999999999, 78, 98.260000000000005 },
                    { 64, 216.06999999999999, 79, 106.63 },
                    { 65, 235.31999999999999, 80, 115.75 },
                    { 66, 236.30000000000001, 81, 125.87 },
                    { 67, 257.20999999999998, 82, 137.31 },
                    { 68, 263.11000000000001, 83, 150.21000000000001 },
                    { 69, 287.13999999999999, 84, 164.25 },
                    { 70, 292.72000000000003, 85, 179.12 }
                });

            migrationBuilder.InsertData(
                table: "Calculo_SafSuperLuxoPorIdade",
                columns: new[] { "Id", "Familiar", "IdadeMaxima", "IdadeMinima", "Individual" },
                values: new object[,]
                {
                    { 1, 6.3799999999999999, 35, 16, 1.99 },
                    { 2, 8.6099999999999994, 40, 36, 3.02 },
                    { 3, 1.52, 45, 41, 4.5300000000000002 },
                    { 4, 16.199999999999999, 50, 46, 6.7199999999999998 },
                    { 5, 22.109999999999999, 55, 51, 10.199999999999999 },
                    { 6, 33.119999999999997, 60, 56, 15.92 },
                    { 7, 42.5, 61, 61, 20.539999999999999 },
                    { 8, 46.310000000000002, 62, 62, 22.469999999999999 },
                    { 9, 50.57, 63, 63, 24.66 },
                    { 10, 55.350000000000001, 64, 64, 27.100000000000001 },
                    { 11, 60.579999999999998, 65, 65, 29.77 },
                    { 12, 66.340000000000003, 66, 66, 32.619999999999997 },
                    { 13, 72.560000000000002, 67, 67, 35.649999999999999 },
                    { 14, 79.299999999999997, 68, 68, 38.869999999999997 },
                    { 15, 86.5, 69, 69, 42.359999999999999 },
                    { 16, 94.379999999999995, 70, 70, 46.270000000000003 },
                    { 17, 103.02, 71, 71, 50.710000000000001 },
                    { 18, 112.70999999999999, 72, 72, 55.799999999999997 },
                    { 19, 123.63, 73, 73, 61.649999999999999 },
                    { 20, 135.94999999999999, 74, 74, 68.150000000000006 },
                    { 21, 149.62, 75, 75, 75.170000000000002 },
                    { 22, 164.63999999999999, 76, 76, 82.599999999999994 },
                    { 23, 180.84999999999999, 77, 77, 90.319999999999993 },
                    { 24, 197.94999999999999, 78, 78, 98.260000000000005 },
                    { 25, 216.06999999999999, 79, 79, 106.63 },
                    { 26, 235.31999999999999, 80, 80, 115.75 },
                    { 27, 236.30000000000001, 81, 81, 125.87 },
                    { 28, 257.20999999999998, 82, 82, 137.31 },
                    { 29, 263.11000000000001, 83, 83, 150.21000000000001 },
                    { 30, 287.13999999999999, 84, 84, 164.25 },
                    { 31, 292.72000000000003, 85, 85, 179.12 }
                });

            migrationBuilder.InsertData(
                table: "Calculo_TaxaPrevcom",
                columns: new[] { "Id", "Idade", "Invalidez", "Morte", "PercentualReajusteInvalidez", "PercentualReajusteMorte" },
                values: new object[,]
                {
                    { 1, 14, 6.9099999999999999E-05, 5.5999999999999999E-05, 0.0, 0.0 },
                    { 2, 15, 6.9099999999999999E-05, 5.5999999999999999E-05, 0.0, 0.0 },
                    { 3, 16, 6.9099999999999999E-05, 5.5999999999999999E-05, 0.0, 0.0 },
                    { 4, 17, 6.9099999999999999E-05, 5.5999999999999999E-05, 0.0, 0.0 },
                    { 5, 18, 6.9099999999999999E-05, 5.5999999999999999E-05, 0.0, 0.0 },
                    { 6, 19, 6.9099999999999999E-05, 5.5999999999999999E-05, 0.0, 0.0 },
                    { 7, 20, 6.9099999999999999E-05, 5.5999999999999999E-05, 0.0, 0.0 },
                    { 8, 21, 6.9099999999999999E-05, 5.5999999999999999E-05, 0.0, 0.0 },
                    { 9, 22, 6.9099999999999999E-05, 5.5999999999999999E-05, 0.0, 0.0 },
                    { 10, 23, 6.9099999999999999E-05, 5.5999999999999999E-05, 0.0, 0.0 },
                    { 11, 24, 6.9099999999999999E-05, 5.5999999999999999E-05, 0.0, 0.0 },
                    { 12, 25, 6.9099999999999999E-05, 5.5999999999999999E-05, 0.0, 0.0 },
                    { 13, 26, 6.9099999999999999E-05, 5.5999999999999999E-05, 0.0, 0.0 },
                    { 14, 27, 6.9099999999999999E-05, 5.5999999999999999E-05, 0.0, 0.0 },
                    { 15, 28, 6.9099999999999999E-05, 5.5999999999999999E-05, 0.0, 0.0 },
                    { 16, 29, 6.9099999999999999E-05, 5.5999999999999999E-05, 0.0, 0.0 },
                    { 17, 30, 6.9099999999999999E-05, 5.5999999999999999E-05, 0.0, 0.0 },
                    { 18, 31, 6.9099999999999999E-05, 5.5999999999999999E-05, 0.0, 0.0 },
                    { 19, 32, 6.9099999999999999E-05, 5.5999999999999999E-05, 0.0, 0.0 },
                    { 20, 33, 6.9099999999999999E-05, 5.5999999999999999E-05, 0.0, 0.0 },
                    { 21, 34, 6.9099999999999999E-05, 5.5999999999999999E-05, 0.0, 0.0 },
                    { 22, 35, 6.9099999999999999E-05, 5.5999999999999999E-05, 0.0, 0.0 },
                    { 23, 36, 9.0500000000000004E-05, 9.2100000000000003E-05, 31.050000000000001, 64.549999999999997 },
                    { 24, 37, 9.0500000000000004E-05, 9.2100000000000003E-05, 31.050000000000001, 64.549999999999997 },
                    { 25, 38, 9.0500000000000004E-05, 9.2100000000000003E-05, 31.050000000000001, 64.549999999999997 },
                    { 26, 39, 9.0500000000000004E-05, 9.2100000000000003E-05, 31.050000000000001, 64.549999999999997 },
                    { 27, 40, 9.0500000000000004E-05, 9.2100000000000003E-05, 31.050000000000001, 64.549999999999997 },
                    { 28, 41, 0.00012010000000000001, 0.00015589999999999999, 32.719999999999999, 69.299999999999997 },
                    { 29, 42, 0.00012010000000000001, 0.00015589999999999999, 32.719999999999999, 69.299999999999997 },
                    { 30, 43, 0.00012010000000000001, 0.00015589999999999999, 32.719999999999999, 69.299999999999997 },
                    { 31, 44, 0.00012010000000000001, 0.00015589999999999999, 32.719999999999999, 69.299999999999997 },
                    { 32, 45, 0.00012010000000000001, 0.00015589999999999999, 32.719999999999999, 69.299999999999997 },
                    { 33, 46, 0.00017899999999999999, 0.0002764, 49.009999999999998, 77.25 },
                    { 34, 47, 0.00017899999999999999, 0.0002764, 49.009999999999998, 77.25 },
                    { 35, 48, 0.00017899999999999999, 0.0002764, 49.009999999999998, 77.25 },
                    { 36, 49, 0.00017899999999999999, 0.0002764, 49.009999999999998, 77.25 },
                    { 37, 50, 0.00017899999999999999, 0.0002764, 49.009999999999998, 77.25 },
                    { 38, 51, 0.00029359999999999998, 0.00042969999999999998, 64.060000000000002, 55.490000000000002 },
                    { 39, 52, 0.00029359999999999998, 0.00042969999999999998, 64.060000000000002, 55.490000000000002 },
                    { 40, 53, 0.00029359999999999998, 0.00042969999999999998, 64.060000000000002, 55.490000000000002 },
                    { 41, 54, 0.00029359999999999998, 0.00042969999999999998, 64.060000000000002, 55.490000000000002 },
                    { 42, 55, 0.00029359999999999998, 0.00042969999999999998, 64.060000000000002, 55.490000000000002 },
                    { 43, 56, 0.0005153, 0.00060269999999999996, 75.469999999999999, 40.25 },
                    { 44, 57, 0.0005153, 0.00060269999999999996, 75.469999999999999, 40.25 },
                    { 45, 58, 0.0005153, 0.00060269999999999996, 75.469999999999999, 40.25 },
                    { 46, 59, 0.0005153, 0.00060269999999999996, 75.469999999999999, 40.25 },
                    { 47, 60, 0.0005153, 0.00060269999999999996, 75.469999999999999, 40.25 },
                    { 48, 61, 0.00094129999999999995, 0.0008788, 82.689999999999998, 45.82 },
                    { 49, 62, 0.00094129999999999995, 0.0008788, 82.689999999999998, 45.82 },
                    { 50, 63, 0.00094129999999999995, 0.0008788, 82.689999999999998, 45.82 },
                    { 51, 64, 0.00094129999999999995, 0.0008788, 82.689999999999998, 45.82 },
                    { 52, 65, 0.00094129999999999995, 0.0008788, 82.689999999999998, 45.82 },
                    { 53, 66, 0.0013672000000000001, 0.0011739000000000001, 45.240000000000002, 33.57 },
                    { 54, 67, 0.0015502000000000001, 0.0012994, 13.390000000000001, 10.69 },
                    { 55, 68, 0.0017587, 0.0014396999999999999, 13.449999999999999, 10.800000000000001 },
                    { 56, 69, 0.0019962000000000001, 0.0015953, 13.5, 10.81 },
                    { 57, 70, 0.0022666000000000001, 0.0017668, 13.56, 10.82 },
                    { 58, 71, 0.0025755000000000001, 0.0019550000000000001, 13.609999999999999, 10.83 },
                    { 59, 72, 0.0029321999999999998, 0.0021608999999999999, 13.67, 10.84 },
                    { 60, 73, 0.0033465000000000001, 0.0023855999999999999, 13.720000000000001, 10.85 },
                    { 61, 74, 0.0038302000000000002, 0.0026304000000000002, 13.779999999999999, 10.859999999999999 },
                    { 62, 75, 0.0043975000000000004, 0.0028968000000000002, 13.83, 10.869999999999999 },
                    { 63, 76, 0.0050660000000000002, 0.0031862000000000001, 13.890000000000001, 10.880000000000001 },
                    { 64, 77, 0.0058569, 0.0035005000000000001, 13.94, 10.890000000000001 },
                    { 65, 78, 0.0067952999999999998, 0.0038417, 14.0, 10.9 },
                    { 66, 79, 0.0079105000000000009, 0.0042123999999999998, 14.050000000000001, 10.91 },
                    { 67, 80, 0.0092356999999999995, 0.0046153000000000001, 14.109999999999999, 10.92 },
                    { 68, 80, 0.0092356999999999995, 0.0046153000000000001, 14.109999999999999, 10.92 },
                    { 69, 81, 0.010997399999999999, 0.0050639999999999999, 14.16, 10.93 },
                    { 70, 82, 0.012915299999999999, 0.0055639000000000001, 14.220000000000001, 10.94 },
                    { 71, 83, 0.0150052, 0.0061222000000000004, 14.279999999999999, 10.949999999999999 },
                    { 72, 84, 0.017284299999999999, 0.0067467999999999998, 14.34, 10.960000000000001 },
                    { 73, 85, 0.019769100000000001, 0.0074453999999999996, 14.4, 10.970000000000001 },
                    { 74, 86, 0.0224771, 0.0082264999999999994, 14.460000000000001, 10.98 },
                    { 75, 87, 0.025426199999999999, 0.0090994999999999999, 14.52, 10.99 },
                    { 76, 88, 0.028635299999999999, 0.0100742, 14.58, 11.0 },
                    { 77, 89, 0.032124100000000003, 0.011161600000000001, 14.640000000000001, 11.01 },
                    { 78, 90, 0.035913599999999997, 0.0123725, 14.699999999999999, 11.02 },
                    { 79, 91, 0.040024900000000002, 0.0137191, 14.76, 11.029999999999999 },
                    { 80, 92, 0.044478999999999998, 0.015213900000000001, 14.82, 11.039999999999999 },
                    { 81, 93, 0.049297500000000001, 0.0168693, 14.880000000000001, 11.050000000000001 },
                    { 82, 94, 0.0545029, 0.018698800000000002, 14.94, 11.06 },
                    { 83, 95, 0.060117900000000002, 0.020716700000000001, 15.0, 11.07 },
                    { 84, 96, 0.066164100000000003, 0.022938400000000001, 15.06, 11.08 },
                    { 85, 97, 0.072663000000000005, 0.0253806, 15.119999999999999, 11.09 },
                    { 86, 98, 0.079635300000000006, 0.028059199999999999, 15.18, 11.1 },
                    { 87, 99, 0.0871006, 0.030990400000000001, 15.24, 11.109999999999999 },
                    { 88, 100, 0.095077800000000004, 0.034189600000000001, 15.300000000000001, 11.119999999999999 },
                    { 89, 101, 0.10358299999999999, 0.037672600000000001, 15.359999999999999, 11.130000000000001 },
                    { 90, 102, 0.112631, 0.041454100000000001, 15.42, 11.140000000000001 },
                    { 91, 103, 0.1222369, 0.0455483, 15.48, 11.15 },
                    { 92, 104, 0.1324138, 0.049968100000000001, 15.539999999999999, 11.16 },
                    { 93, 105, 0.14317350000000001, 0.054725799999999998, 15.6, 11.17 },
                    { 94, 106, 0.15452689999999999, 0.059832700000000003, 15.66, 11.18 },
                    { 95, 107, 0.16648379999999999, 0.065299800000000005, 15.720000000000001, 11.19 },
                    { 96, 108, 0.17905299999999999, 0.071137199999999998, 15.779999999999999, 11.199999999999999 },
                    { 97, 109, 0.19224289999999999, 0.077354099999999995, 15.84, 11.210000000000001 },
                    { 98, 110, 0.20606099999999999, 0.083959699999999998, 15.9, 11.220000000000001 },
                    { 99, 111, 0.22051480000000001, 0.0909634, 15.960000000000001, 11.23 },
                    { 100, 112, 0.23561170000000001, 0.0983739, 16.02, 11.24 },
                    { 101, 113, 0.25135879999999999, 0.1062007, 16.079999999999998, 11.25 },
                    { 102, 114, 0.26776359999999999, 0.1144529, 16.140000000000001, 11.26 }
                });

            migrationBuilder.InsertData(
                table: "Calculo_TermLife",
                columns: new[] { "Id", "Feminino10", "Feminino15", "Feminino20", "Feminino25", "Feminino30", "Idade", "Masculino10", "Masculino15", "Masculino20", "Masculino25", "Masculino30" },
                values: new object[,]
                {
                    { 1, 0.043549999999999998, 0.051319999999999998, 0.062719999999999998, 0.080079999999999998, 0.10271, 25, 0.0974, 0.1047, 0.1169, 0.13763, 0.17086000000000001 },
                    { 2, 0.045969999999999997, 0.054539999999999998, 0.06726, 0.086529999999999996, 0.11099000000000001, 26, 0.098680000000000004, 0.1074, 0.12149, 0.14527999999999999, 0.18265999999999999 },
                    { 3, 0.048680000000000001, 0.058290000000000002, 0.072309999999999999, 0.093630000000000005, 0.12013, 27, 0.10048, 0.11076, 0.12686, 0.15423000000000001, 0.19578999999999999 },
                    { 4, 0.051700000000000003, 0.062560000000000004, 0.077969999999999998, 0.10135, 0.13019, 28, 0.10313, 0.115, 0.13314999999999999, 0.16467000000000001, 0.21049999999999999 },
                    { 5, 0.054980000000000001, 0.067330000000000001, 0.0843, 0.10969, 0.14124, 29, 0.10647, 0.12003999999999999, 0.14058000000000001, 0.17669000000000001, 0.22661000000000001 },
                    { 6, 0.058639999999999998, 0.072550000000000003, 0.091359999999999997, 0.11877, 0.15336, 30, 0.11020000000000001, 0.12579000000000001, 0.14896999999999999, 0.18991, 0.24465000000000001 },
                    { 7, 0.06275, 0.078280000000000002, 0.099129999999999996, 0.12873000000000001, 0.16667999999999999, 31, 0.11447, 0.13228999999999999, 0.15876999999999999, 0.20474999999999999, 0.26455000000000001 },
                    { 8, 0.067510000000000001, 0.084580000000000002, 0.10765, 0.13969000000000001, 0.18126, 32, 0.1195, 0.13968, 0.17007, 0.22112000000000001, 0.28650999999999999 },
                    { 9, 0.072910000000000003, 0.091619999999999993, 0.11687, 0.15174000000000001, 0.19722000000000001, 33, 0.12548999999999999, 0.14804999999999999, 0.18306, 0.23932, 0.31028 },
                    { 10, 0.078899999999999998, 0.099470000000000003, 0.12681999999999999, 0.16495000000000001, 0.21451999999999999, 34, 0.13217000000000001, 0.15764, 0.19778000000000001, 0.25903999999999999, 0.33623999999999998 },
                    { 11, 0.08541, 0.1082, 0.13761000000000001, 0.17943000000000001, 0.23327000000000001, 35, 0.13977000000000001, 0.16844999999999999, 0.21398, 0.28111000000000003, 0.36475999999999997 },
                    { 12, 0.092499999999999999, 0.11779000000000001, 0.14942, 0.19533, 0.25346999999999997, 36, 0.14835999999999999, 0.18110999999999999, 0.23216999999999999, 0.30547000000000002, 0.39577000000000001 },
                    { 13, 0.10034, 0.12833, 0.16245999999999999, 0.21276999999999999, 0.27534999999999998, 37, 0.15805, 0.19567999999999999, 0.25219999999999998, 0.33234000000000002, 0.42942999999999998 },
                    { 14, 0.10918, 0.13974, 0.17680999999999999, 0.23188, 0.29903000000000002, 38, 0.16869999999999999, 0.21223, 0.27428999999999998, 0.36124000000000001, 0.46544000000000002 },
                    { 15, 0.11917999999999999, 0.15210000000000001, 0.19261, 0.25263999999999998, 0.32484000000000002, 39, 0.18106, 0.23108000000000001, 0.29827999999999999, 0.39287, 0.50485000000000002 },
                    { 16, 0.13034000000000001, 0.16547000000000001, 0.20993999999999999, 0.27515000000000001, 0.35291, 40, 0.1951, 0.25185000000000002, 0.32518999999999998, 0.42769000000000001, 0.54757 },
                    { 17, 0.14251, 0.18007999999999999, 0.22892999999999999, 0.29937000000000002, 0.38346999999999998, 41, 0.21159, 0.27511999999999998, 0.35487999999999997, 0.46551999999999999, 0.59447000000000005 },
                    { 18, 0.15556, 0.19596, 0.24958, 0.32546999999999998, 0.41648000000000002, 42, 0.23050999999999999, 0.30059000000000002, 0.38752999999999999, 0.50651000000000002, 0.64607000000000003 },
                    { 19, 0.16938, 0.21328, 0.27209, 0.35363, 0.45234999999999997, 43, 0.25197000000000003, 0.32861000000000001, 0.42259999999999998, 0.55032999999999999, 0.70335000000000003 },
                    { 20, 0.18411, 0.23222999999999999, 0.29643999999999998, 0.38424999999999998, 0.49123, 44, 0.27646999999999999, 0.35891000000000001, 0.46095000000000003, 0.59831999999999996, 0.76709000000000005 },
                    { 21, 0.20005999999999999, 0.25306000000000001, 0.32290000000000002, 0.41760999999999998, 0.53425, 45, 0.30317, 0.39278000000000002, 0.50307000000000002, 0.65027999999999997, 0.83709 },
                    { 22, 0.21759999999999999, 0.27601999999999999, 0.35143000000000002, 0.45404, 0.58172999999999997, 46, 0.33313999999999999, 0.43009999999999998, 0.54884999999999995, 0.70735999999999999, 0.91163000000000005 },
                    { 23, 0.23693, 0.30119000000000001, 0.38231999999999999, 0.49353000000000002, 0.63434000000000001, 47, 0.36593999999999999, 0.47119, 0.59848999999999997, 0.77027000000000001, 0.99260999999999999 },
                    { 24, 0.25796999999999998, 0.32858999999999999, 0.41561999999999999, 0.53642999999999996, 0.69172999999999996, 48, 0.4022, 0.51536999999999999, 0.65168999999999999, 0.84031999999999996, 1.0806800000000001 },
                    { 25, 0.28078999999999998, 0.35807, 0.45175999999999999, 0.58284999999999998, 0.75488999999999995, 49, 0.44067000000000001, 0.56323000000000001, 0.70965999999999996, 0.91812000000000005, 1.1771400000000001 },
                    { 26, 0.30554999999999999, 0.38983000000000001, 0.49096000000000001, 0.63410999999999995, 0.82442000000000004, 50, 0.48370000000000002, 0.61573, 0.77242, 1.00363, 1.2802100000000001 },
                    { 27, 0.33277000000000001, 0.42392000000000002, 0.53369999999999995, 0.69067999999999996, 0.90139999999999998, 51, 0.52993999999999997, 0.67188000000000003, 0.84075, 1.0941099999999999, 1.3927499999999999 },
                    { 28, 0.36262, 0.46078000000000002, 0.58001000000000003, 0.75344, 0.98689000000000004, 52, 0.57986000000000004, 0.73199000000000003, 0.91549999999999998, 1.19198, 1.51433 },
                    { 29, 0.39567000000000002, 0.50085999999999997, 0.63058999999999998, 0.82218000000000002, 1.0822099999999999, 53, 0.63209000000000004, 0.79540999999999995, 0.99817999999999996, 1.29796, 1.6459699999999999 },
                    { 30, 0.43179000000000001, 0.54481999999999997, 0.68562999999999996, 0.89822999999999997, 1.18781, 54, 0.68794999999999995, 0.86414000000000002, 1.0898099999999999, 1.4139299999999999, 1.78603 },
                    { 31, 0.47110999999999997, 0.59292999999999996, 0.74673999999999996, 0.98224, 1.30358, 55, 0.74965999999999999, 0.93872999999999995, 1.1908300000000001, 1.5379400000000001, 1.9354100000000001 },
                    { 32, 0.5131, 0.64536000000000004, 0.81413999999999997, 1.0753200000000001, 0.0, 56, 0.81559000000000004, 1.0202100000000001, 1.29766, 1.6736800000000001, 0.0 },
                    { 33, 0.55817000000000005, 0.70184999999999997, 0.88876999999999995, 1.1786700000000001, 0.0, 57, 0.88683999999999996, 1.11016, 1.41377, 1.82094, 0.0 },
                    { 34, 0.60667000000000004, 0.76273000000000002, 0.97119999999999995, 1.29196, 0.0, 58, 0.96403000000000005, 1.20967, 1.54678, 2.00162, 0.0 },
                    { 35, 0.65908999999999995, 0.82938000000000001, 1.06098, 1.41415, 0.0, 59, 1.04749, 1.31945, 1.6934199999999999, 2.1923499999999998, 0.0 },
                    { 36, 0.71592, 0.90051000000000003, 1.15364, 1.5464199999999999, 0.0, 60, 1.1377600000000001, 1.44177, 1.8578399999999999, 2.4089100000000001, 0.0 },
                    { 37, 0.77712000000000003, 0.98146999999999995, 1.2666599999999999, 0.0, 0.0, 61, 1.2299100000000001, 1.5753600000000001, 1.9869600000000001, 0.0, 0.0 },
                    { 38, 0.84262000000000004, 1.0697300000000001, 1.387, 0.0, 0.0, 62, 1.33569, 1.71465, 2.1606800000000002, 0.0, 0.0 },
                    { 39, 0.91281999999999996, 1.16526, 1.5204899999999999, 0.0, 0.0, 63, 1.45584, 1.86646, 2.34979, 0.0, 0.0 },
                    { 40, 0.98806000000000005, 1.2703, 1.66777, 0.0, 0.0, 64, 1.5905100000000001, 2.0326200000000001, 2.5502400000000001, 0.0, 0.0 },
                    { 41, 1.0713299999999999, 1.38548, 1.82809, 0.0, 0.0, 65, 1.73719, 2.2069000000000001, 2.7613099999999999, 0.0, 0.0 },
                    { 42, 1.1633500000000001, 1.51271, 0.0, 0.0, 0.0, 66, 1.8892100000000001, 2.3970699999999998, 0.0, 0.0, 0.0 },
                    { 43, 1.26501, 1.6530100000000001, 0.0, 0.0, 0.0, 67, 2.0520800000000001, 2.6008, 0.0, 0.0, 0.0 },
                    { 44, 1.3739399999999999, 1.8077399999999999, 0.0, 0.0, 0.0, 68, 2.22818, 2.8206099999999998, 0.0, 0.0, 0.0 },
                    { 45, 1.4912000000000001, 1.9756499999999999, 0.0, 0.0, 0.0, 69, 2.41683, 3.0477099999999999, 0.0, 0.0, 0.0 },
                    { 46, 1.61653, 2.15429, 0.0, 0.0, 0.0, 70, 2.6093899999999999, 3.2814999999999999, 0.0, 0.0, 0.0 },
                    { 47, 1.78593, 0.0, 0.0, 0.0, 0.0, 71, 2.8682799999999999, 0.0, 0.0, 0.0, 0.0 },
                    { 48, 1.9805299999999999, 0.0, 0.0, 0.0, 0.0, 72, 3.15272, 0.0, 0.0, 0.0, 0.0 },
                    { 49, 2.2046000000000001, 0.0, 0.0, 0.0, 0.0, 73, 3.4639899999999999, 0.0, 0.0, 0.0, 0.0 },
                    { 50, 2.4616899999999999, 0.0, 0.0, 0.0, 0.0, 74, 3.7950499999999998, 0.0, 0.0, 0.0, 0.0 },
                    { 51, 2.7490000000000001, 0.0, 0.0, 0.0, 0.0, 75, 4.1511399999999998, 0.0, 0.0, 0.0, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Calculo_VidaInteira",
                columns: new[] { "Id", "Homem", "Idade", "Mulher" },
                values: new object[,]
                {
                    { 1, 0.23000000000000001, 16, 0.20999999999999999 },
                    { 2, 0.23000000000000001, 17, 0.20999999999999999 },
                    { 3, 0.23000000000000001, 18, 0.20999999999999999 },
                    { 4, 0.23000000000000001, 19, 0.20999999999999999 },
                    { 5, 0.23000000000000001, 20, 0.20999999999999999 },
                    { 6, 0.23000000000000001, 21, 0.20999999999999999 },
                    { 7, 0.23000000000000001, 22, 0.20999999999999999 },
                    { 8, 0.23000000000000001, 23, 0.20999999999999999 },
                    { 9, 0.23000000000000001, 24, 0.20999999999999999 },
                    { 10, 0.23000000000000001, 25, 0.20999999999999999 },
                    { 11, 0.23000000000000001, 26, 0.20999999999999999 },
                    { 12, 0.23000000000000001, 27, 0.20999999999999999 },
                    { 13, 0.23000000000000001, 28, 0.20999999999999999 },
                    { 14, 0.23000000000000001, 29, 0.20999999999999999 },
                    { 15, 0.23000000000000001, 30, 0.20999999999999999 },
                    { 16, 0.28000000000000003, 31, 0.25 },
                    { 17, 0.28000000000000003, 32, 0.25 },
                    { 18, 0.28000000000000003, 33, 0.25 },
                    { 19, 0.28000000000000003, 34, 0.25 },
                    { 20, 0.28000000000000003, 35, 0.25 },
                    { 21, 0.35999999999999999, 36, 0.32000000000000001 },
                    { 22, 0.35999999999999999, 37, 0.32000000000000001 },
                    { 23, 0.35999999999999999, 38, 0.32000000000000001 },
                    { 24, 0.35999999999999999, 39, 0.32000000000000001 },
                    { 25, 0.35999999999999999, 40, 0.32000000000000001 },
                    { 26, 0.54000000000000004, 41, 0.48999999999999999 },
                    { 27, 0.54000000000000004, 42, 0.48999999999999999 },
                    { 28, 0.54000000000000004, 43, 0.48999999999999999 },
                    { 29, 0.54000000000000004, 44, 0.48999999999999999 },
                    { 30, 0.54000000000000004, 45, 0.48999999999999999 },
                    { 31, 0.82999999999999996, 46, 0.75 },
                    { 32, 0.82999999999999996, 47, 0.75 },
                    { 33, 0.82999999999999996, 48, 0.75 },
                    { 34, 0.82999999999999996, 49, 0.75 },
                    { 35, 0.82999999999999996, 50, 0.75 },
                    { 36, 1.3, 51, 1.1699999999999999 },
                    { 37, 1.3, 52, 1.1699999999999999 },
                    { 38, 1.3, 53, 1.1699999999999999 },
                    { 39, 1.3, 54, 1.1699999999999999 },
                    { 40, 1.3, 55, 1.1699999999999999 },
                    { 41, 2.0299999999999998, 56, 1.8300000000000001 },
                    { 42, 2.0299999999999998, 57, 1.8300000000000001 },
                    { 43, 2.0299999999999998, 58, 1.8300000000000001 },
                    { 44, 2.0299999999999998, 59, 1.8300000000000001 },
                    { 45, 2.0299999999999998, 60, 1.8300000000000001 },
                    { 46, 2.6600000000000001, 61, 2.3900000000000001 },
                    { 47, 2.9100000000000001, 62, 2.6099999999999999 },
                    { 48, 3.1800000000000002, 63, 2.8599999999999999 },
                    { 49, 3.4700000000000002, 64, 3.1200000000000001 },
                    { 50, 3.79, 65, 3.4100000000000001 },
                    { 51, 4.1500000000000004, 66, 3.7400000000000002 },
                    { 52, 4.5499999999999998, 67, 4.0899999999999999 },
                    { 53, 4.9800000000000004, 68, 4.4800000000000004 },
                    { 54, 5.4500000000000002, 69, 4.9100000000000001 },
                    { 55, 5.9500000000000002, 70, 5.3499999999999996 },
                    { 56, 6.4699999999999998, 71, 5.8200000000000003 },
                    { 57, 7.0099999999999998, 72, 6.3099999999999996 },
                    { 58, 7.5599999999999996, 73, 6.7999999999999998 },
                    { 59, 8.1400000000000006, 74, 7.3300000000000001 },
                    { 60, 8.7699999999999996, 75, 7.8899999999999997 },
                    { 61, 9.4600000000000009, 76, 8.5199999999999996 },
                    { 62, 10.24, 77, 9.2200000000000006 },
                    { 63, 11.119999999999999, 78, 10.01 },
                    { 64, 12.09, 79, 10.880000000000001 },
                    { 65, 13.140000000000001, 80, 11.83 },
                    { 66, 14.26, 81, 12.84 },
                    { 67, 15.44, 82, 13.890000000000001 },
                    { 68, 16.66, 83, 14.99 },
                    { 69, 17.93, 84, 16.129999999999999 },
                    { 70, 19.260000000000002, 85, 17.329999999999998 }
                });

            migrationBuilder.InsertData(
                table: "Calculo_VidaInteiraConjuge",
                columns: new[] { "Id", "Homem", "Idade", "Mulher" },
                values: new object[,]
                {
                    { 1, 0.19, 16, 0.17000000000000001 },
                    { 2, 0.19, 17, 0.17000000000000001 },
                    { 3, 0.19, 18, 0.17000000000000001 },
                    { 4, 0.19, 19, 0.17000000000000001 },
                    { 5, 0.19, 20, 0.17000000000000001 },
                    { 6, 0.19, 21, 0.17000000000000001 },
                    { 7, 0.19, 22, 0.17000000000000001 },
                    { 8, 0.19, 23, 0.17000000000000001 },
                    { 9, 0.19, 24, 0.17000000000000001 },
                    { 10, 0.19, 25, 0.17000000000000001 },
                    { 11, 0.19, 26, 0.17000000000000001 },
                    { 12, 0.19, 27, 0.17000000000000001 },
                    { 13, 0.19, 28, 0.17000000000000001 },
                    { 14, 0.19, 29, 0.17000000000000001 },
                    { 15, 0.19, 30, 0.17000000000000001 },
                    { 16, 0.23000000000000001, 31, 0.20000000000000001 },
                    { 17, 0.23000000000000001, 32, 0.20000000000000001 },
                    { 18, 0.23000000000000001, 33, 0.20000000000000001 },
                    { 19, 0.23000000000000001, 34, 0.20000000000000001 },
                    { 20, 0.23000000000000001, 35, 0.20000000000000001 },
                    { 21, 0.29999999999999999, 36, 0.27000000000000002 },
                    { 22, 0.29999999999999999, 37, 0.27000000000000002 },
                    { 23, 0.29999999999999999, 38, 0.27000000000000002 },
                    { 24, 0.29999999999999999, 39, 0.27000000000000002 },
                    { 25, 0.29999999999999999, 40, 0.27000000000000002 },
                    { 26, 0.44, 41, 0.40000000000000002 },
                    { 27, 0.44, 42, 0.40000000000000002 },
                    { 28, 0.44, 43, 0.40000000000000002 },
                    { 29, 0.44, 44, 0.40000000000000002 },
                    { 30, 0.44, 45, 0.40000000000000002 },
                    { 31, 0.68000000000000005, 46, 0.60999999999999999 },
                    { 32, 0.68000000000000005, 47, 0.60999999999999999 },
                    { 33, 0.68000000000000005, 48, 0.60999999999999999 },
                    { 34, 0.68000000000000005, 49, 0.60999999999999999 },
                    { 35, 0.68000000000000005, 50, 0.60999999999999999 },
                    { 36, 1.0700000000000001, 51, 0.95999999999999996 },
                    { 37, 1.0700000000000001, 52, 0.95999999999999996 },
                    { 38, 1.0700000000000001, 53, 0.95999999999999996 },
                    { 39, 1.0700000000000001, 54, 0.95999999999999996 },
                    { 40, 1.0700000000000001, 55, 0.95999999999999996 },
                    { 41, 1.6699999999999999, 56, 1.5 },
                    { 42, 1.6699999999999999, 57, 1.5 },
                    { 43, 1.6699999999999999, 58, 1.5 },
                    { 44, 1.6699999999999999, 59, 1.5 },
                    { 45, 1.6699999999999999, 60, 1.5 },
                    { 46, 2.1800000000000002, 61, 1.96 },
                    { 47, 2.3799999999999999, 62, 2.1499999999999999 },
                    { 48, 2.6000000000000001, 63, 2.3399999999999999 },
                    { 49, 2.8500000000000001, 64, 2.5600000000000001 },
                    { 50, 3.1099999999999999, 65, 2.7999999999999998 },
                    { 51, 3.4100000000000001, 66, 3.0699999999999998 },
                    { 52, 3.73, 67, 3.3599999999999999 },
                    { 53, 4.0899999999999999, 68, 3.6800000000000002 },
                    { 54, 4.4699999999999998, 69, 4.0199999999999996 },
                    { 55, 4.8799999999999999, 70, 4.3899999999999997 },
                    { 56, 5.3099999999999996, 71, 4.7800000000000002 },
                    { 57, 5.75, 72, 5.1699999999999999 },
                    { 58, 6.2000000000000002, 73, 5.7800000000000002 },
                    { 59, 6.6799999999999997, 74, 6.0099999999999998 },
                    { 60, 7.1900000000000004, 75, 6.4699999999999998 },
                    { 61, 7.7599999999999998, 76, 6.9900000000000002 },
                    { 62, 8.4000000000000004, 77, 7.5599999999999996 },
                    { 63, 9.1199999999999992, 78, 8.2100000000000009 },
                    { 64, 9.9199999999999999, 79, 8.9299999999999997 },
                    { 65, 10.779999999999999, 80, 9.6999999999999993 },
                    { 66, 11.699999999999999, 81, 10.529999999999999 },
                    { 67, 12.66, 82, 11.4 },
                    { 68, 13.66, 83, 12.300000000000001 },
                    { 69, 14.710000000000001, 84, 13.24 },
                    { 70, 15.800000000000001, 85, 14.220000000000001 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthToken");

            migrationBuilder.DropTable(
                name: "Beneficiarios");

            migrationBuilder.DropTable(
                name: "Cadastros");

            migrationBuilder.DropTable(
                name: "Calculo_AdicionalDiariaInternacaoHospitalar");

            migrationBuilder.DropTable(
                name: "Calculo_DiariaIncapacidadeTemporariaAcidente");

            migrationBuilder.DropTable(
                name: "Calculo_DiariaInternacaoHospitalar");

            migrationBuilder.DropTable(
                name: "Calculo_DitMedico");

            migrationBuilder.DropTable(
                name: "Calculo_DoencasGraves");

            migrationBuilder.DropTable(
                name: "Calculo_DoencasGravesMaster");

            migrationBuilder.DropTable(
                name: "Calculo_InvalidezAcidenteMajorada");

            migrationBuilder.DropTable(
                name: "Calculo_InvalidezAcidenteMajoradaDoenca");

            migrationBuilder.DropTable(
                name: "Calculo_InvalidezTotalAcidente");

            migrationBuilder.DropTable(
                name: "Calculo_MortePorAcidente");

            migrationBuilder.DropTable(
                name: "Calculo_PensaoPorMorte");

            migrationBuilder.DropTable(
                name: "Calculo_PrazoCerto");

            migrationBuilder.DropTable(
                name: "Calculo_RendaInvalidez");

            migrationBuilder.DropTable(
                name: "Calculo_SafLuxo");

            migrationBuilder.DropTable(
                name: "Calculo_SafSuperLuxo");

            migrationBuilder.DropTable(
                name: "Calculo_SafSuperLuxoPorIdade");

            migrationBuilder.DropTable(
                name: "Calculo_TaxaPrevcom");

            migrationBuilder.DropTable(
                name: "Calculo_TermLife");

            migrationBuilder.DropTable(
                name: "Calculo_VidaInteira");

            migrationBuilder.DropTable(
                name: "Calculo_VidaInteiraConjuge");

            migrationBuilder.DropTable(
                name: "Configuracoes");

            migrationBuilder.DropTable(
                name: "Documentos");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
