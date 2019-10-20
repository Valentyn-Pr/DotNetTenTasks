using NUnit.Framework;
using Training2;

namespace Training2Tests
{

    [TestFixture]
    public class PersonTests
    {
        Person Valik;
        int personAge = 21;

        [SetUp]
        public void PersonSetup()
        {
            Valik = new Person() { Name = "Valentyn", Age = personAge, Surname = "Prysiazhniuk" };
        }
        
        [Test]
        public void CompareWithHigherAgeTest()
        {
            Assert.AreEqual($"Valentyn Prysiazhniuk younger than {personAge + 1}", Valik.CompareWithAge(personAge + 1));
        }

        [Test]
        public void CompareWithLowerAgeTest()
        {
            Assert.AreEqual($"Valentyn Prysiazhniuk older than {personAge - 1}", Valik.CompareWithAge(personAge - 1));
        }

        [Test]
        public void InvalidArgumentExceptionTest()
        {
            Assert.Throws<InvalidArgumentException>( () => Valik.CompareWithAge(-2), "Invalid compare age" );
        }
    }
}