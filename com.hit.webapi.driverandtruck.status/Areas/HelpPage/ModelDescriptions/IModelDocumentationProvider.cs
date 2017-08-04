using System;
using System.Reflection;

namespace com.hit.webapi.driverandtruck.status.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}