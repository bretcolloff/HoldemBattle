//-----------------------------------------------------------------------
// <copyright file="Player.cs" company="TODO">
//     Not really copyright. 
// </copyright>
// <summary>Stores values used for cards.</summary>
//-----------------------------------------------------------------------

namespace HoldemBattle
{
    /// <summary>
    /// Contains player information and manages table connection.
    /// </summary>
    public sealed class Player
    {
        /// <summary>
        /// The friendly name associated with the player.
        /// </summary>
        private string name;

        /// <summary>
        /// The key associated with the player.
        /// </summary>
        private string key;

        /// <summary>
        /// The amount of cash that this player has either won or lost.
        /// </summary>
        private int cash;

        public Player(string name, string key, int cash)
        {
            this.name = name;
            this.key = key;
            this.cash = cash;
        }

        /// <summary>
        /// Gets the amount of cash the player has that isn't in play.
        /// </summary>
        public int Cash
        {
            get { return cash; }
        }

        /// <summary>
        /// Adds money to the players total.
        /// </summary>
        /// <param name="amount">The amount of money to add to the players total.</param>
        public void AddCash(uint amount)
        {
            cash += (int) amount;
        }

        /// <summary>
        /// Removes money from the players total.
        /// </summary>
        /// <param name="amount"></param>
        public void RemoveCash(uint amount)
        {
            cash -= (int) amount;
        }
    }
}
