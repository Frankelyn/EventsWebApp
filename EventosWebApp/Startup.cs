

using EventosWebApp.BLL;
using Microsoft.AspNetCore.Builder;


namespace EventosWebApp
{
   
    
        public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
                
            services.AddScoped<EventoBLL>();
            services.AddScoped<SeccionBLL>();


            // Agrega cualquier otra configuración de servicios necesaria
        }
    }
    
}
