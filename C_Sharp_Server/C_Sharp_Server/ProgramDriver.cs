using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Configuration;


namespace C_Sharp_Server
{
    class ProgramDriver
    {
        static void Main(string[] args)
        {
            var con = new TCPListener();

            con.IsListening();

        }
    
    }
}
