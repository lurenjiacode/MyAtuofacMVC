using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.RabbitMQModule
{
    public class RPCRabbit : IRabbitMQMethod
    {
        public void ReceiveMsg()
        {
            throw new NotImplementedException();
        }

        public void ReceiveMsg(string queuename)
        {
            throw new NotImplementedException();
        }

        public void SendMsg()
        {
            throw new NotImplementedException();
        }

        public void SendMsg(string queuename, string msg)
        {
            throw new NotImplementedException();
        }
    }
}
