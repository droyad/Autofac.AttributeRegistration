using Autofac;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class MultiRegistrationFixture : RegistrationFixture
    {
        private MultiRegistrationClass _result1;
        private MultiRegistrationClass _result2;

        void WhenTheServiceIsResolvedInDifferentLifetimeScopes()
        {
            _result1 = _container.ResolveOptional<MultiRegistrationClass>();
            _result2 = _container.ResolveOptionalNamed<MultiRegistrationClass>("Test");
        }

        void ThenResult1IsNotNull()
        {
            _result1.Should().NotBeNull();
        }

        void AndThenResult2IsNotNull()
        {
            _result2.Should().NotBeNull();
        }

        void AndThenTheReferencesShouldBeDifferent()
        {
            _result1.Should().NotBeSameAs(_result2);
        }

    }
}