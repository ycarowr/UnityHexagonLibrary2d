using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tools.Extensions.Arrays
{
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        ///     Returns a random item from inside the array.
        /// </summary>
        public static T RandomItem<T>(this T[] array)
        {
            if (array.Length == 0)
                throw new IndexOutOfRangeException("Array is Empty");

            var randomIndex = Random.Range(0, array.Length);
            return array[randomIndex];
        }

        /// <summary>
        ///     Shuffles the List using Fisher Yates algorithm: https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle.
        /// </summary>
        public static void Shuffle<T>(this T[] array)
        {
            var n = array.Length;
            for (var i = 0; i <= n - 2; i++)
            {
                //random index
                var rdn = Random.Range(0, n - i);

                //swap positions
                var curVal = array[i];
                array[i] = array[i + rdn];
                array[i + rdn] = curVal;
            }
        }

        /// <summary>
        ///     Prints the list in the following format: [item[0], item[1], ... , item[Count-1]]
        /// </summary>
        public static void Print<T>(this T[] array, string log = "")
        {
            log += "[";
            for (var i = 0; i < array.Length; i++)
            {
                log += array[i].ToString();
                log += i != array.Length - 1 ? ", " : "]";
            }

            Debug.Log(log);
        }
    }
}