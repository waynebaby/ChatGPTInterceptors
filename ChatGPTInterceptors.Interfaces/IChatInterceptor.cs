using Azure.AI.OpenAI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatGPTInterceptors.Interfaces
{
    public interface IChatInterceptor
    {
        IChatInterceptedAction Action { get;  }

        Task<IInterceptingResult> TryInterceptAsync(IChatSession session);
    }
}