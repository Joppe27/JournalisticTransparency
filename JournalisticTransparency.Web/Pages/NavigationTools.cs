// Copyright (c) Joppe27 <joppe27.be>.Licensed under the MIT License.
// See LICENSE file in repository root for full license text.

using JournalisticTransparency.Web.Components.Articles;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;

namespace JournalisticTransparency.Web.Pages;

public static class NavigationTools
{
    public static void RedirectToArticle(TransparencyType transparencyType, bool showDebugInfo, NavigationManager navigationManager)
    {
        const string baseUri = "/article";
        Dictionary<string, string?> queryParameters = new()
        {
            { "transparencytype", ((int)transparencyType).ToString() },
            { "debugging", showDebugInfo ? "true" : "false" }
        };

        string uri = QueryHelpers.AddQueryString(baseUri, queryParameters);
        
        navigationManager.NavigateTo(uri);
    }
}