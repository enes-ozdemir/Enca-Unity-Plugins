using System;
using System.Collections.Generic;

namespace Editor.Extensions
{
    public static class Entensions
    {
        public static int ToInt(this float floatNumber) => Convert.ToInt32(floatNumber);
        public static int ToInt(this double doubleNumber) => Convert.ToInt32(doubleNumber);

        public static T SelectRandomItem<T>(this List<T> list)
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("Cannot select a random element from an empty list");
            }

            var randomIndex = Random.GetRandomNumber(list.Count).ToInt();
            return list[randomIndex];
        }
        
        public static T SelectRandomItem<T>(this T[] array) {
            return array[Random.GetRandomNumber(array.Length).ToInt()];
        }
    }
}