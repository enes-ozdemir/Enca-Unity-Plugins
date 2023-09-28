using System;
using System.Collections.Generic;
using Random = Enca.Extensions.Random;

namespace Enca.Extensions
{
    public static class Extensions
    {
        /// <summary>
        ///     Convert Float value to Integer.
        /// </summary>
        /// <param name="floatNumber"></param>
        public static int ToInt(this float floatNumber) => Convert.ToInt32(floatNumber);

        /// <summary>
        ///     Convert Double value to Integer.
        /// </summary>
        /// <param name="doubleNumber"></param>
        public static int ToInt(this double doubleNumber) => Convert.ToInt32(doubleNumber);

        /// <summary>
        ///     Convert String value to Integer.
        /// </summary>
        /// <param name="text"></param>
        public static int ToInt(this string text) => Convert.ToInt32(text);

        /// <summary>
        ///     Get random item from given list.
        /// </summary>
        /// <param name="List"></param>
        public static T SelectRandomItem<T>(this List<T> list)
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("Cannot select a random item from an empty list");
            }

            var randomIndex = Random.GetRandomNumber(list.Count);
            return list[randomIndex];
        }

        /// <summary>
        ///     Get random item from given list.
        /// </summary>
        /// <param name="array"></param>
        public static T SelectRandomItem<T>(this T[] array)
        {
            return array[Random.GetRandomNumber(array.Length)];
        }

        /// <summary>
        /// Merges an unknown number of lists into a single list.
        /// </summary>
        /// <typeparam name="T">The type of elements in the lists.</typeparam>
        /// <param name="lists">An array of lists to be merged.</param>
        /// <returns>A new List containing all the elements from the input lists.</returns>
        public static List<T> MergeLists<T>(params List<T>[] lists)
        {
            var mergedList = new List<T>();

            foreach (var list in lists)
            {
                mergedList.AddRange(list);
            }

            return mergedList;
        }
    }
}