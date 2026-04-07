using Frameworks2.Core;
using Frameworks2.Services;

namespace Frameworks2.Modules
{
    public sealed partial class LeaderboardModule
    {
        private sealed class ShowLeaderboardAction : IAppAction
        {
            private readonly IScoreStorage _storage;
            public ShowLeaderboardAction(IScoreStorage storage) => _storage = storage;

            public string Title => "Вывод таблицы лидеров (Leaderboard)";

            public Task ExecuteAsync(CancellationToken cancellationToken)
            {
                var scores = _storage.GetAllScores()
                    .OrderByDescending(x => x.Value)
                    .ToList();

                Console.WriteLine("\n=== ТАБЛИЦА ЛИДЕРОВ ===");
                for (int i = 0; i < scores.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {scores[i].Key} - {scores[i].Value} pts");
                }
                Console.WriteLine("=======================\n");

                return Task.CompletedTask;
            }
        }
    }
}
