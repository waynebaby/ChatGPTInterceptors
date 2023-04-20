namespace ChatGPTInterceptors.Interfaces.EventArgs
{
    public abstract class CompletionEventArgsBase : System.EventArgs
    {

        public CompletionEventArgsBase(ICompletion completion)
        {
            Completion = completion;
        }
        public ICompletion Completion { get; }

    }
}
