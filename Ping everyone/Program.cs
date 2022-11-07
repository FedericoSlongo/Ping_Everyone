using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ping_everyone
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter("ip-v4.txt");
            send_ping pinger = new send_ping();
            int[] ipv4 = new int[4] {1,1,1,0};
            bool[] ipv4_bool = new bool[4] {false,false,false,true};
            for (double i = 0; i < 4294967296; i++)
            {
                if (ipv4[0] == 255)
                    break;
                
                for (int coc = 0; coc < 255; coc++)
                {
                    for (int z = 0; z < 255; z++)
                    {
                        for (int a = 0; a < 255; a++)
                        {
                             ipv4[3]++;
                            //Prints out the ip it's pinging
                            Console.WriteLine($"{ipv4[0]}.{ipv4[1]}.{ipv4[2]}.{ipv4[3]}");
                            writer_pinger(sw, ipv4, pinger);
                        }
                        ipv4[3] = 0;
                        ipv4[2]++;
                    }
                    ipv4[2] = 0;
                    ipv4[1]++;
                }
                ipv4[1] = 0;
                ipv4[0]++;

                //Only ping external ips
                if (ipv4[0] == 192 || ipv4[0] == 127)
                    continue;
                //Pings and write to file the result
                writer_pinger(sw, ipv4, pinger);
            }
            Console.ReadKey();
            sw.Dispose();
        }

        public static void writer_pinger(StreamWriter sw, int[] ipv4 , send_ping pinger)
        {
            Console.WriteLine($"{ipv4[0]}.{ipv4[1]}.{ipv4[2]}.{ipv4[3]}");
            //Pings and write to file the result
            if (pinger.pingi($"{ipv4[0]}.{ipv4[1]}.{ipv4[2]}.{ipv4[3]}"))
                sw.WriteLine($"Does respond {ipv4[0]}.{ipv4[1]}.{ipv4[2]}.{ipv4[3]}");
            else
                sw.WriteLine($"Did not respond {ipv4[0]}.{ipv4[1]}.{ipv4[2]}.{ipv4[3]}");
        }
    }
}
