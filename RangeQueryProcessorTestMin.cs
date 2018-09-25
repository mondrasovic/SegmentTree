using NUnit.Framework;
using System;

namespace SegmentTree
{
    [TestFixture]
    public class RangeQueryProcessorTestMin : RangeQueryProcessorTest<int>
    {
        public RangeQueryProcessorTestMin()
            : base(int.MaxValue, (argA, argB) => Math.Min(argA, argB))
        {
        }

        [Test]
        public void TestMinQueryAtArrayBeginning()
        {
            GivenValues(1, 0, -1, 5, 4, 3);
            ThenQueryRangeReturns(0, 2, -1);
        }

        [Test]
        public void TestMinQueryAtArrayEnd()
        {
            GivenValues(5, -100, -25, 40, -15, 9, 13);
            ThenQueryRangeReturns(4, 6, -15);
        }

        [Test]
        public void TestMinQueryInTheMiddle()
        {
            GivenValues(-2, -100, -8, -6, -4, 5);
            ThenQueryRangeReturns(1, 3, -100);
        }

        [Test]
        public void TestMinQueryOverEntireRange()
        {
            GivenValues(-5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5);
            ThenQueryRangeReturns(0, 11, -5);
        }
    }
}
