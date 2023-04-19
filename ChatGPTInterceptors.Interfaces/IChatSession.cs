namespace ChatGPTInterceptors.Interfaces
{
    public interface IChatSession
    {
        System.Collections.Generic.IList<IChatInterceptor> UserInterceptors { get; set; }
        System.Collections.Generic.IList<IChatInterceptor> AgentInterceptors { get; set; }

    }



}