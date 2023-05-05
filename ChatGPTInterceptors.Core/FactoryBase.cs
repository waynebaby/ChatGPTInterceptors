using ChatGPTInterceptors.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;

namespace ChatGPTInterceptors.Core
{
    public abstract class FactoryBase<TProduct> : IFactory<TProduct>

        where TProduct : class
    {
        protected readonly Func<IServiceProvider, TProduct> productInstanceCreator;
        protected ConcurrentDictionary<string, Func<IServiceProvider, TProduct?>> factories = new ConcurrentDictionary<string, Func<IServiceProvider, TProduct?>>();
        public IServiceProvider ServiceProvider { get; }

        public FactoryBase(IServiceProvider serviceProvider, Func<IServiceProvider, TProduct> productInstanceCreator)
        {
            ServiceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            this.productInstanceCreator = productInstanceCreator ?? throw new ArgumentNullException(nameof(productInstanceCreator));
        }



        public virtual IFactory<TProduct> AddDefault(Action<IServiceProvider, TProduct> productDecorator)
        {
            return AddVariant("", productDecorator);
        }



        public virtual IFactory<TProduct> AddVariant(string name, Action<IServiceProvider, TProduct> productDecorator)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                name = "";
            }

            Func<IServiceProvider, TProduct?> factoryInstance = sp =>
            {
                var product = productInstanceCreator(sp);
                productDecorator(sp, product);
                return product;
            };


            _ = factories.AddOrUpdate(name, factoryInstance, (_, __) => factoryInstance);

            return this;

        }

        public TProduct CreateDefaltProduct()
        {
            return CreateProduct("");
        }

        public TProduct CreateProduct(string name)
        {
            if (factories.TryGetValue(name, out var builderFactory))
            {
                var rval = builderFactory(ServiceProvider);
                if (rval is null)
                {
                    throw new IndexOutOfRangeException($"The builder with name '{name}' created a null referece of {typeof(TProduct).Name}");
                }
                else
                {
                    return rval;
                }
            }
            else
            {
                throw new IndexOutOfRangeException($"The builder with name '{name}' was not registered in the builder factory");
            }
        }

        public IFactory<TProduct> AddDefault(Action<TProduct> builderConfiguration)
        {
            return AddDefault((sp, x) => builderConfiguration(x));
        }

        public IFactory<TProduct> AddVariant(string name, Action<TProduct> builderConfiguration)
        {
            return AddVariant(name, (sp, x) => builderConfiguration(x));
        }
    }
}