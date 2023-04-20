using ChatGPTInterceptors.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPTInterceptors.Interfaces
{
    public interface IChatInterceptedAction
    {
        Task ExecuteAsync(IChatSession session);
    }
}