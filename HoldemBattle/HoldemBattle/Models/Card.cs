//-----------------------------------------------------------------------
// <copyright file="Card.cs" company="TODO">
//     Not really copyright. 
// </copyright>
// <summary>Represents the model of a physical playing card.</summary>
//-----------------------------------------------------------------------

namespace HoldemBattle.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Suit = GameValues.Suit;
    using Value = GameValues.Value;

    /// <summary>
    /// The Card class, to represent a physical playing card.
    /// </summary>
    public sealed class Card
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="suit">The <see cref="Suit"/> of the card.</param>
        /// <param name="value">The <see cref="Value"/> of the card.</param>
        public Card(Suit suit, Value value)
        {
            this.Suit = suit;
            this.Value = value;
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="Card"/> class from being created.
        /// </summary>
        private Card()
        {
            throw new InvalidOperationException("Use the public constructor.");
        }

        /// <summary>
        /// Gets the suit of the card.
        /// </summary>
        public Suit Suit
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the value of the card.
        /// </summary>
        public Value Value
        {
            get;
            private set;
        }
    }
}
