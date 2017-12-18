using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FileParser.Code;


namespace FileParser.Code.Test
{
    public class TryParseLineTest
    {
        [Fact]
        public void ParseSimpleComma()
        {

            var input = "first,last,gender,color,11/11/2016";
            var output = new Record("first", "last", "gender", "color", Convert.ToDateTime("11/11/2016"));
            var res = RecordParser.TryParseLine(input);
            Assert.Equal(res.Item1, output);
        }
        [Fact]
        public void ParseSimpleSpace()
        {

            var input = "first last gender color 11/11/2016";
            var output = new Record("first", "last", "gender", "color", Convert.ToDateTime("11/11/2016"));
            var res = RecordParser.TryParseLine(input);
            Assert.Equal(res.Item1, output);
        }
        [Fact]
        public void ParseSimplePipe()
        {

            var input = "first|last|gender|color|11/11/2016";
            var output = new Record("first", "last", "gender", "color", Convert.ToDateTime("11/11/2016"));
            var res = RecordParser.TryParseLine(input);
            Assert.Equal(res.Item1, output);
        }
        [Fact]
        public void ParseFailInputLength()
        {
            var input = "first,last,gender,11/11/2016";            
            Action act = () => RecordParser.ParseLineWithDelimiter(input, ",");
            Assert.Throws<ArgumentException>(act);
            
        }
    }
}
