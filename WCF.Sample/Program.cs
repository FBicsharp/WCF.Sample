using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading.Tasks;

namespace WCF.Sample.Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var uri = "net.tcp://localhost:9000/MessageService";
            IMessage mservice1 = new Message(); 
            var service =  WcfFactory.CreateWcfServerService(uri, mservice1);

            
        }
    }
}
