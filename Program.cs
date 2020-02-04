using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text.RegularExpressions;

namespace Email_Extraction
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Training\Email Extraction\Email Extraction\";
            Regex rgxFullEmail = new Regex(@"\w+(@\w+(\.\w+)+)\W"); // Takes out whole email addresses
            string input = File.ReadAllText(path + @"Text.txt");
            MatchCollection results = rgxFullEmail.Matches(input);
            int resultsCount = results.Count;
            Console.WriteLine($@"{resultsCount} matches found.");

            int counter = 0;
            string[] emails = new string[results.Count];
            foreach (Match match in results)
            {
                string emailAddress = match.ToString();
                emails[counter] = emailAddress;
                Console.WriteLine(emailAddress);
                counter += 1;
            }


            // File.WriteAllLines(path +@"Dictionary.txt", emails);

            Regex rgxDomainGroups = new Regex(@"(@\w+(\.\w+)+)\W"); //Domain only
            MatchCollection domainOutput = rgxDomainGroups.Matches(input);

            Dictionary<string, int> domainNames = new Dictionary<string, int>();

            foreach (Match match in domainOutput)
            {
                string matchInstance = match.Groups[1].ToString();
                if (domainNames.ContainsKey(matchInstance))
                {
                    domainNames.Remove(matchInstance, out var value);
                    value += 1;
                    domainNames.Add(matchInstance, value);
                }
                else
                {
                    int value = 1;
                    domainNames.Add(matchInstance, value);
                }

            }

            string[] sortedList = new string[domainNames.Count];

            foreach (var entry in domainNames)
            {
                string concatPair = entry.ToString();
                int sortDomains = entry.Value;
                int counter2 = 0;
                foreach (var domain in domainNames)
                {
                    int domValue = domain.Value;
                    string concatPair2 = domain.ToString();
                    if (sortedList.Contains(concatPair))
                    {
                        counter2 += 1;
                    } else {

                        if (sortDomains < domValue)
                        {
                            sortedList[counter2] = concatPair2;
                            sortedList[counter2 + 1] = concatPair;
                        }
                        else
                        {
                            sortedList[counter2] = concatPair;
                            sortedList[counter2 + 1] = concatPair2;
                        }

                        counter2 += 2; 
                    }
                }
            }

            foreach (var entry in sortedList)
            {
                Console.WriteLine(entry);
            }

        }
    }






}
