using ChatGPTInterceptors.Interfaces.Entities;
using System.Threading.Tasks;

namespace ChatGPTInterceptors.Interfaces
{
    public interface IInterceptingResult
    {
        bool IsIntercepted { get; }

        Task InterceptionActionsCompletion { get; }

        Task InterceptionActionsResult { get; }
    }

}