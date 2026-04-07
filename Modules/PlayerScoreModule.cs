using Frameworks2.Core;

namespace Frameworks2.Modules
{
    public sealed partial class PlayerScoreModule : IAppModule
    {
        public string Name => "PlayerScore";
        public IReadOnlyCollection<string> Requires => new[] { "Core", "Game" };

        public void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IAppAction, ApplyBonusAction>();
        }

        public Task InitializeAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
            => Task.CompletedTask;
    }
}
