using Application.Extensions;
using FluentAssertions;

namespace Test.xUnit.Extensions
{
    public class StringExtensionsFactTest
    {
        [Fact]
        public void FirstToken_ShouldWorkCorrectly()
        {
            // Arrange
            var str = "abc.asd.qwe";

            // Act
            var result = str.FirstToken('.');

            // Assert
            Assert.Equal("abc", result); // xUnit Assert
        }

        [Fact]
        public void LastToken_ShouldWorkCorrectly()
        {
            // Arrange
            var str = "abc.asd.qwe";

            // Act
            var result = str.LastToken('.');

            // Assert
            result.Should().BeEquivalentTo("qwe"); // FluentAssertions
        }
    }
}
