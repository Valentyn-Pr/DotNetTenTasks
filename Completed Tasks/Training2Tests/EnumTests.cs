using NUnit.Framework;
using Training2;

namespace Training2Tests
{

    [TestFixture]
    public class EnumTests
    {
        MonthEnum monthEnum = new MonthEnum();

        [Test]
        public void GetMonthByNumberTest()
        {
            Assert.AreEqual("Mar", monthEnum.GetMonthByNumber(2));
        }

        [TestCase (-1)]
        [TestCase (13)]
        public void EnumInvalidArgumentExceptionTest(int monthNumber)
        {
            Assert.Throws<InvalidArgumentException>(() => monthEnum.GetMonthByNumber(monthNumber));
        }
    }
}
