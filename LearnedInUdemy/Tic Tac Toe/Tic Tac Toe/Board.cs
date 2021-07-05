using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
    class Board
    {
        // this array initializes numbers on the board that will become 'X' or 'O'
        public char[] board = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        // another array for each of the number to mark them as 'already played'
        // made so players can't overwrite each other
        public bool[] marked = new bool[9];
    }
}
