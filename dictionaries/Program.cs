using System;
using System.Collections.Generic;

namespace dictionaries {
    class Program {
        static void Main (string[] args) {
            // Add a few more of your favorite stocks
            Dictionary<string, string> stocks = new Dictionary<string, string> ();
            stocks.Add ("GM", "General Motors");
            stocks.Add ("CAT", "Caterpillar");
            stocks.Add ("DIS", "Disney");
            stocks.Add ("AAPL", "Apple");
            stocks.Add ("GE", "General Electric");

            // Add more purchases for each stock as Dictionaries going into a List
            List<Dictionary<string, double>> purchases = new List<Dictionary<string, double>> ();
            purchases.Add (new Dictionary<string, double>() { { "GE", 230.21 } });
            purchases.Add (new Dictionary<string, double>() { { "GE", 580.98 } });
            purchases.Add (new Dictionary<string, double>() { { "GE", 406.34 } });
            purchases.Add (new Dictionary<string, double>() { { "DIS", 1176.80 } });
            purchases.Add (new Dictionary<string, double>() { { "AAPL", 2100.32 } });
            purchases.Add (new Dictionary<string, double>() { { "AAPL", 232.23 } });

            /*
            Define a new Dictionary to hold the aggregated purchase information.
            - The key should be a string that is the full company name.
            - The value will be the total valuation of each stock


            From the the purchases above, one of the entries
            in this new dictionary will be...
                {"General Electric", 1217.53}
             */
            Dictionary<string , double> stockReport = new Dictionary<string , double> ();

            /*
               Iterate over the purchases and record the valuation
               for each stock.
            */
            foreach (Dictionary<string, double> purchase in purchases)
            {
                // Iterate over each individual purchase
                foreach (KeyValuePair<string, double> transaction in purchase)
                {
                    // Take the stock ticker that is the key for the purachase and use it to get the full name from the stocks
                    string fullCompanyName = stocks[transaction.Key];
                    // If their already is an entry add all the transaction values together otherwise
                    if (stockReport.ContainsKey(fullCompanyName)) {
                        stockReport[fullCompanyName] += transaction.Value;
                    } else { // If their isn't a stockreport entry then make one witht he full name and value
                        stockReport[fullCompanyName] = transaction.Value;
                    }
                }
            }

            // Display all holdings and their valuations from the stock report
            foreach (KeyValuePair<string, double> valuation in stockReport)
            {
                //Display the value in currency
                Console.WriteLine($"{valuation.Key} has a valuation of {valuation.Value.ToString("C")}");
            }

            Console.WriteLine ("Hello World!");
        }
    }
}