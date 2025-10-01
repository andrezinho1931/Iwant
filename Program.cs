using CliSenhas2024.Data;
using CliSenhas2024.Repositorio;
using ChatSignalR.Hubs; // Importa��o necess�ria para o ChatHub
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CliSenhas2024.AjudanteVSessao;


var builder = WebApplication.CreateBuilder(args);

// Configura o contexto do banco de dados
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


// Configura o Identity para autentica��o e autoriza��o
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddControllersWithViews();


//variaveis de sessao
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();//quando chamar a interface, implementa a seguinte classe 



// Register IUtilizadorRepositorio service
builder.Services.AddScoped<IUtilizadorRepositorio, UtilizadorRepositorio>();

/*Registro: services.AddScoped<IProdutoRepositorio, ProdutoRepositorio() registra ProdutoRepositorio como 
  a implementa��o de IProdutoRepositorio.
  
  O m�todo AddScoped especifica que uma nova inst�ncia de ProdutoRepositorio 
  ser� criada para cada solicita��o HTTP.

 Resolu��o: Quando RegistoProdutoController � criado,
o cont�iner de DI (inje�ao de dependencia) injeta uma inst�ncia de ProdutoRepositorio no construtor 
do controlador porque foi registrado como a implementa��o da interface IProdutoRepositorio.*/
builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();



//sessoes
builder.Services.AddScoped<ISessao, Sessao>();

builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});




// Adiciona servi�os para SignalR
builder.Services.AddSignalR(); // Registra os servi�os necess�rios para SignalR no cont�iner de inje��o de depend�ncia.

var app = builder.Build();

// Configura o pipeline de requisi��o HTTP
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.UseSession();//sessoes

// Configura os endpoints para SignalR
app.MapHub<ChatHub>("/chat"); // Mapeia o endpoint "/chat" para o ChatHub, que � o hub SignalR que gerencia a comunica��o em tempo real.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
