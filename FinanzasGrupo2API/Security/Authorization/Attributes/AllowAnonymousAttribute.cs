using System;

namespace FinanzasGrupo2API.Security.Authorization.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAnonymousAttribute : Attribute
    {
        
    }
}