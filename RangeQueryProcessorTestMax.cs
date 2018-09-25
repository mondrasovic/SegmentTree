using NUnit.Framework;
using System;

namespace SegmentTree
{
    [TestFixture]
    public class RangeQueryProcessorTestMax : RangeQueryProcessorTest<float>
    {
        public RangeQueryProcessorTestMax()
            : base(float.MinValue, (argA, argB) => Math.Max(argA, argB))
        {
        }

        [Test]
        public void TestMaxQueryAtArrayBeginning()
        {
            GivenValues(1, 0, -1, 5, 4, 3);
            ThenQueryRangeReturns(0, 2, 1);
        }

        [Test]
        public void TestMaxQueryAtArrayEnd()
        {
            GivenValues(5, -100, -25, 40, -15, 9, 13);
            ThenQueryRangeReturns(4, 6, 13);
        }

        [Test]
        public void TestMaxQueryInTheMiddle()
        {
            GivenValues(-2, -100, -8, -6, -4, 5);
            ThenQueryRangeReturns(1, 3, -6);
        }

        [Test]
        public void TestMaxQueryOverEntireRange()
        {
            GivenValues(-5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5);
            ThenQueryRangeReturns(0, 11, 5);
        }
    }
}
