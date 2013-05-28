using System;

namespace Autofac
{
    public class SingleInstance : AutofacRegistrationAttribute
    {
        internal override void Register(ContainerBuilder builder, Type type)
        {
            var registrationBuilder = builder.RegisterType(type).SingleInstance();
            Register(registrationBuilder, type);
        }
    }
}