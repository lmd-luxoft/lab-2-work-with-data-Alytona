using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    abstract class AMonopolyField
    {
        protected static MonopolyPlayer EmptyPlayer = new MonopolyPlayer( "Empty" );

        public readonly string Name;

        public MonopolyPlayer Owner
        {
            get; set;
        } = EmptyPlayer;

        protected AMonopolyField (string name)
        {
            Name = name;
        }

        public virtual bool SellTo (MonopolyPlayer buyer)
        {
            if (Owner == EmptyPlayer) {
                buyer.MinusAmount( GetBuyAmount() );
                Owner = buyer;
                return true;
            }
            return false;
        }
        protected virtual int GetBuyAmount ()
        {
            return 0;
        }

        public virtual bool RentFrom (MonopolyPlayer tenant)
        {
            if (Owner == EmptyPlayer)
                return false;

            int rentAmount = GetRentAmount();

            tenant.MinusAmount( rentAmount );
            Owner.PlusAmount( rentAmount );
            return true;
        }
        protected virtual int GetRentAmount ()
        {
            return 0;
        }

        public override int GetHashCode ()
        {
            return Name.GetHashCode();
        }

        public override bool Equals (Object obj)
        {
            if (obj is AMonopolyField otherField)
            {
                return otherField.Name == Name;
            }
            return false;
        }
    }
}
