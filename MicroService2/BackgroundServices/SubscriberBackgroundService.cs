using webapi.Contracts.Services;

namespace webapi.BackgroundServices
{
    public class SubscriberBackgroundService : BackgroundService
    {
        private readonly ISubService _subService;
        private readonly IPubService _pubService;

        public SubscriberBackgroundService(ISubService subService, IPubService pubService)
        {
            _subService = subService;
            _pubService = pubService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _subService.Receive();
                await _pubService.Publish();
            }
        }
    }
}
