using System;

namespace LargestSubArrayWithEqualNumberOfZeroesAndOnes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Longest Subarray with equal number of zeroes and ones!");
            Console.WriteLine("------------------------------------------------------");

            int[] array = GetArrayFromUserInput();
            PrintLongestSubArrayWithEqualNumberOfZeroesAndOnes(array);

            Console.ReadLine();
        }

        private static int[] GetArrayFromUserInput(){
            int[] array = null;
            Console.WriteLine("Enter the number of elements in the array");
            try{
                int sizeofArray = int.Parse(Console.ReadLine().Trim());
                array = new int[sizeofArray];
                Console.WriteLine("Enter the elements of the array separated" +
                    " by space, comma or semi-colon");
                String[] elements = Console.ReadLine().Trim().Split(' ', ',', ';');
                for (int arrayIndex = 0; arrayIndex < sizeofArray; arrayIndex++) {
                    array[arrayIndex] = int.Parse(elements[arrayIndex]);
                }
            }
            catch (Exception exception) {
                Console.WriteLine("Thrown exception is "+exception.Message);
            }
            return array;
        }

        private static void PrintLongestSubArrayWithEqualNumberOfZeroesAndOnes(int[] array) {

            int maxLength = int.MinValue;
            int startIndex = 0;
            int countOf1s = 0;
            int countOf0s = 0;

            for (int index = 0; index < array.Length; index++) {
                if (array[index] == 0)
                {
                    countOf0s++;
                }
                else {
                    countOf1s++;
                }
                for (int secIndex = index + 1; secIndex < array.Length; secIndex++) {
                    if (array[secIndex] == 0)
                    {
                        countOf0s++;
                    }
                    else
                    {
                        countOf1s++;
                    }
                    if (countOf0s == countOf1s && 
                        (maxLength < secIndex - index + 1)) {
                        startIndex = index;
                        maxLength = secIndex - index + 1;                        
                    }
                }
            }
            Console.WriteLine("The longest subarray with equal number of zeroes " +
                "and ones lies between "+startIndex + "and" +
                maxLength-1);
        }
    }
}
