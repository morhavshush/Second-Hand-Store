using Services.Interfaces;
using System;
using System.Threading.Tasks;
using System.Timers;

namespace Services.ServicesFolder
{
    public class TimerService : ITimerService
    {
        private readonly IProductService _service;
        private readonly ILoggerException _logger;
        public TimerService(IProductService service,ILoggerException logger)
        {
            _service = service;
            _logger = logger;
            var aTimer = new Timer();
            aTimer.Interval = 3000000;
            aTimer.Enabled = true;
            aTimer.Elapsed += OnTimedEvent;
        }
        private void OnTimedEvent(Object source,ElapsedEventArgs e)
        {
            try
            {
                Task taskA = new Task(() => _service.CheckExpirationDate());
                taskA.Start();
            }
            catch (Exception ex)
            {
                _logger.WriteToFile(ex.Message);
            }
        }
    }
}
