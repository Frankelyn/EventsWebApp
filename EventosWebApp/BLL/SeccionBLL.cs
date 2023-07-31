using EventosWebApp.DAL;
using EventosWebApp.Models;
using Newtonsoft.Json;
using System;

namespace EventosWebApp.BLL
{
    public class SeccionBLL
    {
        private readonly ApiClient apiClient;

        public SeccionBLL()
        {
            apiClient = new ApiClient();
        }


        private static int eventoId;

        public static void setEventoId(int id)
        {
            eventoId = id;
        }

        public static int getEventoId()
        {
            return eventoId;    
        }

        public async Task<List<Seccion>> ObtenerSecciones()
        {
            try
            {
                HttpResponseMessage response = await apiClient.GetAsync("secciones/");

                if (response.IsSuccessStatusCode)
                {
                    string seccionesJSON = await response.Content.ReadAsStringAsync();
                    List<Seccion> secciones = JsonConvert.DeserializeObject<List<Seccion>>(seccionesJSON);
                    return secciones;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al obtener las secciones.", ex);
            }
        }


        public List<Seccion> SeccionesPorEvento(List<Seccion> secciones, int idEvento)
        {
            return secciones.Where(s => s.id_evento == idEvento).ToList();
        }

        public async Task<Seccion> BuscarSeccionPorId(int idSeccion)
        {
            var listaSecciones = await ObtenerSecciones();

            return listaSecciones.FirstOrDefault(seccion => seccion.id_seccion == idSeccion);
        }


        public async Task<bool> ActualizarSeccion(Seccion seccion)
        {
            try
            {
                HttpResponseMessage response = await apiClient.PutAsync("secciones/" + seccion.id_seccion + "/", seccion);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al actualizar la sección.", ex);
            }
        }


    }



}
