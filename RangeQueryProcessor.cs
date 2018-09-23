using System;

namespace SegmentTree
{
    public class RangeQueryProcessor<T>
    {
        readonly T[] items;
        readonly T[] segmentTree;
        readonly T placeholder;
        readonly Func<T, T, T> accumulator;

        public T this[int index]
        {
            get => items[index];
            set => UpdateValue(index, value);
        }

        public int Count
        {
            get => items.Length;
        }

        public RangeQueryProcessor(T[] items, T placeholder,
                                   Func<T, T, T> accumulator)
        {
            this.items = new T[items.Length];
            items.CopyTo(this.items, 0);

            var segmentTreeSize = CalcSegmentTreeArraySize(this.items.Length);
            segmentTree = new T[segmentTreeSize];

            this.placeholder = placeholder;
            this.accumulator = accumulator;

            BuildSegmentTree();
        }

        public T QueryRange(int startIndex, int endIndex)
        {
            throw new NotImplementedException();
        }

        static int CalcSegmentTreeArraySize(int underlyingArraySize)
        {
            var log = Math.Log(underlyingArraySize, 2);
            var exp = Math.Ceiling(log);
            return (int)((2 * Math.Pow(2, exp)) - 1);
        }

        void BuildSegmentTree()
        {

        }

        void UpdateValue(int index, T value)
        {
            throw new NotImplementedException();
        }
    }
}
