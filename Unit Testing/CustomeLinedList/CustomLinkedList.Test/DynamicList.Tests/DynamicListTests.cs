using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomLinkedList;

namespace CustomLinkedList.Test.DynamicList.Tests
{
    [TestClass]
    public class DynamicListTests
    {
        private DynamicList<int> numbers;

        [TestInitialize]
        public void InitList()
        {
            this.numbers = new DynamicList<int>();
        }

        [TestMethod]
        public void TestCountAfterAddingThreeTimes()
        {
            this.numbers.Add(4);
            this.numbers.Add(13);
            this.numbers.Add(7);

            Assert.AreEqual(3, this.numbers.Count, "The count is not equal to 3.");
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void ThrowExceptionIfIndexOfGettedNumberIsNegativeNumber()
        {
            this.numbers.Add(5);
            var number = this.numbers[-1];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ThrowExceptionIfIndexOfGettedNumberIsGreaterThanListsCount()
        {
            this.numbers.Add(5);
            var number = this.numbers[2];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ThrowExceptionIfIndexOfSettedItemIsNegativeNumber()
        {
            this.numbers.Add(12);
            this.numbers.Add(2);
            this.numbers[-1] = 10;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ThrowExceptionIfIndexOfSettedItemIsGreaterThanListsCount()
        {
            this.numbers.Add(12);
            this.numbers.Add(2);
            this.numbers[3] = 10;
        }

        [TestMethod]
        public void ChangingElementValueBySettingNewValueInSpecifiedIndex()
        {
            this.numbers.Add(1);
            this.numbers.Add(100);
            this.numbers.Add(51);
            this.numbers[1] = 10;

            Assert.AreEqual(10, this.numbers[1], "The element on position 1 is not 10.");
        }
        
        [TestMethod]
        public void RemovingElementAtSpecifiedIndexShouldDecreaseCount()
        {
            this.numbers.Add(12);
            this.numbers.Add(14);
            this.numbers.Add(112);
            this.numbers.Add(1412);
            this.numbers.RemoveAt(1);

            Assert.AreEqual(3, this.numbers.Count, "The count of the list has not decreased to 3.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ThrowExceptionIfIndexOfRemovingItemIsNegativeNumber()
        {
            this.numbers.Add(12);
            this.numbers.RemoveAt(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ThrowExceptionIfIndexOfRemovingItemIsGreaterThanListsCount()
        {
            this.numbers.Add(12);
            this.numbers.RemoveAt(2);
        }

        [TestMethod]
        public void ContainsShouldReturnFalseWhenTheElementIsMissing()
        {
            bool containsFive = this.numbers.Contains(5);

            Assert.IsFalse(containsFive, "The element is existing.");
        }

        [TestMethod]
        public void ContainsShouldReturnTrueWhenTheElementIsExisting()
        {
            this.numbers.Add(5);
            bool containsFive = this.numbers.Contains(5);

            Assert.IsTrue(containsFive, "The element is missing.");
        }

        [TestMethod]
        public void RemoveShouldReturnElementsIndexIfElementIsExisting()
        {
            this.numbers.Add(2);
            this.numbers.Add(7);
            this.numbers.Add(205);
            int removeNumberIndex = this.numbers.Remove(7);

            Assert.AreEqual(1, removeNumberIndex, "The index of the removed element is not equal to 1.");
        }

        [TestMethod]
        public void RemoveShouldReturnMinusOneIfElementIsMissing()
        {
            this.numbers.Add(2);
            this.numbers.Add(7);
            this.numbers.Add(205);
            int removeNumberIndex = this.numbers.Remove(5);

            Assert.AreEqual(-1, removeNumberIndex, "The element is existing");
        }

        [TestMethod]
        public void ShouldReturnTheIndexOfTheFirstOccurrenceOfTheElementIfItIsExisting()
        {
            this.numbers.Add(1);
            this.numbers.Add(3);
            this.numbers.Add(5);
            this.numbers.Add(5);
            int indexOfFive = numbers.IndexOf(5);

            Assert.AreEqual(2, indexOfFive, "The element is not found.");
        }
    }
}
