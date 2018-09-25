using NUnit.Framework;

namespace SegmentTree
{
    [TestFixture]
    public class RangeQueryProcessorTestSum : RangeQueryProcessorTest<long>
    {
        public RangeQueryProcessorTestSum()
            : base(0, (argA, argB) => argA + argB)
        {
        }

        [Test]
        public void TestSumQueryAtArrayBeginning()
        {
            GivenValues(1, 0, -1, 5, 4, 3);
            ThenQueryRangeReturns(0, 2, 0);
        }

        [Test]
        public void TestSumQueryAtArrayEnd()
        {
            GivenValues(5, -100, -25, 40, -15, 9, 13);
            ThenQueryRangeReturns(4, 6, 7);
        }

        [Test]
        public void TestSumQueryInTheMiddle()
        {
            GivenValues(-2, -100, -8, -6, -4, 5);
            ThenQueryRangeReturns(1, 3, -114);
        }

        [Test]
        public void TestSumQueryOverEntireRange()
        {
            GivenValues(-5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5);
            ThenQueryRangeReturns(0, 11, 0);
        }
    }
}
