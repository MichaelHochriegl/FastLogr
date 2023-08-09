using FastLogr.Attributes;

namespace FastLogr.Example.WorkerService;

public class Worker : BackgroundService
{
    [LogMessage(MessageTemplate = "Test with one parameter: '{firstParameter}'")]
    private static Action<string> LogExampleMessageInWorker = default!;
    
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogExampleMessageInWorker("test");
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
    }
}