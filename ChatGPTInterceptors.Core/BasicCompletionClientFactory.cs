using System;

namespace ChatGPTInterceptors.Core
{
    public class BasicCompletionClientFactory : FactoryBase<BasicCompletionClientBuilder>
    {
        public BasicCompletionClientFactory(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public BasicCompletionClientFactory(Func<BasicCompletionClientBuilder> builderFactory) : base(builderFactory)
        {
        }
    }
}