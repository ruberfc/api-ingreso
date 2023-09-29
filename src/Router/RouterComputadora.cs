using Microsoft.AspNetCore.Builder;
using api_ingreso.src.Tools;

namespace api_ingreso.src.Router
{
    public static class RouterComputadora
    {
        public static void MapRouterComputadora(WebApplication app)
        {

            //app.MapGet("/ruta1", () => "Estás en la ruta 1");

            //app.MapGet("/ruta2", () => "Estás en la ruta 2");

            app.MapGet("Computadora/{id}", (int id) => { 
                ObjGeneric Computadora = new() {
                    Objeto = new
                    {
                        Id = id,
                        Ip = "192.168.1.123",
                        Id_Puerta = "123",
                        Id_Local = "1",
                        Id_Usuario = "f10102e"
                    }
                };
                return Computadora;
            });

            app.MapGet("Computadora", () => {

                List<ObjGeneric> listComputadora = new()
                {
                    new()
                    {
                        Objeto = new
                        {
                            Id = 1,
                            Ip = "192.168.1.123",
                            Id_Puerta = "123",
                            Id_Local = "1",
                            Id_Usuario = "f10102e"
                        },
                    },
                    new()
                    {
                        Objeto = new
                        {
                            Id = 2,
                            Ip = "192.168.1.124",
                            Id_Puerta = "123",
                            Id_Local = "1",
                            Id_Usuario = "f10102e"
                        },
                    },
                    new()
                    {
                        Objeto = new
                        {
                            Id = 3,
                            Ip = "192.168.1.125",
                            Id_Puerta = "123",
                            Id_Local = "1",
                            Id_Usuario = "f10102e"
                        },
                    },
                };

                return listComputadora;
            });
        }

    }

}
