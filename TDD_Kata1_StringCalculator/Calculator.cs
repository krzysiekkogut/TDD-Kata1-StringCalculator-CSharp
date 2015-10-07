using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Kata1_StringCalculator
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            var delimiters = new[] { ",", "\n" };
            if (numbers.StartsWith("//"))
            {
                if (numbers[2].Equals('['))
                {
                    var tmp = new List<string>();
                    var i = 2;
                    do
                    {
                        i++;
                        var delim = string.Empty;
                        while (!numbers[i].Equals(']'))
                        {
                            delim += numbers[i];
                            i++;
                        }

                        tmp.Add(delim);
                        i++;
                    }
                    while (numbers[i].Equals('['));
                    delimiters = tmp.ToArray();
                    numbers = numbers.Substring(i + 1);
                }
                else
                {
                    delimiters = new[] { numbers[2].ToString() };
                    numbers = numbers.Substring(4);
                }
            }

            var splitted = numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            var neg = splitted.Where(x => x.StartsWith("-")).Select(x => Convert.ToInt32(x));
            if (neg.Count() == 0)
            {
                return splitted
                    .Where(x => Convert.ToInt32(x) <= 1000)
                    .Sum(x => Convert.ToInt32(x));
            }

            throw new NegativesNotAllowedException { Negatives = neg.ToArray() };
        }
    }
}
