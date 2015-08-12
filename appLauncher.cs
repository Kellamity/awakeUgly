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
            else
            {
                fileName = args[0];
                path = args[1];
                timer = args[2];                
            }
            application.StartInfo.FileName = path + fileName;
            application.StartInfo.Arguments = "-v -s -a";
            setProcess(0);  //disable Windows power settings
            try
            {
                application.Start();   
            }
            catch
            {
                Console.Writeline("Process not found");
                setProcess(timer);  //reset Windows power settings if application not launched
            }          
            application.WaitForExit();
            var exitCode = application.ExitCode;
            application.Close();
            setProcess(timer); 
        }
    }
    
    void setProcess(int timer)
    {
            Process.Start("powercfg", "-CHANGE -standby-timeout-ac " + timer);        
            Process.Start("powercfg", "-CHANGE -hibernate-timeout-ac " + timer));
            Process.Start("powercfg", "-CHANGE -monitor-timeout-ac " + timer)); 
    }
}