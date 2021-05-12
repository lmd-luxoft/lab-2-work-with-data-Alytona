using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class MonopolyPlayer
    {
        public const int START_AMOUNT = 6000;

        public readonly string Name;

        public int Amount
        {
            get; private set;
        }
        public MonopolyPlayer (string name)
        {
            Name = name;
            Amount = START_AMOUNT;
        }
        public MonopolyPlayer (string name, int startAmount)
        {
            Name = name;
            Amount = startAmount;
        }

        public int MinusAmount (int minusValue)
        {
            Amount -= minusValue;
            return Amount;
        }
        public int PlusAmount (int plusValue)
        {
            Amount += plusValue;
            return Amount;
        }

        public override int GetHashCode ()
        {
            return Name.GetHashCode();
        }

        public override bool Equals (Object obj)
        {
            if (obj is MonopolyPlayer otherPlayer)
            {
                return otherPlayer.Name == Name && otherPlayer.Amount == Amount;
            }
            return false;
        }
    }
}
