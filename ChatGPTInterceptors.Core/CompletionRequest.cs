using Azure.AI.OpenAI;

namespace ChatGPTInterceptors.Core
{
    public class CompletionRequest : CompletionRequestBase
    {
        public CompletionRequest(OpenAIClient client, string deploymentOrModelName, CompletionsOptions completionsOptions) : base(client, deploymentOrModelName, completionsOptions)
        {
        }
    }
}
 