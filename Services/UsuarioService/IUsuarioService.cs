using System.Collections.Generic;
using System.Threading.Tasks;

using Gimnasio.DTOS;

namespace Gimnasio.Services.UsuaiorService
{
    public class IUsuauarioService
    {
        Task<IEnumerable<UsuarioDto>> GetAllUsuariosAsync();
        Task<UsuarioDto> GetUsuarioByIdAsync(int id);
        Task AddUsuarioAsync(UsuarioDto usuarioDto);
        Task UpdateUsuarioAsync(UsuarioDto usuarioDto);
        Task DeleteUsuarioAsync(int id);
    }
}
