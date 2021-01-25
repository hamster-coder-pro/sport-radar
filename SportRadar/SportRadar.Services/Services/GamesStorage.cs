using System;
using System.Collections.Generic;

namespace SportRadar.Services
{
    public class GamesStorage : IGamesStorage
    {
        private IDictionary<Guid, Game> games = new Dictionary<Guid, Game>();

        public bool AddGame(Game game)
        {
            return games.TryAdd(game.Id, game);
        }

        public bool RemoveGame(Guid gameId)
        {
            return games.Remove(gameId);
        }

        public bool UpdateGameData(
            Guid gameId,
            Action<Game> update
        )
        {
            if (games.TryGetValue(gameId, out var game))
            {
                update(game);
                return true;
            }

            return false;
        }

        public Guid? Find(Predicate<Game> searchPredicate)
        {
            foreach (var (id, game) in games)
            {
                if (searchPredicate(game))
                {
                    return id;
                }
            }

            return null;
        }

        public IEnumerable<Game> Enumerate()
        {
            return games.Values;
        }
    }
}