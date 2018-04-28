using System;
using System.ComponentModel;
using Autofac.Builder;

namespace Autofac
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public abstract class AutofacRegistrationAttribute : Attribute
    {
        internal abstract void Register(ContainerBuilder builder, Type type);

        protected AutofacRegistrationAttribute()
        {
            AsImplementedInterface = true;
        }

        public string Name { get; set; }
             
        [DefaultValue(true)]
        public bool AsImplementedInterface { get; set; }
       
        [DefaultValue(false)]
        public bool AutoActivate { get; set; }

        protected void Register<TLimit>(IRegistrationBuilder<TLimit, ConcreteReflectionActivatorData, SingleRegistrationStyle> registrationBuilder, Type type)
        {
            if(Name == null)
                registrationBuilder.AsSelf();
            else
                registrationBuilder.Named(Name, type);

            if (AsImplementedInterface)
                registrationBuilder.AsImplementedInterfaces();

            if(AutoActivate)
                registrationBuilder.AutoActivate();
        }
    }
}