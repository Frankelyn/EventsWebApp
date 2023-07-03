using EventosWebApp.DAL;
using EventosWebApp.Models;
using Newtonsoft.Json;

namespace EventosWebApp.BLL
{
    public class EventoBLL
    {
        public ApiClient apiClient = new ApiClient();

        public async Task<List<Evento>> ObtenerEventos()
        {
            
            try
            {
                HttpResponseMessage response = await apiClient.GetAsync("eventos/");

                if (response.IsSuccessStatusCode)
                {
                    string eventosJson = await response.Content.ReadAsStringAsync();
                    List<Evento>? eventos = JsonConvert.DeserializeObject<List<Evento>>(eventosJson);
                    return eventos;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se produjo un error al obtener los eventos: " + ex.Message);
                return null;
            }
        }

        public async Task<bool> ModificarEventos(Evento evento, List<Seccion> secciones)
        {
            try
            {
                string jsonEvento = JsonConvert.SerializeObject(evento);
                HttpResponseMessage responseEvento = await apiClient.PutAsync("eventos/", jsonEvento);

                if (responseEvento.IsSuccessStatusCode)
                {
                    //MessageBox.Show("Evento modificado correctamente.");

                    foreach (Seccion seccion in secciones)
                    {
                        string jsonSeccion = JsonConvert.SerializeObject(seccion);
                        HttpResponseMessage responseSeccion = await apiClient.PutAsync("secciones/", jsonSeccion);

                        if (!responseSeccion.IsSuccessStatusCode)
                        {
                            string contenidoRespuesta = await responseSeccion.Content.ReadAsStringAsync();
                            //MessageBox.Show("Error al modificar la sección. Detalles del error: " + Environment.NewLine + contenidoRespuesta);
                            return false;
                        }
                    }

                    //MessageBox.Show("Secciones modificadas correctamente.");
                    return true;
                }
                else
                {
                    string contenidoRespuesta = await responseEvento.Content.ReadAsStringAsync();
                    //MessageBox.Show("Error al modificar el evento. Detalles del error: " + Environment.NewLine + contenidoRespuesta);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se produjo un error al obtener los eventos: " + ex.Message);

                //MessageBox.Show("Se produjo un error al modificar el evento: " + ex.Message);
                return false;
            }
        }
    }
}
