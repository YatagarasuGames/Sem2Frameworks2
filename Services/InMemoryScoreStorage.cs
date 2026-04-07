using System.Collections.Concurrent;

namespace Frameworks2.Services
{
    public sealed class InMemoryScoreStorage : IScoreStorage
    {
        // Потокобезопасное хранилище игроков и их очков
        private readonly ConcurrentDictionary<string, int> _scores = new();

        public void AddOrUpdateScore(string playerName, int score)
        {
            _scores.AddOrUpdate(playerName, score, (_, current) => current + score);
        }

        public IReadOnlyDictionary<string, int> GetAllScores() => _scores;
    }
}
