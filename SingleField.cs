using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcaby
{
    class SingleField
    {

       public Pawn pawn; //referencja do pionka bedacego na polu
       public SingleField()
        {
            pawn = null;

        }
        public void placePawn(Pawn _pawn)
        {
            pawn = _pawn;
            pawn.currentPosition = this;

        }
        public string GetPawnColor()
        {
            if(pawn == null)
            {
                return "empty";
            }
            else
            {
                return pawn.PawnColor;
            }

        }

    }
}
