using System.Collections.Generic;

namespace Overlord.PicoEsb.Models
{
    class SubscribeQueue
    {
        public int QueueId { get; set; }
        public Queue<string> Messages { get; set; }
    }
}
