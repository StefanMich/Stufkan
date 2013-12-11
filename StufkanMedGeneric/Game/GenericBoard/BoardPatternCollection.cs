using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Stufkan.Game
{
    /// <summary>
    /// A collection of LifePatterns with a describing name
    /// </summary>
    [Serializable()]
    public class BoardPatternCollection<T> : BoardPattern<T>, IEnumerable<BoardPattern<T>>
    {
        List<BoardPattern<T>> patternCollection;


        /// <summary>
        /// gets the grid from the first pattern in the collection 
        /// </summary>
        public override T[,] Grid
        {
            get
            {
                T[,] temp;
                if (patternCollection.Count > 0)
                    temp = patternCollection[0].Grid;
                else temp = new T[5, 5];
                return temp;
            }
        }

        /// <summary>
        /// Creates a LifePatternCollection with a name
        /// </summary>
        /// <param name="name">the name to describe the collection of LifePatterns</param>
        public BoardPatternCollection(string name)
        {
            base.Name = name;
            patternCollection = new List<BoardPattern<T>>();
        }

        /// <summary>
        /// Searches for the LifePattern and returns the zerobased index of the first instance of the LifePattern
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(BoardPattern<T> item)
        {
            return patternCollection.IndexOf(item);
        }

        /// <summary>
        /// Inserts a LifePattern at index
        /// </summary>
        /// <param name="index">The index to insert the LifePattern at </param>
        /// <param name="item">The LifePattern to insert</param>
        public void Insert(int index, BoardPattern<T> item)
        {
            patternCollection.Insert(index, item);
        }

        /// <summary>
        /// Removes the LifePattern at index
        /// </summary>
        /// <param name="index">The index of the LifePattern to remove</param>
        public void RemoveAt(int index)
        {
            patternCollection.RemoveAt(index);
        }

        /// <summary>
        /// Sets or gets the specified index of the patterncollection of the LifePattern
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public BoardPattern<T> this[int index]
        {
            get
            {
                return patternCollection[index];
            }
            set
            {
                patternCollection[index] = value;
            }
        }

        /// <summary>
        /// Adds the specified item to the LifePatternCollection
        /// </summary>
        /// <param name="item">The item to add to the LifePatternCollection</param>
        public void Add(BoardPattern<T> item)
        {
            patternCollection.Add(item);
        }

        /// <summary>
        /// Clears the LifePatternCollection for items
        /// </summary>
        public void Clear()
        {
            patternCollection.Clear();
        }

        /// <summary>
        /// Returns if the specified item is in the LifePatternCollection
        /// </summary>
        /// <param name="item">The item to search for</param>
        /// <returns>If the item is in the LifePatternCollection</returns>
        public bool Contains(BoardPattern<T> item)
        {
            return patternCollection.Contains(item);
        }

        /// <summary>
        /// Copies the entire list to the specified array, starting from arrayIndex
        /// </summary>
        /// <param name="array">The array to copy to</param>
        /// <param name="arrayIndex">The index to start copying from</param>
        public void CopyTo(BoardPattern<T>[] array, int arrayIndex)
        {
            patternCollection.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// The number of items in the LifePatternCollecti