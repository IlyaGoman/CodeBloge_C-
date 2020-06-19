using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ServerTCP
{
    class Program
    {
        static void Main(string[] args)
        {

            const string ip = "127.0.0.1";
            const int port = 8081;

            #region TCP
            //var tcpEnDPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            //var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //tcpSocket.Bind(tcpEnDPoint);
            //tcpSocket.Listen(5);

            //while(true)
            //{
            //    var listener = tcpSocket.Accept();
            //    var buffer = new byte[256];
            //    var size = 0;
            //    var strBuider = new StringBuilder();

            //    do
            //    {
            //        size = listener.Receive(buffer);
            //        strBuider.Append(Encoding.UTF8.GetString(buffer, 0, size));

            //    } while (listener.Available>0);

            //    Console.WriteLine(strBuider);

            //    listener.Send(Encoding.UTF8.GetBytes("Successfully"));

            //    listener.Shutdown(SocketShutdown.Both);
            //    listener.Close();
            //}
            #endregion

            #region UDP
            var udpEnDPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            udpSocket.Bind(udpEnDPoint);

            while (true)
            {
                var buffer = new byte[256];
                var size = 0;
                var strBuider = new StringBuilder();

                EndPoint senderEndPoint = new IPEndPoint(IPAddress.Any, 0);

                do
                {
                    size = udpSocket.ReceiveFrom(buffer, ref senderEndPoint);

                    strBuider.Append(Encoding.UTF8.GetString(buffer));
                } while (udpSocket.Available > 0);

                udpSocket.SendTo(Encoding.UTF8.GetBytes("Message receive"), senderEndPoint);

                Console.WriteLine(strBuider);


            }
            
            // TODO: Сделать закрытие сокета
            #endregion
        }
    }
}
