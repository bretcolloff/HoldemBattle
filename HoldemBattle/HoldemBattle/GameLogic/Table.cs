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

    using HoldemBattle.Models;

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
        /// The stakes for the table.
        /// </summary>
        private readonly StakeInfo stakeInfo;

        /// <summary>
        /// The GUID used to identify the table.
        /// </summary>
        private readonly Guid tableId;

        /// <summary>
        /// The maximum number of players allowed to sit at this table.
        /// </summary>
        private readonly int tableCapacity;

        /// <summary>
        /// Initializes a new instance of the <see cref="Table"/> class.
        /// </summary>
        /// <param name="playerMax">The maximum number of players the dealer should be allowed to have participate.</param>
        /// <param name="stakeInfo">The stake information for the table.</param>
        public Table(uint playerMax, StakeInfo stakeInfo)
        {
            if (playerMax <= 1)
            {
                throw new InvalidOperationException("A table should allow for at least 2 players.");   
            }

            if (playerMax > 10)
            {
                throw new InvalidOperationException("A table cannot hold more than 10 players.");
            }

            if (stakeInfo == null)
            {
                throw new ArgumentNullException("stakeInfo");    
            }

            this.players = new Dictionary<Player, int>((int)playerMax);
            
            this.stakeInfo = stakeInfo;
            this.tableId = Guid.NewGuid();
            this.tableCapacity = (int)playerMax;
        }

        /// <summary>
        /// Gets the table Id.
        /// </summary>
        public Guid Id
        {
            get { return this.tableId; }
        }

        /// <summary>
        /// Gets the number of remaining free seats at the table.
        /// </summary>
        public int RemainingSeats
        {
            get
            {
                return this.tableCapacity - this.players.Count;
            }
        }

        /// <summary>
        /// Gets the stake information for the table.
        /// </summary>
        public StakeInfo StakeInfo
        {
            get { return this.stakeInfo; }
        }

        /// <summary>
        /// Add a player to the table.
        /// </summary>
        /// <param name="player">The player to add to the table.</param>
        public void AddPlayer(Player player)
        {
            if (this.players.ContainsKey(player))
            {
                throw new InvalidOperationException("Specified player is already at the table.");    
            }

            if (this.RemainingSeats == 0)
            {
                throw new InvalidOperationException("The table is full.");
            }

            if (this.players.Count < this.tableCapacity)
            {
                int stackSize = this.stakeInfo.BigBlind * 100;

                this.players.Add(player, stackSize);
                player.RemoveCash((uint)stackSize);
            }
        }

        /// <summary>
        /// Removes a player from the table.
        /// </summary>
        /// <param name="player">The player to remove from the table.</param>
        public void RemovePlayer(Player player)
        {
            if (this.players.ContainsKey(player))
            {
                int playerCash = this.players[player];
                this.players.Remove(player);

                player.AddCash((uint)playerCash);
            }
        }
    }
}
