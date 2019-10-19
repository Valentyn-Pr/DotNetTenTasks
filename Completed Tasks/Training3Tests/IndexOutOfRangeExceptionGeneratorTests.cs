using NUnit.Framework;
using System;
using Training3;

namespace Training3Tests
{
    [TestFixture]
    public class IndexOutOfRangeExceptionGeneratorTest
    {
        [Test]
        public void GetIndexOutOfRangeExceptionGeneratorTest()
        {
            IndexOutOfRangeExceptionGenerator indexOutOfRangeGetter = new IndexOutOfRangeExceptionGenerator();
            Assert.Throws<IndexOutOfRangeException>(() => indexOutOfRangeGetter.GetIndexOutOfRangeException(), 
                "Index out of range!");
        }
    }
}