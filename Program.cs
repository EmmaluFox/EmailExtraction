﻿using System;
using System.IO;
using System.Net.Mime;

namespace Email_Extraction
{
    class Program
    {
        static void Main(string[] args)
        {
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
    }
}