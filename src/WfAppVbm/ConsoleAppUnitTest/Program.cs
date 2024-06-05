using System;
using System.Data;
using System.Data.Sql;
using System.Management;

namespace ConsoleAppUnitTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CheckExistingSqlServerInstance();
        }

        static void CheckExistingSqlServerInstance()
        {
            // Get the instance of SqlDataSourceEnumerator
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;

            // Get a DataTable containing information about available SQL Server instances
            DataTable dataTable = instance.GetDataSources();

            // Iterate through the rows and display information about each SQL Server instance
            foreach (DataRow row in dataTable.Rows)
            {
                string serverName = row["ServerName"].ToString();
                string instanceName = row["InstanceName"].ToString();
                string version = row["Version"].ToString();

                Console.WriteLine($"SQL Server instance found: {serverName}\\{instanceName} (Version: {version})");
            }
            Console.ReadKey();
        }

        static void WmiQueryLocalSqlInstances2()
        {
            string[] namespaces = {
                @"\\.\root\Microsoft\SqlServer\ComputerManagement14", // SQL Server 2017, 2019, 2022
                @"\\.\root\Microsoft\SqlServer\ComputerManagement13", // SQL Server 2016
                @"\\.\root\Microsoft\SqlServer\ComputerManagement12", // SQL Server 2014
                @"\\.\root\Microsoft\SqlServer\ComputerManagement11", // SQL Server 2012
                @"\\.\root\Microsoft\SqlServer\ComputerManagement10", // SQL Server 2008 R2
                @"\\.\root\Microsoft\SqlServer\ComputerManagement"    // SQL Server 2005
            };

            foreach (var ns in namespaces)
            {
                try
                {
                    ManagementScope scope = new ManagementScope(ns);
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
                    return; // Exit once a valid namespace is found and processed
                } catch (ManagementException ex)
                {
                    Console.WriteLine($"Failed to query namespace '{ns}': {ex.Message}");
                } catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine($"Access denied to namespace '{ns}': {ex.Message}");
                }
            }

            Console.WriteLine("No valid SQL Server namespace found.");
            Console.ReadKey();
        }

        static void QueryAvailableNamespaces()
        {
            try
            {
                ManagementScope scope = new ManagementScope(@"\\.\root");
                ObjectQuery query = new ObjectQuery("SELECT * FROM __namespace");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                ManagementObjectCollection queryCollection = searcher.Get();

                foreach (ManagementObject m in queryCollection)
                {
                    Console.WriteLine("Namespace: root\\" + m["Name"]);
                }
            } catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            Console.ReadKey();
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
