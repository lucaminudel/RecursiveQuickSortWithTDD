using System;

namespace QuickSort
{
	public class RecursiveQuickSort : IRecursiveQuickSort
	{

		public void CalculateSortProblemReduction(ISortProblem sortProblem)
		{
			CalculateSortProblemReduction(sortProblem, this);
		}

		public void CalculateSortProblemReduction(ISortProblem sortProblem, IRecursiveQuickSort reducedSortProblemSolver)
		{
			if (sortProblem.IsBasicCase)
			{
				return;
			}

			var reducedProblems = sortProblem.GetReducedProblems();
			foreach (var reducedProblem in reducedProblems)
			{
				reducedSortProblemSolver.CalculateSortProblemReduction(reducedProblem);
			}
		}

		public void Sort(int[] arrayToBeSorted)
		{
			CalculateSortProblemReduction(new SplitByMedianItem(new ArraySegment<int>(arrayToBeSorted)));
		}
	}
}
