using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileParser.Code
{
    public class RecordParser
    {

        public static List<Record> ParseLines(List<string> input)
        {

            var res = new List<Record>();

            //If nothing, return empty list
            if (input.Count == 0)
                return res;
            var delim =TryParseLine(input.First()).Item2;

            //loop through input and parse data to record
            foreach (var inputString in input)
            {
                try
                {
                    res.Add(ParseLineWithDelimiter(inputString, delim));
                }
                catch
                {
                    throw new ArgumentException($"invalid input: {inputString}");
                }
            }

            return res;
        }
        public static Tuple<Record,string> TryParseLine(string input)
        {
            int i = 0;
            String delim = null;

            // define delimiters of interest
            string[] delimiters = new string[] { " ", "|", "," };

            //while there is no delimiter found loop through all delimiters in array
            while (i < delimiters.Length && string.IsNullOrEmpty(delim))
            {
                try
                {
                    //this will return the parsed line and delimiter if parsable, else errors out
                    return Tuple.Create<Record, string>(ParseLineWithDelimiter(input, delimiters[i]), delimiters[i]);
                }
                catch{ }
                finally
                {
                    i++;
                }
            }

            //only thrown if not parsable
            throw new ArgumentException($"No Valid Delimiter");
        }
        public static Record ParseLineWithDelimiter(string input, string delimiter)
        {
            // define delimiters of interest
            var res = input.Split(delimiter);
            if (res.Length != 5)
            {
                throw new ArgumentException($"Incorrect format of Record: {input}");
            }

            return new Record(res[0].Trim(), res[1].Trim(), res[2].Trim(), res[3].Trim(), Convert.ToDateTime(res[4].Trim()));
        }
    }
}
