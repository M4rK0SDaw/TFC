namespace Gimnasio.DTOS
{
    public class UsuarioDto
    { 
        public int UsuarioId { get; set; }
        public required string UsuarioNombre { get; set; }
        public required string UsuarioApellidos { get; set; }
        public required string UsuarioDocIdent { get; set; }
        public TimeSpan UsuarioFechaNacimiento { get; set; }
        public string? UsuarioDireccion { get; set; }
        public required  string UsuarioTelefono { get; set; }
        public required string UsuarioEmail { get; set; }
        public TimeSpan UsuarioFechaAlta { get; set; }
        public TimeSpan? UsuarioFechaBaja { get; set; }
        public int UsuarioTipoMembresia { get; set; }
        public bool? UsuarioEstado { get; set; }

    }
}
