using System;
using System.Threading.Tasks;

namespace Core.Abstractions
{
    public interface ICommandHandler<TResponse>
    {
         ValueTask<(Exception Error, TResponse Data)> Execute();
    }
    
    public interface ICommandHandler<TRequest,TResponse>
    {
         ValueTask<(Exception Error, TResponse Data)> Execute(TRequest command);
    }
}