using NUnit.Framework;
using System;

namespace Lists.Tests
{
    public class ArrayListTests
    {
        [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 0 })]
        [TestCase(100, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 100 })]
        [TestCase(51, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 51 })]
        [TestCase(-10, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, -10 })]
        [TestCase(-77, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, -77 })]
        public void Add_WhenValidValuePassed_ShouldAddValueOnLastPositionInTheList_Tests(int value, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.Add(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(100, new int[] { 1, 2, 3, 4, 5 }, new int[] { 100, 1, 2, 3, 4, 5 })]
        [TestCase(51, new int[] { 1, 2, 3, 4, 5 }, new int[] { 51, 1, 2, 3, 4, 5 })]
        [TestCase(-10, new int[] { 1, 2, 3, 4, 5 }, new int[] { -10, 1, 2, 3, 4, 5 })]
        [TestCase(-77, new int[] { 1, 2, 3, 4, 5 }, new int[] { -77, 1, 2, 3, 4, 5 })]
        public void AddFirst_WhenValidValuePassed_ShouldAddValueOnFirstPositionInTheList_Tests(int value, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.AddFirst(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(20, 0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 20, 1, 2, 3, 4, 5 })]
        [TestCase(21, 1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 21, 2, 3, 4, 5 })]
        [TestCase(0, 2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 0, 3, 4, 5 })]
        [TestCase(-8, 3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, -8, 4, 5 })]
        [TestCase(-33, 4, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, -33, 5 })]
        public void AddByIndex_WhenValidValuePassed_ShouldAddValueOnPositionByIndexInTheList_Tests(
            int value, int index, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.AddByIndex(value, index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(10, 10, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(-10, -10, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(0, 6, new int[] { 1, 2, 3, 4, 5 })]
        public void AddByIndex_WhenInvalidValuePaseed_ShouldReturnIndexOutOfRangeException_NegativeTests(int value, int index, int[] actualArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);

            Assert.Throws<IndexOutOfRangeException>(() => actual.AddByIndex(value, index));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 5, 4, 3, 2, 1 }, new int[] { 5, 4, 3, 2 })]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, new int[] { -1, -2, -3, -4 })]
        [TestCase(new int[] { -5, -4, -3, -2, -1 }, new int[] { -5, -4, -3, -2 })]
        [TestCase(new int[] { 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 })]
        public void Remove_WhenValidValuePassed_ShouldRemoveValueOnLastPositionInTheList_Tests(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.Remove();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(new int[] { 5, 4, 3, 2, 1 }, new int[] { 4, 3, 2, 1 })]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, new int[] { -2, -3, -4, -5 })]
        [TestCase(new int[] { -5, -4, -3, -2, -1 }, new int[] { -4, -3, -2, -1 })]
        [TestCase(new int[] { 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 })]
        public void RemoveFirst_WhenValidValuePassed_ShouldRemoveValueOnFirstPositionInTheList_Tests(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.RemoveFirst();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(1, new int[] { 5, 4, 3, 2, 1 }, new int[] { 5, 3, 2, 1 })]
        [TestCase(2, new int[] { -1, -2, -3, -4, -5 }, new int[] { -1, -2, -4, -5 })]
        [TestCase(3, new int[] { -5, -4, -3, -2, -1 }, new int[] { -5, -4, -3, -1 })]
        [TestCase(4, new int[] { 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 })]
        public void RemoveByIndex_WhenValidValuePassed_ShouldRemoveValueOnPositionByIndexInTheList_Tests(
            int index, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.RemoveByIndex(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(10, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(-10, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(6, new int[] { 1, 2, 3, 4, 5 })]
        public void RemoveByIndex_WhenInvalidValuePassed_ShouldReturnIndexOutOfRangeException_NegativeTests(int index, int[] actualArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);

            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveByIndex(index));
        }

        [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] { 5, 4, 3, 2, 1 }, new int[] { 5, 4, 3, 2 })]
        [TestCase(2, new int[] { -1, -2, -3, -4, -5 }, new int[] { -1, -2, -3 })]
        [TestCase(3, new int[] { -5, -4, -3, -2, -1 }, new int[] { -5, -4 })]
        [TestCase(4, new int[] { 0, 0, 0, 0, 0 }, new int[] { 0 })]
        public void RemoveNElements_WhenValidValuePassed_ShouldRemoveNValuesFromEndOfTheList_Tests(int n, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.RemoveNElements(n);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] { 5, 4, 3, 2, 1 }, new int[] { 4, 3, 2, 1 })]
        [TestCase(2, new int[] { -1, -2, -3, -4, -5 }, new int[] { -3, -4, -5 })]
        [TestCase(3, new int[] { -5, -4, -3, -2, -1 }, new int[] { -2, -1 })]
        [TestCase(4, new int[] { 0, 0, 0, 0, 0 }, new int[] { 0 })]
        public void RemoveNElementsFromStart_WhenValidValuePassed_ShouldRemoveNValuesFromStartOfTheList_Tests(
            int n, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.RemoveNElementsFromStart(n);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, 4, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, 3, new int[] { 5, 4, 3, 2, 1 }, new int[] { 5, 4, 3, 1 })]
        [TestCase(2, 2, new int[] { -1, -2, -3, -4, -5 }, new int[] { -1, -2, -5 })]
        [TestCase(3, 1, new int[] { -5, -4, -3, -2, -1 }, new int[] { -5, -1 })]
        [TestCase(4, 0, new int[] { 0, 0, 0, 0, 0 }, new int[] { 0 })]
        public void RemoveNElementsByIndex_WhenValidValuePassed_ShouldRemoveNValuesStartingOutByIndexToEndOfTheList_Tests(
            int n, int index, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.RemoveNElementsByIndex(n, index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(-10, 0, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(-5, 1, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(-100, 2, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(-50, 3, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(-1000, 4, new int[] { 1, 2, 3, 4, 5 })]
        public void RemoveNElementsByIndex_WhenInvalidValuePassed_ShouldReturnArgumentException_NegativeTests(int n, int index, int[] actualArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);

            Assert.Throws<ArgumentException>(() => actual.RemoveNElementsByIndex(n, index));
        }

        [TestCase(0, -1, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, 9, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(2, -4, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(3, 8, new int[] { 1, 2, 3, 4, 5 })]
        public void RemoveNElementsByIndex_WhenInvalidValuePassed_ShouldReturnIndexOutOfRangeException_NegativeTests(int n, int index, int[] actualArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);

            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveNElementsByIndex(n, index));
        }

        [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] { 5, 4, 3, 2, 1 }, new int[] { 5, 4, 3, 2 })]
        [TestCase(-2, new int[] { -1, -2, -3, -4, -5 }, new int[] { -1, -3, -4, -5 })]
        [TestCase(-3, new int[] { -5, -4, -3, -2, -1 }, new int[] { -5, -4, -2, -1 })]
        [TestCase(0, new int[] { 1, 2, 3, 0, 0 }, new int[] { 1, 2, 3, 0 })]
        public void RemoveElementByValue_WhenValidValuePassed_ShouldRemoveFirstFoundElementByValueStartingOutFromEndOfTheList_Tests(
            int value, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.RemoveElementByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(5, new int[] { 1, 2, 3, 5, 5 }, new int[] { 1, 2, 3 })]
        [TestCase(4, new int[] { 5, 4, 3, 2, 4 }, new int[] { 5, 3, 2 })]
        [TestCase(-2, new int[] { -2, -2, -3, -4, -5 }, new int[] { -3, -4, -5 })]
        [TestCase(-1, new int[] { -5, -4, -1, -2, -1 }, new int[] { -5, -4, -2 })]
        [TestCase(0, new int[] { 0, 0, 0, 0, 0 }, new int[0] { })]
        public void RemoveAllElementsByValue_WhenValidValuePassed_ShouldRemoveAllFoundElementsByValueStartingOutFromEndOfTheList_Tests(
            int value, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.RemoveAllElementsByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, new int[] { 0, 0, 0, 0, 0 }, 0)]
        [TestCase(1, new int[] { 1, 2, 3, 4, 5 }, 0)]
        [TestCase(2, new int[] { 5, 4, 3, 2, 1 }, 3)]
        [TestCase(-3, new int[] { -1, -2, -3, -4, -5 }, 2)]
        [TestCase(-4, new int[] { -5, -4, -3, -2, -1 }, 1)]
        public void GetIndexbyValue_WhenValidValuePassed_ShouldGetIndexbyValueOfFirstFoundElementStartingOutFromStartOfTheList_Tests(
            int value, int[] actualArray, int expected)
        {
            ArrayList array = ArrayList.Create(actualArray);

            int actual = array.GetIndexbyValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 5, 4, 3, 2, 1 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, new int[] { -5, -4, -3, -2, -1 })]
        [TestCase(new int[] { -5, -4, -3, -2, -1 }, new int[] { -1, -2, -3, -4, -5 })]
        [TestCase(new int[] { 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0 })]
        public void Reverse_WhenValidValuePassed_ShouldReverseElementsOfTheList_Tests(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.Reverse();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4)]
        [TestCase(new int[] { 5, 4, 3, 2, 1 }, 0)]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, 0)]
        [TestCase(new int[] { -5, -4, -3, -2, -1 }, 4)]
        [TestCase(new int[] { 0, 0, 0, 0, 0 }, 0)]
        public void GetIndexMaxValue_WhenValidValuePassed_ShouldGetIndexOfMaxValueElementOfTheList_Tests(int[] actualArray, int expected)
        {
            ArrayList array = ArrayList.Create(actualArray);

            int actual = array.GetIndexMaxValue();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0)]
        [TestCase(new int[] { 5, 4, 3, 2, 1 }, 4)]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, 4)]
        [TestCase(new int[] { -5, -4, -3, -2, -1 }, 0)]
        [TestCase(new int[] { 0, 0, 0, 0, 0 }, 0)]
        public void GetIndexMinValue_WhenValidValuePassed_ShouldGetIndexOfMinValueElementOfTheList_Tests(int[] actualArray, int expected)
        {
            ArrayList array = ArrayList.Create(actualArray);

            int actual = array.GetIndexMinValue();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { 5, 4, 3, 2, 1 }, 5)]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, -1)]
        [TestCase(new int[] { -5, -4, -3, -2, -1 }, -1)]
        [TestCase(new int[] { 0, 0, 0, 0, 0 }, 0)]
        public void GetMaxValue_WhenValidValuePassed_ShouldGetMaxValueElementOfTheList_Tests(int[] actualArray, int expected)
        {
            ArrayList array = ArrayList.Create(actualArray);

            int actual = array.GetMaxValue();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1)]
        [TestCase(new int[] { 5, 4, 3, 2, 1 }, 1)]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, -5)]
        [TestCase(new int[] { -5, -4, -3, -2, -1 }, -5)]
        [TestCase(new int[] { 0, 0, 0, 0, 0 }, 0)]
        public void GetMinValue_WhenValidValuePassed_ShouldGetMinValueElementOfTheList_Tests(int[] actualArray, int expected)
        {
            ArrayList array = ArrayList.Create(actualArray);

            int actual = array.GetMinValue();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 0, 0, 0 })]
        public void AddArrayList_WhenValidValuePassed_ShouldAddArrayListInTheEndOfTheOtherList_Tests(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);
            ArrayList addedList = ArrayList.Create(new int[] { 0, 0, 0 });

            actual.AddArrayList(addedList);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 0, 0, 0, 1, 2, 3, 4, 5 })]
        public void AddArrayListToStart_WhenValidValuePassed_ShouldAddArrayListInTheEndOfTheOtherList_Tests(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);
            ArrayList addedList = ArrayList.Create(new int[] { 0, 0, 0 });

            actual.AddArrayListToStart(addedList);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 0, 0, 0, 2, 3, 4, 5 })]
        public void AddArrayListByIndex_WhenValidValuePassed_ShouldAddArrayListByIndexToOtherList_Tests(
            int index, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);
            ArrayList addedList = ArrayList.Create(new int[] { 0, 0, 0 });

            actual.AddArrayListByIndex(addedList, index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(null, 20, new int[] { 1, 2, 3, 4, 5 })]
        public void AddArrayListByIndex_WhenInvalidValuePassed_ShouldReturnIndexOutOfRangeException_NegativeTests(
            ArrayList list, int index, int[] actualArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);

            Assert.Throws<IndexOutOfRangeException>(() => actual.AddArrayListByIndex(list, index));
        }

        [TestCase(false, new int[] { 1, 3, 5, 2, 4 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(false, new int[] { 5, 4, 3, 2, 1 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(true, new int[] { -1, -3, -5, -2, -4 }, new int[] { -5, -4, -3, -2, -1 })]
        [TestCase(true, new int[] { -5, -3, -4, -2, -1 }, new int[] { -5, -4, -3, -2, -1 })]
        [TestCase(true, new int[] { 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0 })]
        public void Sort_WhenValidValuePassed_ShouldSortElementsOfTheList_Tests(bool isDescending, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.Sort(isDescending);

            Assert.AreEqual(expected, actual);
        }
    }
}