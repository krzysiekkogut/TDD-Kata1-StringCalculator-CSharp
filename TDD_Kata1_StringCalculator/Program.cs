using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Kata1_StringCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type numbers:");
            string line;
            StringBuilder sb = new StringBuilder();
            do
            {
                line = Console.ReadLine();
                sb.AppendLine(line);
            }
            while (!line.Equals(string.Empty));
            Console.WriteLine(new Calculator().Add(sb.ToString()));
            Console.ReadKey();
        }
    }
}