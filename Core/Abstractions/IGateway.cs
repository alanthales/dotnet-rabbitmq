namespace Core.Abstractions
{
    public interface IGateway<T> where T : class
    {
        T Instance { get; }
    }
}