// Copyright (c) Joppe27 <joppe27.be>. Licensed under the MIT License.
// See LICENSE file in repository root for full license text.

#region

using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;
using ObservableCollections;

#endregion

namespace JournalisticTransparency.Web.Components.Logging;

public interface ITracked
{
    [JsonIgnore]
    public object Object { get; }

    public string ObjectType => Object.GetType().ToString();
    
    public string Name { get; init; }

    [JsonIgnore]
    public IComponent Owner { get; init; }

    public string OwnerType => Owner.GetType().ToString();
    
    [JsonIgnore]
    public EventCallback<ITracked> OnTrackedElementCreated { get; set; }
    
    public ObservableCollection<TrackedInteraction> Interactions { get; }
    
    [JsonIgnore]
    public EventCallback<ITracked> OnInteractionsChanged { get; set; }
}

public record TrackedInteraction(Interaction Interaction, TimeSpan Time);

public enum Interaction
{
    Opened,
    Closed,
    Clicked,
}