using System.Runtime.CompilerServices;

namespace YourScheduler.Infrastructure.Entities
{
    public class Message
    {
        public List<string> To { get; set; }       
        public string Subject { get; set; }
        public string MessageContent { get; set; }

        public Message(List<string> to, string subject, string messageContent)
        {
            To = to;
            Subject = subject;
            MessageContent = messageContent;
        }
    }
}
