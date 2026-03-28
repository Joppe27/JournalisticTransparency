// Copyright (c) Joppe27 <joppe27.be>.Licensed under the MIT License.
// See LICENSE file in repository root for full license text.

#region

using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

#endregion

namespace JournalisticTransparency.Web.Components.Logging;

public interface ITracked
{
    [JsonIgnore] public object Object { get; }

    public string ObjectType => Object.GetType().ToString();
    
    [JsonIgnore] public int ComponentIndex { get; } 

    public string Name { get; init; }

    [JsonIgnore] public IComponent Owner { get; init; }

    public string OwnerType => Owner.GetType().ToString();

    public ObservableCollection<TrackedInteraction> Interactions { get; }
}

public record TrackedInteraction(Interaction Interaction, TimeSpan Time);

public enum Interaction
{
    Opened,
    Closed,
    Clicked,
}