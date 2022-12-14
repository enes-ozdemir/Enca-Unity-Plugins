using System;
using System.Collections.Generic;

namespace Editor.Extensions
{
    public static class Entensions
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

            var randomIndex = Random.GetRandomNumber(list.Count).ToInt();
            return list[randomIndex];
        }

        /// <summary>
        ///     Get random item from given list.
        /// </summary>
        /// <param name="array"></param>
        public static T SelectRandomItem<T>(this T[] array)
        {
            return array[Random.GetRandomNumber(array.Length).ToInt()];
        }
    }
}