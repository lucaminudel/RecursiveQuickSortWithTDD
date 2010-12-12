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

			var expectedResult = new int[] { 1, 2 };
			CollectionAssert.AreEqual(expectedResult, array, "Sorted array");
		}

		[Test]
		public void Sort_should_sort_a_3_items_array_with_median_items_not_already_sorted()
		{
			var target = new RecursiveQuickSort();
			var array = new int[] { 2, 3, 1 };

			target.Sort(array);

			var expectedResult = new int[] { 1, 2, 3 };
			CollectionAssert.AreEqual(expectedResult, array, "Sorted array");
		}

		[Test]
		public void Sort_should_sort_the_unsorted_array()
		{
			var target = new RecursiveQuickSort();
			var array = new int[] { 10, 5000, 8, 4000, 7, 3500, 6, 3000, 5, 2500 };

			target.Sort(array);

			var expectedResult = new int[] { 5, 6, 7, 8, 10, 2500, 3000, 3500, 4000, 5000 };
			CollectionAssert.AreEqual(expectedResult, array, "Sorted array");
		}

		[Test]
		public void Sort_should_sort_the_reverse_sorted_array()
		{
			var target = new RecursiveQuickSort();
			var array = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

			target.Sort(array);

			var expectedResult = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			CollectionAssert.AreEqual(expectedResult, array, "Sorted array");
		}

		[Test]
		public void Sort_should_sort_the_double_reverse_sorted_array()
		{
			var target = new RecursiveQuickSort();
			var array = new int[] { 6, 5, 4, 3, 2, 1, 9, 8, 7 };

			target.Sort(array);

			var expectedResult = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			CollectionAssert.AreEqual(expectedResult, array, "Sorted array");
		}


	}

}
