using System;
using System.Collections.Generic;
using System.Linq;


namespace _08.NightLife
{
    class NightLife
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string[] splitInp;
            Dictionary<string, string> placePerformer = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, string>> cityPlaceEvent = new Dictionary<string, Dictionary<string, string>>();
            while (input!="END")
            {
                splitInp = input.Split(';').ToArray();
                if (cityPlaceEvent.ContainsKey(splitInp[0]))
                {
                    if (cityPlaceEvent[splitInp[0]].Select(d => d.Key).Contains(splitInp[1]))
                    {
                        placePerformer = cityPlaceEvent[splitInp[0]];
                        placePerformer[splitInp[1]] += " ," + splitInp[2];
                        cityPlaceEvent[splitInp[0]] = new Dictionary<string, string>(placePerformer);
                        placePerformer.Clear();
                    }
                    else
                    {
                        placePerformer.Add(splitInp[1], splitInp[2]);
                        cityPlaceEvent[splitInp[0]].Add(splitInp[1],splitInp[2]);
                        placePerformer.Clear();
                    }
                    
                }
                else
                {
                    placePerformer.Add(splitInp[1], splitInp[2]);
                }
                if(!cityPlaceEvent.ContainsKey(splitInp[0]))
                {
                    cityPlaceEvent.Add(splitInp[0], new Dictionary<string, string>(placePerformer));
                }
                placePerformer.Clear();
                input = Console.ReadLine();
            }
            foreach (var city in cityPlaceEvent)
            {
                Console.WriteLine(city.Key);
                foreach (var place in city.Value)
                {
                    Console.WriteLine("->{0}: {1}",place.Key,place.Value);
                }
            }
        }
    }
}
