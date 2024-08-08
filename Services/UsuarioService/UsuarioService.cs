using Gimnasio.DTOS;
using Gimnasio.Models;
using Gimnasio.Services.Service;

namespace Gimnasio.Services.UsuaiorService
{
    public class UsuarioService : IUsuauarioService
    {
    private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<UsuarioDto>> GetAllUsuariosAsync()
        {
            var usuarios = await _usuarioRepository.GetAllUsuariosAsync();
            return usuarios.Select(u => new UsuarioDto
            {
                UsuarioId = u.UsuarioId,
                UsuarioNombre = u.UsuarioNombre,
                UsuarioApellidos = u.UsuarioApellidos,
                UsuarioDocIdent = u.UsuarioDocIdent,
                UsuarioFechaNacimiento = u.UsuarioFechaNacimiento,
                UsuarioDireccion = u.UsuarioDireccion,
                UsuarioTelefono = u.UsuarioTelefono,
                UsuarioEmail = u.UsuarioEmail,
                UsuarioFechaAlta = u.UsuarioFechaAlta,
                UsuarioFechaBaja = u.UsuarioFechaBaja,
                UsuarioTipoMembresia = u.UsuarioTipoMembresia,
                UsuarioEstado = u.UsuarioEstado
            }).ToList();
        }

        public async Task<UsuarioDto> GetUsuarioByIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetUsuarioByIdAsync(id);
            if (usuario == null) return null;

            return new UsuarioDto
            {
                UsuarioId = usuario.UsuarioId,
                UsuarioNombre = usuario.UsuarioNombre,
                UsuarioApellidos = usuario.UsuarioApellidos,
                UsuarioDocIdent = usuario.UsuarioDocIdent,
                UsuarioFechaNacimiento = usuario.UsuarioFechaNacimiento,
                UsuarioDireccion = usuario.UsuarioDireccion,
                UsuarioTelefono = usuario.UsuarioTelefono,
                UsuarioEmail = usuario.UsuarioEmail,
                UsuarioFechaAlta = usuario.UsuarioFechaAlta,
                UsuarioFechaBaja = usuario.UsuarioFechaBaja,
                UsuarioTipoMembresia = usuario.UsuarioTipoMembresia,
                UsuarioEstado = usuario.UsuarioEstado
            };
        }

        public async Task AddUsuarioAsync(UsuarioDto usuarioDto)
        {
            var usuario = new Usuario
            {
                UsuarioNombre = usuarioDto.UsuarioNombre,
                UsuarioApellidos = usuarioDto.UsuarioApellidos,
                UsuarioDocIdent = usuarioDto.UsuarioDocIdent,
                UsuarioFechaNacimiento = usuarioDto.UsuarioFechaNacimiento,
                UsuarioDireccion = usuarioDto.UsuarioDireccion,
                UsuarioTelefono = usuarioDto.UsuarioTelefono,
                UsuarioEmail = usuarioDto.UsuarioEmail,
                UsuarioFechaAlta = usuarioDto.UsuarioFechaAlta,
                UsuarioFechaBaja = usuarioDto.UsuarioFechaBaja,
                UsuarioTipoMembresia = usuarioDto.UsuarioTipoMembresia,
                UsuarioEstado = usuarioDto.UsuarioEstado
            };
            await _usuarioRepository.AddUsuarioAsync(usuario);
        }

        public async Task UpdateUsuarioAsync(UsuarioDto usuarioDto)
        {
            var usuario = await _usuarioRepository.GetUsuarioByIdAsync(usuarioDto.UsuarioId);
            if (usuario != null)
            {
                usuario.UsuarioNombre = usuarioDto.UsuarioNombre;
                usuario.UsuarioApellidos = usuarioDto.UsuarioApellidos;
                usuario.UsuarioDocIdent = usuarioDto.UsuarioDocIdent;
                usuario.UsuarioFechaNacimiento = usuarioDto.UsuarioFechaNacimiento;
                usuario.UsuarioDireccion = usuarioDto.UsuarioDireccion;
                usuario.UsuarioTelefono = usuarioDto.UsuarioTelefono;
                usuario.UsuarioEmail = usuarioDto.UsuarioEmail;
                usuario.UsuarioFechaAlta = usuarioDto.UsuarioFechaAlta;
                usuario.UsuarioFechaBaja = usuarioDto.UsuarioFechaBaja;
                usuario.UsuarioTipoMembresia = usuarioDto.UsuarioTipoMembresia;
                usuario.UsuarioEstado = usuarioDto.UsuarioEstado;
                await _usuarioRepository.UpdateUsuarioAsync(usuario);
            }
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            await _usuarioRepository.DeleteUsuarioAsync(id);
        }
    }
}
