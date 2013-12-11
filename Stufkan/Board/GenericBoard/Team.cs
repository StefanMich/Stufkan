using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stufkan.Game
{
    /// <summary>
    /// An interface describing a team playing on a board.
    /// </summary>
    [Serializable()]
    public class Team : ICollection<Piece>
    {
        /// <summary>
        /// Instantiates a team with a name and an id
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        public Team(string name, int id)
        {
            this.Name = name;
            this.id = id;
            this.pieces = new List<Piece>();

        }

        private string name;
        /// <summary>
        /// The name of the team
        /// </summary>
        public string Name { get { return name; } set { name = value; } }

        private int id;
        /// <summary>
        /// An ID to identify the team
        /// </summary>
        int ID { get { return id; } set { id = value; } }

        private List<Piece> pieces;
        /// <summary>
        /// A list of pieces accesible to the team
        /// </summary>
        public List<Piece> Pieces { get { return pieces; } set { pieces = value; } }

        /// <summary>
        /// Override of ToString returning the team id and name
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Team: " + id.ToString() + " Name: " + name;
        }

        /// <summary>
        /// Adds a piece to the list of pieces
        /// </summary>
        /// <param name="item"></param>
        public void Add(Piece item)
        {
            pieces.Add(item);
        }

        /// <summary>
        /// Clears the list of pieces
        /// </summary>
        public void Clear()
        {
            pieces.Clear();
        }

        /// <summary>
        /// Checks if the piece is in the list of pieces
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(Piece item)
        {
            return pieces.Contains(item);
        }

        /// <summary>
        /// Copies the array to another array from the arrayindex
        /// </summary>
        /// <param name="array">The destination array</param>
        /// <param name="arrayIndex">The index to start the copying from</param>
        public void CopyTo(Piece[] array, int arrayIndex)
        {
            pieces.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// The number of pieces
        /// </summary>
        public int Count
        {
            get { return pieces.Count; }
        }

        /// <summary>
        /// If the list of pieces is readonly
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Removes the piece from the list of pieces
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(Piece item)
        {
            return pieces.Remove(item);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the list
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Piece> GetEnumerator()
        {
            return pieces.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
