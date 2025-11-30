using Blazorise;
using Blazorise.FluentUI2;
using Blazorise.Icons.FluentUI;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using JournalisticTransparency.Web;
using Microsoft.AspNetCore.Components;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
    .AddBlazorise()
    .AddFluentUI2Providers()
    .AddFluentUIIcons();

await builder.Build().RunAsync();
