using System;
using System.Collections.Generic;

namespace QuickSort.Tests
{
	public class MockSortProblem : ISortProblem
	{
		private bool? isBasicCase = null;
		private int isBasicCaseExpectedCallCount = 0;
		private int isBasicCaseCallCount = 0;

		private IEnumerable<ISortProblem> getReducedProblems = null;
		private int getReducedProblemsExpectedCallCount = 0;
		private int getReducedProblemsCallCount = 0;

		public void SetExpectedCall_IsBasicCase(bool returnValue)
		{
			isBasicCase = returnValue;
			isBasicCaseExpectedCallCount = 1;
		}

		public void SetExpectedCall_GetReducedProblems(IEnumerable<ISortProblem> returnValue)
		{
			getReducedProblems = returnValue;
			getReducedProblemsExpectedCallCount = 1;
		}

		public void VerifyExpectations()
		{
			if (isBasicCaseCallCount != isBasicCaseExpectedCallCount)
			{
				throw new InvalidOperationException(string.Format("Expected calls to IsBasicCase: {0}, done: {1}", isBasicCaseExpectedCallCount, isBasicCaseCallCount));				
			}

			if (getReducedProblemsCallCount != getReducedProblemsExpectedCallCount)
			{
				throw new InvalidOperationException(string.Format("Expected calls to GetReducedProblems: {0}, done: {1}", getReducedProblemsExpectedCallCount, getReducedProblemsCallCount));								
			}
		}


		bool ISortProblem.IsBasicCase
		{
			get
			{
				++isBasicCaseCallCount;
				return isBasicCase.Value;
			}
		}

		IEnumerable<ISortProblem> ISortProblem.GetReducedProblems()
		{
			++getReducedProblemsCallCount;
			return getReducedProblems;
		}


	}
}