using Overlord.PicoEsb.Interfaces;
using Overlord.PicoEsb.Models;
using System.Collections.Generic;
using System.Linq;

namespace Overlord.PicoEsb
{
    class StackMessage : IStackMessage
    {
        private List<SubscribeQueue> _logMessages = new List<SubscribeQueue>();

        public void SendToQueue(string message)
        {
            foreach (var logMessage in _logMessages)
            {
                logMessage.Messages.Enqueue(message);
            }
        }

        public void Subscribe(int hash)
        {
            _logMessages.Add(new SubscribeQueue()
            {
                QueueId = hash,
                Messages = new Queue<string>()
            });
        }

        public void Unsubscribe(int hash)
        {
            _logMessages.RemoveAll(x => x.QueueId == hash);
        }

        public bool TryGetQueue(out string message, int hash)
        {
            return _logMessages.Where(x => x.QueueId == hash).Select(x => x.Messages).First().TryDequeue(out message);
        }
    }
}
