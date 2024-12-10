using DonarVida;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ClassDonarVida.Services;
using ClassDonarVida.Services.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5198") });
//builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
var configuration = builder.Configuration;
builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(configuration["ApiUrl"]) });


builder.Services.AddScoped<DonanteService>();
builder.Services.AddScoped<DonacionService>();
builder.Services.AddScoped<CentroDonacionService>();
builder.Services.AddScoped<ProgramaDonacionService>();
builder.Services.AddSweetAlert2();



await builder.Build().RunAsync();
builder.Services.AddBlazorBootstrap();
