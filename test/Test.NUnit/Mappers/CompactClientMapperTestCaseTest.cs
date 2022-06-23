using Application.Mappers;
using Application.Models;
using Shouldly;
using System.Diagnostics;

namespace Test.NUnit.Mappers
{
    internal class CompactClientMapperTestCaseTest
    {
        private CompactClientMapper _mapper;
        private CompactClientComparer _comparer;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Debug.WriteLine($"{nameof(CompactClientMapperTestCaseTest)}: OneTimeSetUp fired");

            _mapper = new();
            _comparer = new();
        }

        [TestCaseSource(nameof(GetTestData))]
        public void CompactClientMapper_ShouldWorkCorrectly(Client client, CompactClient expectedResult)
        {
            // Act
            var result = _mapper.Map(client);

            // Assert
            // Without comparer
            result.ShouldBeEquivalentTo(expectedResult); // Shouldly
            // With comparer
            result.ShouldBe(expectedResult, _comparer); // Shouldly

            // Needs to override CompactClient Equals method
            Assert.That(result, Is.EqualTo(expectedResult)); // NUnit Assert
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Debug.WriteLine($"{nameof(CompactClientMapperTestCaseTest)}: OneTimeTearDown fired");

            _mapper.Dispose();
            _comparer.Dispose();
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
    }
}
