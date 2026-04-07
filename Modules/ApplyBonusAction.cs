using Frameworks2.Core;
using Frameworks2.Services;

namespace Frameworks2.Modules
{
    public sealed partial class PlayerScoreModule
    {
        private sealed class ApplyBonusAction : IAppAction
        {
            private readonly IScoreStorage _storage;
            public ApplyBonusAction(IScoreStorage storage) => _storage = storage;

            public string Title => "Расчет бонусных очков игрока";

            public Task ExecuteAsync(CancellationToken cancellationToken)
            {
                Console.WriteLine("[PlayerScore] Применение бонусов к очкам...");
                _storage.AddOrUpdateScore("PlayerOne", 500);
                return Task.CompletedTask;
            }
        }
    }
}
