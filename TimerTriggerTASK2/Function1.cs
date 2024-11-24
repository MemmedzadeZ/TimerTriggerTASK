using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using TimerTriggerTASK2.Services;
namespace TimerTriggerTASK2;


public class Function1
{
    private readonly IQueueService _queueService;

    public Function1(IQueueService queueService)
    {
        _queueService = queueService;
    }
    // İkinci TimerTrigger - Her 7 saniyede bir sıradaki mesajı alır ve siler
    [FunctionName("ProcessAndDeleteQueueMessage")]
    public async Task ProcessAndDeleteQueueMessage([TimerTrigger("*/7 * * * * *")] TimerInfo myTimer, ILogger log)
    {
        string message = await _queueService.ReceiveMessageAsync();
        if (message != null)
        {
            log.LogInformation($"Mesaj Okundu ve Silindi: {message}");
        }
        else
        {
            log.LogInformation("Kuyrukta işlenecek mesaj yok.");
        }
    }
}
