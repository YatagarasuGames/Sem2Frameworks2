using Frameworks2.Core;
using Frameworks2.Services;

namespace Frameworks2.Modules
{
    public sealed class CoreModule : IAppModule
    {
        public string Name => "Core";
        public IReadOnlyCollection<string> Requires => Array.Empty<string>();

        public void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IScoreStorage, InMemoryScoreStorage>();
        }

        public Task InitializeAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
            => Task.CompletedTask;
    }
}
