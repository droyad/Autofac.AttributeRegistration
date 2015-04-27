using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace Tests
{
    public interface ISingleInstanceClass
    {
    }

    [SingleInstance]
    public class SingleInstanceClass : ISingleInstanceClass
    {
    }

    public interface IInstancePerDependencyClass
    {
    }

    [InstancePerDependency]
    public class InstancePerDependencyClass : IInstancePerDependencyClass
    {
    }


    public interface IConcreteTypeRegistrationClass
    {
    }

    [SingleInstance(AsImplementedInterface = false)]
    public class ConcreteTypeRegistrationClass : IConcreteTypeRegistrationClass
    {
    }


    [SingleInstance(AsImplementedInterface = false)]
    [SingleInstance(Name = "Test", AsImplementedInterface = false)]
    public class MultiRegistrationClass
    {
    }

}
