using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Hermes.Models; // Adicione isso
using Hermes.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ISupabaseService, SupabaseService>();
builder.Services.AddControllersWithViews();

// Adicione isso para configurar o seu contexto de banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Este código adiciona a autenticação de identidade padrão ao serviço de injeção de dependência.
// Ele configura o contexto do banco de dados para usar o ApplicationDbContext e adiciona o ApplicationUser como a entidade de usuário.
builder.Services.AddDefaultIdentity<ApplicationUser>() // Altere IdentityUser para ApplicationUser
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthentication(); // Adicione isso para habilitar a autenticação
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();