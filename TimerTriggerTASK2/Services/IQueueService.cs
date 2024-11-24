using System.Threading.Tasks;

namespace TimerTriggerTASK2.Services
{
    public interface IQueueService
    {
        Task SendMessageAsync(string message);
        Task<string> ReceiveMessageAsync();
    }
}
