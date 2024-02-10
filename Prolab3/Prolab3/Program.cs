using System;
using Newtonsoft.Json;


namespace Prolab3
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            

        }
    }
}