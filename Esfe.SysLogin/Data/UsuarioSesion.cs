using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esfe.SysLogin.Data
{
	internal class UsuarioSesion
	{
		public bool IsLoggedIn { get; set; }
		public UsuarioData User { get; set; }

		public UsuarioSesion()
		{
			IsLoggedIn = false;
			User = null;
		}
	}
}
