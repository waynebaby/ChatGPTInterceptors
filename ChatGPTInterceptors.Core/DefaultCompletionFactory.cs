using ChatGPTInterceptors.Interfaces;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ChatGPTInterceptors.Core
{

    public class DefaultCompletionFactory : FactoryBase<BasicCompletionClientBuilder>
    {
        public DefaultCompletionFactory(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public DefaultCompletionFactory(Func<BasicCompletionClientBuilder> builderFactory) : base(builderFactory)
        {
        }
    }
}