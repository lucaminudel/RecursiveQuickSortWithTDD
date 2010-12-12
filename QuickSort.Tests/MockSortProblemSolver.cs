using System;
using System.Collections.Generic;

namespace QuickSort.Tests
{
	class MockSortProblemSolver : ISortProblemSolver
	{
		private readonly List<ISortProblem> calculateSortProblemReduction = new List<ISortProblem>();
		private int calculateSortProblemReductionExpectedCallCount = 0;
		private int calculateSortProblemReductionCallCount = 0;

		public void SetExpectedCall_CalculateSortProblemReduction(ISortProblem parameterExpectedValue)
		{
			calculateSortProblemReduction.Add(parameterExpectedValue);
			++calculateSortProblemReductionExpectedCallCount;
		}

		public void VerifyExpectations()
		{
			if (calculateSortProblemReductionCallCount != calculateSortProblemReductionExpectedCallCount)
			{
				throw new InvalidOperationException(string.Format("Expected calls to IsBasicCase: {0}, done: {1}", calculateSortProblemReductionExpectedCallCount, calculateSortProblemReductionCallCount));
			}
		}


		void ISortProblemSolver.SolveReducedProblem(ISortProblem sortProblem)
		{
			if (sortProblem != calculateSortProblemReduction[calculateSortProblemReductionCallCount])
			{
				throw new InvalidOperationException(string.Format("Expected value for sortProblem: {0}, actual: {1}", calculateSortProblemReduction[calculateSortProblemReductionCallCount], sortProblem));
			}

			++calculateSortProblemReductionCallCount;
		}

		public void Sort(int[] arrayToBeSorted)
		{
			throw new NotImplementedException();
		}
	}
}
