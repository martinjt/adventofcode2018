using System;
using Xunit;
using Shouldly;

namespace day1.tests
{
    public class UnitTest1
    {
        private readonly day1.Logic _logic; 
        public UnitTest1()
        {
            _logic = new day1.Logic();
        }

        [Fact]
        public void Test1()
        {
            var result = _logic.GetResult(new [] { "0" });
            result.ShouldBe(0);
        }

        [Fact]
        public void Test2()
        {
            var result = _logic.GetResult(new [] { "-1" });
            result.ShouldBe(-1);
        }

        [Fact]
        public void Test3()
        {
            var result = _logic.GetResult(new [] { "-1", "+2" });
            result.ShouldBe(1);
        }

        [Theory]
        [InlineData(new [] { "-1", "-2"}, null)]
        [InlineData(new [] { "3", "3", "4", "-2", "-4"}, 10)]
        [InlineData(new [] { "-6", "3", "8", "5", "-6"}, 5)]
        [InlineData(new [] { "7", "7", "-2", "-7", "-4"}, 14)]
        public void Test4(string[] input, int? expectedResult)
        {
            var result = _logic.GetRepeatedResult(input);
            result.ShouldBe(expectedResult);
        }

        // [Fact]
        // public void Test5()
        // {
        //     var 
        // }
    }
}
