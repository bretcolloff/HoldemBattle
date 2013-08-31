//-----------------------------------------------------------------------
// <copyright file="StakeInfo.cs" company="TODO">
//     Not really copyright. 
// </copyright>
// <summary>Stores values used for cards.</summary>
//-----------------------------------------------------------------------

namespace HoldemBattle.GameLogic
{
    using System;

    /// <summary>
    /// Contains the stake information for a table.
    /// </summary>
    public sealed class StakeInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StakeInfo"/> class.
        /// </summary>
        /// <param name="smallBlind">The small blind.</param>
        /// <param name="bigBlind">The big blind.</param>
        public StakeInfo(uint smallBlind, uint bigBlind)
        {
            if (bigBlind < smallBlind)
            {
                throw new InvalidOperationException("bigBlind should be greater than or equal to smallBlind.");
            }

            this.SmallBlind = (int)smallBlind;
            this.BigBlind = (int)bigBlind;
        }

        /// <summary>
        /// Gets the small blind value.
        /// </summary>
        public int SmallBlind { get; private set; }

        /// <summary>
        /// Gets the big blind value.
        /// </summary>
        public int BigBlind { get; private set; }
    }
}
