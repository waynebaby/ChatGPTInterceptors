using System;
using System.Collections.Generic;
using System.Text;

namespace ChatGPTInterceptors.Interfaces.EventArgs
{
    public abstract class ChatEventArgsBase : System.EventArgs
    {

        public ChatEventArgsBase(IChatSession session)
        {
            Session = session;
        }
        public IChatSession Session { get; }

    }
}
