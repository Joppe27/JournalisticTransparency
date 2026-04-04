// Copyright (c) Joppe27 <joppe27.be>.Licensed under the MIT License.
// See LICENSE file in repository root for full license text.

#region

using System.Diagnostics;
using Microsoft.AspNetCore.Components;

#endregion

namespace JournalisticTransparency.Web.Components.Logging.Objects;

public class TrackedStopwatch : TrackedObject<Stopwatch>
{
    private readonly Stopwatch _stopwatch;

    public TrackedStopwatch(TrackingService trackingService, Stopwatch sessionTimer)
        : base(trackingService, sessionTimer)
    {
        _stopwatch = (Object as Stopwatch)!;
    }

    public void Start()
    {
        Interactions.Add(new TrackedInteraction(Interaction.Opened, SessionTimer.Elapsed));
        _stopwatch.Start();
    }

    public void Stop()
    {
        Interactions.Add(new TrackedInteraction(Interaction.Closed, SessionTimer.Elapsed));
        _stopwatch.Stop();
    }
}