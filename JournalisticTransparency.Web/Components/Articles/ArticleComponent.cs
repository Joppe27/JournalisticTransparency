// Copyright (c) Joppe27 <joppe27.be>.Licensed under the MIT License.
// See LICENSE file in repository root for full license text.

using Microsoft.AspNetCore.Components;

namespace JournalisticTransparency.Web.Components.Articles;

public class ArticleComponent
{
    public required RenderFragment Content { get; init; }
    
    public required bool Interactive { get; init; }

    public bool Readable { get; set; }
}