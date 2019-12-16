namespace Core.Abstractions
{
    public interface IBrokerPublisher<T>
    {
        void Publish(string topic, T message);         
    }
}