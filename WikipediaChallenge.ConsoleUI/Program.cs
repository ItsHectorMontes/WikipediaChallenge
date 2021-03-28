using System;
using WikipediaChallenge.Infrastructure.Repository;

namespace WikipediaChallenge.ConsoleUI
{
    public class Program
    {
        /// <summary>
        /// execute application.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            DateTime currentPeriod = DateTime.Now.ToUniversalTime();
            int lastHourNumber = 1;
            DataProcess dataProcessor = new DataProcess(lastHourNumber, currentPeriod);
            dataProcessor.RunMainProcess();
            System.Console.WriteLine("Press enter to quit.");
            System.Console.ReadLine();
        }
    }
}
