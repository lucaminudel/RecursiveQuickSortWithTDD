using System.Collections.Generic;
using NUnit.Framework;

namespace QuickSort.Tests
{
	[TestFixture]
	public class RecursiveQuickSortTest
	{
		[Test]
		public void ReduceThenSolveReducedProblems_just_finish_with_basic_case_sort_problem()
		{
			var mockSortProblem = new MockSortProblem();
			mockSortProblem.SetExpectedCall_IsBasicCase(true);
			ISortProblemSolver reducedSortProblemSolver = null;
			var target = new RecursiveQuickSort();

			target.ReduceThenSolveReducedProblems(mockSortProblem, reducedSortProblemSolver);

			mockSortProblem.VerifyExpectations();
		}

		[Test]
		public void ReduceThenSolveReducedProblems_with_non_basic_case_sort_problem_send_reduced_problems_to_the_solver()
		{
			var mockSortProblem = new MockSortProblem();
			mockSortProblem.SetExpectedCall_IsBasicCase(false);
			ISortProblem reducedProblem1 = new MockSortProblem();
			ISortProblem reducedProblem2 = new MockSortProblem();
			IEnumerable<ISortProblem> reducedProblems = new[] {reducedProblem1, reducedProblem2};
			mockSortProblem.SetExpectedCall_GetReducedProblems(reducedProblems);
					
			var mockReducedSortProblemSolver = new MockSortProblemSolver();
			mockReducedSortProblemSolver.SetExpectedCall_CalculateSortProblemReduction(reducedProblem1);
			mockReducedSortProblemSolver.SetExpectedCall_CalculateSortProblemReduction(reducedProblem2);


			var target = new RecursiveQuickSort();
			target.ReduceThenSolveReducedProblems(mockSortProblem, mockReducedSortProblemSolver);


			mockSortProblem.VerifyExpectations();
			mockReducedSortProblemSolver.VerifyExpectations();
		}
	}
}
