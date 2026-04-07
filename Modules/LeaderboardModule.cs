using Frameworks2.Core;

namespace Frameworks2.Modules
{
    public sealed partial class LeaderboardModule : IAppModule
    {
        public string Name => "Leaderboard";
        public IReadOnlyCollection<string> Requires => new[] { "Core", "PlayerScore" };

        public void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IAppAction, ShowLeaderboardAction>();
        }

        public Task InitializeAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
            => Task.CompletedTask;
    }
}
