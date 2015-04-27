# Autofac.AttributeRegistration #

[Nuget Package](https://www.nuget.org/packages/Autofac.AttributeRegistration)

The best way to register your Autofac service is to use the [convention approach](http://docs.autofac.org/en/latest/register/scanning.html). However there are always exceptions to the rule, and sometimes the registration process needs to be done on a case by case basis. When this happens, we usually end up with something like this in the Autofac module or the container builder:

	builder.RegisterType<Foo>().As<IFoo>().SingleInstance();
	builder.RegisterType<Bar>().AsSelf().AsImplementedInterfaces().InstancePerLifetimeScope();
	builder.RegisterType<Baz>().AsImplementedInterfaces().Named("Baz").InstancePerDependency();

This can get unweildly quickly. The other problem is that when modifying a serice, it is not clear what it's lifestyle is.

The `Autofac.AttributeRegistration` library helps to clean up the registrations by moving the registration adjacent to the class declaration but using attributes. 

## Usage ##
To register a class, add the appropriate attribute:

	[SingleInstance]
    public class Foo : IFoo { }


And then in your container builder or module, call `RegisterByAttributes(params Assembly[])`:

	builder.RegisterByAttributes(ThisAssembly, typeof(OtherAssemblyType).Assembly)

For other lifestyles, you can use the `[InstancePerDependency]`, `[InstancePerLifetimeScope]` and `[InstancePerHttpRequest]` attributes.

## Registration Options ##

By default, all types are registered as `AsSelf()` and as `AsImplementedInterfaces()`.

### As Interface ###
To prevent the registration as `AsImplementedInterfaces()`, set the `AsImplementedInterface` attribute property to false, eg `[SingleInstance(AsImplementedInterface = false)]`. If the type does not have any interfaces, this option is not required.

### Named Service ###

To register a type as a named service, use the `Name` attribute property, eg `[SingleInstance(Name = "Test")]`.

### AutoActivate ###

If you want to register the type as AutoActive, use the `AutoActive` attribute property, eg `[SingleInstance(AutoActive = true)]`

### Multiple Regisistration ###

If you need to register a type in several different ways, you can specify the attribute more than once:

	[SingleInstance(AsImplementedInterface = false)]
    [SingleInstance(Name = "Test", AsImplementedInterface = false)]
    public class MultiRegistrationClass

The registration is run for each attribute, so in this case the type is registered twice.

## Compatability ##

Autofac.AttributeRegistration is a Portable Class Library and has been tested against `Autofac 3.1.5` and the following library types:

- .NET 4.5
- .NET 4 Client Profile
- .NET 4
- Sliverlight 5
- Windows Store
- Windows Phone 8

If you are having problems compiling with errors referring to System.Core 2.0.5.0, see [here](http://autofac.readthedocs.org/en/latest/faq/pcl.html).

If you are trying to use Autofac in a VSTO application, you may get build errors. This is related again to System.Core (Portable class library). The solution is not to reference and PCL assemblies from the VSTO project directly.