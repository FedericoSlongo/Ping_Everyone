using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Ping_everyone
{
    internal class send_ping
    {
        public bool pingi(string ipurl)
        {
            Ping pingSender = new Ping();
            string data = "thisisatesttoseeifihaveinternetl"; //Dati che verrano mandati
            byte[] buffer = Encoding.ASCII.GetBytes(data); //Dati in byte che verrano mandati
            int timeout = 800;
            PingOptions options = new PingOptions(64, true);
            PingReply reply = pingSender.Send("8.8.8.8", timeout, buffer, options);
            try
            {
                reply = pingSender.Send(ipurl, timeout, buffer, options);
            }
            catch (System.Net.NetworkInformation.PingException)
            {
                return false;
            }
            if (reply.Status == IPStatus.Success)
                return true;
            else
                return false;

        }


        //Mette al centro dello schermo lo spazio
        static void centro(int stringa)
        {
            Console.Clear();
            int grandezza = (Console.WindowWidth / 2);
            int altezza = (Console.WindowHeight / 2) / 2;
            for (int i = 0; i < altezza; i++)
                Console.WriteLine("\n");
            for (int i = 0; i < grandezza - (stringa / 2); i++)
                Console.Write(" ");
        }
        //Mette a metà dello schermo lo spazio
        static void middle(int stringa)
        {
            int grandezza = (Console.WindowWidth / 2);
            for (int i = 0; i < grandezza - (stringa / 2); i++)
                Console.Write(" ");
        }
    }
}
