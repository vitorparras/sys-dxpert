using Domain.Enum;

namespace Domain.DTO.Response
{
    public class UsuarioResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public TipoUsuario Permissao { get; set; }
    }
}
