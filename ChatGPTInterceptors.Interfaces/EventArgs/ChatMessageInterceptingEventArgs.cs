using Azure;
using Azure.AI.OpenAI;

namespace ChatGPTInterceptors.Interfaces.EventArgs
{
    public class ChatResponseInterceptingEventArgs :ChatEventArgsBase
    {
        public ChatResponseInterceptingEventArgs( ChatCompletionsOptions options, IInterceptingResult intercepting, 
            Response<ChatCompletions> response, Response<StreamingChatCompletions> streamingResponse, IChatSession session) : base(session)
        {
            Options = options;
            Intercepting = intercepting;
            Response = response;
            StreamingResponse = streamingResponse;
        }

        public ChatCompletionsOptions Options { get; }
        public IInterceptingResult Intercepting { get; }
        public Response<ChatCompletions> Response { get; }
        public Response<StreamingChatCompletions> StreamingResponse { get; }
    }
}