using System;
using System.Linq;


//static double Average(int[] array)
//{
//    double sum = 0;
//	foreach (var number in array)
//	{
//		sum += number;
//	}
//	return sum/array.Length;
//}

//static double ClosestToAverage(int[] array)
//{
//	int closestToAverage = array[0];
//	double distance = 0;
//    double average = array.Average();
//    double minDistance = average;

//    for (int i=0;i<array.Length;i++)
//	{
//		distance = Math.Abs(average - array[i]);
//		if(distance < minDistance)
//		{
//			minDistance = distance;
//			closestToAverage=array[i];
//		}
//    }
//	return closestToAverage;
//}

//static int[] NewArray(int[] oldArray,int index,int element)
//{
//	int[] newArray = new int[oldArray.Length + 1];

//	for (int i = 0; i < oldArray.Length; i++)
//	{
//		if(i<index)
//		{
//			newArray[i] = oldArray[i];
//		}
//		else if(i==index)
//		{
//			newArray[i] = element;
//			newArray[i+1] = oldArray[i];
//		}
//		else
//		{
//			newArray[i + 1] = oldArray[i];
//        }
//	}
//	return newArray;
//}

//static int[] RemoveElement(int[] oldArray, int index)
//{
//    int[] newArray = new int[oldArray.Length -1];

//    for (int i = 0; i < oldArray.Length; i++)
//    {
//        if (i < index)
//        {
//            newArray[i] = oldArray[i];
//        }
//        else if (i == index)
//        {
//            continue;
//        }
//        else
//        {
//            newArray[i-1] = oldArray[i];
//        }
//    }
//    return newArray;
//}

//Console.WriteLine(Average(array));
//Console.WriteLine(ClosestToAverage(array));
//Console.WriteLine(String.Join(", ", NewArray(array,3,65)));
//Console.WriteLine(String.Join(", ", RemoveElement(array, 3)));
//Console.WriteLine(String.Join(", ", CombinedSortedArray(firstArray, secondArray)));

//static int[] CombinedSortedArray(int[] firstArray, int[] secondArray)
//{
//	int[] resultArray=new int[firstArray.Length+secondArray.Length];
//    int indexOne = 0;
//    int indexTwo = 0;
//    for (int i = 0; i < resultArray.Length; i++)
//	{
//        if(indexOne==firstArray.Length)
//        {
//            resultArray[i] = secondArray[indexTwo];
//        }
//        else if(indexTwo==secondArray.Length)
//        {
//            resultArray[i] = firstArray[indexOne];
//        }
//        else
//        {
//            if (firstArray[indexOne] <= secondArray[indexTwo])
//            {
//                resultArray[i] = firstArray[indexOne];
//                indexOne++;
//            }
//            else
//            {
//                resultArray[i] = secondArray[indexTwo];
//                indexTwo++;
//            }
//        }
//	}
//    return resultArray;
//}

//static bool[] EratostenPrimeNumbers(int n)
//{
//    bool[] numbers=new bool[n+1];
//	for (int i = 0; i < numbers.Length; i++)
//	{
//		numbers[i] = true;
//	}

//	for (int i = 2; i < numbers.Length; i++)
//	{
//		if (numbers[i]==true)
//		{
//			for (int j = i+i; j < numbers.Length; j+=i)
//			{
//				numbers[j] = false;
//			}
//		}
//	}
//	return numbers;
//}

//static int DoubleSearch(int[] numbers, int element)
//{
//	int left = 0;
//	int right= numbers.Length;
//	int middle = (left + right )/ 2;
//	while(left<=right)
//	{		
//		if (element < numbers[middle])
//		{
//			right = middle-1;
//			middle=(left + right) / 2;
//		}
//		else if (element > numbers[middle])
//		{
//			left= middle+1;
//            middle = (left + right) / 2;
//        }
//		else
//		{
//			return middle;
//		}
//	}
//	return -1;
//}

//int searchedElement = int.Parse(Console.ReadLine());

//Console.WriteLine(DoubleSearch(numbers,searchedElement));


int[] numbers = { 1, 3, 5, 7, 9 ,3,53,23,21,4};


//Bubble Sort
//for (int i = 0; i < numbers.Length; i++)
//{
//	for (int j = i+1; j < numbers.Length; j++)
//	{
//		if (numbers[i] > numbers[j])
//		{
//			int k = numbers[i];
//			numbers[i] = numbers[j];
//			numbers[j] = k;
//		}
//	}
//}


Console.WriteLine(String.Join(", ",numbers));
