using Azure;
using Azure.AI.OpenAI;

namespace ChatGPTInterceptors.Interfaces.EventArgs
{
    public class ChatStreamingResponseReceivedEventArgs :ChatEventArgsBase
    {
        public ChatStreamingResponseReceivedEventArgs(Response<StreamingChatCompletions> response, ChatCompletionsOptions options, IChatSession session) : base(session)
        {
            Response = response;
            Options = options;
        }

        public Response<StreamingChatCompletions> Response { get; }
        public ChatCompletionsOptions Options { get; }
    }
}