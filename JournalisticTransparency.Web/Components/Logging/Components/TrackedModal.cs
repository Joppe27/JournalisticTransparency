// Copyright (c) Joppe27 <joppe27.be>.Licensed under the MIT License.
// See LICENSE file in repository root for full license text.

#region

using Blazorise;
using Microsoft.AspNetCore.Components;

#endregion

namespace JournalisticTransparency.Web.Components.Logging.Components;

public class TrackedModal : TrackedComponent<Modal>
{
    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);

        if (!firstRender)
            return;

        AddNestedCallback(nameof(Modal.Opened), new EventCallbackWrapper(EventCallback.Factory.Create(this, () =>
            Interactions.Add(new TrackedInteraction(Interaction.Opened, SessionTimer.Elapsed)))));
        AddNestedCallback(nameof(Modal.Closed), new EventCallbackWrapper(EventCallback.Factory.Create(this, () =>
            Interactions.Add(new TrackedInteraction(Interaction.Closed, SessionTimer.Elapsed)))));
        StateHasChanged();
    }
}