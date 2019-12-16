namespace Core.Abstractions
{
    public interface IBrokerConnection<TChannel>
    {
        TChannel CreateChannel();         
    }
}