using System;

namespace xmlreader
{
    class Program
    {
        static void Main(string[] args)
        {
            XMLparse parse = new XMLparse("Data/SampleData.xml");

            for (int i = 0; i < 21; i++)
            {
                if (parse.findType(i) == "standard")
                {
                    Console.Write("Name: " + parse.findValue(i, "name"));
                    Console.Write(" | ");
                    Console.Write("Point Value: " + parse.findValue(i, "pointWorth"));
                    Console.WriteLine();
                    Console.Write("Description: " + parse.findValue(i, "description"));
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else if (parse.findType(i) == "special")
                {
                    Console.Write("Name: " + parse.findValue(i, "name"));
                    Console.Write(" | ");
                    Console.Write("Point Value: " + parse.findValue(i, "pointWorth"));
                    Console.WriteLine();
                    Console.Write("Description: " + parse.findValue(i, "description"));
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else if (parse.findType(i) == "enemies")
                {
                    Console.Write("Name: " + parse.findValue(i, "name"));
                    Console.Write(" \n");
                    Console.Write("Description: " + parse.findValue(i, "description"));
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }

            Console.ReadKey();
        }
    }
}
