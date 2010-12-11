
using System;

namespace QuickSort
{
	public class SplitByMedianItem
	{
		public ArraySegment<int> LeftSplit;
		public ArraySegment<int> RightSplit;

		public SplitByMedianItem(ArraySegment<int> source)
		{

			if (source.Count == 0)
				return; 

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
	}
}
