using Application.Mappers;
using Application.Models;
using Shouldly;
using System.Diagnostics;

namespace Test.NUnit.Mappers
{
    internal class CompactClientCollectionTest
    {
        private CompactClientMapper _mapper;
        private CompactClientComparer _comparer;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Debug.WriteLine($"{nameof(CompactClientCollectionTest)}: OneTimeSetUp fired");

            _mapper = new();
            _comparer = new();
        }

        [Test]
        public void CompactClientMapper_ShouldWorkCorrectly_InRightOrder()
        {
            // Arrange
            var input = new List<Client>
            {
                new Client
                {
                    Id = 1,
                    FirstName = "A",
                    LastName = "B",
                    Inn = "234",
                    Requests = new List<Request> { new Request { Id = 1 }, new Request { Id = 2 }, new Request() }
                },
                new Client
                {
                    Id = 2,
                    FirstName = "Acx",
                    LastName = "Bww",
                    Inn = string.Empty,
                    Requests = new List<Request>()
                },
                new Client
                {
                    Id = 3,
                    FirstName = "A",
                    LastName = "B",
                    Inn = default,
                    Requests = default
                },
            };
            var output = new List<CompactClient>
            {
                new CompactClient
                {
                    Id = 1,
                    FullName = "A B",
                    Inn = "234",
                    Requests = 2
                },
                new CompactClient
                {
                    Id = 2,
                    FullName = "Acx Bww",
                    Inn = string.Empty,
                    Requests = 0
                },
                new CompactClient
                {
                    Id = 3,
                    FullName = "A B",
                    Inn = default,
                    Requests = 0
                }
            };

            // Act
            var result = new List<CompactClient>();
            foreach (var client in input)
                result.Add(_mapper.Map(client));

            // Assert
            // Without comparer
            result.ShouldBeEquivalentTo(output); // Shouldly
            // With comparer
            result.ShouldBe(output, _comparer); // Shouldly

            // Needs to override CompactClient Equals method
            CollectionAssert.AreEquivalent(output, result); // NUnit Assert
            CollectionAssert.AreEqual(output, result); // NUnit Assert
        }

        [Test]
        public void CompactClientMapper_ShouldWorkCorrectly_InWrongOrder()
        {
            // Arrange
            var input = new List<Client>
            {
                new Client
                {
                    Id = 1,
                    FirstName = "A",
                    LastName = "B",
                    Inn = "234",
                    Requests = new List<Request> { new Request { Id = 1 }, new Request { Id = 2 }, new Request() }
                },
                new Client
                {
                    Id = 2,
                    FirstName = "Acx",
                    LastName = "Bww",
                    Inn = string.Empty,
                    Requests = new List<Request>()
                },
                new Client
                {
                    Id = 3,
                    FirstName = "A",
                    LastName = "B",
                    Inn = default,
                    Requests = default
                },
            };
            var output = new List<CompactClient>
            {
                new CompactClient
                {
                    Id = 2,
                    FullName = "Acx Bww",
                    Inn = string.Empty,
                    Requests = 0
                },
                new CompactClient
                {
                    Id = 3,
                    FullName = "A B",
                    Inn = default,
                    Requests = 0
                },
                new CompactClient
                {
                    Id = 1,
                    FullName = "A B",
                    Inn = "234",
                    Requests = 2
                },
            };

            // Act
            var result = new List<CompactClient>();
            foreach (var client in input)
                result.Add(_mapper.Map(client));

            // Assert
            // ShouldBeEquivalentTo include sequences
            result.ShouldBeEquivalentTo(output); // Shouldly
            // With comparer and ignore order
            result.ShouldBe(output, _comparer, true); // Shouldly

            // Needs to override CompactClient Equals method
            // AreEquivalent excludes sequences
            CollectionAssert.AreEquivalent(output, result);
            // AreEqual includes sequences
            CollectionAssert.AreEqual(output, result);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Debug.WriteLine($"{nameof(CompactClientCollectionTest)}: OneTimeTearDown fired");

            _mapper.Dispose();
            _comparer.Dispose();
        }
    }
}
