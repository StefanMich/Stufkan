using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stufkan.Game;

namespace Stufkan.Game
{
    /// <summary>
    /// A class that keeps track of the team having the turn
    /// </summary>
    public class TurnControl
    {
        /// <summary>
        /// The function to use for finding the next player
        /// </summary>
        public Func<Team> NextMethod;

        /// <summary>
        /// A list of all the teams present in the game
        /// </summary>
        public List<Team> Teams = new List<Team>();
        
        /// <summary>
        /// A queue with all the teams present in the game
        /// </summary>
        public Queue<Team> Q = new Queue<Team>();

        /// <summary>
        /// The team having the turn
        /// </summary>
        public Team CurrentTeam;

        /// <summary>
        /// Instantiates a turncontrol with a startTeam and a number of teams
        /// </summary>
        /// <param name="startTeam">The team to begin</param>
        /// <param name="team">The other teams in the game</param>
        public TurnControl(Team startTeam, params Team[] team)
        {
            Teams.Add(startTeam);
            Teams.AddRange(team);

            Q.Enqueue(startTeam);
            foreach (Team t in team)
            {
                Q.Enqueue(t);
            }

            CurrentTeam = startTeam;
            NextMethod = rotation;
        }

        /// <summary>
        /// Instantiates a turncontrol with a startTeam, a number of teams and a method to find the next player
        /// </summary>
        /// <param name="nextMethod">A method that returns the next player</param>
        /// <param name="startTeam">The team to begin</param>
        /// <param name="team">The other teams in the game</param>
        public TurnControl(Func<Team> nextMethod, Team startTeam, params Team[] team): this(startTeam, team)
        {
            this.NextMethod = nextMethod;            
        }

        /// <summary>
        /// Uses the 
        /// </summary>
        public void NextPlayer()
        {
            CurrentTeam = NextMethod();
        }

        /// <summary>
        /// The standard method to decide the next player. Rotates the queue.
        /// </summary>
        /// <returns></returns>
        public Team rotation()
        { 
           Q.Enqueue(Q.Dequeue());
           return Q.Peek();
        }


    }
}
