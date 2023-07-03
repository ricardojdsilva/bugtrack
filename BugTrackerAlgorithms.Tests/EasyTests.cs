using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace BugTrackerAlgorithms.Tests
{
    [TestClass]
    public class EasyTests
    {
        public static Easy _easy;

        [ClassInitialize]
        public static void Setup(TestContext context) {
            _easy = new Easy();
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("()", true)]
        [DataRow("()[]{}", true)]
        [DataRow("(()", false)]
        public void IsValidParentheses(string param, bool result)
        {
            var actual = _easy.IsValidParentheses(param);
            Assert.AreEqual(result, actual);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
        [DataRow(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
        [DataRow(new int[] { 3, 5, 7, 3 }, 6, new int[] { 0, 3 })]
        public void TwoSumMustMatch(int[] arrParam, int matchParam, int[] result)
        {
            var actual = _easy.TwoSum(arrParam, matchParam);
            Assert.IsTrue(result.Any(a => actual.Contains(a)));
        }

        [DataTestMethod]
        [DataRow(new int[] { 3, 2, 2, 3 }, 3, new int[] { 2, 2 })]
        [DataRow(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2, new int[] { 0, 0, 1, 3, 4 })]
        public void RemoveElementShouldPass(int[] array, int valueToRemove, int[] expectedArray)
        {
            var actualLength = _easy.RemoveElement(array, valueToRemove);
            Array.Sort(array, 0, actualLength);
            Assert.AreEqual(expectedArray.Length, actualLength);
            for (int i = 0; i < actualLength; i++)
            {
                Assert.AreEqual(array[i], expectedArray[i]);
            }
        }
    }
}
