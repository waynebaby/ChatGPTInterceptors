using Azure;
using Azure.AI.OpenAI;

namespace ChatGPTInterceptors.Interfaces.EventArgs
{
    public class ChatMessageReceivedEventArgs : ChatEventArgsBase
    {
        public ChatMessageReceivedEventArgs(ChatCompletionsOptions options, ChatMessage chatMessage, IChatSession session) : base(session)
        {
            ChatMessage = chatMessage;
            Options = options;
        }
        public ChatCompletionsOptions Options { get; }
        public ChatMessage ChatMessage { get; }

    }
}