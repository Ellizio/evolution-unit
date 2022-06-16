using Application.Mappers;
using Application.Models;
using FluentAssertions;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Test.xUnit.Mappers
{
    public class CompactClientMapperTheoryTest : IDisposable
    {
        private readonly CompactClientMapper _mapper;
        private readonly CompactClientComparer _comparer;

        public CompactClientMapperTheoryTest()
        {
            Debug.WriteLine($"CompactClientMapperTheoryTest: ctor fired");

            _mapper = new CompactClientMapper();
            _comparer = new CompactClientComparer();
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void CompactClientMapper_ShouldWorkCorrectly(Client client, CompactClient expectedCompactClient)
        {
            // Act
            var result = _mapper.Map(client);

            // Assert
            // Does not require comparer
            result.Should().BeEquivalentTo(expectedCompactClient); // FluentAssertions

            // Requires comparer
            Assert.Equal(result, expectedCompactClient, _comparer); // xUnit Assert
        }

        public static List<object[]> GetTestData()
        {
            // Arrange
            return new List<object[]>
            {
                new object[]
                {
                    new Client
                    {
                        Id = 1,
                        FirstName = "A",
                        LastName = "B",
                        Inn = "234",
                        Requests = new List<Request> { new Request { Id = 1 }, new Request { Id = 2 }, new Request() }
                    },
                    new CompactClient
                    {
                        Id = 1,
                        FullName = "A B",
                        Inn = "234",
                        Requests = 2
                    }
                },
                new object[]
                {
                    new Client
                    {
                        Id = 2,
                        FirstName = "Acx",
                        LastName = "Bww",
                        Inn = string.Empty,
                        Requests = new List<Request>()
                    },
                    new CompactClient
                    {
                        Id = 2,
                        FullName = "Acx Bww",
                        Inn = string.Empty,
                        Requests = 0
                    }
                },
                new object[]
                {
                    new Client
                    {
                        Id = 3,
                        FirstName = "A",
                        LastName = "B",
                        Inn = default,
                        Requests = default
                    },
                    new CompactClient
                    {
                        Id = 3,
                        FullName = "A B",
                        Inn = default,
                        Requests = 0
                    }
                },
            };
        }

        public void Dispose()
        {
            Debug.WriteLine("CompactClientMapperTheoryTest: Dispose fired");

            _mapper.Dispose();
            _comparer.Dispose();
        }
    }
}
