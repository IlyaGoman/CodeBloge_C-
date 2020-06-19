using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientTCP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Connect info
            const string ip = "127.0.0.1";
            const int port = 8082;

            #region TCP
            ////create tcp 
            //var tcpEnDPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            //var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            ////get message for send
            //Console.WriteLine("Input message");
            //string message = Console.ReadLine();

            //var data = Encoding.UTF8.GetBytes(message);

            ////send our message to server
            //tcpSocket.Connect(tcpEnDPoint);
            //tcpSocket.Send(data);

            ////
            //var buffer = new byte[256];
            //var size = 0;
            //var answer = new StringBuilder();

            //do
            //{
            //    size = tcpSocket.Receive(buffer);
            //    answer.Append(Encoding.UTF8.GetString(buffer, 0, size));

            //} while (tcpSocket.Available > 0);

            //Console.WriteLine(answer.ToString());
            //tcpSocket.Shutdown(SocketShutdown.Both);
            //tcpSocket.Close();

            //Console.ReadLine();
            #endregion

            var udpEnDPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            udpSocket.Bind(udpEnDPoint);


            while(true)
            {
                Console.WriteLine("Input message:");
                var message = Console.ReadLine();

                EndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(ip), 8081);
                udpSocket.SendTo(Encoding.UTF8.GetBytes(message), serverEndPoint);

                var buffer = new byte[256];
                var size = 0;
                var answer = new StringBuilder();

                EndPoint senderEndPoint = new IPEndPoint(IPAddress.Any, 0);

                do
                {
                    size = udpSocket.ReceiveFrom(buffer, ref senderEndPoint);

                    answer.Append(Encoding.UTF8.GetString(buffer));
                } while (udpSocket.Available > 0);

                Console.WriteLine(answer);
                Console.ReadLine();
            }
        }
    }
}
