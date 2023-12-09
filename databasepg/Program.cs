using System.Net.Sockets;
using System.Net;
using databasepg;



namespace Driver
{
      

    public class AzurePostgresRead
    {       
        static void Main(string[] args)
        {

            var notifier = new Notifier();
            //WebSocketOld.ForceWebSocket(notifier);

           
            testDataBase.DataBasePostgreSQL(notifier);
        }
    }
}