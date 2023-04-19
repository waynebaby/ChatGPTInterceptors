namespace ChatGPTInterceptors.Interfaces
{
    public interface IInterceptingResult
    {
        bool IsIntercepted { get; }

        Task InterceptionActionsCompletion { get; }

        Task<ExecuteResultRecord> InterceptionActionsResult { get; }
    }

}