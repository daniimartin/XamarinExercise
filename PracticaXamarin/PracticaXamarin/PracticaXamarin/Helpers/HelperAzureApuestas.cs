using Newtonsoft.Json;
using PracticaXamarin.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PracticaXamarin.Helpers
{
    public class HelperAzureApuestas
    {
        private string UrlApi = "http://apiapuestaspgs.azurewebsites.net/";

        private HttpClient GetHttpClient()
        {
            HttpClient clientehttp = new HttpClient();
            clientehttp.DefaultRequestHeaders.Accept.Clear();
            clientehttp.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return clientehttp;
        }

        public async Task<List<Apuesta>> GetApuestas()
        {
            List<Apuesta> listadatos = null;
            //CREAMOS LA PETICION
            String peticion = "api/Apuestas";
            Uri uri = new Uri(UrlApi + peticion);
            HttpClient client = this.GetHttpClient();
            HttpResponseMessage respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                listadatos = JsonConvert.DeserializeObject<List<Apuesta>>(contenido);
            }
            return listadatos;
        }

        public async Task<List<Equipo>> GetEquipos()
        {
            List<Equipo> listadatos = null;
            //CREAMOS LA PETICION
            String peticion = "api/Equipos";
            Uri uri = new Uri(UrlApi + peticion);
            HttpClient client = this.GetHttpClient();
            HttpResponseMessage respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                listadatos = JsonConvert.DeserializeObject<List<Equipo>>(contenido);
            }
            return listadatos;
        }

        public async Task<bool> InsertarApuesta(Apuesta apuesta)
        {
            //CONVERTIMOS EL OBJETO EN JSON
            string jsonapuesta = JsonConvert.SerializeObject(apuesta, Formatting.Indented);
            //PASAMOS SUS DATOS A BYTES
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(jsonapuesta);
            //CREAMOS UN CONTENIDO DE BYTES PARA ENVIAR
            //EN LA PETICION
            ByteArrayContent content = new ByteArrayContent(buffer);
            //INDICAMOS EN LA CABECERA EL TIPO DE CONTENIDO A ENVIAR
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //CREAMOS EL CLIENTE
            HttpClient client = this.GetHttpClient();
            //CREAMOS LA PETICION
            String peticion = UrlApi + "api/Apuestas";
            //REALIZAMOS LA LLAMADA AL API POST ENVIANDO EL CONTENIDO
            var respuesta = await client.PostAsync(peticion, content);
            if (respuesta.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
