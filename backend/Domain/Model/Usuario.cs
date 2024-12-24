using Domain.Enum;
using Domain.Model.Bases;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class Usuario : BaseEntity
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }

        public bool Ativo { get; set; } = true;

        public TipoUsuario Permissao { get; set; } = TipoUsuario.Normal;

        [Required]
        public string? Senha { get; set; }


        public bool ValidarSenha(string senha)
        {
            return string.IsNullOrEmpty(senha) || !Senha.Equals(senha);
        }


        public static void InsertData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario()
                {
                    Ativo = true,
                    Id = 1,
                    Email = "teste@teste.com",
                    Nome = "teste",
                    Permissao = TipoUsuario.Admin,
                    Senha = "12345",
                    Telefone = "12345",
                    DataCriacao = DateTime.Now,
                    DataAlteracao = DateTime.Now
                });
        }
    }
}
