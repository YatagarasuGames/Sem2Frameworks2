namespace Frameworks2.Core
{
    public interface IAppModule
    {
        string Name { get; }

        IReadOnlyCollection<string> Requires { get; }

        void RegisterServices(IServiceCollection services);

        Task InitializeAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken);
    }
}
