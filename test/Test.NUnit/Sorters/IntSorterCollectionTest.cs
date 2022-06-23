using Application.Sorters;
using Shouldly;

namespace Test.NUnit.Sorters
{
    internal class IntSorterCollectionTest
    {
        [Test]
        public void IntSorter_ShouldWorkCorrectly()
        {
            // Arrange
            var collection = new List<int> { 5, 3, 7, 8, 9, 0, 1, 4, 2, 6 };
            var expectedResult = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Act
            var result = IntSorter.Sort(collection);

            // Assert
            // Equal includes sequences
            result.ShouldBe(expectedResult); // Shouldly

            // AreEqual includes sequences
            CollectionAssert.AreEqual(expectedResult, result); // NUnit Assert
        }

        [Test]
        public void IntMixer_ShouldWorkCorrectly()
        {
            // Arrange
            var collection = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Act
            var result = IntSorter.Mix(collection);

            // Assert
            // With ignore order
            result.ShouldBe(collection, true); // Shouldly

            // AreEquivalent excludes sequences
            CollectionAssert.AreEquivalent(collection, result); // NUnit Assert
        }
    }
}
