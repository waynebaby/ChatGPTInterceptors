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
        Func<Task<OpenAIClient>>? OpenClientFactory { get; set; }
        string? DeploymentOrModelName { get; set; }
        Task StartBuildingAsync();

        TClient? Product { get; }
    }


    public interface ICompletionClientBuilder : IClientBuilder<ICompletion> 
    {
        Func<Task<CompletionsOptions?>>? CompletionsOptionsFactory { get; set; }
        string? PromptOrTemplate { get; set; }
    }

    public interface IChatSessionClientBuilder : IClientBuilder<IChatSession>  
    {

        Func<Task<ChatCompletionsOptions?>>? ChatCompletionsOptionsFactory { get; set; }
        string SystemMessageOrTemplate { get; set; }
        IList<ChatMessage> MessagesHistory { get; set; }
    }

}