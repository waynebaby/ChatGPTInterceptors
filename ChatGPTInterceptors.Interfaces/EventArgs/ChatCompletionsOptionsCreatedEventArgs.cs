using Azure.AI.OpenAI;

namespace ChatGPTInterceptors.Interfaces.EventArgs
{
    public class ChatCompletionsOptionsCreatedEventArgs : ChatEventArgsBase
    {
        public ChatCompletionsOptionsCreatedEventArgs( ChatCompletionsOptions createdInstance , IChatSession session) :base  (session)
        {
            CreatedInstance = createdInstance;
        }

        public ChatCompletionsOptions CreatedInstance { get; }
    }
}