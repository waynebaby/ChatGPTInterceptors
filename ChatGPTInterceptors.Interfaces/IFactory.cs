using System;
using System.Threading.Tasks;

namespace ChatGPTInterceptors.Interfaces
{
    public interface IFactory<out TProduct>
    {
        IFactory<TProduct> AddDefault(Action<TProduct> builderConfiguration);
        IFactory<TProduct> AddVariant(string name, Action<TProduct> builderConfiguration);

        IFactory<TProduct> AddDefault(Action<IServiceProvider, TProduct> builderConfiguration);
        IFactory<TProduct> AddVariant(string name, Action<IServiceProvider, TProduct> builderConfiguration);


        TProduct CreateProduct(string name);
        TProduct CreateDefaltProduct();
    }
}