using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Stufkan.Game
{
    /// <summary>
    /// An interface describing a piece able to be placed on the board
    /// </summary>
    [Serializable()]
    public class Piece
    {
        /// <summary>
        /// Instantiates a new piece 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="team"></param>
        /// <param name="model"></param>
        public Piece(string name, Team team, Bitmap model)
        {
            this.Name = name;
            this.Team = team;
            this.Model = model;
        }

        private Bitmap model;

        /// <summary>
        /// The model depicting the piece
        /// </summary>
        public System.Drawing.Bitmap Model
        {
            get { return model; }
            set { model = value; }
        }
        private string name;

        /// <summary>
        /// The name of the piece
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        private Team team;
        /// <summary>
        /// The team the piece belongs to
        /// </summary>
        public Team Team
        {
            get
            {
                return team;
            }
            set
            {
                team = value;
            }
        }

        /// <summary>
        /// Override of ToString that returns the piece name and team
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Piece: " + name + " Team: " + team;
        }
    }
}
