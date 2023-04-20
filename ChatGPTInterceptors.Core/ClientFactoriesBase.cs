using Azure.AI.OpenAI;
using ChatGPTInterceptors.Interfaces;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPTInterceptors.Core
{
    public abstract class ClientFactoriesBase : IClientFactories
    {
        public abstract Task<ChatCompletionsOptions> GetChatCompletionsOptionsByNameAsync(string templateName);
        public abstract Task<OpenAIClient> GetClientByNameAsync(string templateName);
        public abstract Task<string> GetCompletionPromptFromTemplateme(string templateName);
        public abstract Task<ChatCompletionsOptions> GetDefaultChatCompletionsOptionsAsync();
        public abstract Task<OpenAIClient> GetDefaultClientAsync();
    }
}