//-----------------------------------------------------------------------
// <copyright file="CardRanking.cs" company="TODO">
//     Not really copyright. 
// </copyright>
// <summary>Stores values used for cards.</summary>
//-----------------------------------------------------------------------

namespace HoldemBattle.GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using HoldemBattle.Models;

    using Value = Models.GameValues.Value;

    /// <summary>
    /// Contains logic for working out value specific value comparisons.
    /// </summary>
    public static class CardRanking
    {
        /// <summary>
        /// Determines whether a provided sequence of <see cref="Card"/> objects contain a subset of 5 cards who's values are consecutive.
        /// </summary>
        /// <param name="cards">An <see cref="IEnumerable"/> of <see cref="Card"/> objects.</param>
        /// <returns>If no appropriate subset is found null, otherwise the value of the highest card in the subset.</returns>
        public static Value? ContainsStraight(IEnumerable<Card> cards)
        {
            var orderedValues = cards.OrderBy(x => x.Value).Select(x => (int)x.Value).ToList();
            
            // If the list contains an ace, add the low value aswell, to check for 5 high straights.
            if (orderedValues.Contains((int)Value.Ace))
            {
                orderedValues.Add(1);
                orderedValues.Sort();
            }

            int sequenceStart = orderedValues[0];
            int sequenceLast = orderedValues[0];

            for (int i = 1; i < orderedValues.Count(); i++)
            {
                // If this card is 1 value higher than the last, continue.
                if (orderedValues[i] == (sequenceLast + 1))
                {
                    sequenceLast = orderedValues[i];

                    // If we've got a straight, return the highest card value in it.
                    if ((sequenceLast - sequenceStart) == 4)
                    {
                        return (Value)sequenceLast;
                    }

                    continue;
                }
                else
                {
                    sequenceStart = orderedValues[i];
                    sequenceLast = orderedValues[i];
                }
            }

            return null;
        }
    }
}
