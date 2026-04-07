namespace Frameworks2.Core
{
    public interface IAppAction
    {
        string Title { get; }

        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}
