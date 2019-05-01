using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructTree_InorderLevelOrder
{
    public static class ArrayUtility
    {
        public static int[] GetArrayFromUser() {
            int[] array = null;

            Console.WriteLine("Enter the number of elements in the array");
            try
            {
                int numberOfElements = int.Parse(Console.ReadLine().Trim());
                array = new int[numberOfElements];
                Console.WriteLine("Enter the elements separated by space, comma or semi-colon");
                String[] elements = Console.ReadLine().Trim().Split(' ', ',', ';');
                for (int index = 0; index < numberOfElements; index++) {
                    array[index] = int.Parse(elements[index]);
                }

            }catch (Exception exception) {
                Console.WriteLine("Thrown exception is "+exception.Message);
            }
            return array;
        }
    }
}
