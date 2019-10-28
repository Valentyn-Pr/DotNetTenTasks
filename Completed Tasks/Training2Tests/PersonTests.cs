using NUnit.Framework;
using Training2;

namespace Training2Tests
{
    [TestFixture]
    public class PersonTests
    {
        Person valik;
        int personAge = 21;

        [SetUp]
        public void PersonSetup()
        {
            valik = new Person() { Name = "Valentyn", Age = personAge, Surname = "Prysiazhniuk" };
        }
        
        [Test]
        public void CompareWithHigherAgeTest()
        {
            Assert.AreEqual($"Valentyn Prysiazhniuk younger than {personAge + 1}", valik.CompareWithAge(personAge + 1));
        }

        [Test]
        public void CompareWithLowerAgeTest()
        {
            Assert.AreEqual($"Valentyn Prysiazhniuk older than {personAge - 1}", valik.CompareWithAge(personAge - 1));
        }

        [Test]
        public void InvalidArgumentExceptionTest()
        {
            Assert.Throws<InvalidArgumentException>( () => valik.CompareWithAge(-2), "Invalid compare age" );
        }
    }
}