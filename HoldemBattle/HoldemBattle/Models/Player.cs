//-----------------------------------------------------------------------
// <copyright file="Player.cs" company="TODO">
//     Not really copyright. 
// </copyright>
// <summary>Stores values used for cards.</summary>
//-----------------------------------------------------------------------

namespace HoldemBattle.Models
{
    using System;

    /// <summary>
    /// Contains player information and manages table connection.
    /// </summary>
    public sealed class Player
    {
        /// <summary>
        /// The amount of cash that this player has either won or lost.
        /// </summary>
        private int cash;
        
        /// <summary>
        /// The key associated with the player.
        /// </summary>
        private string key;

        /// <summary>
        /// The friendly name associated with the player.
        /// </summary>
        private string name;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="name">The player name.</param>
        /// <param name="key">Their registration key.</param>
        /// <param name="cash">The amount of cash they player has.</param>
        public Player(string name, string key, int cash)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Provided name value was null or empty.");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Provided key value was null or emtpy.");
            }

            this.name = name;
            this.key = key;
            this.cash = cash;
        }

        /// <summary>
        /// Gets the amount of cash the player has that isn't in play.
        /// </summary>
        public int Cash
        {
            get { return this.cash; }
        }

        /// <summary>
        /// Gets the friendly name of the player.
        /// </summary>
        public string Name
        {
            get { return this.name; }
        }

        /// <summary>
        /// Adds money to the players total.
        /// </summary>
        /// <param name="amount">The amount of money to add to the players total.</param>
        public void AddCash(uint amount)
        {
            this.cash += (int)amount;
        }

        /// <summary>
        /// Removes money from the players total.
        /// </summary>
        /// <param name="amount">The amount of cash to remove from the players total.</param>
        public void RemoveCash(uint amount)
        {
            this.cash -= (int)amount;
        }
    }
}
