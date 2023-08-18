using Microsoft.AspNetCore.Builder;

namespace api_ingreso.src.Router
{
    public static class RouterComputadora
    {
        public static void MapRouterComputadora(WebApplication app)
        {
            app.MapGet("/ruta1", () => "Estás en la ruta 1");

            app.MapGet("/ruta2", () => "Estás en la ruta 2");

            app.MapGet("/ruta3/{valor}", context =>
            {
                var valor = context.Request.RouteValues["valor"];
                return context.Response.WriteAsync($"Estás en la ruta 3 con el valor: {valor}");
            });
        }

    }

}
