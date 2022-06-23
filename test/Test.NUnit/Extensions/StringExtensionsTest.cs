using Application.Extensions;
using Shouldly;

namespace Test.NUnit.Extensions
{
    internal class StringExtensionsTest
    {
        [Test]
        public void FirstToken_ShouldWorkCorrectly()
        {
            // Arrange
            var str = "abc.asd.qwe";

            // Act
            var result = str.FirstToken('.');

            // Assert
            Assert.That(result, Is.EqualTo("abc")); // NUnit Assert
        }

        [Test]
        public void LastToken_ShouldWorkCorrectly()
        {
            // Arrange
            var str = "abc.asd.qwe";

            // Act
            var result = str.LastToken('.');

            // Assert
            result.ShouldBe("qwe"); // Shouldly
        }
    }
}
