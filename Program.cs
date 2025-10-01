using CliSenhas2024.Data;
using CliSenhas2024.Repositorio;
using ChatSignalR.Hubs; // Importação necessária para o ChatHub
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CliSenhas2024.AjudanteVSessao;


var builder = WebApplication.CreateBuilder(args);

// Configura o contexto do banco de dados
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


// Configura o Identity para autenticação e autorização
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddControllersWithViews();


//variaveis de sessao
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();//quando chamar a interface, implementa a seguinte classe 



// Register IUtilizadorRepositorio service
builder.Services.AddScoped<IUtilizadorRepositorio, UtilizadorRepositorio>();

/*Registro: services.AddScoped<IProdutoRepositorio, ProdutoRepositorio() registra ProdutoRepositorio como 
  a implementação de IProdutoRepositorio.
  
  O método AddScoped especifica que uma nova instância de ProdutoRepositorio 
  será criada para cada solicitação HTTP.

 Resolução: Quando RegistoProdutoController é criado,
o contêiner de DI (injeçao de dependencia) injeta uma instância de ProdutoRepositorio no construtor 
do controlador porque foi registrado como a implementação da interface IProdutoRepositorio.*/
builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();



//sessoes
builder.Services.AddScoped<ISessao, Sessao>();

builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});




// Adiciona serviços para SignalR
builder.Services.AddSignalR(); // Registra os serviços necessários para SignalR no contêiner de injeção de dependência.

var app = builder.Build();

// Configura o pipeline de requisição HTTP
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
app.MapHub<ChatHub>("/chat"); // Mapeia o endpoint "/chat" para o ChatHub, que é o hub SignalR que gerencia a comunicação em tempo real.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
