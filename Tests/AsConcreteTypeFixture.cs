using Autofac;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class AsConcreteTypeFixture : RegistrationFixture
    {
        private ConcreteTypeRegistrationClass _result;
        private IConcreteTypeRegistrationClass _resultByInterface;


        void WhenTheServiceIsResolved()
        {
            _result = _container.ResolveOptional<ConcreteTypeRegistrationClass>();
            _resultByInterface = _container.ResolveOptional<IConcreteTypeRegistrationClass>();
        }

        void ThenTheResultIsNotNull()
        {
            _result.Should().NotBeNull();
        }

        void AndThenTheResultByInterfaceIsNull()
        {
            _resultByInterface.Should().BeNull();
        }

        void AndThenTheReferencesShouldBeTheSame()
        {
            _result.Should().BeOfType<ConcreteTypeRegistrationClass>();
        }
    }
}