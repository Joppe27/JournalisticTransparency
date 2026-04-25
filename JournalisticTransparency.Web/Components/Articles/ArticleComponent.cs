// Copyright (c) Joppe27 <joppe27.be>.Licensed under the MIT License.
// See LICENSE file in repository root for full license text.

#region

using Microsoft.AspNetCore.Components;

#endregion

namespace JournalisticTransparency.Web.Components.Articles;

public class ArticleComponent
{
    public RenderFragment? Content { get; init; }

    public RenderFragment[]? TransparencyElements { get; init; }

    public bool Readable { get; set; }
}