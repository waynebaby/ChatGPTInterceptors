using Azure.AI.OpenAI;
using ChatGPTInterceptors.Interfaces;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ChatGPTInterceptors.Core
{
    public class BasicCompletionClientBuilder : ICompletionClientBuilder 
    {

        public BasicCompletionClientBuilder()
        {


        }


        public string? DeploymentOrModelName { get; set; }
        public ICompletion? Product { get; private set; }
        public Func<Task<CompletionsOptions>>? CompletionsOptionsFactory { get; set; }
        public string? PromptOrTemplate { get; set; }
        public Func<Task<OpenAIClient?>>? OpenClientFactory { get; set; }

        public async Task StartBuildingAsync()
        {
            if (DeploymentOrModelName == null)
            {
                throw new NullReferenceException(nameof(DeploymentOrModelName));
            }

            if (OpenClientFactory == null)
            {
                throw new NullReferenceException(nameof(OpenClientFactory));
            }
            if (CompletionsOptionsFactory == null)
            {
                throw new NullReferenceException(nameof(CompletionsOptionsFactory));
            }

            var client = await OpenClientFactory();
            if (client == null)
            {
                throw new NullReferenceException("result of " + nameof(OpenClientFactory));
            }

            var completionsOptions = await CompletionsOptionsFactory();


            if (CompletionsOptionsFactory == null)
            {
                throw new NullReferenceException("result of " + nameof(CompletionsOptionsFactory));
            }


            var completion = new BasicCompletion(client, DeploymentOrModelName, completionsOptions);
            Product = completion;
        }
    }
}