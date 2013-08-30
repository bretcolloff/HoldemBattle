//-----------------------------------------------------------------------
// <copyright file="Table.cs" company="TODO">
//     Not really copyright. 
// </copyright>
// <summary>Stores values used for cards.</summary>
//-----------------------------------------------------------------------

namespace HoldemBattle.GameLogic
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Controls game-flow for a set of players.
    /// </summary>
    public sealed class Table
    {
        /// <summary>
        /// The players involved in this instance of the game.
        /// </summary>
        private readonly Dictionary<Player, int> players;

        /// <summary>
        /// The GUID used to identify the table.
        /// </summary>
        private readonly Guid tableId;

        /// <summary>
        /// The maximum number of players allowed to sit at this table.
        /// </summary>
        private readonly int tableCapacity;

        /// <summary>
        /// Gets the table Id.
        /// </summary>
        public Guid Id
        {
            get { return tableId; }
        }
 
        /// <summary>
        /// Initializes a new instance of the <see cref="Table"/> class.
        /// </summary>
        /// <param name="playerMax">The maximum number of players the dealer should be allowed to have participate.</param>
        public Table(int playerMax)
        {
            players = new Dictionary<Player, int>(playerMax);
            tableId = Guid.NewGuid();
            tableCapacity = playerMax;
        }

        /// <summary>
        /// Add a player to the table.
        /// </summary>
        /// <param name="player">The player to add to the table.</param>
        public void AddPlayer(Player player)
        {
            if (players.Count < tableCapacity)
            {
                players.Add(player, 100);
            }
        }

        /// <summary>
        /// Removes a player from the table.
        /// </summary>
        /// <param name="player">The player to remove from the table.</param>
        public void RemovePlayer(Player player)
        {
            if (players.ContainsKey(player))
            {
                players.Remove(player);
            }
        }
    }
}
