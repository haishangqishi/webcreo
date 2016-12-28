using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    [Serializable]
    public class Message
    {
        string msg;

        public Message(string msg)
        {
            this.msg = msg;
        }

        public string Msg
        {
            get { return msg; }
            set { msg = value; }
        }

    }
}
