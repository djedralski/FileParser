using FileParser.Code;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace FileParser.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //argument checks
            if (args.Length != 3)
            {
                Console.WriteLine("3 filepaths required");
                return;
            }
            //validate arguments lead to files
            foreach (var arg in args)
            {
                if (!File.Exists(arg))
                {
                    Console.WriteLine($"No file exists at {arg}");
                    return;
                }
            }

            //Add records for each file to RecordList
            var recordList = new List<Record>();
            foreach (var arg in args)
            {
                List<string> fileInput = new List<string>();
                using (var reader = new StreamReader(arg))
                {
                    //Parse file
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        fileInput.Add(line);
                    }
                }
                recordList.AddRange(RecordParser.ParseLines(fileInput));
            }

            //Output 1 – sorted by gender(females before males) then by last name ascending.            
            Console.WriteLine("Output 1 – sorted by gender(females before males) then by last name ascending");
            recordList = recordList.OrderBy(x => x.Gender).ThenBy(x => x.LastName).ToList();
            OutputRecordsToConsole(recordList);

            //Output 2 – sorted by birth date, ascending.
            Console.WriteLine("Output 2 – sorted by birth date, ascending.");
            recordList = recordList.OrderBy(x => x.DateOfBirth).ToList();
            OutputRecordsToConsole(recordList);

            //Output 3 – sorted by last name, descending.
            Console.WriteLine("Output 3 – sorted by last name, descending.");
            recordList = recordList.OrderByDescending(x => x.LastName ).ToList();
            OutputRecordsToConsole(recordList);

        }
        private static void OutputRecordsToConsole(List<Record> list)
        {
            foreach(var line in list)
            {
                Console.WriteLine($"{line.LastName}, {line.FirstName}, {line.Gender}, {line.FavoriteColor}, {line.DateOfBirth.ToString("M/d/yyyy", CultureInfo.InvariantCulture)} ");
            }
        }
    }
}
