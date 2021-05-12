using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class PrisonMonopolyField : AMonopolyField
    {
        public PrisonMonopolyField (string name) : base( name )
        {
        }
        public override bool SellTo (MonopolyPlayer buyer)
        {
            return false;
        }
        public override bool RentFrom (MonopolyPlayer tenant)
        {
            tenant.MinusAmount( 1000 );
            return true;
        }
    }
}
