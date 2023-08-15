using api_ingreso.src.Tools;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.MapControllers();

app.MapGet("/", () =>
{
    ResponseCustom response = new(){Code = 200, Mensaje = "Api - Ingreso"};
    return response;
});

app.Run();












//app.MapGet("/Locales", () => {
//    return LocalService.GetAllLocal();
//});

/*
app.MapGet("/Local/{localId}", (int localId) =>
{
    try
    {
        var Response = new
        {
            StatusCode = 200,
            Message = "Ok",
            Details = LocalService.GetLocalById(localId)
        };

        return Results.Json(Response);

    }
    catch (Exception ex)
    {
        var errorResponse = new
        {
            StatusCode = 500,
            Message = "Ocurrió un error en el servidor",
            ErrorDetails = ex.Message
        };

        return Results.Json(errorResponse);

    }

});
*/




/*
app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();
*/

