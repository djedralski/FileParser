using FileParser.Code;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileParser.App
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> fileInput = new List<string>();
            string path = null;
            if (args == null || args.Length != 1)
            {
                path = Directory.GetCurrentDirectory() + @"\test.csv";
            }
            else
            {
                path = args[0];
            }
            if(!File.Exists(path))
            {
                //no file exists
                Console.WriteLine("Requested File Does not Exist");                
                return;
            }
            using (var reader = new StreamReader(path))
            {
                //Parse file
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    fileInput.Add(line);                   
                }                
            }
            //Convert to Record List
            var parsedRecordLines = RecordParser.ParseLines(fileInput);

            //Save Data Here
        }
    }
}
