using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
using Timer = System.Threading.Timer;

namespace BBL___AFK_BOT
{

    internal class Program
    {

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("Bienvenue sur Blablaland - AFK BOT [v.0.1]");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("[>] Recherche du processus <Blablaland Desktop.exe>..");
            Console.WriteLine();

            Process[] processlist = Process.GetProcessesByName("Blablaland Desktop");
            foreach (Process theprocess in processlist)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("Processus: {0} ID: {1}", theprocess.ProcessName, theprocess.Id);
            }
            Console.WriteLine();

            Process[] pname = Process.GetProcessesByName("Blablaland Desktop");
            if (pname.Length > 0)
            {
                Timer t = new Timer(TimerCallback, null, 0, 10000);
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("[>] Processus trouvé lancement du bot..");



            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("[X] Processus non trouvé, merci de lancer Blablaland.fun..");
            }

            Console.ReadLine();

        }

        private static void TimerCallback(Object o)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[>] Anti-AFK: " + DateTime.Now);

            IntPtr hWnd = Native.FindWindow(null, "Jouer | Blablaland.fun");
            ForegroundWindowBypass.Set(hWnd);

            SendKeys.SendWait("{DOWN}");
            
            GC.Collect();
        }
    }
}
