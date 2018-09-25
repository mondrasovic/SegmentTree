using NUnit.Framework;
using System;

namespace SegmentTree
{
    [TestFixture]
    public class RangeQueryProcessorTestGeneral : RangeQueryProcessorTest<int>
    {
        public RangeQueryProcessorTestGeneral()
            : base(int.MaxValue, (argA, argB) => Math.Min(argA, argB))
        {
        }

        [Test]
        public void TestCaseCountEqualsBaseArrayLength()
        {
            GivenValues(1, 2, 4, 8, 16, 32, 64, 128, 256);
            ThenCountEquals(9);
        }

        [Test]
        public void TestOneElementRangeQuery()
        {
            GivenValues(5, 10, 15);
            ThenQueryRangeReturns(1, 1, 10);
        }

        [Test]
        public void TestQUeryIndexingIsZeroBased()
        {
            GivenValues(1, 2, 3, 4, 5);
            ThenQueryRangeReturns(0, 0, 1);
            ThenQueryRangeReturns(4, 4, 5);
        }
    }
}
