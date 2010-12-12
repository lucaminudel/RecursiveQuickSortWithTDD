
using System;
using System.Collections.Generic;

namespace QuickSort
{
	public class SplitByMedianItem: ISortProblem
	{
		public ArraySegment<int> LeftSplit;
		public ArraySegment<int> RightSplit;
		private ArraySegment<int> source;

		public SplitByMedianItem(ArraySegment<int> source)
		{
			this.source = source;

			if (IsBasicCase)
			{
				return; 				
			}

			int i = 0; 
			int j = source.Upperbound();
			int median = source.GetSegmentItem(source.Upperbound() / 2);

			do
			{
				while ((source.GetSegmentItem(i) < median) && (i < source.Upperbound()))
					i++;
				while ((median < source.GetSegmentItem(j)) && (j > 0))
					j--;

				if (i <= j)
				{
					source.SwapItems(i, j);
					i++; j--;
				}

			} while (i <= j);

			if (0 < j)
				LeftSplit = source.CreateSubSegment(0, j);

			if (i < source.Upperbound())
				RightSplit = source.CreateSubSegment(i, source.Upperbound());

		}

		public IEnumerable<ISortProblem> GetReducedProblems()
		{
			var result = new List<ISortProblem>();
			result.Add(new SplitByMedianItem(LeftSplit));
			result.Add(new SplitByMedianItem(RightSplit));

			return result;
		}


		public bool IsBasicCase
		{
			get
			{
				bool isBasicCase = (source.Count == 0);
				return isBasicCase;
			}
		}

	}
}
