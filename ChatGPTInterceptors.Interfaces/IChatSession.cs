using Azure;
using Azure.AI.OpenAI;
using ChatGPTInterceptors.Interfaces.EventArgs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Threading;

namespace ChatGPTInterceptors.Interfaces
{
    public interface IChatSession : IDisposable
    {

        System.Collections.Generic.IList<IChatInterceptor> UserInterceptors { get; set; }
        System.Collections.Generic.IList<IChatInterceptor> AgentInterceptors { get; set; }
        bool IsStreaming { get; }
        string SystemMessage { get; set; }
        Queue<SoftDeleteable<ChatMessage>>? UserAgentMessageHistory { get; }

        void Abort();

        void Start(bool useStreaming);
        void Reset(bool useStreaming);

        event  EventHandler<ChatCompletionsOptionsCreatedEventArgs>? ChatCompletionsOptionsCreated;

        event EventHandler<ChatResponseReceivedEventArgs>? ResponseReceived;

        event EventHandler<Response<ChatMessage>>? ChatMessageReceived;

        event EventHandler<ChatResponseInterceptingEventArgs>? ChatResponseIntercepting;


        IObservable<TEventArgs> AsObservable<TEventArgs>() where TEventArgs:ChatEventArgsBase;
    }
}