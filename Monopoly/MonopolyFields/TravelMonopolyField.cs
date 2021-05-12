using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class TravelMonopolyField : AMonopolyField
    {
        public TravelMonopolyField (string name) : base( name )
        {
        }
        protected override int GetBuyAmount ()
        {
            return 700;
        }
        protected override int GetRentAmount ()
        {
            return 300;
        }
    }
}
