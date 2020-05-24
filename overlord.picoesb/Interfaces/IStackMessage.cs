namespace Overlord.PicoEsb.Interfaces
{
    public interface IStackMessage
    {
        void SendToQueue(string message);
        bool TryGetQueue(out string message, int hash);
        void Subscribe(int hash);
        void Unsubscribe(int hash);
    }
}
