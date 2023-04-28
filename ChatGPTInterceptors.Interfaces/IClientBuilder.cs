using Azure.AI.OpenAI;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ChatGPTInterceptors.Interfaces
{
    public interface IClientBuilder<out TClient> where TClient : class
    {
        Func<Task<OpenAIClient>>? OpenClientFactory { get; }
        string? DeploymentOrModelName { get; }
        Task StartBuildingAsync();

        TClient? Product { get; }
    }


    public interface ICompletionClientBuilder : IClientBuilder<ICompletion>
    {
        Func<IServiceProvider, CompletionsOptions, Task>? CompletionsOptionsSettings { get; set; }
        string? PromptOrTemplate { get; set; }
    }

    public interface IChatSessionClientBuilder : IClientBuilder<IChatSession>
    {

        Func<IServiceProvider, ChatCompletionsOptions, Task>? ChatCompletionsOptionsSettings { get; set; }
        string SystemMessageOrTemplate { get; set; }
        IList<ChatMessage> MessagesHistory { get; set; }
    }

}