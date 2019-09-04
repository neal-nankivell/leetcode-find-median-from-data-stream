using Answer;
using NUnit.Framework;

namespace Tests
{
    public class MinHeapTests
    {
        [TestCase(2, 3, 4, ExpectedResult = 2)]
        [TestCase(2, ExpectedResult = 2)]
        [TestCase(4, 2, 1, ExpectedResult = 1)]
        [TestCase(5, 7, 3, 2, 5, 2, 4, 1, 4, 5, ExpectedResult = 1)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, ExpectedResult = 1)]
        public int PopMin(params int[] nums)
        {
            var sut = new MinHeap();

            foreach (var num in nums)
            {
                sut.Add(num);
            }

            return sut.PopMin();
        }
    }
}