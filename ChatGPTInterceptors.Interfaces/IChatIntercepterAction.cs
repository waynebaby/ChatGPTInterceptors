using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatGPTInterceptors.Interfaces
{
    public interface IChatInterceptedAction
    {
        Task<ExecuteResultRecord> ExecuteAsync(IChatSession session);
    }
}