using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stufkan.Game
{
    /// <summary>
    /// Contains a method to cast an array of one type to an array of another type
    /// </summary>
    public static class PieceExtension
    {
        /// <summary>
        /// Copies all the pieces from an array to the output array
        /// </summary>
        /// <typeparam name="T">The type to copy from</typeparam>
        /// <typeparam name="R">The type to copy to</typeparam>
        /// <param name="array">The array to copy from</param>
        /// <param name="result">The array to copy to</param>
        public static void CastArray<T, R>(this T[,] array, out R[,] result) where R : T
        {
            R[,] newArray = new R[array.GetLength(0), array.GetLength(1)];

            Array.Copy(array, newArray, array.Length);

            result= newArray;
        }
    }
}
