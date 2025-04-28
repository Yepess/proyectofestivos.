using ProyectoFestivos.Aplicacion.Servicios;
using ProyectoFestivos.Aplicacion;
using ProyectoFestivos.CORE.Repositorios;
using ProyectoFestivos.CORE.Servicios;
using ProyectoFestivos.Infraestructura.Repositorios;
using ProyectoFestivos.Presentacion.DI;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") 
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AgregarDependencias(builder.Configuration);

builder.Services.AddControllersWithViews();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.UseCors("PermitirFrontend");

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Tipo}/{action=Index}/{id?}");

app.Run();

builder.Services.AddScoped<IFestivoServicio, FestivoServicio>();
builder.Services.AddScoped<ITipoServicio, TipoServicio>();

builder.Services.AddScoped<IFestivoRepositorio, FestivoRepositorio>();
builder.Services.AddScoped<ITipoRepositorio, TipoRepositorio>();



