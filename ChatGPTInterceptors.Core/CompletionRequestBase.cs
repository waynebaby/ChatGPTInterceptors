using Azure.AI.OpenAI;
using ChatGPTInterceptors.Interfaces;
using ChatGPTInterceptors.Interfaces.Entities;
using ChatGPTInterceptors.Interfaces.EventArgs;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ChatGPTInterceptors.Core
{
    public abstract class CompletionRequestBase : ICompletionRequest
    {
        protected CompletionRequestBase(OpenAIClient client, string deploymentOrModelName, CompletionsOptions completionsOptions)
        {

            this.client = client;
            this.completionsOptions = completionsOptions;
            DeploymentOrModelName = deploymentOrModelName;
            PromptTemplate = completionsOptions.Prompts.FirstOrDefault() ?? "{0}";
        }


        protected OpenAIClient client;
        private CompletionsOptions completionsOptions;

        public string PromptTemplate { get; set; }
        public string DeploymentOrModelName { get; set; }


        private void PrepareOptions(object[] parameters)
        {
            if (parameters == null || parameters.Length == 0)
            {
                parameters = new object[] { "What is the answer of everything?" };

            }


            var input = string.IsNullOrWhiteSpace(PromptTemplate) ? "" : string.Format(PromptTemplate, parameters);
            OnPreparingOptions(input, completionsOptions);

        }

        protected virtual void OnPreparingOptions(string prompt, CompletionsOptions options)
        {
            options.Prompts.Clear();
            options.Prompts.Add(prompt);
        }

        public async Task<ExecuteResult<Completions>> RequestAsync(params object[] parameters)
        {
            try
            {
                PrepareOptions(parameters);

#if DEBUG
                foreach (var item in completionsOptions.Prompts)
                {
                    Console.WriteLine(item);

                }
#endif

                var result = await client.GetCompletionsAsync(DeploymentOrModelName, completionsOptions);
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

                PrepareOptions(parameters);
                var result = await client.GetCompletionsStreamingAsync(DeploymentOrModelName, completionsOptions);
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
