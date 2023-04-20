using Azure;
using Azure.AI.OpenAI;
using System;

namespace ChatGPTInterceptors.Interfaces.EventArgs
{
    public class ChatResponseReceivedEventArgs :ChatEventArgsBase
    {
        public ChatResponseReceivedEventArgs(Response<ChatCompletions> response, ChatCompletionsOptions options, IChatSession session) : base(session)
        {
            Response = response;
            Options = options;
        }

        public Response<ChatCompletions> Response { get; }
        public ChatCompletionsOptions Options { get; }
    }
}