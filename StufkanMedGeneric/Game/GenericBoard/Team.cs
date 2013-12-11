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

        public override string ToString()
        {
            return "Team " + id.ToString()+ " " + name;
        }

        public void Add(Piece item)
        {
            pieces.Add(item);
        }

        public void Clear()
        {
            pieces.Clear();
        }

        public bool Contains(Piece item)
        {
            return pieces.Contains(item);
        }

        public void CopyTo(Piece[] array, int arrayIndex)
        {
            pieces.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return pieces.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Piece item)
        {
            return pieces.Remove(item);
        }

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
