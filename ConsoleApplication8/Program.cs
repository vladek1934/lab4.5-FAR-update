using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarWithRecursion
{

    class Program
    {
        static string show(string directory, int index)
        {
            Console.Clear();
            int m = 0;
            DirectoryInfo di = new DirectoryInfo(directory);
            DirectoryInfo[] diArr = di.GetDirectories();


            foreach (DirectoryInfo d in diArr)
            {
                if (m == index)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    current = d.Name;
                    current2 = directory + "\\" + current;
                    Console.WriteLine(d.Name);
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(d.Name);
                }
                
                m++;
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            System.IO.FileInfo[] fileNames = di.GetFiles("*.*");


            foreach (System.IO.FileInfo fi in fileNames)
            {
                if (m == index)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    current = fi.Name;
                    current2 = directory + "\\" + current ;
                    Console.WriteLine( fi.Name);
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(fi.Name);
                }

                m++;
               
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(current2);

            return current2;
        }

        public static string current, current2;

        static void move(string directory, int index)
        {
            DirectoryInfo di = new DirectoryInfo(directory);
            DirectoryInfo[] diArr = di.GetDirectories();

            System.IO.FileInfo[] fileNames = di.GetFiles("*.*");

            current2 = show(directory, index);
            while (true)
            {
                show(directory, index);
                ConsoleKeyInfo pressedKey = Console.ReadKey();

                if (pressedKey.Key == ConsoleKey.UpArrow)
                {
                    if ((index - 1) >= 0)
                    {
                        index--;
                        show(directory, index);
                    }
                }
                else if (pressedKey.Key == ConsoleKey.DownArrow)
                {
                    if ((index + 1) < diArr.Length + fileNames.Length)
                    {
                        index++;
                        show(directory, index);
                    }

                }
                else if (pressedKey.Key == ConsoleKey.Enter)
                {

                    if ((index + 1) < diArr.Length)
                    {
            
                        move(current2, 0);
                    }

                    if ((index + 1) >= diArr.Length)
                    {
                        Console.Clear();
                        string[] lines = System.IO.File.ReadAllLines(@current2);
                        System.Console.WriteLine("Contents of the file = ");
                        foreach (string line in lines)
                        {
                          
                            Console.WriteLine("\t" + line);
                        }
                        Console.WriteLine("Press any key to exit.");
                        System.Console.ReadKey();
                    }
                }
                else if (pressedKey.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }





        }

        static void Main(string[] args)
        {
            string dir = Console.ReadLine();
            move(@dir, 0);
        }
    }
}