using EquipmentLeaseService.Core.BackgroundProcessingContract;

namespace EquipmentLeaseService.API.BackgroundProcessing
{
    public class BackgroundTaskProcessor : BackgroundService
    {
        private readonly IBackgroundTaskQueue _taskQueue;
        private readonly ILogger<BackgroundTaskProcessor> _logger;

        public BackgroundTaskProcessor(IBackgroundTaskQueue taskQueue, ILogger<BackgroundTaskProcessor> logger)
        {
            _taskQueue = taskQueue;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var workItem = await _taskQueue.DequeueAsync(stoppingToken);

                    _logger.LogInformation("Executing background task");
                    await workItem(stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred executing background task.");
                }
            }
        }
    }
}

