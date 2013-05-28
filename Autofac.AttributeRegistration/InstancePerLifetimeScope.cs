using System;

namespace Autofac
{
    public class InstancePerLifetimeScope : AutofacRegistrationAttribute
    {
        internal override void Register(ContainerBuilder builder, Type type)
        {
            var registrationBuilder = builder.RegisterType(type).InstancePerLifetimeScope();
            Register(registrationBuilder, type);
        }
    }
}