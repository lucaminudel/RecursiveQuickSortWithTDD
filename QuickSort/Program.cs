using System;
using System.Collections.Generic;

namespace QuickSort
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Inserisci l'array di interi da ordinare (es: 1, 3, -10, 33): ");
			string input = Console.ReadLine();
			string[] numbers = input.Split(',');
			
			List<int> validNumgersAsInt = new List<int>();
			foreach (var s in numbers)
			{

				try
				{
					int i = int.Parse(s);
					validNumgersAsInt.Add(i);
				}
				catch (FormatException)
				{
					continue;
				}
			}

			var quickSort = new RecursiveQuickSort();

			int[] arrayToBeSorted = validNumgersAsInt.ToArray();
			quickSort.Sort(arrayToBeSorted);

			foreach (var i in arrayToBeSorted)
			{
				Console.Write(i + " ");
			}

			Console.WriteLine();
		}
	}
}
