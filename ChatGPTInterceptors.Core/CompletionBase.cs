using Azure.AI.OpenAI;
using ChatGPTInterceptors.Interfaces;
using ChatGPTInterceptors.Interfaces.Entities;
using ChatGPTInterceptors.Interfaces.EventArgs;
using System;
using System.Threading.Tasks;

namespace ChatGPTInterceptors.Core
{
    public abstract class CompletionBase : ICompletion
    {
        protected CompletionBase(OpenAIClient client, string deploymentOrModelName, string promptTemplate, Func<Task<CompletionsOptions>> completionsOptionsFactory)
        {
            PromptTemplate = promptTemplate;
            this.client = client;
            this.completionsOptionsFactory = completionsOptionsFactory;
            DeploymentOrModelName = deploymentOrModelName;
        }


        protected OpenAIClient client;
        private readonly Func<Task<CompletionsOptions>> completionsOptionsFactory;

        public string PromptTemplate { get; set; }
        public string DeploymentOrModelName { get; set; }

        public event EventHandler<CompletionsOptionsCreatedEventArgs>? CompletionsOptionsCreated;
        protected virtual void OnPreparingOptions(string prompt, CompletionsOptions options)
        {
            options.Prompts.Clear();
            options.Prompts.Add(prompt);
        }

        public async Task<ExecuteResult< Completions>> ExecuteAsync(params object[] parameters)
        {
            try
            {

                var input = string.Format(PromptTemplate, parameters);

                var options = await completionsOptionsFactory();
                OnPreparingOptions(input, options);

                var result = await client.GetCompletionsAsync(DeploymentOrModelName, options);
                var value = result.Value;

                return new ExecuteResult<Completions>
                {
    
                    Exception = null,
                    Value = value

                };

            }
            catch (Exception ex)
            {

                return new ExecuteResult<Completions>
                {

                    Exception = ex,
                    Value = null

                };
            }
        }


        public async Task<ExecuteResult<StreamingCompletions>> ExecuteStreamingAsync(params object[] parameters)
        {
            try
            {

                var input = string.Format(PromptTemplate, parameters);

                var options = await completionsOptionsFactory();
                OnPreparingOptions(input, options);

                var result = await client.GetCompletionsStreamingAsync(DeploymentOrModelName, options);
                var value = result.Value;

                return new ExecuteResult<StreamingCompletions>
                {
                   

                    Exception = null,
                    Value = value

                };

            }
            catch (Exception ex)
            {

                return new ExecuteResult<StreamingCompletions>
                {
 
                    Exception = ex,
                    Value = null

                };
            }
        }
    }
}