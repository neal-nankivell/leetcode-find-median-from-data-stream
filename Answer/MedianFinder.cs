using System.Collections.Generic;

namespace Answer
{
    /*
    Median is the middle value in an ordered integer list.
    If the size of the list is even, there is no middle value.
    So the median is the mean of the two middle value.

    For example,
    [2,3,4], the median is 3

    [2,3], the median is (2 + 3) / 2 = 2.5

    Design a data structure that supports the following two operations:

    void addNum(int num)
    - Add a integer number from the data stream to the data structure.

    double findMedian()
    - Return the median of all elements so far.
     */
    public class MedianFinder
    {
        private readonly MinHeap _minheap = new MinHeap();
        private readonly MaxHeap _maxheap = new MaxHeap();

        public void AddNum(int num)
        {
            if (_minheap.Count == 0)
            {
                _minheap.Add(num);
                return;
            }
            if (num > FindMedian())
            {
                _minheap.Add(num);
                if (_minheap.Count > (_maxheap.Count + 1))
                {
                    _maxheap.Add(_minheap.PopMin());
                }
            }
            else
            {
                _maxheap.Add(num);
                if (_maxheap.Count > (_minheap.Count + 1))
                {
                    _minheap.Add(_maxheap.PopMax());
                }
            }
        }

        public double FindMedian()
        {
            if (_minheap.Count > _maxheap.Count)
            {
                return _minheap.GetMin();
            }
            else if (_minheap.Count < _maxheap.Count)
            {
                return _maxheap.GetMax();
            }
            return (double)(_minheap.GetMin() + _maxheap.GetMax()) / 2;
        }
    }

    /**
     * Your MedianFinder object will be instantiated and called as such:
     * MedianFinder obj = new MedianFinder();
     * obj.AddNum(num);
     * double param_2 = obj.FindMedian();
     */

    public class MinHeap
    {
        private List<int> _heap = new List<int>();

        public void Add(int num)
        {
            var index = _heap.Count;
            _heap.Add(num);

            int? parentIndex = GetParentIndex(index);

            while (parentIndex.HasValue && num < _heap[parentIndex.Value])
            {
                Swap(index, parentIndex.Value);
                index = parentIndex.Value;
                parentIndex = GetParentIndex(index);
            }
        }

        public int GetMin() => _heap[0];

        public int Count => _heap.Count;

        public int PopMin()
        {
            var min = GetMin();
            if (_heap.Count == 1)
            {
                _heap.Clear();
                return min;
            }
            Swap(0, _heap.Count - 1);
            _heap.RemoveAt(_heap.Count - 1);

            var index = 0;
            var valueToBubbleDown = _heap[0];

            (int leftChildIndex, int rightChildIndex) GetChildIndexes(int i) =>
                (i * 2 + 1, i * 2 + 2);

            (int? leftChildValue, int? rightChildValue) GetChildren(int i)
            {
                (var leftChildIndex, var rightChildIndex) = GetChildIndexes(i);
                return (
                    leftChildIndex < _heap.Count ? _heap[leftChildIndex] : (int?)null,
                    rightChildIndex < _heap.Count ? _heap[rightChildIndex] : (int?)null
                );
            };

            (int aIndex, int bIndex) = GetChildIndexes(index);
            (int? a, int? b) = GetChildren(index);

            while ((a.HasValue && a.Value < valueToBubbleDown) ||
                (b.HasValue && b.Value < valueToBubbleDown))
            {
                if (b.HasValue && b.Value < a.Value)
                {
                    Swap(index, bIndex);
                    index = bIndex;
                }
                else
                {
                    Swap(index, aIndex);
                    index = aIndex;
                }
                var indexes = GetChildIndexes(index);
                var values = GetChildren(index);
                a = values.leftChildValue;
                b = values.rightChildValue;
                aIndex = indexes.leftChildIndex;
                bIndex = indexes.rightChildIndex;
            }

            return min;
        }

        private void Swap(int indexA, int indexB)
        {
            var a = _heap[indexA];
            var b = _heap[indexB];
            _heap[indexA] = b;
            _heap[indexB] = a;
        }

        private int? GetParentIndex(int index)
        {
            if (index == 0)
            {
                return null;
            }
            return (index - 1) / 2;
        }
    }

    public class MaxHeap
    {
        private List<int> _heap = new List<int>();

        public void Add(int num)
        {
            var index = _heap.Count;
            _heap.Add(num);

            int? parentIndex = GetParentIndex(index);

            while (parentIndex.HasValue && num > _heap[parentIndex.Value])
            {
                Swap(index, parentIndex.Value);
                index = parentIndex.Value;
                parentIndex = GetParentIndex(index);
            }
        }

        public int GetMax() => _heap[0];

        public int Count => _heap.Count;

        public int PopMax()
        {
            var max = GetMax();
            if (_heap.Count == 1)
            {
                _heap.Clear();
                return max;
            }
            Swap(0, _heap.Count - 1);
            _heap.RemoveAt(_heap.Count - 1);

            var index = 0;
            var valueToBubbleDown = _heap[0];

            (int leftChildIndex, int rightChildIndex) GetChildIndexes(int i) =>
                (i * 2 + 1, i * 2 + 2);

            (int? leftChildValue, int? rightChildValue) GetChildren(int i)
            {
                (var leftChildIndex, var rightChildIndex) = GetChildIndexes(i);
                return (
                    leftChildIndex < _heap.Count ? _heap[leftChildIndex] : (int?)null,
                    rightChildIndex < _heap.Count ? _heap[rightChildIndex] : (int?)null
                );
            };

            (int aIndex, int bIndex) = GetChildIndexes(index);
            (int? a, int? b) = GetChildren(index);

            while ((a.HasValue && a.Value > valueToBubbleDown) ||
                (b.HasValue && b.Value > valueToBubbleDown))
            {
                if (b.HasValue && b.Value > a.Value)
                {
                    Swap(index, bIndex);
                    index = bIndex;
                }
                else
                {
                    Swap(index, aIndex);
                    index = aIndex;
                }
                var indexes = GetChildIndexes(index);
                var values = GetChildren(index);
                a = values.leftChildValue;
                b = values.rightChildValue;
                aIndex = indexes.leftChildIndex;
                bIndex = indexes.rightChildIndex;
            }

            return max;
        }

        private void Swap(int indexA, int indexB)
        {
            var a = _heap[indexA];
            var b = _heap[indexB];
            _heap[indexA] = b;
            _heap[indexB] = a;
        }

        private int? GetParentIndex(int index)
        {
            if (index == 0)
            {
                return null;
            }
            return (index - 1) / 2;
        }
    }
}
