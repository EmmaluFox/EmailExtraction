using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Text.RegularExpressions;

namespace Email_Extraction
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Regex newExpression = new Regex(@"\w+(@\w+(\.\w+)+)\W");
            string input = File.ReadAllText(@"C:\Training\Email Extraction\Email Extraction\text.txt");
            MatchCollection results = newExpression.Matches(input);
            int countResults = results.Count;
            Console.Write($@"{countResults} matches found.");

            int counter = 0;
            string[] dictionaryAdd = new string[results.Count];
            foreach (Match match in results)
            {
                string emailAddress = match.ToString();
                dictionaryAdd[counter] = emailAddress;
                Console.WriteLine(emailAddress);
                counter += 1;
            }
            
            File.WriteAllLines(@"C:\Training\Email Extraction\Email Extraction\Dictionary.txt", dictionaryAdd);

        }
    }
}
