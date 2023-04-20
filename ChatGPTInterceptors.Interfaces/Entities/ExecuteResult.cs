using System;
using System.Diagnostics.CodeAnalysis;

namespace ChatGPTInterceptors.Interfaces.Entities
{
    public  class ExecuteResult<T>
    {
        public Type? Type =>typeof(T);
        [AllowNull]
        public  T Value { get; set; }
        public Exception? Exception { get; set; }
    }
}