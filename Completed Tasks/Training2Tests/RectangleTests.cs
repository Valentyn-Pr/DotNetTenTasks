using NUnit.Framework;
using Training2;

namespace Training2Tests
{
    [TestFixture]
    public class RectangleTests
    {
        [Test]
        public void GetPerimetrTest()
        {
            Rectangle rectangle = new Rectangle(2.5f, 3, 0, 0);
            Assert.AreEqual(11, rectangle.Perimeter());
        }

        [Test]
        public void RectangleInvalidArgumentExceptionTest()
        {
            Assert.Throws<InvalidArgumentException>( () => new Rectangle(0, 0, 0, 0), "heigth or width are invalid");
        }
    }
}