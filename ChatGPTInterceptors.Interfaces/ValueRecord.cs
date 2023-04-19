namespace ChatGPTInterceptors.Interfaces
{
    public record ExecuteResultRecord
    {
        public Type? Type { get; }
        public object? Value { get; }
        public Exception? Exception { get; }
    }

}