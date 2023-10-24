using Esfe.SysLogin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esfe.SysLogin.Service
{
    internal interface IUsuarioService
    {
        Task<UsuarioData> IniciarSesion(UsuarioData pUsuario);

    }
}
