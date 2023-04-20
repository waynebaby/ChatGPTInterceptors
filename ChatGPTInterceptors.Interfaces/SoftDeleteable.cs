namespace ChatGPTInterceptors.Interfaces
{
    public class SoftDeleteable<T> where T : class
    {
        public bool IsDeleted { get; set; }
        public T? Value { get; set; }
    }
}