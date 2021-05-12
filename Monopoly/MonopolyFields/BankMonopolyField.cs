using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class BankMonopolyField : AMonopolyField
    {
        public BankMonopolyField (string name) : base( name )
        {
        }
        public override bool SellTo (MonopolyPlayer buyer)
        {
            return false;
        }
        public override bool RentFrom (MonopolyPlayer tenant)
        {
            tenant.MinusAmount( 700 );
            return true;
        }
    }
}
