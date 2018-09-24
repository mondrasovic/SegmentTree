using System;

namespace SegmentTree
{
    public class RangeQueryProcessor<T>
    {
        readonly T[] baseArray;
        readonly T[] segTree;
        readonly T placeholder;
        readonly Func<T, T, T> accumulator;

        public T this[int index]
        {
            get => baseArray[index];
            set => UpdateValue(index, value);
        }

        public int Count
        {
            get => baseArray.Length;
        }

        public RangeQueryProcessor(T[] array, T placeholder,
                                   Func<T, T, T> accumulator)
        {
            CheckBaseArrayLength(array);
            baseArray = new T[array.Length];
            array.CopyTo(baseArray, 0);

            var segTreeSize = CalcSegTreeArraySize(baseArray.Length);
            segTree = new T[segTreeSize];

            this.placeholder = placeholder;
            this.accumulator = accumulator;

            BuildSegTree();
        }

        public T QueryRange(int startIndex, int endIndex)
        {
            throw new NotImplementedException();
        }

        static int CalcSegTreeArraySize(int underlyingArraySize)
        {
            var log = Math.Log(underlyingArraySize, 2);
            var exp = Math.Ceiling(log);
            return (int)((2 * Math.Pow(2, exp)) - 1);
        }

        void CheckBaseArrayLength(T[] array)
        {
            if (array.Length < 1)
            {
                throw new ArgumentException("base array must not be empty");
            }
        }

        void BuildSegTree()
        {
            BuildSegTree(0, baseArray.Length - 1, 0);
        }

        void BuildSegTree(int baseArrayStartIndex, int baseArrayEndIndex,
                          int segTreeRootIndex)
        {
            if (baseArrayStartIndex == baseArrayEndIndex)
            {
                segTree[segTreeRootIndex] = baseArray[baseArrayStartIndex];
                return;
            }

            var baseArrayMidIndex = (baseArrayStartIndex + baseArrayEndIndex)
                / 2;
            var segTreeLeftChildIndex = (segTreeRootIndex * 2) + 1;
            var segTreeRightChildIndex = (segTreeRootIndex * 2) + 2;

            BuildSegTree(baseArrayStartIndex, baseArrayMidIndex,
                         segTreeLeftChildIndex);
            BuildSegTree(baseArrayMidIndex + 1, baseArrayEndIndex,
                         segTreeRightChildIndex);

            var leftVal = segTree[segTreeLeftChildIndex];
            var rightVal = segTree[segTreeRightChildIndex];
            var accumulatedVal = accumulator.Invoke(leftVal, rightVal);
            segTree[segTreeRootIndex] = accumulatedVal;
        }

        void UpdateValue(int index, T value)
        {
            throw new NotImplementedException();
        }
    }
}
