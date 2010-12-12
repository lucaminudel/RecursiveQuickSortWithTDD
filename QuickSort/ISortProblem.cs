using System.Collections.Generic;

namespace QuickSort
{
	public interface ISortProblem
	{
		IEnumerable<ISortProblem> GetReducedProblems();
		bool IsBasicCase { get; }
	}
}
