using System;
using System.Collections.Generic;

namespace SportRadar.Services
{
    public interface IGamesStorage
    {
        bool AddGame(Game game);

        bool RemoveGame(Guid gameId);

        bool UpdateGameData(
            Guid gameId,
            Action<Game> update
        );

        Guid? Find(Predicate<Game> searchPredicate);

        IEnumerable<Game> Enumerate();
    }
}