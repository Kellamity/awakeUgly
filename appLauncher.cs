using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var application = new Process();
            string fileName;    //executable filename for application
            string path;         //path to application
            int timer;          //default power settings timer
            if (args.Length > 3)    //not enough arguemnts passed
            {
                fileName = "Spotify.exe";
                path = "c:\\Program Files\\Spotify\\";
                timer = 30;
            }
            //if no custom filename passed, default to Spotity.exe
            if (args != null)
            {
                fileName = args[0];                                
            }
            else
            {
                fileName = "Spotify.exe";
            }
            application.StartInfo.FileName = fileName;
            application.StartInfo.Arguments = "-v -s -a";
            Process.Start("powercfg", "-CHANGE -standby-timeout-ac 0");        
            Process.Start("powercfg", "-CHANGE -hibernate-timeout-ac 0");
            Process.Start("powercfg", "-CHANGE -monitor-timeout-ac 0"); 
            try
            {
                application.Start();   
            }
            catch
            {
                Console.Writeline("Process not found");
            }          
            application.WaitForExit();
            var exitCode = application.ExitCode;
            application.Close();
            Process.Start("powercfg", "-CHANGE -standby-timeout-ac 30");        
            Process.Start("powercfg", "-CHANGE -hibernate-timeout-ac 30");
            Process.Start("powercfg", "-CHANGE -monitor-timeout-ac 30"); 
        }
    }
}