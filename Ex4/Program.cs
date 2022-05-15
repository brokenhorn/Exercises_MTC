using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Ex4
{
    class Program
    {
	    static void Swap<T>(ref T lhs, ref T rhs)
	    {
		    T temp;
		    temp = lhs;
		    lhs = rhs;
		    rhs = temp;
	    }

		static void QuickSort(int[] arr, int start, int end)
		{
			int i;
			if (start < end)
			{
				i = Partition(arr, start, end);

				QuickSort(arr, start, i - 1);
				QuickSort(arr, i + 1, end);
			}
		}

		static int Partition(int[] arr, int start, int end)
		{
			int temp;
			int p = arr[end];
			int i = start - 1;

			for (int j = start; j <= end - 1; j++)
			{
				if (arr[j] <= p)
				{
					i++;
					temp = arr[i];
					arr[i] = arr[j];
					arr[j] = temp;
				}
			}

			temp = arr[i + 1];
			arr[i + 1] = arr[end];
			arr[end] = temp;
			return i + 1;
		}

		/// <summary>
		/// Возвращает отсортированный по возрастанию поток чисел
		/// </summary>
		/// <param name="inputStream">Поток чисел от 0 до maxValue. Длина потока не превышает миллиарда чисел.</param>
		/// <param name="sortFactor">Фактор упорядоченности потока. Неотрицательное число. Если в потоке встретилось число x, то в нём больше не встретятся числа меньше, чем (x - sortFactor).</param>
		/// <param name="maxValue">Максимально возможное значение чисел в потоке. Неотрицательное число, не превышающее 2000.</param>
		/// <returns>Отсортированный по возрастанию поток чисел.</returns>
		static IEnumerable<int> Sort(IEnumerable<int> inputStream, int sortFactor, int maxValue)
        {
	        int[] array         = inputStream.ToArray();
	        int pivot           = -1;
	        int firstGreaterVal = -1;

			for (int i = 0; i < inputStream.Count() - 1; i++)
	        {
		        if (array[i] > sortFactor)
		        {
			        if (array[i + 1] < sortFactor & firstGreaterVal != -1)
			        {
				        Swap(ref array[firstGreaterVal], ref array[i + 1]);
				        if (array[firstGreaterVal + 1] > sortFactor)
					        firstGreaterVal = firstGreaterVal + 1;
			        }
			        else if (array[i + 1] < sortFactor & firstGreaterVal == -1)
			        {
				        Swap(ref array[i], ref array[i + 1]);
				        firstGreaterVal = i + 1;
			        }
					else if (firstGreaterVal == -1)
			        {
				        firstGreaterVal = i;
			        }
		        }

		        if (array[i] == sortFactor)
		        {
			        if (firstGreaterVal != -1)
			        {
				        Swap(ref array[i], ref array[firstGreaterVal]);
				        pivot = firstGreaterVal;
			        }
					else
						pivot = i;
			        break;
				}
	        }

			if (pivot > 1)
		        QuickSort(array, 0, pivot - 1);
	        if (pivot + 1 < inputStream.Count()- 1)
		        QuickSort(array, pivot + 1, inputStream.Count() - 1);
	        
	        return array;
        }

        static void Main(string[] args)
        {


		        Random rnd        = new Random();
		        int streamLength  = rnd.Next(9, 10);
		        int sortFactor    = 50;
		        int maxValue      = 2000;
		        int sortFactorPos = rnd.Next(0, streamLength - 1);
		        List<int> a       = new List<int>(streamLength);

		        for (int i = 0; i < streamLength; i++)
		        {
			        if (i == sortFactorPos)
				        a.Add(sortFactor);
					else if (i > sortFactorPos)
				        a.Add(rnd.Next(sortFactor, maxValue + 1));
			        else if (i < sortFactorPos)
			        {
				        int tmp = rnd.Next(1, 3);
				        switch (tmp)
				        {
					        case 1:
						        a.Add(rnd.Next(0, sortFactor));
						        break;
					        case 2:
						        a.Add(rnd.Next(sortFactor + 1, maxValue + 1));
						        break;
				        }
			        }
		        }

		        IEnumerable<int> test = Sort(a, sortFactor, maxValue);
		        a.Sort();
				
		        bool answer1 = Enumerable.SequenceEqual(test, a);
        }
    }
}
