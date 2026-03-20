// Copyright (c) Joppe27 <joppe27.be>.Licensed under the MIT License.
// See LICENSE file in repository root for full license text.

using Blazorise;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace JournalisticTransparency.Web.Components.Logging.Components;

public class TrackedAccordionToggle : TrackedComponent<AccordionToggle>
{
    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);

        if (!firstRender)
            return;
        
        var toggle = (Object as AccordionToggle)!;
        
        AddNestedCallback(nameof(AccordionToggle.Clicked), new EventCallbackWrapper<MouseEventArgs>(EventCallback.Factory.Create(this, (MouseEventArgs _) =>
        {
            Interactions.Add(new TrackedInteraction(!toggle.AccordionItemVisible ? Interaction.Opened : Interaction.Closed, SessionTimer.Elapsed));
        })));
        StateHasChanged();
    }
}