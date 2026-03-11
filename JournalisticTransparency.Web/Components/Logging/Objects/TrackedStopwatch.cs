// Copyright (c) Joppe27 <joppe27.be>.Licensed under the MIT License.
// See LICENSE file in repository root for full license text.

using System.Diagnostics;
using Microsoft.AspNetCore.Components;

namespace JournalisticTransparency.Web.Components.Logging.Objects;

public class TrackedStopwatch : TrackedObject<Stopwatch>
{
    private readonly Stopwatch _stopwatch;
    
    public TrackedStopwatch(Stopwatch stopwatch, EventCallback<ITracked> createdCallback, EventCallback<ITracked> interactionCallback)
        : base(stopwatch, createdCallback, interactionCallback) // TODO: check if bad
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