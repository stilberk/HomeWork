using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace _071.PhoneBook
{
    class PhoneBook
    {
        static void Main()
        {
            string regX = @"([a-zA-Z]+\-?\(?[a-zA-Z]+\)?)";
            string regXnum = @"(\+?[0-9]+\/?[0-9]+)";
            Regex nameRgx = new Regex(regX);
            Regex numberRgx = new Regex(regXnum);
            string inputData = Console.ReadLine();
            List<string> nums = new List<string>();
            Dictionary<string, List<string>> PhoneBook = new Dictionary<string, List<string>>();
            while (inputData!="search")
            {
                string name = nameRgx.Match(inputData).ToString();
                string number = numberRgx.Match(inputData).ToString();
                if (!PhoneBook.ContainsKey(name))
                {
                    nums.Add(number);
                    PhoneBook.Add(name, new List<string>(nums));
                    nums.Clear();
                }
                else
                {
                    nums.Clear();
                    nums = PhoneBook[name];
                    nums.Add(number);
                    PhoneBook[name]= nums;
                }
                Console.WriteLine(name);
                inputData = Console.ReadLine(); 
            }
            while (inputData!="")
            {
                if (PhoneBook.ContainsKey(inputData))
                {
                    nums = new List<string>(PhoneBook[inputData]);
                    Console.WriteLine("{0} -> {1}",inputData,nums[0]);
                }
                else
                {
                    Console.WriteLine("Contact {0} does not exist.",inputData);
                }
                inputData = Console.ReadLine();
            }
        }
    }
}
