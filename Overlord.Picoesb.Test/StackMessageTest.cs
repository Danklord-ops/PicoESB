using Overlord.PicoEsb;
using Xunit;

namespace Overlord.Picoesb.Test
{
    public class StackMessageTest
    {
        [Fact]
        public void TryGetQueue_ReturnFalse_IfNoMessageSended()
        {
            string message;
            var stackMessage = new StackMessage();
            stackMessage.Subscribe(1);
            Assert.False(stackMessage.TryGetQueue(out message, 1));
            stackMessage.Unsubscribe(1);
        }

        [Fact]
        public void TryGetQueue_ReturnTreuAndMessage_IfMessageSended()
        {
            string sendedMessage = "test123";
            string resultMessage;
            var stackMessage = new StackMessage();
            stackMessage.Subscribe(1);
            stackMessage.SendToQueue(sendedMessage);
            Assert.True(stackMessage.TryGetQueue(out resultMessage, 1));
            Assert.True(sendedMessage == resultMessage);
            stackMessage.Unsubscribe(1);
        }
    }
}
