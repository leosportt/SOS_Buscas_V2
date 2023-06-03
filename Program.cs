using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SOS_Buscas_V2.Data;
using SOS_Buscas_V2.Helper;
using SOS_Buscas_V2.Repositorio;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//----------------------------------------------------------------------------------------------------------------
//Conexão com o banco

string conection = builder.Configuration.GetConnectionString("SOS_BuscasDB");

builder.Services.AddDbContextPool<BancoContext>(options => options.UseSqlServer(conection));

//----------------------------------------------------------------------------------------------------------------
// Configurando as injeções de dependência

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); 

builder.Services.AddScoped<IUsuario, UsuarioRepositorio>();
builder.Services.AddScoped<ISessao, SessaoRepositorio>();
builder.Services.AddScoped<IDesaparecido, DesaparecidoRepositorio>();

builder.Services.AddSession(o =>
        {
            o.Cookie.HttpOnly = true;
            o.Cookie.IsEssential = true;
        });

//----------------------------------------------------------------------------------------------------------------


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
