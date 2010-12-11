using System;

namespace QuickSort
{
	public static class ArraySegmentExtension
	{
		public static T GetSegmentItem<T>(this ArraySegment<T> segment, int index)
		{
			return segment.Array[segment.Offset + index];
		}

		public static void SetSegmentItem<T>(this ArraySegment<T> segment, int index, T value)
		{
			segment.Array[segment.Offset + index] = value;
		}

		public static ArraySegment<T> CreateSubSegment<T>(this ArraySegment<T> segment, int lowerbound, int upperbound)
		{
			var offset = segment.Offset + lowerbound;
			var count = upperbound - lowerbound +1;
			return new ArraySegment<T>(segment.Array, offset, count);
		}

		public static int Upperbound<T>(this ArraySegment<T> segment)
		{
			return segment.Count - 1;
		}

		public static void SwapItems<T>(this ArraySegment<T> segment, int i, int j)
		{
			T val = segment.GetSegmentItem(i);
			segment.SetSegmentItem(i, segment.GetSegmentItem(j));
			segment.SetSegmentItem(j, val);
		}

	}
}