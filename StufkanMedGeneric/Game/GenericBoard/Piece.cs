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
        public Piece(string name, Team team, Bitmap model)
        {
            this.Name = name;
            this.Team = team;
            this.Model = model;
        }

        private Bitmap model;
        public System.Drawing.Bitmap Model
        {
            get { return model; }
            set { model = value; }
        }
        private string name;

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

        public override string ToString()
        {
            return "Piece " + team + " " + name;
        }
    }
}
