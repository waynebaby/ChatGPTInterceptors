using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatGPTInterceptors.Interfaces
{
    public interface ICompletionChatInterceptor : IChatInterceptor
    {
        ICompletion Completion  { get;}
    }
}