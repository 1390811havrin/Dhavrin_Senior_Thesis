using System;

namespace CSharpTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What's Up!");
            var con = new ConnectIt();
            con.connect("Bitches");
        }
    }
}
