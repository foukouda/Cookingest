using System;
using MySql.Data.MySqlClient;//utilisation de la bibliothèque

namespace Cookieges_projet
{
    internal class Program
    {
       static void Main(string[] args)
        {
            Console.WindowWidth = 80;
            Console.BufferWidth = 80;

            string cookinguestAscii = @"
  ____                            _       _   
 / ___|___  _ __  _ __   ___  _ __(_) __ _| |_ 
| |   / _ \| '_ \| '_ \ / _ \| '__| |/ _` | __|
| |__| (_) | | | | | | | (_) | |  | | (_| | |_ 
 \____\___/|_| |_|_| |_|\___/|_|  |_|\__,_|\__|
            ";

            string[] menuItems = new string[]
            {
                "Option 1",
                "Option 2",
                "Option 3",
                "Option 4",
                "Quitter"
            };

            int selectedIndex = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine(cookinguestAscii);

                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (selectedIndex == i)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (menuItems[i].Length / 2)) + "}", menuItems[i]));

                    Console.ResetColor();
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex - 1 + menuItems.Length) % menuItems.Length;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex + 1) % menuItems.Length;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }

            Console.Clear();
            Console.WriteLine($"Vous avez sélectionné {menuItems[selectedIndex]}.");
            Console.ReadLine();
        }
    }
}
