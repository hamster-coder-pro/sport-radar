using System;
using System.Linq.Expressions;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace SportRadar.Services.Tests
{
    public class GameManagerTests
    {
        [Test]
        public void FindGameSucceed()
        {
            Guid? expectedResult = Guid.NewGuid();
            
            var gs = new Mock<IGamesStorage>();
            gs.Setup(x => x.Find(It.IsAny<Predicate<Game>>())).Returns(() => expectedResult);
            IGameManager manager = new GameManager(gs.Object);
            var id = manager.FindGame("Dynamo Kiev", "Club Brugge");
            id.Should().Be(expectedResult);
        }

        private Expression<Func<Game, bool>> GameIsEquivalent(Game expected)
        {
            return game => game.Away.Name == expected.Away.Name
                           && game.Away.Score == expected.Away.Score
                           && game.Home.Name == expected.Home.Name
                           && game.Home.Score == expected.Home.Score;
        }
        
        [Test]
        public void StartGamePositive()
        {
            // arrange
            var expectedGame = new Game("my", "test");
            var gs = new Mock<IGamesStorage>();
            gs.Setup(x => x.AddGame(It.IsAny<Game>())).Returns(() => true);

            IGameManager manager = new GameManager(gs.Object);
            // act
            manager.StartGame(expectedGame.Home.Name, expectedGame.Away.Name);
            // assert
            gs.Verify(x => x.AddGame(It.Is<Game>(GameIsEquivalent(expectedGame))), Times.Once);
        }
        
        [Test]
        public void StartGameCheckException()
        {
            // assign
            var expectedGame = new Game("my", "test");
            var gs = new Mock<IGamesStorage>();
            gs.Setup(x => x.AddGame(It.IsAny<Game>())).Returns(() => false);

            // act
            try
            {
                IGameManager manager = new GameManager(gs.Object);
                manager.StartGame(expectedGame.Home.Name, expectedGame.Away.Name);
            }
            // assert
            catch (CantStartGameException)
            {
                return;
            }
            catch (Exception)
            {
                Assert.Fail("Unexpected exception type");
                return;
            }
            
            Assert.Fail("Exception not thrown");
        }
        
        [Test]
        public void StartGameCheckWrappedException()
        {
            // assign
            var expectedGame = new Game("my", "test");
            var gs = new Mock<IGamesStorage>();
            gs.Setup(x => x.AddGame(It.IsAny<Game>())).Throws<NotImplementedException>();

            // act
            try
            {
                IGameManager manager = new GameManager(gs.Object);
                manager.StartGame(expectedGame.Home.Name, expectedGame.Away.Name);
            }
            // assert
            catch (CantStartGameException actualException)
            {
                if (actualException.InnerException is NotImplementedException)
                    return;
                Assert.Fail("Exception not wrapped");
            }
            catch (Exception)
            {
                Assert.Fail("Unexpected exception type");
                return;
            }
            
            Assert.Fail("Exception not thrown");
        }        
    }
}