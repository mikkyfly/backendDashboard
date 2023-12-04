using System.Net;
using System.Net.Sockets;
using System;
using WebSocketSharp.Server;
using Driver;
using WebSocketSharp;

namespace databasepg
{
    public class Echo : WebSocketBehavior
    {
      
        protected override void OnMessage(MessageEventArgs e)
        {
            
            Console.WriteLine("Received message from client: " + e.Data);

            Send("Клиент прислал: " + e.Data);
            //while (true)
            //{
            //    Thread.Sleep(2000);
            //    Send("Клиент прислал: " + e.Data);
            //    Console.WriteLine("Клиент прислал: " + e.Data);
            //}

        }
    }
    public class WebSocketOld: DBPG
    {
        public static void ForceWebSocket()
        {
            
            WebSocketServer server = new WebSocketServer("ws://192.168.0.29:8000/");

            server.Start();
            Console.WriteLine("Start server WebSocket");
            
            server.AddWebSocketService<Echo>("/Echo");

            
            Console.ReadKey();
            server.Stop();
        }
    }
}
