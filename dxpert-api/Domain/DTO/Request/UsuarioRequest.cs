using Domain.Enum;

namespace Domain.DTO.Request
{
    public class UsuarioRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public TipoUsuario Permissao { get; set; }
        public string? Senha { get; set; }

    }
}
