using System.Linq;
using Autofac;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class InstacePerDependencyLifetimeFixture : RegistrationFixture
    {
        private IInstancePerDependencyClass _result1;
        private IInstancePerDependencyClass _result2;


        void WhenTheServiceIsResolvedTwice()
        {
            _result1 = _container.ResolveOptional<IInstancePerDependencyClass>();
            _result2 = _container.ResolveOptional<IInstancePerDependencyClass>();
        }


        void ThenResult1IsNotNull()
        {
            _result1.Should().NotBeNull();
        }

        void AndThenResult2IsNotNull()
        {
            _result2.Should().NotBeNull();
        }

        void AndThenTheReferencesShouldBeTheSame()
        {
            _result1.Should().NotBeSameAs(_result2);
        }

        void AndThenTheTypeShouldBeInstancePerDependencyClass()
        {
            _result1.Should().BeOfType<InstancePerDependencyClass>();
        }
    }
}