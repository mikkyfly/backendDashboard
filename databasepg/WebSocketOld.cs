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

        public Echo(Notifier notifier)
        {
            notifier.OnMessageReceived = (msgs) =>
            {
                msgs.ForEach(Send);
            };
        }

        protected override void OnMessage(MessageEventArgs e)
        {
           notifier: 
            Console.WriteLine("Received message from client: " + e.Data);

            //Send("Клиент прислал: " + e.Data);
            //Send(DBPG.Pkge);
            while (true)
            {

                Thread.Sleep(1000);
                //Send("Клиент прислал: " + e.Data);
                
                
                
                
                //Console.WriteLine("Клиент прислал: " + e.Data);
            }

        }
        
    }
    
    public class WebSocketOld
    {
        public static void ForceWebSocket(Notifier notifier)
        {
            
            WebSocketServer server = new WebSocketServer("ws://localhost:8000/");

            server.Start();
            Console.WriteLine("Start server WebSocket");
            
            server.AddWebSocketService<Echo>("/Echo", () => new Echo(notifier));
            
            Console.ReadKey();
            server.Stop();
        }
    }
}
