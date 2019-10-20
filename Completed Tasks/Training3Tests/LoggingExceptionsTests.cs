using NUnit.Framework;
using System;
using Training3;

namespace Training3Tests
{
    [TestFixture]
    public class LoggingExceptionTest
    {
        ExceptionsLogging exceptionLogging;

        [SetUp]
        public void DoSomeMathSetup()
        {
            exceptionLogging = new ExceptionsLogging();
        }

        [Test]
        public void DoSomeMathDoesNotThrowExceptionTest()
        {
            Assert.DoesNotThrow( () => exceptionLogging.DoSomeMath(0, 0));
        }

        [TestCase (-1, 0)]
        [TestCase (0, 3)]
        public void DoSomeMathDoesThrowArgumentExceptionTest(int a, int b)
        {
            Assert.Throws<ArgumentException>(() => exceptionLogging.DoSomeMath(a, b));
        }
    }
}