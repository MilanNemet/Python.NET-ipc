using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CSharpMain
{
    static class Program
    {
        static string localHost = "127.0.0.1";
        static int port = 50500;
        static void Main(string[] args)
        {
            UdpClient remoteUdpClient = new UdpClient(port);
            var RemoteIpEndPoint = new IPEndPoint(IPAddress.Parse(localHost), port);

            try
            {
                Byte[] receiveBytes = remoteUdpClient.Receive(ref RemoteIpEndPoint);

                var msg = Encoding.UTF8.GetBytes(   "Csáó!\n" +
                                                    "Így lehűlt a levegő?");
                remoteUdpClient.Send(msg, msg.Length, RemoteIpEndPoint);

                string returnData = Encoding.UTF8.GetString(receiveBytes);

                Console.WriteLine("received message: \n" +
                                          returnData.ToString());
                Console.WriteLine(  "\n" +
                                    "This message was sent from " +
                                            RemoteIpEndPoint.Address.ToString() +
                                            ":" +
                                            RemoteIpEndPoint.Port.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
