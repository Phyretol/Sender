using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Sender {
    class Program {
        static void Main(string[] args) {
            IPEndPoint endPoint = new IPEndPoint(/*IPAddress.Parse("188.152.121.238")*/ IPAddress.Parse("93.71.49.23"), 11223);

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.Bind(new IPEndPoint(IPAddress.Any, 0));

            int i = 0;
            while (true) {
                MemoryStream stream = new MemoryStream();
                BinaryWriter writer = new BinaryWriter(stream);

                writer.Write(i++);
                writer.Close();

                socket.SendTo(stream.ToArray(), endPoint);
            }
        }
    }
}
