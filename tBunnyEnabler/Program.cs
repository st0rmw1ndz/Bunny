using Microsoft.Win32;
using System;

namespace tBunnyEnabler
{
    internal class Program
    {
        private const string registryEntry = @"Software\Terraria";

        static void Main(string[] args)
        {
            using (RegistryKey terrariaKey = Registry.CurrentUser.OpenSubKey(registryEntry, writable: true))
            {
                if (terrariaKey == null)
                {
                    Console.WriteLine($"An error occurred reading the bunny value in '{registryEntry}'. Exiting.");
                    Console.ReadKey();
                    return;
                }
                if ((string)terrariaKey.GetValue("Bunny") == "1")
                {
                    Console.WriteLine("The bunny value is already set. Exiting.");
                    Console.ReadKey();
                    return;
                }
                terrariaKey.SetValue("Bunny", "1", RegistryValueKind.String);
            }
            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}