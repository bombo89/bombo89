using System;

namespace Tic_Tac_Toe
{
    class Program
    {
        
        // initializes board class (draws a board in console)
        static Board board = new Board();
        // sets player 1 as default for first player
        static int player = 1;
        // sets turn counter to 1, counter will be used to determine if it's a draw and all fields have been checked
        static int turnCounter = 1;
        // number input used to select board field and to check if it's inside scope
        static int userInput;
        // sets the default charachter to X to mark selected field
        static char ticTacToe = 'X';
        // instructions on what to do at given moment
        static string instructions = "Type in a number from 1 - 9 to choose your field and press enter.";        
        // bool to check if game has been won
        static bool isWon = false;

        static void Main(string[] args)
        {
            // setting all 'marked' bools in class to false
            for (int i = 0; i < 9; i++)
            {
                board.marked[i] = false;
            }

            // starts the game with player 1 (X) being the first to play
            // needs a feature to choose which player goes first
            StartGame();
        }

        // StartGame called at the start of game. could be reworked to add player choice of simbol and first move
        public static void StartGame()
        {
            instructions = "Type in a number from 1 - 9 to choose your field and press enter.";
            if (player == 1)
            {
                Player1Turn();
            }
            else if (player == 2)
            {
                Player2Turn();
            }
        }
        // displays board on console (drawn with strings)
        // used to update every time a move is made
        public static void GameDisplay()
        {
            // clears console
            Console.Clear();
            if (isWon == false)
            {
                Console.WriteLine("Turn {0}", turnCounter);
                Console.WriteLine("Player {0} ('{1}') is on the move.", player, ticTacToe);
            }
            Console.WriteLine(" -----------------");
            Console.WriteLine("|     |     |     |");            
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |", board.board[0], board.board[1], board.board[2]);
            Console.WriteLine("|     |     |     |");
            Console.WriteLine(" -----------------");
            Console.WriteLine("|     |     |     |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |", board.board[3], board.board[4], board.board[5]);
            Console.WriteLine("|     |     |     |");
            Console.WriteLine(" -----------------");
            Console.WriteLine("|     |     |     |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |", board.board[6], board.board[7], board.board[8]);
            Console.WriteLine("|     |     |     |");
            Console.WriteLine(" -----------------");
            Console.WriteLine(instructions);  
        }               
        // Player1Turn and Player2Turn sets player number and symbol (X or O)
        // it loops until game is either won or drawn
        public static void Player1Turn()
        {
            if (turnCounter == 10 && isWon == false)
            {                
                Draw();
            }
            //switch those 2 statements below for easier readability
            else if(isWon == false)
            {
                player = 1;
                ticTacToe = 'X';
                GameDisplay();

                InputCheck();
                WinCheck();
                Player2Turn();                
            }
            else
            {
                GameWon();
            }

        }
        public static void Player2Turn()
        {
            if (turnCounter == 10 && isWon == false)
            {                
                Draw();
            }
            else if(isWon == false)
            {
                player = 2;
                ticTacToe = 'O';
                GameDisplay();

                InputCheck();
                WinCheck();
                Player1Turn();
            }
            else
            {
                GameWon();
            }
        }

        // MarkedFields checks if any of the fields are already marked by X or O   
        public static void MarkedFields()
        {
            // if the field isn't marked, it places the current players character in field chosen by input
            if (board.marked[userInput - 1] == false)
            {                
                board.board[userInput - 1] = ticTacToe;
                turnCounter++;
                board.marked[userInput - 1] = true;
                instructions = "Type in a number from 1 - 9 to choose your field and press enter.";
            }
            else
            {
                // if the field is marked, it alerts the player and repeats the turn
                instructions = "That field is already checked. Choose another one and press enter.";
                if (player == 1)
                    Player1Turn();
                else if (player == 2)
                    Player2Turn();
            }
        }
        // InputCheck checks if user entered a valid input
        // if anything other than numbers 1 - 9 is entered, it warns the player and repeats the turn
        public static void InputCheck()
        {
            
            if (int.TryParse(Console.ReadLine(), out userInput) && userInput > 0 && userInput < 10)
            {
                // if input is correct it proceeds to check if the field is already marked
                MarkedFields();
            }            
            else
            {
                // if input is incorrect it repeats the current player's turn
                instructions = "Please choose only numbers from 1 - 9 and press enter";
                if (player == 1)
                {                    
                    Player1Turn();
                }
                else if (player == 2)
                {                   
                    Player2Turn();     
                }                
            }
        }
        // Draw function is called when all fields are full and there are no winners
        public static void Draw()
        {
            instructions = "";
            GameDisplay();            
            Console.WriteLine("Game ended in a draw.");
            Console.WriteLine("Would you like to restart? Y/N");
            ResetOrExit(Console.ReadLine().ToLower());
        }
       
        // WinCheck checks if any row, column, or diagonal have 3 same signs in a row
        // if that's the case, it changes isWon bool to true
        public static void WinCheck()
        {
            if (board.board[0] == board.board[1] && board.board[1] == board.board[2])
            {
                isWon = true;
            }
            if (board.board[3] == board.board[4] && board.board[4] == board.board[5])
            {
                isWon = true;
            }
            if (board.board[6] == board.board[7] && board.board[7] == board.board[8])
            {
                isWon = true;
            }
            if (board.board[0] == board.board[4] && board.board[4] == board.board[8])
            {
                isWon = true;
            }
            if (board.board[6] == board.board[4] && board.board[4] == board.board[2])
            {
                isWon = true;
            }
            if (board.board[0] == board.board[3] && board.board[3] == board.board[6])
            {
                isWon = true;
            }
            if (board.board[1] == board.board[4] && board.board[4] == board.board[7])
            {
                isWon = true;
            }
            if (board.board[2] == board.board[5] && board.board[5] == board.board[8])
            {
                isWon = true;
            }

        }
        // GameWon is called when there are 3 same signs in a row
        public static void GameWon()
        {
            instructions = "";
            GameDisplay();
            Console.WriteLine("Player {0} ('{1}') is the winner!", player, ticTacToe);

            // this sets the losing player as first
            if (player == 1)
                player = 2;
            else if (player == 2)
                player = 1;

            Console.WriteLine("Would you like to restart? Y/N");
            ResetOrExit(Console.ReadLine().ToLower());
        }
        // ResetOrExit promts the player to choose between restarting or exiting the game
        public static void ResetOrExit(string reset)
        {
            if(reset == "y")
            {
                for (int i = 0; i < 9; i++)
                {                    
                    board.marked[i] = false;
                }
                board.board = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9'};
                isWon = false;
                turnCounter = 1;                
                Console.Beep();
                StartGame();                
            }
            else if(reset == "n")
            {
                return;
            }
            else
            {
                Console.WriteLine("Type 'Y' for yes or 'N' for no : ");
                ResetOrExit(Console.ReadLine().ToLower());
            }
        }
    }
}
