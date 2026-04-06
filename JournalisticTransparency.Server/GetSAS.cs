// Copyright (c) Joppe27 <joppe27.be>.Licensed under the MIT License.
// See LICENSE file in repository root for full license text.

#region

using System.Globalization;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

#endregion

namespace JournalisticTransparency.Server;

public class GetSAS
{
    private readonly ILogger<GetSAS> _logger;

    public GetSAS(ILogger<GetSAS> logger)
    {
        _logger = logger;
    }

    [Function("GetSAS")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
    {
        var blobServiceClient = new BlobServiceClient(Environment.GetEnvironmentVariable("BlobConnection"));
        var blobContainerClient = blobServiceClient.GetBlobContainerClient("trackingdata");
        var sas = blobContainerClient.GenerateSasUri(BlobContainerSasPermissions.Create, DateTimeOffset.Now.AddSeconds(30));
        
        return new OkObjectResult(sas);
    }
}