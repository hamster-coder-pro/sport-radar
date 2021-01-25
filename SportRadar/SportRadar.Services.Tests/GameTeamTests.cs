using FluentAssertions;
using NUnit.Framework;

namespace SportRadar.Services.Tests
{
    public class GameTeamTests
    {
        [Test]
        public void Default()
        {
            // arrange
            const string expectedName = "";
            const int expectedScore = 0;
            //
            var actual = new GameTeam();
            //
            actual.Should().NotBeNull();
            actual.Name.Should().Be(expectedName);
            actual.Score.Should().Be(expectedScore);
        }

        [Test]
        public void SettersTest()
        {
            // arrange
            const string expectedName = "test";
            const int expectedScore = 2;
            // act
            var actual = new GameTeam()
            {
                Name = expectedName
            };
            actual.Score = expectedScore;
            // assert
            actual.Should().NotBeNull();
            actual.Name.Should().Be(expectedName);
            actual.Score.Should().Be(expectedScore);
        }
    }
}