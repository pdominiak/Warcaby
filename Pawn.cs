using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcaby
{
    class Pawn
    {
        public int pawnID;
        public bool isQueen;       
        public SingleField currentPosition; //referencja do pola na ktorym jest pionek

        public Pawn()
        {
            currentPosition = null;
            PawnColor = "";
            isQueen = false;
        }
        private string pawnColor;
        public string PawnColor
        {
            get
            {
                return this.pawnColor;
            }
            set
            {
                this.pawnColor = value;

            }

        }
            
    }
}
