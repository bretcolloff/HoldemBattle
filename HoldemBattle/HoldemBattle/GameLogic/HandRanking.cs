//-----------------------------------------------------------------------
// <copyright file="CardRanking.cs" company="TODO">
//     Not really copyright. 
// </copyright>
// <summary>Stores values used for cards.</summary>
//-----------------------------------------------------------------------

namespace HoldemBattle.GameLogic
{
    using System.Collections.Generic;
    using System.Linq;
    using HoldemBattle.Models;

    using Value = Models.GameValues.Value;

    /// <summary>
    /// Contains logic for working out value specific value comparisons.
    /// </summary>
    public static class HandRanking
    {
        /// <summary>
        /// Determines whether a provided sequence of <see cref="Card"/> objects contain a subset of 5 cards who's values are consecutive.
        /// </summary>
        /// <param name="cards">An <see cref="IEnumerable"/> of <see cref="Card"/> objects.</param>
        /// <returns>If no appropriate subset is found null, otherwise the value of the highest card in the subset.</returns>
        public static Value? ContainsStraight(IEnumerable<Card> cards)
        {
            var orderedValues = cards.Select(x => (int)x.Value).Distinct().OrderByDescending(x => x).ToList();
            
            // If the list contains an ace, add the low value aswell, to check for 5 high straights.
            if (orderedValues.Contains((int)Value.Ace))
            {
                orderedValues.Add(1);
            }

            int sequenceStart = orderedValues[0];
            int sequenceEnd = orderedValues[0];

            for (int i = 1; i < orderedValues.Count(); i++)
            {
                var nextExpectedValue = sequenceEnd - 1;

                // If this card is 1 value lower than the last, continue.
                if (orderedValues[i] == nextExpectedValue)
                {
                    sequenceEnd = orderedValues[i];

                    // If we've got a straight, return the highest card value in it.
                    if ((sequenceStart - sequenceEnd) == 4)
                    {
                        return (Value)sequenceStart;
                    }

                    continue;
                }
                else
                {
                    sequenceStart = orderedValues[i];
                    sequenceEnd = orderedValues[i];
                }
            }

            return null;
        }

        /// <summary>
        /// Determines whether a provided sequence of <see cref="Card"/> objects contain a subset of 5 cards who are of the same suit.
        /// </summary>
        /// <param name="cards">An <see cref="IEnumerable"/> of <see cref="Card"/> objects.</param>
        /// <returns>If no appropriate subset is found null, otherwise the value of the highest card in the subset.</returns>
        public static Value? ContainsFlush(IEnumerable<Card> cards)
        {
            IEnumerable<IGrouping<GameValues.Suit, Card>> suitGroups = cards.GroupBy(x => x.Suit);
            IGrouping<GameValues.Suit, Card> flushGroup = suitGroups.SingleOrDefault(x => x.Count() >= 5);

            if (flushGroup == null)
            {
                return null;
            }

            return flushGroup.OrderByDescending(x => (int)x.Value).First().Value;
        }
    }
}
