using System;
using System.Collections.Generic;

namespace sets
{
    class Program
    {
        static void Main(string[] args)
        {
            //make a HashSet
            HashSet<string> Showroom = new HashSet<string>();
            //Add strings to the HashSet
            Showroom.Add("Mustang");
            Showroom.Add("Ferrri");
            Showroom.Add("Lamborgini");
            Showroom.Add("Camero");
            Showroom.Add("Camero");

            HashSet<string> UsedLot = new HashSet<string>();
            UsedLot.Add("Camry");
            UsedLot.Add("Cube");

            // Use UnionWith to add a set to another set
            Showroom.UnionWith(UsedLot);
            // Use remove to get rid of a single item
            Showroom.Remove("Camry");

            HashSet<string> Junkyard = new HashSet<string>();
            Junkyard.Add("Rav4");
            Junkyard.Add("Eclipse");
            Junkyard.Add("Dodge");
            Junkyard.Add("Scion");
            Junkyard.Add("Mustang");
            Junkyard.Add("Camero");

            HashSet<string> clone = new HashSet<string>(Showroom);

            //Use IntersectWith to see what items are in both HashSets
            clone.IntersectWith(Junkyard);

            foreach (string car in clone)
            {
                Console.WriteLine(car);
            }
            Showroom.UnionWith(Junkyard);
            Showroom.Remove("Rav4");
            Showroom.Remove("Dodge");
            Showroom.Remove("Scion");
            foreach (string car in Showroom)
            {
                Console.WriteLine(car);
            }
        }
    }
}
