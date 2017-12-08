using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FileParser.Code.Test
{
    public class ParseLines
    {
        [Fact]
        public void ParseEmpty()
        {
            var res = RecordParser.ParseLines(new List<string>());
            Assert.Equal(res, new List<Record>());
        }
        [Fact]
        public void ParseFailInputLength()
        {
            var input = new List<string> { "first1,last1,gender1,color1,11/11/2016", "first2,last2, gender2, color2, 11/11/2016" };           
            var output = new List<Record> { new Record("first", "last", "gender", "color", Convert.ToDateTime("11/11/2016")), new Record("first", "last", "gender", "color", Convert.ToDateTime("11/11/2016"))};
            var res = RecordParser.ParseLines(new List<string>());
            Assert.Equal(res, output);            
        }
    }
}
