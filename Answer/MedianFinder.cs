using System;
using System.Collections.Generic;
using System.Linq;

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
        private readonly List<int> _nums = new List<int>();

        public void AddNum(int num)
        {
            _nums.Add(num);
        }

        public double FindMedian()
        {
            _nums.Sort();

            if (_nums.Count % 2 == 0)
            {
                var a = _nums[((_nums.Count - 1) / 2)];
                var b = _nums[((_nums.Count - 1) / 2) + 1];
                return (double)(a + b) / 2;
            }
            else
            {
                return _nums[(_nums.Count - 1) / 2];
            }
        }
    }

    /**
     * Your MedianFinder object will be instantiated and called as such:
     * MedianFinder obj = new MedianFinder();
     * obj.AddNum(num);
     * double param_2 = obj.FindMedian();
     */
}
