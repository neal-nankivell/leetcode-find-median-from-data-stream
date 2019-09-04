using Answer;
using NUnit.Framework;

namespace Tests
{
    public class MedianFinderTests
    {
        [TestCase(2, 3, 4, ExpectedResult = 3)]
        [TestCase(2, 3, ExpectedResult = 2.5)]
        [TestCase(2, ExpectedResult = 2)]
        public double FindMedian(params int[] nums)
        {
            var sut = new MedianFinder();

            foreach (var num in nums)
            {
                sut.AddNum(num);
            }

            var median = sut.FindMedian();

            return median;
        }
    }
}