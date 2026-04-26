// Copyright (c) Joppe27 <joppe27.be>.Licensed under the MIT License.
// See LICENSE file in repository root for full license text.

#region

using JournalisticTransparency.Web.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;

#endregion

namespace JournalisticTransparency.Web.Utils;

public static class NavigationTools
{
    public static void RedirectToArticle(TransparencyType transparencyType, bool showDebugInfo, NavigationManager navigationManager)
    {
        const string baseUri = "/article";
        Dictionary<string, string?> queryParameters = new()
        {
            { "assignedtransparencytype", ((int)transparencyType).ToString() },
            { "debugging", showDebugInfo ? "true" : "false" }
        };

        string uri = QueryHelpers.AddQueryString(baseUri, queryParameters);

        navigationManager.NavigateTo(uri);
    }
}