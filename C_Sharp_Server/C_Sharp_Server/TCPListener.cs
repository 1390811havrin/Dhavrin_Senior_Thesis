using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Configuration;

namespace C_Sharp_Server
{

    class TCPListener
    {

        public void IsListening()
        {
            _TcpListening();
           
        }

        protected string _TcpListening()
        {
            string received = string.Empty;
            TcpListener server = null;
            try
            {
                // Set the TcpListener on port 13000.
                Int32 port = 13000;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                server.Start();

                // Buffer for reading data
                Byte[] bytes = new Byte[256];
                String sdata = null;
                String rdata = null;
                bool sent = false;
                // Enter the listening loop.
                while (!sent)
                {
                    Console.Write("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    // You could also user server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    sdata = null;
                    rdata = null;
                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int i;

                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        rdata = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Received: {0}", rdata);

                        // Process the data sent by the client.
                        sdata = rdata.ToUpper();
                        received = rdata;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(sdata);

                        // Send back a response.
                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine("Sent: {0}", sdata);
                        sent = true;
                    }

                    // Shutdown and end connection
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }

           
            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
            return received;
        }
    }
}