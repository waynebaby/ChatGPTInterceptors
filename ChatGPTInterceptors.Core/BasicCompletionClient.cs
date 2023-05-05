using Azure;
using Azure.AI.OpenAI;
using ChatGPTInterceptors.Interfaces;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ChatGPTInterceptors.Core
{
    public class BasicCompletionClient : ICompletionClient
    {
        public BasicCompletionClient()
        {
        }

        public BasicCompletionClient(IServiceProvider serviceProvider, IOpenAIConfiguration openAIConfiguration)
        {
            DeploymentOrModelName = openAIConfiguration.DeploymentOrModelName;

            OpenClientFactory = new Func<Task<OpenAIClient?>>(async () =>
            {
                if (openAIConfiguration.APIKey == null)
                {
                    throw new NullReferenceException(nameof(openAIConfiguration.APIKey));
                }
                if (openAIConfiguration.Host == null)
                {
                    throw new NullReferenceException(nameof(openAIConfiguration.Host));
                }
                var uri = new Uri($"https://{openAIConfiguration.Host}/");
                var client = new OpenAIClient(uri, new AzureKeyCredential(openAIConfiguration.APIKey));
                return client;
            });
            ServiceProvider = serviceProvider;
        }


        public string? DeploymentOrModelName { get; protected set; }
        public ICompletionRequest? Product { get; private set; }
        public Func<IServiceProvider, CompletionsOptions, Task>? CompletionsOptionsSettings { get; set; }
        public string? PromptOrTemplate { get; set; }
        public Func<Task<OpenAIClient?>>? OpenClientFactory { get; protected set; }
        public IServiceProvider ServiceProvider { get; }

        public async Task StartConnectionAsync()
        {
            if (DeploymentOrModelName == null)
            {
                throw new NullReferenceException(nameof(DeploymentOrModelName));
            }

            if (OpenClientFactory == null)
            {
                throw new NullReferenceException(nameof(OpenClientFactory));
            }
      

            var client = await OpenClientFactory();


            if (client == null)
            {
                throw new NullReferenceException("result of " + nameof(OpenClientFactory));
            }

            var completionsOptions = new CompletionsOptions();

            if (CompletionsOptionsSettings!=null)
            {
                await CompletionsOptionsSettings(ServiceProvider, completionsOptions);
            }

            var completionRequest = new CompletionRequest(client, DeploymentOrModelName, completionsOptions);
            if (!string.IsNullOrWhiteSpace(PromptOrTemplate))
            {
                completionRequest.PromptTemplate = PromptOrTemplate;
            }
            
            Product = completionRequest;
        }
    }
}