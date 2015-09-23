using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CountSymbols
{
    class CountSymbols
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int eqalCharsCount = 0;
            Dictionary<char,int> charsAndCount = new Dictionary<char,int>();
            foreach (var ch in input)
            {
                foreach (var ch1 in input)
                {
                    if (ch==ch1)
                    {
                        eqalCharsCount++;
                    }
                }
                try
                {
                    charsAndCount.Add(ch, eqalCharsCount);
                }
                catch (ArgumentException)
                {
                    
                }
                eqalCharsCount = 0;
            }
            var sorte = charsAndCount.OrderBy(a => a.Key);
            foreach (var str in sorte)
            {
                Console.WriteLine(str);
            }
        }
    }
}
