﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Gimnasio.Models;

namespace Gimnasio.Repositories.UsuarioRepository
{
    public class IUsuarioRepository
    {

        Task<IEnumerable<Usuario>> GetAllUsuariosAsync();
        Task<Usuario> GetUsuarioByIdAsync(int id);
        Task AddUsuarioAsync(Usuario usuario);
        Task UpdateUsuarioAsync(Usuario usuario);
        Task DeleteUsuarioAsync(int id);

    }
}
