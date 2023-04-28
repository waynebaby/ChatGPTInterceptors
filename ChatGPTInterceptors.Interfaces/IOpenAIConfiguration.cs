using System;
using System.Collections.Generic;
using System.Text;

namespace ChatGPTInterceptors.Interfaces
{
    public interface IOpenAIConfiguration
    {
        string APIKey { get; set; }
        string DeploymentOrModelName { get; set; }
        string Host { get; set; }
    }
}
