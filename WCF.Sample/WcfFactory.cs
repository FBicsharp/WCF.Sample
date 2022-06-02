using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading.Tasks;

namespace WCF.Sample.Server
{
    internal class WcfFactory
    {
        internal static ServiceHost CreateWcfServerService( string uri, IMessage mservice1)
        {
            
            ServiceHost host = new ServiceHost(mservice1);
            host.AddServiceEndpoint(typeof(IMessage), new NetTcpBinding(SecurityMode.None), uri);
            
            while (true)
            {
                if (host.State != CommunicationState.Opened)
                {
                    host.Open();
                    System.Threading.Thread.Sleep(500);                    
                    Console.WriteLine("Service is starting...");
                }
                
            }
            

        }
    }
}
