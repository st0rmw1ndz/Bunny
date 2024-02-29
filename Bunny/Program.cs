using Microsoft.Win32;
using System;

namespace Bunny
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Terraria"))
                {
                    if (key != null)
                    {
                        key.SetValue("Bunny", "1");
                        Console.WriteLine("Successfully given bunny access.");
                    }
                    else
                    {
                        Console.WriteLine("Error: Unable to create or access registry key.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}