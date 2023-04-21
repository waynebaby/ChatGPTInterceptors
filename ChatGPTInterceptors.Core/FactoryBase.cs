using ChatGPTInterceptors.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;

namespace ChatGPTInterceptors.Core
{
    public abstract class FactoryBase<Product> : IFactory<Product>

        where Product : class
    {
        protected readonly Func<Product> productInstanceCreator;
        protected ConcurrentDictionary<string, Func<Product>> factories = new ConcurrentDictionary<string, Func<Product>>();
        public FactoryBase(IServiceProvider serviceProvider)
        {
            this.productInstanceCreator = () => serviceProvider.GetRequiredService<Product>();
        }

        public FactoryBase(Func<Product> productInstanceCreator)
        {
            this.productInstanceCreator = productInstanceCreator;
        }



        public virtual IFactory<Product> AddDefault(Action<Product> productDecorator)
        {
            return AddVariant("", productDecorator);
        }



        public virtual IFactory<Product> AddVariant(string name, Action<Product> productDecorator)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                name = "";
            }

            Func<Product?> factoryInstance = () =>
            {
                var product = productInstanceCreator();
                productDecorator(product);
                return product;
            };


            factories.AddOrUpdate(name, factoryInstance, (_, __) => factoryInstance);

            return this;

        }

        public Product CreateDefaltProduct()
        {
            return CreateProduct("");
        }

        public Product CreateProduct(string name)
        {
            if (factories.TryGetValue(name, out var builderFactory))
            {
                return builderFactory();

            }
            else
            {
                throw new IndexOutOfRangeException($"The builder with name '{name}' was not registered in the builder factory");
            }
        }
    }
}