namespace QuickSort
{
	public interface IRecursiveQuickSort
	{
		void CalculateSortProblemReduction(ISortProblem sortProblem);
		void Sort(int[] arrayToBeSorted);
	}
}