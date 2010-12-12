using NUnit.Framework;

namespace QuickSort.Tests
{
	[TestFixture]
	public class RecursiveQuickSortAcceptanceTest
	{
		[Test]
		public void Sort_should_keep_the_empty_array_unchanged()
		{
			var target = new RecursiveQuickSort();
			var array = new int[] {};

			target.Sort(array);

			var expectedResult = new int[] {};
			CollectionAssert.AreEqual(expectedResult, array, "Sorted array");
		}

		[Test]
		public void Sort_should_sort_a_2_items_array()
		{
			var target = new RecursiveQuickSort();
			var array = new int[] { 2, 1 };

			target.Sort(array);

			var expectedResult = new int[] { 1, 2};
			CollectionAssert.AreEqual(expectedResult, array, "Sorted array");
		}

		[Test]
		public void Sort_should_sort_the_array()
		{
			var target = new RecursiveQuickSort();
			var array = new int[] { 10, 5000, 8, 4000, 7, 3500, 6, 3000, 5, 2500 };

			target.Sort(array);

			var expectedResult = new int[] { 5, 6, 7, 8, 10, 2500, 3000, 3500, 4000, 5000 };
			CollectionAssert.AreEqual(expectedResult, array, "Sorted array");
		}

	}

}
