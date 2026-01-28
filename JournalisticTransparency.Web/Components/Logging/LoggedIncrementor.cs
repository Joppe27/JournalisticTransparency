// Copyright (c) Joppe27 <joppe27.be>. Licensed under the MIT License.
// See LICENSE file in repository root for full license text.

using Blazorise;
using Microsoft.AspNetCore.Components;

namespace JournalisticTransparency.Web.Components.Logging;

public class LoggedIncrementor
{
    public required string Name { get; init; }
    
    public int Value { get; set; } = 0;
    
    public IComponent? Owner { get; init; }
}