// Copyright (c) Joppe27 <joppe27.be>. Licensed under the MIT License.
// See LICENSE file in repository root for full license text.

#region

using Microsoft.AspNetCore.Components;

#endregion

namespace JournalisticTransparency.Web.Components.Logging;

public interface ITrackedObject
{
    public TrackedObjectStatus Status { get; set; }

    public string Name { get; init; }

    public IComponent Owner { get; init; }
}