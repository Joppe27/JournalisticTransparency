// Copyright (c) Joppe27 <joppe27.be>. Licensed under the MIT License.
// See LICENSE file in repository root for full license text.

#region

using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Components;
using ObservableCollections;

#endregion

namespace JournalisticTransparency.Web.Components.Logging;

public class TrackedObject<T> : ITracked where T : notnull, new()
{
    public object Object { get; set; } = new T();

    public required string Name { get; init; }

    public required IComponent Owner { get; init; }
    
    public TrackedStatus Status { get; set; }
    
    public EventCallback<TrackedStatus> OnStatusChanged { get; set; }

    public ObservableCollection<TrackedInteraction> Interactions { get; } = new();

    public EventCallback<ITracked> OnInteractionsChanged { get; set; }
}