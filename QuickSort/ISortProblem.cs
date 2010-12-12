using System.Collections.Generic;

namespace QuickSort
{
	public interface ISortProblem
	{
		bool IsBasicCase { get; }
		IEnumerable<ISortProblem> GetReducedProblems();
	}
}
