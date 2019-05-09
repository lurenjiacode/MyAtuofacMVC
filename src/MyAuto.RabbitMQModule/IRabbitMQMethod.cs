using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.RabbitMQModule
{
    public interface IRabbitMQMethod
    {
        void SendMsg();
        void SendMsg(string queuename, string msg);
        void ReceiveMsg();
        void ReceiveMsg(string queuename);
    }
}
