// Copyright (c) Joppe27 <joppe27.be>.Licensed under the MIT License.
// See LICENSE file in repository root for full license text.

namespace JournalisticTransparency.Web.Components.Logging;

public class TrackingService
{
    public event Action<ITracked>? OnTrackedElementCreated;

    public event Action<ITracked>? OnInteractionsChanged;

    public void NotifyTrackedElementCreated(ITracked element) => OnTrackedElementCreated?.Invoke(element);

    public void NotifyInteractionsChanged(ITracked element) => OnInteractionsChanged?.Invoke(element);
}