// Copyright (c) Joppe27 <joppe27.be>.Licensed under the MIT License.
// See LICENSE file in repository root for full license text.

#region

using System.Collections.ObjectModel;
using System.Diagnostics;
using Microsoft.AspNetCore.Components;

#endregion

namespace JournalisticTransparency.Web.Components.Logging;

public class TrackedObject<T> : ITracked where T : notnull, new()
{
    protected TrackedObject(TrackingService trackingService, Stopwatch sessionTimer)
    {
        SessionTimer = sessionTimer;
        
        Object = new T();
        Interactions.CollectionChanged += (_, _) => trackingService.NotifyInteractionsChanged(this);

        trackingService.NotifyTrackedElementCreated(this);
    }
    
    protected Stopwatch SessionTimer { get; }

    public object Object { get; }

    public int ComponentIndex { get; init; }

    public required string Name { get; set; }

    public required IComponent Owner { get; set; }

    public ObservableCollection<TrackedInteraction> Interactions { get; } = new();
}