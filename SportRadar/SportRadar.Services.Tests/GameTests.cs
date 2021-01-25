using System;
using FluentAssertions;
using NUnit.Framework;

namespace SportRadar.Services.Tests
{
    public class GameTests
    {
        [Test]
        public void Default()
        {
            // arrange
            var expectedHome = new GameTeam()
            {
                Name = "home"
            };
            var expectedAway = new GameTeam()
            {
                Name = "away"
            };


            //
            var actual = new Game(expectedHome.Name, expectedAway.Name);
            //
            actual.Should().NotBeNull();
            actual.AddedOn.Kind.Should().Be(DateTimeKind.Utc);
            (actual.AddedOn - DateTime.UtcNow).TotalMilliseconds.Should().BeLessThan(1);
            actual.Id.Should().NotBeEmpty();
            actual.Home.Should().BeEquivalentTo(expectedHome);
            actual.Away.Should().BeEquivalentTo(expectedAway);
        }

        [Test]
        public void UpdateScore()
        {
            // arrange
            var expectedHome = new GameTeam()
            {
                Name = "home",
                Score = 2
            };
            var expectedAway = new GameTeam()
            {
                Name = "away",
                Score = 5
            };


            //
            var actual = new Game(expectedHome.Name, expectedAway.Name);
            actual.UpdateScore(expectedHome.Score, expectedAway.Score);
            //
            actual.Should().NotBeNull();
            actual.AddedOn.Kind.Should().Be(DateTimeKind.Utc);
            (actual.AddedOn - DateTime.UtcNow).TotalMilliseconds.Should().BeLessThan(1);
            actual.Id.Should().NotBeEmpty();
            actual.Home.Should().BeEquivalentTo(expectedHome);
            actual.Away.Should().BeEquivalentTo(expectedAway);
        }
    }
}