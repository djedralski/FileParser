using FileParser.Code;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FileParser.Test
{
    public class ParseLineWithDelimiter
    {
        [Fact]
        public void ParseEmpty()
        {
            var input = "";
            Action act = () => RecordParser.ParseLineWithDelimiter(input, ",");
            Assert.Throws<ArgumentException>(act);
            
        }
        [Fact]
        public void ParseFailDelimiterInputLength()
        {
            var input = "first,last,gender,11/11/2016";
            Action act = () => RecordParser.ParseLineWithDelimiter(input, ",");
            Assert.Throws<ArgumentException>(act);

        }
        [Fact]
        public void ParseDelimiter()
        {
            var res = RecordParser.ParseLineWithDelimiter("first1,last1,gender1,color1,11/11/2016", ",");
            var output = new Code.Record("first1", "last1", "gender1", "color1", Convert.ToDateTime("11/11/2016"));
            Assert.Equal(res, output);
        }
        [Fact]
        public void ParseFailDelimiter()
        {
            var input ="first1,last1,gender1,color1,11/11/2016";
            Action act = () => RecordParser.ParseLineWithDelimiter(input, "|");
            Assert.Throws<ArgumentException>(act);
        }
        [Fact]
        public void ParseFailInputLength()
        {
            var input = new List<string> { "first1,last1,gender1,color1,11/11/2016", "first2,last2, gender2, color2, 11/11/2016" };
            var output = new List<Code.Record> { new Code.Record("first", "last", "gender", "color", Convert.ToDateTime("11/11/2016")), new Code.Record("first", "last", "gender", "color", Convert.ToDateTime("11/11/2016")) };
            var res = RecordParser.ParseLines(new List<string>());
            Assert.Equal(res, res);
        }
    }
}
