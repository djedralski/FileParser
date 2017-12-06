using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileParser.Code
{
    class RecordParser
    {

        public static List<Record> ParseLines(List<string> input)
        {

            var res = new List<Record>();
            int i = 0;
            String delim = null;
            // define delimiters of interest
            string[] delimiters = new string[] { " ", "|", "," };

            //If nothing, return empty list
            if (input.Count == 0)
                return res;

            //while there is no delimiter found loop through all delimiters in array
            while (i< delimiters.Length && string.IsNullOrEmpty(delim))
            {
                try
                {
                    ParseLine(input.First(), delimiters[i]);
                    delim = delimiters[i];
                }              
                finally
                {
                    i++;
                }
            }
            
            if(string.IsNullOrEmpty(delim))
            {
                //error as no valid delimiter
            }
            
            //loop through input and parse data to record
            foreach(var inputString in input)
            {
                res.Add(ParseLine(inputString, delim));
            }

            return res;
        }

        public static Record ParseLine(string input, string delimiter)
        {
            // define delimiters of interest
            var res = input.Split(delimiter);
            if (res.Length != 5)
            {
                //error
            }

            return new Record(res[0].Trim(),res[1].Trim(), res[2].Trim(), res[3].Trim(), Convert.ToDateTime(res[4].Trim()));
        }
    }
}
