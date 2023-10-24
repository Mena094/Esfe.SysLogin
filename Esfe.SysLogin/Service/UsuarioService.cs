using Esfe.SysLogin.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Esfe.SysLogin.Service
{
    internal class UsuarioService : IUsuarioService
    {
		

		public async Task<UsuarioData> IniciarSesion(UsuarioData pUsuario)
        {
            // URL de la ruta de autenticación en tu servidor Node.js
            string apiUrl = "http://localhost:3005/api/login"; // Asegúrate de usar la URL correcta

            // Datos de autenticación a enviar en la solicitud
            var data = new
            {
                nameUser = pUsuario.nameUser,
                password = pUsuario.password
            };

            using (var client = new HttpClient())
            {
                // Serializa los datos en formato JSON
                var jsonContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                // Realiza una solicitud POST a la ruta de autenticación
                var response = await client.PostAsync(apiUrl, jsonContent);

                if (response.IsSuccessStatusCode)
                {

                    // La solicitud fue exitosa (código de respuesta 2xx)
                    var content = await response.Content.ReadAsStringAsync();
					var json = JObject.Parse(content);
					var usuarioData = json["usuario"].ToObject<UsuarioData>();
					return usuarioData;
				}
				else
                {
                    // La solicitud no fue exitosa (código de respuesta diferente de 2xx)
                    var contentMessage = await response.Content.ReadAsStringAsync();
                    var jsonResponse = JsonConvert.DeserializeObject<ErrorMensaje>(contentMessage);

                    if (response.StatusCode == HttpStatusCode.NotFound) // La solicitud no fue exitosa (código de respuesta diferente de 404)
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", jsonResponse.message, "Aceptar");
                    }
                    else if (response.StatusCode == HttpStatusCode.Unauthorized) // La solicitud no fue exitosa (código de respuesta diferente de 401)
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", jsonResponse.message, "Aceptar");
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Error inesperado: " + response.StatusCode, "Aceptar");
                    }

                    return null; // Devuelve nulo en caso de error
                }
            }
        }

		
	}
}
