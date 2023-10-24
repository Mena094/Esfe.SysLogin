using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esfe.SysLogin.Data
{
    internal class UsuarioData
    {

        public int id { get; set; } // ID del usuario
		[JsonProperty("nameUser")]

		public string nameUser { get; set; } // Nombre de usuario
        public string password { get; set; } // Contraseña
		[JsonProperty("Nombre")]

		public string Nombre { get; set; } // Nombre del usuario
        public string Apellido { get; set; } // Apellido del usuario
        public int Edad { get; set; } // Edad del usuario
    }
    internal class ErrorMensaje
    {
        public string message { get; set; }
    }
	

}
