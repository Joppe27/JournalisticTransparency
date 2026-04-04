// Copyright (c) Joppe27 <joppe27.be>.Licensed under the MIT License.
// See LICENSE file in repository root for full license text.

#region

using Microsoft.AspNetCore.Components;

#endregion

namespace JournalisticTransparency.Web.Components.Logging;

public interface IEventCallback
{
    public object Object { get; }

    public Task InvokeAsync();
}

public class EventCallbackWrapper(EventCallback obj) : IEventCallback
{
    public object Object { get; } = obj;

    public async Task InvokeAsync()
    {
        if (Object is not EventCallback callback)
            throw new InvalidOperationException();

        await callback.InvokeAsync();
    }
}

public class EventCallbackWrapper<T>(EventCallback<T> obj) : IEventCallback
{
    public object Object { get; } = obj;

    public async Task InvokeAsync()
    {
        if (Object is not EventCallback<T> callback)
            throw new InvalidOperationException();

        await callback.InvokeAsync();
    }
}