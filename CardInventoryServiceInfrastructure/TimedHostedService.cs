using CardInventoryServiceDomain.Core.Utilities;
using CardInventoryServiceDomain.Model;
using CardInventoryServiceInfrastructure.IRepository;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardInventoryServiceInfrastructure
{
    public class TimedHostedService : IHostedService , IDisposable
    {
        private readonly ILogger<TimedHostedService> _logger;
        private readonly IStockRepository _stockRepository;
        private Timer? _timer =null;
        public TimedHostedService(IStockRepository stockRepository, ILogger<TimedHostedService> logger)
        {
            _stockRepository = stockRepository;
            _logger = logger;

        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");
            Console.WriteLine("Let it rain");
            _timer = new Timer(e => publish(), null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
        Publisher publisher = new Publisher();
        void publish()
        {
            publisher.Publish<StockSummaryDto>(_stockRepository.GetStockSummary());
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
