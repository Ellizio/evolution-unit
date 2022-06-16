using Application.Mappers;
using Application.Models;
using FluentAssertions;

namespace Test.xUnit.Mappers
{
    public class CompactClientCollectionFactTest
    {
        private readonly CompactClientMapper _mapper = new();

        [Fact]
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
            // Does not require comparer
            result.Should().BeEquivalentTo(output); // FluentAssertions

            // Requires comparer
            Assert.Equal(output, result, new CompactClientComparer()); // xUnit Assert
        }

        [Fact]
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
            // Does not require comparer
            result.Should().BeEquivalentTo(output);

            // Requires comparer
            // Fails because sequences are different
            Assert.Equal(output, result, new CompactClientComparer());
        }
    }
}
