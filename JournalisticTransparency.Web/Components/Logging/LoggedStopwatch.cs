// Copyright (c) Joppe27 <joppe27.be>. Licensed under the MIT License.
// See LICENSE file in repository root for full license text.

using System.Diagnostics;
using Blazorise;
using Microsoft.AspNetCore.Components;

namespace JournalisticTransparency.Web.Components.Logging;

public class LoggedStopwatch : Stopwatch
{
    public required string Name { get; init; }
    
    public IComponent? Owner { get; init; }
}