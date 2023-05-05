using ChatGPTInterceptors.Interfaces;
using System.Threading.Tasks;

namespace ChatGPTInterceptors.Core
{
    public static class ClientBuilderExtensions
    {
        public static async Task<TClient?> ConnectAsync<TClient>(this IClient<TClient> builder) where TClient : class
        {
            await builder.StartConnectionAsync();
            return builder.Product;
        }

    }
}