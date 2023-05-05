using Azure;
using Azure.AI.OpenAI;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChatGPTInterceptors.Interfaces.Entities;
using ChatGPTInterceptors.Interfaces.EventArgs;
using System;

namespace ChatGPTInterceptors.Interfaces
{
    public interface ICompletionRequest
    {
        public string DeploymentOrModelName { get; set; }

   

        string PromptTemplate { get; set; }

        Task<ExecuteResult<Completions>> RequestAsync(params object[] parameters);

        Task<ExecuteResult<StreamingCompletions>> ExecuteStreamingAsync(params object[] parameters);
    }
}