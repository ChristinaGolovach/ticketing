namespace Ticketing.Shared.Infrastructure.Bus
{
    public interface IBusService : IAsyncDisposable
    {
        Task SendMessageAsync<T>(T notification, CancellationToken cancellationToken);
    }
}
