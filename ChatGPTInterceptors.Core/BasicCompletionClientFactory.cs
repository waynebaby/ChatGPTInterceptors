using ChatGPTInterceptors.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ChatGPTInterceptors.Core
{
    public class BasicCompletionClientFactory : FactoryBase<BasicCompletionClientBuilder>
    {
   

        public BasicCompletionClientFactory(IServiceProvider serviceProvider) : base(serviceProvider, sp=>sp.GetRequiredService<BasicCompletionClientBuilder>())
        {
        }


    }

  
}