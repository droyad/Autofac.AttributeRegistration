using System;

namespace Autofac
{
    public class InstancePerDependency : AutofacRegistrationAttribute
    {
        internal override void Register(ContainerBuilder builder, Type type)
        {
            var registrationBuilder = builder.RegisterType(type).InstancePerDependency();
            Register(registrationBuilder, type);
        }
    }
}