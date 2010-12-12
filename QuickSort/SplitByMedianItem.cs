
using System;
using System.Collections.Generic;

namespace QuickSort
{
	public class SplitByMedianItem: ISortProblem
	{
		private ArraySegment<int> source;

		public ArraySegment<int> LeftSplit { get; private set; }
		public ArraySegment<int> RightSplit { get; private set; }

		public SplitByMedianItem(int[] source) : this(new ArraySegment<int>(source)) 
		{
		}

		public SplitByMedianItem(ArraySegment<int> source) 
		{
			this.source = source;

			if (source.Count == 0)
			{
				return;
			}

			int left = 0;
			int right = source.Upperbound();
			int median = source.GetSegmentItem(source.Upperbound() / 2);

			do
			{
				while (source.GetSegmentItem(left) < median)
				{
					++left;
				}

				while (median < source.GetSegmentItem(right))
				{
					--right;					
				}

				if (left <= right)
				{
					source.SwapItems(left, right);
					++left; 
					--right;
				}

			} while (left <= right);

			if (0 < right)
			{
				LeftSplit = source.CreateSubSegment(0, right);				
			}

			if (left < source.Upperbound())
			{
				RightSplit = source.CreateSubSegment(left, source.Upperbound());				
			}

		}

		bool ISortProblem.IsBasicCase
		{
			get
			{
				return (source.Count <= 2);
			}
		}

		IEnumerable<ISortProblem> ISortProblem.GetReducedProblems()
		{
			var result = new ISortProblem[2];
			result[0] = new SplitByMedianItem(LeftSplit);
			result[1] = new SplitByMedianItem(RightSplit);
			return result;
		}
	}
}
