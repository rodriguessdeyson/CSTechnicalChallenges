namespace CSTechnicalChallenges.Domain
{
	/// <summary>
	/// Extende as funcionalidades para um Array[] de int64.
	/// </summary>
	public static class IntegerArrayExtension
	{
		/// <summary>
		/// Realiza a soma de um conjunto de números inteiros.
		/// </summary>
		/// <param name="numbers">Conjunto de números inteiros.</param>
		/// <returns>Soma de todos os elementos do conjunto.</returns>
		public static long Sum(this long[] numbers)
		{
			int numElements = numbers.Length;
			
			// Limite máximo para iteração for single thread.
			const int splitSize = 10000;

			long sum = 0;
			if (numElements <= splitSize)
			{
				for (int elementIndex = 0; elementIndex < numElements; elementIndex++)
				{
					long element = numbers[elementIndex];
					sum += element;
				}
			}
			else
			{
				Parallel.For(0, numElements / splitSize, (element) =>
				{
					int startIndex = element * splitSize;
					int endIndex = Math.Min(startIndex + splitSize, numElements);
					long localSum = 0;

					for (int j = startIndex; j < endIndex; j++)
					{
						localSum += numbers[j];
					}

					Interlocked.Add(ref sum, localSum);
				});

				// Resto de soma, se houver
				for (int index = (numElements / splitSize) * splitSize; index < numElements; index++)
				{
					sum += numbers[index];
				}
			}

			return sum;
		}
	}
}
