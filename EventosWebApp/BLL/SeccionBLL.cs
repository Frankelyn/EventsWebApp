using EventosWebApp.DAL;
using EventosWebApp.Models;
using Newtonsoft.Json;

namespace EventosWebApp.BLL
{
    public class SeccionBLL
    {
        public ApiClient apiClient = new ApiClient();

        public async Task<List<Evento>> ObtenerSecciones()
        {

            try
            {
                HttpResponseMessage response = await apiClient.GetAsync("secciones/");

                if (response.IsSuccessStatusCode)
                {
                    string seccionesJSON = await response.Content.ReadAsStringAsync();
                    List<Evento>? secciones = JsonConvert.DeserializeObject<List<Evento>>(seccionesJSON);
                    return secciones;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se produjo un error al obtener los secciones: " + ex.Message);
                return null;
            }
        }
    }
}
