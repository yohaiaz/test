using System;
using System.Text;

namespace helloworld
{
    public class GameBoard
    {
        #region Private Data

        private bool isOver;
        private int turn = -1;

        private int moves = 0;

        private char[] players = new char[] {'x', 'o'};

        private char[,] gameboard = null;

        #endregion

        #region C-tor

        public GameBoard()
        {

        }

        #endregion

        #region Public methods

        public void Reset()
        {
            gameboard = new char[,] { { '-', '-', '-' }, { '-', '-', '-' }, { '-', '-', '-' } };

            turn = new Random().Next(0, 2);

            isOver = false;

            moves = 0;
        }

        public string Display()
        {
            StringBuilder disp = new StringBuilder();

            disp.Append(Environment.NewLine);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    disp.AppendFormat("{0} ", gameboard[i, j]);
                }
                disp.Append(Environment.NewLine);
            }
            disp.Append(Environment.NewLine);

            return disp.ToString();
        }
         
        public string WhoseTurnItIs()
        {
            if (turn >= 0)
                return string.Format("\n turn to player {0}\n ", players[turn]);
            else 
                return "game not initialized \n";
        }

        public string Play(int col, int row)
        {
            if (!isValid(col, row))
            {
                return string.Format("\n This move at ({0},{1}) is not valid. Try again...\n", col, row);
            }

            gameboard[col, row] = players[turn];
            turn = (turn + 1) % 2;
            moves++;

            char checkWinner = whoIsTheWinner();

            if (!char.Equals(checkWinner, '-'))
            {
                isOver = true;
                return string.Format("\n Player {0} won the game. \n", checkWinner);
            }

            if(moves > 9)
            {
                isOver = true;
                return string.Format("\n no ones won the game. \n");
            }

            return "";
        }

        public bool IsOver()
        {
            return isOver;
        }

        #endregion

        #region private methods

        private bool isValid(int col, int row)
        {
            if ((col < 0) || (col > 2) || (row < 0) || (row > 2))
            {
                return false;
            }

            if (gameboard[col, row] != '-')
                return false;

            return true;
        }

        private char whoIsTheWinner()
        {
            //// check rows
            if ((gameboard[0, 0] == gameboard[0, 1]) && (gameboard[0, 1] == gameboard[0, 2])) { return gameboard[0, 0]; }
            if ((gameboard[1, 0] == gameboard[1, 1]) && (gameboard[1, 1] == gameboard[1, 2])) { return gameboard[1, 0]; }
            if ((gameboard[2, 0] == gameboard[2, 1]) && (gameboard[2, 1] == gameboard[2, 2])) { return gameboard[2, 0]; }

            //// check columns
            if ((gameboard[0, 0] == gameboard[1, 0]) && (gameboard[1, 0] == gameboard[2, 0])) { return gameboard[0, 0]; }
            if ((gameboard[0, 1] == gameboard[1, 1]) && (gameboard[1, 1] == gameboard[2, 1])) { return gameboard[0, 1]; }
            if ((gameboard[0, 2] == gameboard[1, 2]) && (gameboard[1, 2] == gameboard[2, 2])) { return gameboard[0, 2]; }

            // check diagonals
            if ((gameboard[0, 0] == gameboard[1, 1]) && (gameboard[1, 1] == gameboard[2, 2])) { return gameboard[0, 0]; }
            if ((gameboard[0, 2] == gameboard[1, 1]) && (gameboard[1, 1] == gameboard[2, 0])) { return gameboard[0, 2]; }


            return '-';
        }

        #endregion
    }
}
