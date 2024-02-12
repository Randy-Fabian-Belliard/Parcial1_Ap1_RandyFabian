using Microsoft.EntityFrameworkCore;
using Parcial1_Ap1_RandyFabian.Components;
using Parcial1_Ap1_RandyFabian.DAL;
using Parcial1_Ap1_RandyFabian.Models;
using Parcial1_Ap1_RandyFabian.Services;

var builder = WebApplication.CreateBuilder(args);

var ConStr = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContext<Context>(options => options.UseSqlite(ConStr));
builder.Services.AddScoped<MetasServices>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
