using HyperGistCommon;
using System;
using Xunit;

namespace HyperGistCommonTest
{
    public class CounterHelperUnitTest
    {
        [Fact]
        public void GetMinimumSequenceTest()
        {
            var minimumSequence= CounterHelper.GetMinimumSequence(7);
            Assert.True(minimumSequence.Equals("cVubcuc"));
            
        }
        [Fact]
        public void IncrementTest()
        {
            var minimumSequence = CounterHelper.IncrementSequence("cVubcuc");
            Assert.True(minimumSequence.Equals("wVubcuc"));

        }
        [Fact]
        public void Increment2Test()
        {
            var minimumSequence = CounterHelper.IncrementSequence("Fn0yF0F");
            Assert.True(minimumSequence.Equals("Fn0yF0Fb"));

        }
        [Fact]
        public void Increment3Test()
        {
            var minimumSequence = CounterHelper.IncrementSequence("Fn0yF0f");
            Assert.True(minimumSequence.Equals("Fn0yF0F"));

        }
    }
}
