using System.Collections.Generic;
using System.Linq;
using ante_up.Common.ApiModels;
using ante_up.Common.DataModels;
using ante_up.Logic;
using ante_up.Tests.FakeData;
using NUnit.Framework;

namespace ante_up.Tests
{
    public class GameTests
    {
        private readonly GameLogic _gameLogic = new(new FakeGameData());

        public GameTests()
        {
        }

        [Test]
        public void GetAllGames_HasInitialGames()
        {
            List<Game> games = _gameLogic.GetAllGames();

            bool result = games.Any(x => x.Name == "Fortnite");
            
            Assert.IsTrue(result);
        }

        [Test]
        public void GetAllGameNames_FindsAName()
        {
            _gameLogic.GetAllGames();
            
            bool result = _gameLogic.GetAllGameNames().FirstOrDefault(x => x == "Fortnite") != null;
            
            Assert.IsTrue(result);
        }
    }
}