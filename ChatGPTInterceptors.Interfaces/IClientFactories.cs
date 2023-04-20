using Azure.AI.OpenAI;
using System.Threading.Tasks;

namespace ChatGPTInterceptors.Interfaces
{
    public interface IClientFactories
    {
        Task<ChatCompletionsOptions> GetDefaultChatCompletionsOptionsAsync();
        Task<ChatCompletionsOptions> GetChatCompletionsOptionsByNameAsync(string templateName);
        Task<OpenAIClient> GetDefaultClientAsync();
        Task<OpenAIClient> GetClientByNameAsync(string templateName);
        Task<string> GetCompletionPromptFromTemplateme(string templateName);

    }

}