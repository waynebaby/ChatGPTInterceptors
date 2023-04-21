using ChatGPTInterceptors.Interfaces;
using System.Threading.Tasks;

namespace ChatGPTInterceptors.Core
{
    public static class ClientBuilderExtensions
    {
        public static async Task<TClient?> BuildAsync<TClient>(this IClientBuilder<TClient> builder) where TClient : class
        {
            await builder.StartBuildingAsync();
            return builder.Product;
        }

    }
}