// Copyright (c) Joppe27 <joppe27.be>.Licensed under the MIT License.
// See LICENSE file in repository root for full license text.

using JournalisticTransparency.Web.Components.Logging;
using Microsoft.AspNetCore.Components;

namespace JournalisticTransparency.Web.Components.Articles;

public abstract class ArticleContent : ComponentBase
{
    [Parameter] public EventCallback<ITracked> OnLoggedObjectCreated { get; set; }
    [Parameter] public EventCallback DisplayFunctionDisabledToast { get; set; }
    
    protected abstract bool Interactive { get; } 
}