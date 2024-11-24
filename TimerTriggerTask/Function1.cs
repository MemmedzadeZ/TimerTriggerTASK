using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using TimerTriggerTask.Services;

namespace TimerTriggerTask
{
    public class Function1
    {
        private readonly IQueueService _queueService;

        public Function1(IQueueService queueService)
        {
            _queueService = queueService;
        }

        //  Her 5 saniyede bir yeni Product gönderir
        [FunctionName("SendProductToQueue")]
        public async Task SendProductToQueue([TimerTrigger("*/5 * * * * *")] TimerInfo myTimer, ILogger log)
        {
            string productMessage = "Product-" + Guid.NewGuid().ToString();
            await _queueService.SendMessageAsync(productMessage);
            log.LogInformation($"Yeni Ürün Kuyruğa Gönderildi: {productMessage}");
        }
    }
}
