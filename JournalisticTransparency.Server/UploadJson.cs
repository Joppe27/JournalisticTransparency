// Copyright (c) Joppe27 <joppe27.be>.Licensed under the MIT License.
// See LICENSE file in repository root for full license text.

#region

using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

#endregion

namespace JournalisticTransparency.Server;

public class UploadJson
{
    private readonly ILogger<UploadJson> _logger;

    public UploadJson(ILogger<UploadJson> logger)
    {
        _logger = logger;
    }

    [Function("UploadJson")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req, [FromQuery] string? participantId, [FromQuery] int? transparencyType)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        string json = await new StreamReader(req.Body).ReadToEndAsync();

        if (participantId is null || participantId == string.Empty || json == string.Empty)
            return new BadRequestResult();

        var blobServiceClient = new BlobServiceClient(Environment.GetEnvironmentVariable("BlobConnection"));
        var blobContainerClient = blobServiceClient.GetBlobContainerClient("trackingdata");
        await blobContainerClient.UploadBlobAsync($"{transparencyType}/{DateTime.UtcNow.ToShortDateString().Replace('/', '-')}/{participantId}.json", BinaryData.FromString(json),
            CancellationToken.None);

        return new OkResult();
    }
}