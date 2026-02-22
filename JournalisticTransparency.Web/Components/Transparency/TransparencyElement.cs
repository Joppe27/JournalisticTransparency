// Copyright (c) Joppe27 <joppe27.be>.Licensed under the MIT License.
// See LICENSE file in repository root for full license text.

using JournalisticTransparency.Web.Components.Logging;
using Microsoft.AspNetCore.Components;

namespace JournalisticTransparency.Web.Components.Transparency;

public class TransparencyElement : ComponentBase
{
    [Parameter] public string Style { get; set; } = "";
    [Parameter] public bool Interactive { get; set; }
    [Parameter] public EventCallback DisplayFunctionDisabledToast { get; set; }
    [Parameter] public EventCallback<KeyValuePair<TransparencyElement, bool>> OnOpenStateChanged { get; set; }
}