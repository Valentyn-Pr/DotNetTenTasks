using NUnit.Framework;
using Training2;

namespace Training2Tests
{

    [TestFixture]
    public class Tests
    {

        Person Valik = new Person() { Name = "Valentyn", Age = 21, Surname = "Prysiazhniuk" };

        [Test]
        public void CompareWithHigherAgeTest()
        {
            Assert.AreEqual($"Valentyn Prysiazhniuk younger than 22", Valik.CompareWithAge(22));
        }

        [Test]
        public void CompareWithLowerAgeTest()
        {
            Assert.AreEqual($"Valentyn Prysiazhniuk older than 20", Valik.CompareWithAge(20));
        }

        [Test]
        public void InvalidArgumentExceptionTest()
        {
            Assert.Throws<InvalidArgimentException>(()=>Valik.CompareWithAge(-2), "Invalid compare age");
        }
    }
}