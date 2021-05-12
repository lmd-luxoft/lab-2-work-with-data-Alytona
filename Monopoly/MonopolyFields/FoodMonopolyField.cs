using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class FoodMonopolyField : AMonopolyField
    {
        public FoodMonopolyField (string name) : base( name )
        {
        }
        protected override int GetBuyAmount ()
        {
            return 250;
        }
        protected override int GetRentAmount ()
        {
            return 250;
        }
    }
}
