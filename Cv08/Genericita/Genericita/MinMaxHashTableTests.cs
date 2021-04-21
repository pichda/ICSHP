using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericExercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GenericExercise.Tests
{
    [TestClass()]
    public class MinMaxHashTableTests
    {

        #region Basic hash tests (add, contains, get)
        [TestMethod()]
        public void TestOfContainsOnEmptyHashTable()
        {
            MinMaxHashTable<int, string> table = new MinMaxHashTable<int, string>();

            Assert.IsFalse(table.Contains(-1));
            Assert.IsFalse(table.Contains(0));
            Assert.IsFalse(table.Contains(1));
        }

        [TestMethod(), ExpectedException(typeof(KeyNotFoundException))]
        public void TestOfGetOnEmptyHashTable()
        {
            MinMaxHashTable<int, string> table = new MinMaxHashTable<int, string>();

            string value = table.Get(0);
            // Exception should be thrown at previous line
        }

        [TestMethod()]
        public void TestOfAddingSingleElementToHashTable()
        {
            MinMaxHashTable<int, string> table = new MinMaxHashTable<int, string>();

            table.Add(1, "one");

            Assert.IsTrue(table.Contains(1));
            Assert.AreEqual("one", table.Get(1));
            Assert.AreEqual(1, table.Count);
        }

        [TestMethod(), ExpectedException(typeof(ArgumentException))]
        public void TestOfAddingDuplicicKey()
        {
            MinMaxHashTable<int, string> table = new MinMaxHashTable<int, string>();

            table.Add(1, "one");
            table.Add(1, "two");
            // Exception should be thrown at previous line
        }

        [TestMethod()]
        public void TestOfAddingMultipleDistinctElementToHashTable()
        {
            MinMaxHashTable<int, string> table = new MinMaxHashTable<int, string>();

            table.Add(1, "one");
            table.Add(2, "two");
            table.Add(3, "three");

            Assert.IsTrue(table.Contains(1));
            Assert.AreEqual("one", table.Get(1));

            Assert.IsTrue(table.Contains(2));
            Assert.AreEqual("two", table.Get(2));

            Assert.IsTrue(table.Contains(3));
            Assert.AreEqual("three", table.Get(3));

            Assert.AreEqual(3, table.Count);
        }

        [TestMethod()]
        public void TestOfAddingManyDistinctElementToHashTable()
        {
            MinMaxHashTable<int, string> table = new MinMaxHashTable<int, string>(capacity: 16384);

            const int elements = 1000000;
            for (int i = 0; i < elements; i++)
            {
                table.Add(i, i.ToString());
            }

            Assert.AreEqual(elements, table.Count);

            for (int i = 0; i < elements; i++)
            {
                Assert.IsTrue(table.Contains(i));
                Assert.AreEqual(i.ToString(), table.Get(i));
            }

            Assert.IsFalse(table.Contains(-1));
            Assert.IsFalse(table.Contains(elements));
        }

        [TestMethod()]
        public void TestOfRemovingElementFromHashTable()
        {
            MinMaxHashTable<int, string> table = new MinMaxHashTable<int, string>();

            table.Add(1, "one");
            table.Add(2, "two");
            table.Add(3, "three");


            var value = table.Remove(2);


            Assert.AreEqual("two", value);

            Assert.IsTrue(table.Contains(1));
            Assert.AreEqual("one", table.Get(1));

            Assert.IsFalse(table.Contains(2));

            Assert.IsTrue(table.Contains(3));
            Assert.AreEqual("three", table.Get(3));

            Assert.AreEqual(2, table.Count);
        }

        [TestMethod(), ExpectedException(typeof(KeyNotFoundException))]
        public void TestOfRemovingNonExistentElementFromHashTable()
        {
            MinMaxHashTable<int, string> table = new MinMaxHashTable<int, string>();

            table.Add(1, "one");
            table.Add(2, "two");
            table.Add(3, "three");


            var value = table.Remove(20);
            // Exception should be thrown at previous line
        }
        #endregion

        #region Min-Max tests
        [TestMethod(), ExpectedException(typeof(InvalidOperationException))]
        public void TestOfEmptyHashTableMinValue()
        {
            MinMaxHashTable<int, string> table = new MinMaxHashTable<int, string>();

            int min = table.Minimum;
            // Exception should be thrown at previous line
        }

        [TestMethod(), ExpectedException(typeof(InvalidOperationException))]
        public void TestOfEmptyHashTableMaxValue()
        {
            MinMaxHashTable<int, string> table = new MinMaxHashTable<int, string>();

            int min = table.Maximum;
            // Exception should be thrown at previous line
        }

        [TestMethod()]
        public void TestOfNotEmptyHashTableMinMaxValues()
        {
            MinMaxHashTable<int, string> table = new MinMaxHashTable<int, string>();

            table.Add(-1, "one");
            table.Add(2, "two");
            table.Add(-3, "three");

            Assert.AreEqual(-3, table.Minimum);
            Assert.AreEqual(2, table.Maximum);
        }
        #endregion

        #region Range tests
        [TestMethod()]
        public void TestSimpleNumericRangeUsingIndexer()
        {
            MinMaxHashTable<int, string> table = new MinMaxHashTable<int, string>();

            const int elements = 10;
            for (int i = 0; i < elements; i++)
            {
                table.Add(i, i.ToString());
            }


            var range = table[2, 4];


            int[] remaining = new int[] { 0, 0, 1, 1, 1, 0, 0, 0, 0, 0 };

            foreach (var item in range)
            {
                if (remaining[item.Key] < 0)
                {
                    Assert.Fail("Unexpected element in range query");
                }

                remaining[item.Key]--;
            }

            foreach (var item in remaining)
            {
                if (item > 0)
                {
                    Assert.Fail("Some elements weren't read from range");
                }
            }
        }

        [TestMethod()]
        public void TestSimpleNumericSortedRange()
        {
            MinMaxHashTable<int, string> table = new MinMaxHashTable<int, string>();

            const int elements = 100;
            for (int i = 0; i < elements; i++)
            {
                int keyvalue = i - 50;
                table.Add(keyvalue, keyvalue.ToString());
            }


            var range = table.SortedRange(13, 17).Select(kv => kv.Key);


            CollectionAssert.AreEqual(
                new List<int>() { 13, 14, 15, 16, 17},
                range.ToList());
        }
        #endregion
    }
}