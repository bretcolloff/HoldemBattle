//-----------------------------------------------------------------------
// <copyright file="GameValues.cs" company="TODO">
//     Not really copyright. 
// </copyright>
// <summary>Stores values used for cards.</summary>
//-----------------------------------------------------------------------

namespace HoldemBattle.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Stores all of the values specific to the game.
    /// </summary>
    public static class GameValues
    {
        /// <summary>
        /// Represents the 4 options for the suit of the card.
        /// </summary>
        public enum Suit
        {
            /// <summary>
            /// The 'Club' suit value.
            /// </summary>
            Club,

            /// <summary>
            /// The 'Diamond' suit value.
            /// </summary>
            Diamond,

            /// <summary>
            /// The 'Heart' suit value.
            /// </summary>
            Heart,

            /// <summary>
            /// The 'Spade' suit value.
            /// </summary>
            Spade
        }

        /// <summary>
        /// Represents the actual value of the card.
        /// </summary>
        public enum Value
        {
            /// <summary>
            /// The '2' value.
            /// </summary>
            Two = 2,

            /// <summary>
            /// The '3' value.
            /// </summary>
            Three,

            /// <summary>
            /// The '4' value.
            /// </summary>
            Four,

            /// <summary>
            /// The '5' value.
            /// </summary>
            Five,

            /// <summary>
            /// The '6' value.
            /// </summary>
            Six,

            /// <summary>
            /// The '7' value.
            /// </summary>
            Seven,

            /// <summary>
            /// The '8' value.
            /// </summary>
            Eight,

            /// <summary>
            /// The '9' value.
            /// </summary>
            Nine,

            /// <summary>
            /// The 'T' value.
            /// </summary>
            Ten,

            /// <summary>
            /// The 'J' value.
            /// </summary>
            Jack,

            /// <summary>
            /// The 'Q' value.
            /// </summary>
            Queen,

            /// <summary>
            /// The 'K' value.
            /// </summary>
            King,

            /// <summary>
            /// The 'A' value.
            /// </summary>
            Ace
        }
    }
}
