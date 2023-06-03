using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader Input = new StreamReader("Trees.txt");
            while (!Input.EndOfStream)
            {
                Console.Clear();
                string data = Input.ReadLine();
                Tree WRA202 = new Tree(data);
                WRA202.displayTreeStructure();
                Console.WriteLine();
                Console.Write("{0} is ", data);
                if (!WRA202.balancedHeight())
                    Console.Write("NOT ");
                Console.WriteLine("height-balanced");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
            Console.WriteLine("Processing terminated - press enter to continue");
            Console.ReadLine();
        }
    }
}

