// Copyright (c) Joppe27 <joppe27.be>. Licensed under the MIT License.
// See LICENSE file in repository root for full license text.

#region

using Blazorise;
using Blazorise.FluentUI2;
using Blazorise.Icons.FluentUI;
using JournalisticTransparency.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

#endregion

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
    .AddOptions()
    .AddBlazorise()
    .AddFluentUI2Providers()
    .AddFluentUIIcons();

await builder.Build().RunAsync();