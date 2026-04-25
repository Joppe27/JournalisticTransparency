// Copyright (c) Joppe27 <joppe27.be>.Licensed under the MIT License.
// See LICENSE file in repository root for full license text.

using JournalisticTransparency.Web.Components.Logging.Components;
using Microsoft.AspNetCore.Components;

namespace JournalisticTransparency.Web.Components.Articles;

public class ArticleComponent
{
    public RenderFragment? Content { get; init; }
    
    public RenderFragment[]? TransparencyElements { get; init; }

    public bool Readable { get; set; }
}