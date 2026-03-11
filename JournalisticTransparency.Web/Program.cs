// Copyright (c) Joppe27 <joppe27.be>. Licensed under the MIT License.
// See LICENSE file in repository root for full license text.

#region

using System.Diagnostics;
using Blazorise;
using Blazorise.FluentUI2;
using Blazorise.Icons.FluentUI;
using JournalisticTransparency.Web;
using JournalisticTransparency.Web.Components.Logging.Objects;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

#endregion

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

bool debugging = builder.HostEnvironment.IsDevelopment();

builder.Services
    .AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
    .AddKeyedScoped<HttpClient>("ApiHttpClient", (_, _) => new HttpClient() { BaseAddress = debugging ? new Uri("http://localhost:7018") : new Uri(builder.HostEnvironment.BaseAddress) })
    .AddKeyedScoped<Stopwatch>("SessionTimer", (_, _) =>
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        return stopwatch;
    })
    .AddKeyedScoped<string>("ParticipantId", (_, _) => Guid.NewGuid().ToString())
    .AddOptions()
    .AddBlazorise()
    .AddFluentUI2Providers()
    .AddFluentUIIcons();

await builder.Build().RunAsync();