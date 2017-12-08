using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FileParser.Code;


namespace FileParser.Code.Test
{
    public class ParseLineTest
    {
        [Fact]
        public void ParseSimple()
        {

            var input = "first,last,gender,color,11/11/2016";
            var output = new Record("first", "last", "gender", "color", Convert.ToDateTime("11/11/2016"));
            var res = RecordParser.ParseLineWithDelimiter(input, ",");
            Assert.Equal(res, output);
        }
        //[Fact]
        //public void ParseFailInputLength()
        //{
        //    var input = "first,last,gender,color,11/11/2016";
        //    var output = new Record("first", "last", "gender", "color", Convert.ToDateTime("11/11/2016"));
        //    Assert.False(input == output);
        //}        
    }
}
