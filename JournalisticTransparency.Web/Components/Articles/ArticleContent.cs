// Copyright (c) Joppe27 <joppe27.be>.Licensed under the MIT License.
// See LICENSE file in repository root for full license text.

#region

using Microsoft.AspNetCore.Components;

#endregion

namespace JournalisticTransparency.Web.Components.Articles;

public abstract class ArticleContent : ComponentBase
{
    [Parameter] public EventCallback DisplayFunctionDisabledToast { get; set; }

    protected abstract bool Interactive { get; }

    protected abstract bool Invasive { get; }
}