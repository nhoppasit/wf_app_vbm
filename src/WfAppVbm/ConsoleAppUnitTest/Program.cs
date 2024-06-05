using System;
using System.Management;

namespace ConsoleAppUnitTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WmiQueryLocalSqlInstances();
        }

        static void WmiQueryLocalSqlInstances()
        {
            try
            {
                ManagementScope scope = new ManagementScope(@"\\.\root\Microsoft\SqlServer\ComputerManagement13");
                ObjectQuery query = new ObjectQuery("SELECT * FROM SqlServiceAdvancedProperty WHERE SQLServiceType = 1");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                ManagementObjectCollection queryCollection = searcher.Get();

                foreach (ManagementObject m in queryCollection)
                {
                    Console.WriteLine("Instance Name: {0}", m["ServiceName"]);
                    Console.WriteLine("Display Name: {0}", m["DisplayName"]);
                    Console.WriteLine();
                }
                Console.ReadKey();
            } catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.ReadKey();
            }
        }
    }
}
