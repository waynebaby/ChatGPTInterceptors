using Azure.AI.OpenAI;

namespace ChatGPTInterceptors.Interfaces.EventArgs
{
    public class CompletionsOptionsCreatedEventArgs 
    {
        public CompletionsOptionsCreatedEventArgs(ChatCompletionsOptions createdInstance)
        {
            CreatedInstance = createdInstance;
        }

        public ChatCompletionsOptions CreatedInstance { get; }
    }
}