using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace SegmentTree
{
    public abstract class RangeQueryProcessorTest<T>
    {
        protected RangeQueryProcessor<T> rangeQueryProc;
        readonly T placeholder;
        readonly Func<T, T, T> accumulator;

        protected RangeQueryProcessorTest(T placeholder,
                                          Func<T, T, T> accumulator)
        {
            this.placeholder = placeholder;
            this.accumulator = accumulator;
        }

        [SetUp]
        public void SetUp()
        {
            var testName = TestContext.CurrentContext.Test.Name;
            Console.WriteLine($"Running test {testName}.");
        }

        [TearDown]
        public void TearDown()
        {
            rangeQueryProc = null;
        }

        protected void GivenValues(params T[] values)
        {
            rangeQueryProc = new RangeQueryProcessor<T>(values, placeholder,
                                                        accumulator);
        }

        protected void ThenQueryRangeReturns(int startIndex, int endIndex,
                                             T expectedVal)
        {
            var result = rangeQueryProc.QueryRange(startIndex, endIndex);
            var areEqual = EqualityComparer<T>.Default.Equals(result,
                                                              expectedVal);
            Assert.True(areEqual);
        }

        protected void ThenCountEquals(int expectedVal)
        {
            Assert.AreEqual(rangeQueryProc.Count, expectedVal);
        }
    }
}
