namespace ChatGPTInterceptors.Interfaces.EventArgs
{
    public abstract class CompletionEventArgsBase : System.EventArgs
    {

        public CompletionEventArgsBase(ICompletionRequest completion)
        {
            Completion = completion;
        }
        public ICompletionRequest Completion { get; }

    }
}
