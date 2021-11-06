using System;
using System.Collections.Generic;

namespace CollectionsMasterConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Follow the steps provided in the comments under each region.
            //Make the console formatted to display each section well
            //Utlilize the method stubs at the bottom for the methods you must create

            #region Arrays
            // Create an integer Array of size 50
            int[] myArray = new int[50];
            int[] originalArray = new int[50];


            //Create a method to populate the number array with 50 random numbers that are between 0 and 50
            Populater(myArray);


            //make a copy of the original populated array
            myArray.CopyTo(originalArray,0);


            //Print the first number of the array
            Console.WriteLine($"The value in the first element of the array is {myArray[0]}");

            //Print the last number of the array
            Console.WriteLine($"And the value in the last element of the array is {myArray[myArray.Length-1]}");

            Console.WriteLine("All Numbers Original");
            //Use this method to print out your numbers from arrays or lists
            NumberPrinter(myArray);
            Console.WriteLine("-------------------");

            //Reverse the contents of the array and then print the array out to the console.
            //Try for 2 different ways
            /*     Hint: Array._____(); Create a custom method     */


            //Create a new array and copy the origianl array into it so we can reverse all the elements
            int[] reverseArray = new int[50];
            originalArray.CopyTo(reverseArray, 0);

            //Call custom method to reverse the elements of the reversedArray array
            ReverseArray(reverseArray);

            //Use the Array.Reverse method to reverse the elements of the myArray array
            Array.Reverse(myArray);


            Console.WriteLine("All Numbers Reversed (as a result of Array.Reverse:");
            NumberPrinter(myArray);

            Console.WriteLine("---------REVERSE CUSTOM------------");
            NumberPrinter(reverseArray);

            Console.WriteLine("-------------------");

            //Create a method that will set numbers that are a multiple of 3 to zero then print to the console all numbers
            Console.WriteLine("Multiple of three = 0: ");

            //Create a new array and copy the origianl array into it so we can look for multiples of 3
            int[] multipleOf3Array = new int[50];
            originalArray.CopyTo(multipleOf3Array, 0);

            //Call custom method to determine if array elements are a multiple of 3 and if they are zero them out
            ThreeKiller(multipleOf3Array);

            NumberPrinter(multipleOf3Array);

            Console.WriteLine("-------------------");

            //Sort the array in order now
            /*      Hint: Array.____()      */
            Array.Sort(multipleOf3Array);
            Console.WriteLine("Sorted numbers:");
            NumberPrinter(multipleOf3Array);

            Console.WriteLine("\n************End Arrays*************** \n");
            #endregion

            #region Lists
            Console.WriteLine("************Start Lists**************");

            /*   Set Up   */
            //Create an integer List

            List<int> intList = new List<int>();

            //Print the capacity of the list to the console

            Console.WriteLine($"Although, the capacity of a list is inherantly unlimited, there are currently {intList.Count} items in the list.");


            //Populate the List with 50 random numbers between 0 and 50 you will need a method for this            
            Populater(intList);

            //Print the new capacity

            Console.WriteLine($"Although, the capacity of a list is inherantly unlimited, there are currently {intList.Count} items in the list.");


            Console.WriteLine("---------------------");

            //Create a method that prints if a user number is present in the list
            //Remember: What if the user types "abc" accident your app should handle that!

            Boolean validInput = false;

            do
            {
                Console.WriteLine("What number will you search for in the number list?");
                int userInput = 0; 
                bool intResultTryParse = int.TryParse(Console.ReadLine(), out userInput);

                if (intResultTryParse == true)
                {
                    validInput = true;
                    NumberChecker(intList, userInput);
                } else
                {
                    Console.WriteLine("Sorry, but you did not type in an integer.  Try again.");
                }
            }
            while(validInput == false);

            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers:");
            //Print all numbers in the list
            NumberPrinter(intList);
            Console.WriteLine("-------------------");

            //Create a method that will remove all odd numbers from the list then print results
            Console.WriteLine("Evens Only!!");
            OddKiller(intList);
            Console.WriteLine("");
            Console.WriteLine($"I have removed all the odd numbers from the list.  Now there are only {intList.Count} items in the list");
            NumberPrinter(intList);

            Console.WriteLine("------------------");

            //Sort the list then print results
            Console.WriteLine("Sorted Evens!!");
            intList.Sort();
            Console.WriteLine("");
            Console.WriteLine("And here is the list sorted.");
            NumberPrinter(intList);


            Console.WriteLine("------------------");

            //Convert the list to an array and store that into a variable
            int[] toArray = new int[intList.Count];
            toArray = intList.ToArray();

            //Clear the list
            intList.Clear();

            Console.WriteLine("You didn't ask, but here is a print out of the array as a result of the list converting to an array");
            NumberPrinter(toArray);
            Console.WriteLine("");
            Console.WriteLine($"And just so you know, the number of elements left in the list after the clear method executed is {intList.Count}");



            #endregion
        }

        private static void NumberPrinter(int[] passedArray)
        {
            for (var i = 0; i < passedArray.Length; i++)
            {
                Console.WriteLine($"The value in array element {i} is {passedArray[i]}");
            }
        }

        private static void ThreeKiller(int[] numbers)
        {
            for (var i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 3 == 0)
                {
                    numbers[i] = 0;
                }
            }

        }

        private static void OddKiller(List<int> numberList)
        {
            List<int> localList = new List<int>(numberList);

            foreach (int number in localList)
            {
                if (number%2 != 0)
                {
                    numberList.Remove(number);
                }
            }
            numberList = localList;
        }

        private static void NumberChecker(List<int> numberList, int searchNumber)
        {
            bool foundNumber = false;

            foreach (int number in numberList)
            {
                if (number == searchNumber)
                {
                    if (foundNumber == false)
                    {
                        foundNumber = true;
                        Console.WriteLine($"Hay!, Your number ({searchNumber}) was found in my list!");
                    } else
                    {
                        Console.WriteLine("Guess what?  I found your number in my list again.");
                    }
                }
            }
            
        }

        private static void Populater(List<int> numberList)
        {
            Random rng = new Random();
            for (var i = 0;i<50;i++)
            {
                numberList.Add(rng.Next(0,50));
            }
        }

        private static void Populater(int[] numbers)
        {
            Random rng = new Random();
            for (var i=0;i<numbers.Length;i++)
            {
                numbers[i] = rng.Next(0,50);
            }

        }        

        private static void ReverseArray(int[] array)
        {
            int[] localArray = new int[50];

            array.CopyTo(localArray,0);

            for (var i = 0; i < 50; i++)
            {
                array[49 - i] = localArray[i];
            }
        }

        /// <summary>
        /// Generic print method will iterate over any collection that implements IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"> Must conform to IEnumerable</typeparam>
        /// <param name="collection"></param>
        private static void NumberPrinter<T>(T collection) where T : IEnumerable<int>
        {
            //STAY OUT DO NOT MODIFY!!
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
