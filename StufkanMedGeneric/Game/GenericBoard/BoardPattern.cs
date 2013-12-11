using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stufkan;

namespace Stufkan.Game
{
    /// <summary>
    /// A class representing a GameOfLife pattern, with a grid and a name
    /// </summary>
    [Serializable()]
    public class BoardPattern<T>
    {
        T[,] grid;
        string name;

        /// <summary>
        /// Creates a LifePattern without a pattern
        /// </summary>
        public BoardPattern()
        {

        }

        /// <summary>
        /// Creates a LifePattern with a name and a grid
        /// </summary>
        /// <param name="name">The name describing the pattern</param>
        /// <param name="grid">The grid depicting the pattern</param>
        public BoardPattern(string name, T[,] grid)
        {
            this.name = name;
            this.grid = grid;
        }

        /// <summary>
        /// Gets the grid depicting the pattern
        /// </summary>
        public virtual T[,] Grid
        {
            get { return grid; }
        }

        /// <summary>
        /// Gets the name of the pattern
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
