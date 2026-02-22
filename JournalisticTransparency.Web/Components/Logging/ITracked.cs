// Copyright (c) Joppe27 <joppe27.be>. Licensed under the MIT License.
// See LICENSE file in repository root for full license text.

#region

using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Components;
using ObservableCollections;

#endregion

namespace JournalisticTransparency.Web.Components.Logging;

public interface ITracked
{
    public object Object { get; } 
    
    public string Name { get; init; }

    public IComponent Owner { get; init; }
    
    public TrackedStatus Status { get; }
    
    public EventCallback<ITracked> OnTrackedElementCreated { get; set; }
    
    public ObservableCollection<TrackedInteraction> Interactions { get; }
    
    public EventCallback<ITracked> OnInteractionsChanged { get; set; }
}

public record TrackedInteraction(Interaction Interaction, TimeSpan Time);

public enum Interaction
{
    Opened,
    Closed,
    Clicked,
}

public enum TrackedStatus
{
    Active,
    Paused,
    Incremented,
}