using System;
using src;
using Xunit;
using Shouldly;

namespace test
{
    public class UnitTest1
    {
        private readonly Logic _logic;

        public UnitTest1()
        {
            _logic = new Logic();
        }

        [Theory]
        [InlineData(new [] {""}, null)]
        [InlineData(new [] {"aabbb"}, 1)]
        [InlineData(new [] { "ab", "aab", "abbb"}, 1)]
        [InlineData(new [] { "ab", "aab", "abbb", "cggg"}, 2)]
        public void Test1(string[] input, int? expectedResult)
        {
            var result = _logic.GetResult(input);
            result.ShouldBe(expectedResult);
        }
    }
}
