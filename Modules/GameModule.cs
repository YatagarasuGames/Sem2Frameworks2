using Frameworks2.Core;
using Frameworks2.Services;

namespace Frameworks2.Modules
{
    public sealed class GameModule : IAppModule
    {
        public string Name => "Game";
        public IReadOnlyCollection<string> Requires => new[] { "Core" };

        public void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IAppAction, PlayGameAction>();
        }

        public Task InitializeAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
            => Task.CompletedTask;

        private sealed class PlayGameAction : IAppAction
        {
            private readonly IScoreStorage _storage;
            public PlayGameAction(IScoreStorage storage) => _storage = storage;

            public string Title => "Симуляция игрового матча";

            public Task ExecuteAsync(CancellationToken cancellationToken)
            {
                Console.WriteLine("[Game] Матч завершен. Начисление базовых очков...");
                _storage.AddOrUpdateScore("PlayerOne", 1500);
                _storage.AddOrUpdateScore("CyberNinja", 3200);
                _storage.AddOrUpdateScore("NoobMaster", 800);

                return Task.CompletedTask;
            }
        }
    }
}
