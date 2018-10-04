using System;
using System.Collections.Generic;

namespace lists
{
    class Program
    {
        static void Main(string[] args)
        {
            //List of Planets
            List<string> planetList = new List<string>(){"Mercury", "Mars"};
            //Adding Planets to a List
            planetList.Add("Jupiter");
            planetList.Add("Saturn");
            List<string> planetList2 = new List<string>(){"Uranus", "Neptune"};
            //Adding one list to another
            planetList.AddRange(planetList2);
            //Adding a Planet to the list by a certain postion like splice
            planetList.Insert(1, "Earth");
            planetList.Insert(1, "Venus");
            planetList.Add("Pluto");
            List<string> rockeyPlanets = new List<string>(){};
            //Grabbing only the things in the list that are in a certain range
            rockeyPlanets = planetList.GetRange(0, 4);
            planetList.Remove("Pluto");

            // Making a List of Dictionaries
            List<Dictionary<string, string>> probes = new List<Dictionary<string, string>>();

            //Option 1 to create and add a Dictionary to a List
            Dictionary<string, string> viking = new Dictionary<string, string>();
            viking["Mars"] = "Viking";
            probes.Add(viking);

            //Option 2 to create and add a Dictionary to a List
            Dictionary<string, string> mariner10 = new Dictionary<string, string>();
            mariner10.Add("Mercury", "Mariner 10");
            probes.Add(mariner10);

            // Option 3 to create and add a Dictionary to a List
            Dictionary<string, string> marsProbes2 = new Dictionary<string, string>() {
                {"Mars", "Mariner"}
            };
            Dictionary<string, string> marsProbes3 = new Dictionary<string, string>() {
                {"Mars", "Spirit"}
            };
            Dictionary<string, string> marsProbes4 = new Dictionary<string, string>() {
                {"Mars", "Sojourner"}
            };
            probes.Add(marsProbes2);
            probes.Add(marsProbes3);
            probes.Add(marsProbes4);
            // Add multiple dictionary entries but they must have different Keys so no two with Saturn
            Dictionary<string, string> saturnProbes = new Dictionary<string, string>() {
                {"Saturn", "Pioneer"},
                {"Mars", "Pioneer2"}
            };
            Dictionary<string, string> saturnProbes2 = new Dictionary<string, string>() {
                {"Saturn", "Voyager"}
            };
            Dictionary<string, string> saturnProbes3 = new Dictionary<string, string>() {
                {"Saturn", "Cassini"}
            };
            probes.Add(saturnProbes);
            probes.Add(saturnProbes2);
            probes.Add(saturnProbes3);

            foreach (var planet in planetList) // iterate planets
            {
                List<string> matchingProbes = new List<string>();

                foreach(var probe in probes) // iterate probes
                {
                    /*
                        Does the current Dictionary contain the key of
                        the current planet? Investigate the ContainsKey()
                        method on a Dictionary.

                        If so, add the current spacecraft to `matchingProbes`.
                    */
                    if (probe.ContainsKey(planet)) {
                        matchingProbes.Add(probe[planet]);
                    }
                }
                /*
                    Use String.Join(",", matchingProbes) as part of the
                    solution to get the output below. It's the C# way of
                    writing `array.join(",")` in JavaScript.
                    Only list in the console if the planet has probes associated with it
                */
                if (matchingProbes.Count > 0) {
                    Console.WriteLine($"{planet}: {String.Join(", ", matchingProbes)}");
                }
            }
            
            Console.WriteLine("Hello World!");
        }
    }
}
