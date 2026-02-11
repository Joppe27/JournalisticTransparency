// Copyright (c) Joppe27 <joppe27.be>. Licensed under the MIT License.
// See LICENSE file in repository root for full license text.

#region

using JournalisticTransparency.Web.Components.ArticleContent;
using JournalisticTransparency.Web.Components.Logging;
using Microsoft.AspNetCore.Components;

#endregion

namespace JournalisticTransparency.Web.Components;

public interface IArticleContent
{
    public EventCallback<ITrackedObject> OnLoggedObjectCreated { get; set; }
    
    public EventCallback DisplayFunctionDisabledToast { get; set; }
}

public static class ArticleContentFactory
{
    public static IArticleContent Create(TransparencyType type)
    {
        switch (type)
        {
            case TransparencyType.Classic:
                return new ClassicTransparencyContent();
            case TransparencyType.Interactive:
                return new InteractiveTransparencyContent();
            case TransparencyType.InvasiveInteractive:
                return new InvasiveInteractiveTransparencyContent();
            case TransparencyType.ForcedInteractive:
                return new ForcedTransparencyContent();
            case TransparencyType.Incorporated:
                return new IncorporatedTransparencyContent();
            default:
                throw new NotSupportedException();
        }
    }

    public static Type GetComponentType(TransparencyType type)
    {
        switch (type)
        {
            case TransparencyType.Classic:
                return typeof(ClassicTransparencyContent);
            case TransparencyType.Interactive:
                return typeof(InteractiveTransparencyContent);
            case TransparencyType.InvasiveInteractive:
                return typeof(InvasiveInteractiveTransparencyContent);
            case TransparencyType.ForcedInteractive:
                return typeof(ForcedTransparencyContent);
            case TransparencyType.Incorporated:
                return typeof(IncorporatedTransparencyContent);
            default:
                throw new NotSupportedException();
        }
    }
}

public enum TransparencyType
{
    Classic,
    Interactive,
    InvasiveInteractive,
    ForcedInteractive,
    Incorporated
}