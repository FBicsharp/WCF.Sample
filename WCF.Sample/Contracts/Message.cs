using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading.Tasks;

namespace WCF.Sample.Server
{

    [ServiceContract]
    internal interface IMessage
    {

        [OperationContract]
        string ReturnSecretMesage(string content);


        
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    internal class Message :IMessage
    {
        public string ReturnSecretMesage(string content)
        {
            //decote from base 64 to string
            string decoded = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(content));
            return decoded;
        }
    }
}
