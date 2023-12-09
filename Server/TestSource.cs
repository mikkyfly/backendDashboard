namespace Server;

public class TestSource : ISource, IHostedService
{
    public event ISource.AccountHandler? Notify;

    private int _id = 0;
    private readonly int _range = 0;
    
    public TestSource()
    {
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        while (true)
        {
            var datas = Enumerable.Range(_id, _id + _range).Select(i => new Data()
            {
                Id = i,
                Message = $"Message number {i}"
            }).ToList();
            _id += _range;

            Notify?.Invoke(datas);
            await Task.Delay(500, cancellationToken);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}