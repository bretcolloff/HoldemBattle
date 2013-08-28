
namespace HoldemBattle.GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using HoldemBattle.Models;

    using Value = Models.GameValues.Value;

    public static class CardRanking
    {
        /// <summary>
        /// The full list of values ordered by rank.
        /// </summary>
        private static List<Value> rankedValues = new List<Value> 
        { 
            Value.Ace, Value.Two, Value.Three, Value.Four, Value.Five,
            Value.Six, Value.Seven, Value.Eight, Value.Nine, Value.Ten,
            Value.Jack, Value.Queen, Value.King
        };
    }
}
