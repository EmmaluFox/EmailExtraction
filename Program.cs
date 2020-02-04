using System;
using System.IO;
using System.Net.Mime;
using System.Text.RegularExpressions;

namespace Email_Extraction
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine(DomainSearch());
            
            static int DomainSearch()
            {
                int counter = 0;
                string input = File.ReadAllText(@"C:\Training\Email Extraction\Email Extraction\text.txt");
               
                for (int i = 0; i < (input.Length-13); i++)
                {
                    if (input.Substring(i, 13) == "@softwire.com")
                    {
                        counter += 1;
                    }
                }
                return counter;
            }
        }
        */
            
            Regex newExpression = new Regex("@softwire.com");
            string input = File.ReadAllText(@"C:\Training\Email Extraction\Email Extraction\text.txt");
            MatchCollection results = newExpression.Matches(input);
            Console.Write(results.Count);
            
               /* \w(@\w*\.\w*)\W
                finds any char between an @, full stop followed by a space but 
                doesn't pick up .co.uk
               
               \w+(@\w+(\.\w+)+)\W
               
               */


        }
    }
}
