
namespace QuickSort
{
	public class RecursiveQuickSort : ISortProblemSolver
	{

		public void Sort(int[] arrayToBeSorted)
		{
			ISortProblem sortProblem = new SplitByMedianItem(arrayToBeSorted);
			RecursivelySolveSortProblem(sortProblem);
		}

		public void RecursivelySolveSortProblem(ISortProblem sortProblem)
		{
			var reducedSortProblemSolver = this;
			reducedSortProblemSolver.ReduceThenSolveReducedProblems(sortProblem, reducedSortProblemSolver);
		}

		public void ReduceThenSolveReducedProblems(ISortProblem sortProblem, ISortProblemSolver reducedSortProblemSolver)
		{
			if (sortProblem.IsBasicCase)
			{
				return;
			}

			var reducedProblems = sortProblem.GetReducedProblems();
			foreach (var problem in reducedProblems)
			{
				reducedSortProblemSolver.SolveReducedProblem(problem);
			}
		}

		void ISortProblemSolver.SolveReducedProblem(ISortProblem sortProblem)
		{
			RecursivelySolveSortProblem(sortProblem);
		}
	}
}
