//-----------------------------------------------------------------------
// <copyright file="Card.cs" company="TODO">
//     Not really copyright. 
// </copyright>
// <summary>Represents the model of a physical playing card.</summary>
//-----------------------------------------------------------------------

namespace HoldemBattle.Models
{
    using System;

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

        /// <summary>
        /// Implements the greater than operator for <see cref="Card"/>.
        /// </summary>
        /// <param name="left">The left <see cref="Card"/>.</param>
        /// <param name="right">The right <see cref="Card"/>.</param>
        /// <returns>true if the left is greater than the right, otherwise false.</returns>
        public static bool operator >(Card left, Card right)
        {
            return (int)left.Value > (int)right.Value;
        }

        /// <summary>
        /// Implements the less than than operator for <see cref="Card"/>.
        /// </summary>
        /// <param name="left">The left <see cref="Card"/>.</param>
        /// <param name="right">The right <see cref="Card"/>.</param>
        /// <returns>true if the left is less than the right, otherwise false.</returns>
        public static bool operator <(Card left, Card right)
        {
            return (int)left.Value < (int)right.Value;
        }

        /// <summary>
        /// Implements the equals operator for <see cref="Card"/>.
        /// </summary>
        /// <param name="left">The left <see cref="Card"/>.</param>
        /// <param name="right">The right <see cref="Card"/>.</param>
        /// <returns>true if the left is equal to right, otherwise false.</returns>
        public static bool operator ==(Card left, Card right)
        {
            return (int)left.Value == (int)right.Value;
        }

        /// <summary>
        /// Implements the not equal operator for <see cref="Card"/>.
        /// </summary>
        /// <param name="left">The left <see cref="Card"/>.</param>
        /// <param name="right">The right <see cref="Card"/>.</param>
        /// <returns>true if the left is not equal to the right, otherwise false.</returns>
        public static bool operator !=(Card left, Card right)
        {
            return (int)left.Value != (int)right.Value;
        }

        /// <summary>
        /// Checks reference equality between this and another object.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare against.</param>
        /// <returns>true if they are reference equal, otherwise false.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj is Card && this.Equals((Card)obj);
        }

        /// <summary>
        /// Gets a hash code for the object.
        /// </summary>
        /// <returns>The hash code as an <see cref="int"/>.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((int)Suit * 397) ^ (int)Value;
            }
        }

        /// <summary>
        /// Checks equality between this and another <see cref="Card"/>.
        /// </summary>
        /// <param name="other">The <see cref="Card"/> to compare against.</param>
        /// <returns>true if they are equal, otherwise false.</returns>
        private bool Equals(Card other)
        {
            return Suit == other.Suit && Value == other.Value;
        }
    }
}
