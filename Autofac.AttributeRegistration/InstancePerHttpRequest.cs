using System;

namespace Autofac
{
    public class InstancePerHttpRequest : AutofacRegistrationAttribute
    {
        internal override void Register(ContainerBuilder builder, Type type)
        {
            var registrationBuilder = builder.RegisterType(type).InstancePerMatchingLifetimeScope("AutofacWebRequest");
            Register(registrationBuilder, type);
        }
    }
}