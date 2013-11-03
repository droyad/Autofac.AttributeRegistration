using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using Autofac;

namespace WindowsStoreTest
{
    [TestFixture]
    public class Test
    {

        public static void Main()
        {
            
        }

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
