using Azure.AI.OpenAI;

namespace ChatGPTInterceptors.Core
{
    public class BasicCompletion : CompletionBase
    {
        public BasicCompletion(OpenAIClient client, string deploymentOrModelName, CompletionsOptions completionsOptions) : base(client, deploymentOrModelName, completionsOptions)
        {
        }
    }
}
 