using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Autofac;

namespace WindowsStoreTest
{
    [TestFixture]
    public sealed class Test
    {

        [Test]
        public void NewlyBuiltNugetPackageWasInstalled()
        {
            Assert.AreEqual(GetVersion<Test>(), GetVersion<SingleInstance>());
        }

        private string GetVersion<T>()
        {
            return Regex.Match(typeof(T).AssemblyQualifiedName, @"Version=([0-9\.]+)").Value;
        }
    }
}
