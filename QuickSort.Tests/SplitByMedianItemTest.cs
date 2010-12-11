using System;
using NUnit.Framework;

namespace QuickSort.Tests
{
	[TestFixture]
	public class SplitByMedianItemTest
	{

		[Test]
		public void N_element_array_with_median_item_x_should_be_split_into_one_array_of_elements_smaller_than_x_and_one_array_of_elements_bigger_than_x()
		{
			var array = new int[] { 1, 8, 5, 2, 4, 7, 3, 9, 6, 10 };
			var source = new ArraySegment<int>(array);

			var target = new SplitByMedianItem(source);

			var leftSplit = SegmentToArray(target.LeftSplit);
			var expectedLeftSplit = new int[] { 1, 3, 4, 2 };
			CollectionAssert.AreEqual(expectedLeftSplit, leftSplit, "LeftSplit");

			var rightSplit = SegmentToArray(target.RightSplit);
			var expectedRightSplit = new int[] { 5, 7, 8, 9, 6 , 10 };
			CollectionAssert.AreEqual(expectedRightSplit, rightSplit, "RightSplit");
		}

		[Test]
		public void N_minus_1_element_array_with_median_item_x_should_be_split_into_one_array_of_elements_smaller_than_x_and_one_array_of_elements_bigger_than_x()
		{
			var array = new int[] { 1, 8, 5, 2, 4, 7, 3, 9, 6 };
			var source = new ArraySegment<int>(array);

			var target = new SplitByMedianItem(source);

			var leftSplit = SegmentToArray(target.LeftSplit);
			var expectedLeftSplit = new int[] { 1, 3, 4, 2 };
			CollectionAssert.AreEqual(expectedLeftSplit, leftSplit, "LeftSplit");

			var rightSplit = SegmentToArray(target.RightSplit);
			var expectedRightSplit = new int[] { 5, 7, 8, 9, 6 };
			CollectionAssert.AreEqual(expectedRightSplit, rightSplit, "RightSplit");
		}

		[Test]
		public void Tree_element_array_with_median_item_with_median_value_should_be_sorted_and_split_into_two_empty_arrays()
		{
			var array = new int[] { 11, 33, 44 };
			var source = new ArraySegment<int>(array);

			var target = new SplitByMedianItem(source);

			Assert.AreEqual(0, target.LeftSplit.Count, "LeftSplit count");
			Assert.AreEqual(0, target.RightSplit.Count, "RightSplit count");

			Assert.AreEqual(11, array[0], "first sorted item");
			Assert.AreEqual(33, array[1], "second sorted item");
			Assert.AreEqual(44, array[2], "third sorted item");
		}


		[Test]
		public void Tree_element_array_with_minimum_value_as_median_should_split_into_an_empty_array_and_a_two_element_array()
		{
			var array = new int[] { 44, 11, 33 };
			var source = new ArraySegment<int>(array);

			var target = new SplitByMedianItem(source);

			Assert.AreEqual(0, target.LeftSplit.Count, "LeftSplit count");

			var rightSplit = SegmentToArray(target.RightSplit);
			var expectedRightSplit = new int[] { 44, 33 };
			CollectionAssert.AreEqual(expectedRightSplit, rightSplit, "RightSplit");
		}

		[Test]
		public void Tree_element_array_with_maximum_value_as_median_should_split_into_an_empty_array_and_a_two_element_array()
		{
			var array = new int[] { 33, 44, 11 };
			var source = new ArraySegment<int>(array);

			var target = new SplitByMedianItem(source);

			var leftSplit = SegmentToArray(target.LeftSplit);
			var expectedLeftSplit = new int[] { 33, 11 };
			CollectionAssert.AreEqual(expectedLeftSplit, leftSplit, "LeftSplit");

			Assert.AreEqual(0, target.RightSplit.Count, "RightSplit count");
		}

	
		[Test]
		public void Two_element_sorted_array_should_remain_sorted_and_split_into_two_empty_arrays()
		{
			var array = new int[] { 33, 44 };
			var source = new ArraySegment<int>(array);

			var target = new SplitByMedianItem(source);

			Assert.AreEqual(0, target.LeftSplit.Count, "LeftSplit count");
			Assert.AreEqual(0, target.RightSplit.Count, "RightSplit count");

			Assert.AreEqual(33, array[0], "first item");
			Assert.AreEqual(44, array[1], "second item");
		}

		[Test]
		public void Two_element_array_should_be_sorted_and_split_into_two_empty_arrays()
		{
			var array = new int[] { 44, 33 };
			var source = new ArraySegment<int>(array);

			var target = new SplitByMedianItem(source);

			Assert.AreEqual(0, target.LeftSplit.Count, "LeftSplit count");
			Assert.AreEqual(0, target.RightSplit.Count, "RightSplit count");

			Assert.AreEqual(33, array[0], "first item");
			Assert.AreEqual(44, array[1], "second item");
		}

		[Test]
		public void One_element_array_should_split_into_two_empty_arrays()
		{
			var source = new ArraySegment<int>(new int[] { 33 });

			var target = new SplitByMedianItem(source);

			Assert.AreEqual(0, target.LeftSplit.Count, "LeftSplit count");
			Assert.AreEqual(0, target.RightSplit.Count, "RightSplit count");
		}

		[Test]
		public void Empty_array_should_split_into_two_empty_arrays()
		{
			var source = new ArraySegment<int>(new int[0]);

			var target = new SplitByMedianItem(source);

			Assert.AreEqual(0, target.LeftSplit.Count, "LeftSplit count");
			Assert.AreEqual(0, target.RightSplit.Count, "RightSplit count");
		}



		public static T[] SegmentToArray<T>(ArraySegment<T> segment)
		{
			T[] array = new T[segment.Count];
			for (int i = 0; i <= segment.Upperbound(); ++i)
			{
				array[i] = segment.GetSegmentItem(i);
			}

			return array;
		}
	}
}
