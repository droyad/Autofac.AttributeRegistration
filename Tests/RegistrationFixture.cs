using Autofac;
using NUnit.Framework;
using TestStack.BDDfy;

namespace Tests
{
    public class RegistrationFixture
    {
        protected IContainer _container;

        protected void GivenTheContainerIsBuilt()
        {
            var builder = new ContainerBuilder();
            builder.RegisterByAttributes(typeof(ISingleInstanceClass).Assembly);
            _container = builder.Build();
        }

        [Test]
        public void Execute()
        {
            this.BDDfy();
        }
    }
}