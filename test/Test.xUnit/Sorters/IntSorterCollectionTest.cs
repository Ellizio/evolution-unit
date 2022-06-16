using Application.Sorters;
using FluentAssertions;

namespace Test.xUnit.Sorters
{
    public class IntSorterCollectionTest
    {
        [Fact]
        public void IntSorter_ShouldWorkCorrectly()
        {
            // Arrange
            var collection = new List<int> { 5, 3, 7, 8, 9, 0, 1, 4, 2, 6 };
            var expectedResult = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Act
            var result = IntSorter.Sort(collection);
                
            // Assert
            // Equal includes sequences
            result.Should().Equal(expectedResult); // FluentAssertions
            result.Should().BeInAscendingOrder(); // FluentAssertions

            // Equal includes sequences
            Assert.Equal(expectedResult, result); // xUnit Assert
        }

        [Fact]
        public void IntMixer_ShouldWorkCorrectly()
        {
            // Arrange
            var collection = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Act
            var result = IntSorter.Mix(collection);

            // Assert
            // BeEquivalentTo excludes sequences
            result.Should().BeEquivalentTo(collection); // FluentAssertions

            // Fails because sequences are different
            Assert.Equal(collection, result); // xUnit Assert
        }
    }
}
