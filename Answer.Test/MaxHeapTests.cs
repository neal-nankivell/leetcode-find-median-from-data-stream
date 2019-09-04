using Answer;
using NUnit.Framework;

namespace Tests
{
    public class MaxHeapTests
    {
        [TestCase(2, 3, 4, ExpectedResult = 4)]
        [TestCase(2, ExpectedResult = 2)]
        [TestCase(4, 2, 1, ExpectedResult = 4)]
        [TestCase(5, 7, 3, 2, 5, 2, 4, 1, 4, 5, ExpectedResult = 7)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, ExpectedResult = 9)]
        public int PopMax(params int[] nums)
        {
            var sut = new MaxHeap();

            foreach (var num in nums)
            {
                sut.Add(num);
            }

            return sut.PopMax();
        }
    }
}