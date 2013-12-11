using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stufkan.Game
{
    /// <summary>
    /// Instantiates a board with functionality to create boardgames. (Turncontol, teams)
    /// </summary>
    public class GameBoard : GenericBoard
    {
        TurnControl turnControl;

        /// <summary>
        /// The turncontrol that keeps track of the teams participating and whose turn it is.
        /// </summary>
        public TurnControl TurnControl
        {
            get { return turnControl; }
            set { turnControl = value; }
        }

        /// <summary>
        /// Instantiates a new gameboard.
        /// </summary>
        public GameBoard()
            : base()
        {
        }
    }
}
