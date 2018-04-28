using Autofac;
using NUnit.Framework;
using FluentAssertions;

namespace Tests
{
    [TestFixture]
    public class SingleInstanceLifetimeFixture : RegistrationFixture
    {
        private ISingleInstanceClass _result1;
        private ISingleInstanceClass _result2;


        void WhenTheServiceIsResolvedInDifferentLifetimeScopes()
        {
            using (_container.BeginLifetimeScope())
                _result1 = _container.ResolveOptional<ISingleInstanceClass>();

            using (_container.BeginLifetimeScope())
                _result2 = _container.ResolveOptional<ISingleInstanceClass>();
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
            _result1.Should().BeSameAs(_result2);
        }


        void AndThenTheTypeShouldBeSingleInstanceClass()
        {
            _result1.Should().BeOfType<SingleInstanceClass>();
        }
    }
}
