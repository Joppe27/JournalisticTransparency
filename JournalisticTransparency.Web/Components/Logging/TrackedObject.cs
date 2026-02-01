// Copyright (c) Joppe27 <joppe27.be>. Licensed under the MIT License.
// See LICENSE file in repository root for full license text.

#region

using Microsoft.AspNetCore.Components;

#endregion

namespace JournalisticTransparency.Web.Components.Logging;

public class TrackedObject<T> : ITrackedObject where T : notnull, new()
{
    public T Object { get; } = new();

    public TrackedObjectStatus Status { get; set; }

    public required string Name { get; init; }

    public required IComponent Owner { get; init; }
}

public enum TrackedObjectStatus
{
    Active,
    Paused
}