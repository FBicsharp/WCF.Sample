using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF.Sample.Client
{

    [ServiceContract]
    internal interface IMessage
    {

        [OperationContract]
        string ReturnSecretMesage(string content);



    }


    internal class Program
    {
        static void Main(string[] args)
        {


            var uri = "net.tcp://localhost:9000/MessageService";
            var binding = new NetTcpBinding(SecurityMode.None);

            var channel = new ChannelFactory<IMessage>(binding, new EndpointAddress(uri));
            var proxy = channel.CreateChannel();
            while (true)
            {

            var message = Console.ReadLine();
            //encode message to base64 
            var encodedMessage = Convert.ToBase64String(Encoding.UTF8.GetBytes(message));
            Console.WriteLine( $"send message to server  {encodedMessage}" );
            var response = proxy.ReturnSecretMesage(encodedMessage);
            Console.WriteLine( $"server responde {response}" );
            }
            

        }
    }
}
