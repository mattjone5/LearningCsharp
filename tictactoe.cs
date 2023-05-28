using System;

namespace myGame{
    class main
    {
        static void Main(String[] args)
        {
            board game = new board();
            while (true)
            {
                if (game.checkValidMove())
                {
                    if (game.checkWin().Equals("X") || game.checkWin().Equals("O")) // This means that someone has won the game
                    {
                        break;
                    }

                    game.playerMove();

                    if(game.checkWin().Equals("X") || game.checkWin().Equals("O")) // This means that someone has won the game
                    {
                        break;
                    }

                    if (game.checkValidMove())
                    {
                        game.computerMove();
                    }
                    else // There are no more valid moves
                    {
                            break;
                    }
                }
                else // There are no more valid moves
                {
                    break;
                }
            }
            game.displayBoard();
            if(game.checkWin().Equals(""))
            {
                Console.WriteLine("The game ended in a draw!");
            }
            else if (game.checkWin().Equals("X"))
            {
                Console.WriteLine("You win!");
            }
            else
            {
                Console.WriteLine("You lose!");
            }
            
        }
    }

    class board
    {
        /* 
         * The board works like this
         * 1 2 3
         * 4 5 6
         * 7 8 9
         * 
         * X is for the player
         * O if for the computer
         * a number will be placed to show what can be played
         * 
         */
        private string[] theBoard = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        /*
         * This lets me return the board if I needed it for my main class
         */
        public string[] getBoard()
        {
            return theBoard;
        }
        
        /*
         * This allows the player to make a move
         */
        public void playerMove()
        {
            bool isValid = false;

            while (!isValid)
            {
                displayBoard();
                Console.WriteLine("Please enter the spot you want to place your X: ");
                string move = Console.ReadLine();
                for(int i = 0; i < 9; i++)
                {
                    if (theBoard[i].Equals(move))
                    {
                        theBoard[i] = "X";
                        isValid = !isValid;
                        break;
                    }
                }
                if (!isValid)
                {
                    Console.WriteLine("Error, move was not valid, please try again!\n");
                }
            }
        }

        
        /*
         * This is going to allow the computer to make a move
         */
         public void computerMove()
        {
            if (checkValidMove()) // We don't want this code to run if there are not any valid moves for the CPU to make
            {
                Random random = new Random();
                int spot = random.Next(0, 9);
                while (theBoard[spot].Equals("X") || theBoard[spot].Equals("O"))
                {
                    spot = random.Next(0, 9);
                }
                theBoard[spot] = "O";
            }
        }

        public bool checkValidMove()
        {
            for (int i =  0; i < 9; i++)
            {
                if(!(theBoard[i].Equals("X") || theBoard[i].Equals("O")))
                {
                    return true;
                }
            }
            return false;
        }

        /*
         * This is better code then when I did this with Java
         */
        public string checkWin()
        {
            for (int i = 0; i <= 6; i += 3)
            {
                if(theBoard[i] == theBoard[i+1] && theBoard[i] == theBoard[i+2]){ // This will check for a row check
                    return theBoard[i];
                }
            }
            for(int i = 0; i < 3; i++){ // this will check for a column check
                if(theBoard[i] == theBoard[i+3] && theBoard[i] == theBoard[i+6]){
                    return theBoard[i];
                }
            }

            if(theBoard[0] == theBoard[4] && theBoard[0] == theBoard[8]){
                return theBoard[0];
            }

            if(theBoard[2] == theBoard[4] && theBoard[2] == theBoard[6]){
                return theBoard[2];
            }
            return "";
        }

        /*
         * This will allow me to easily print out to the console how the board 
         * 
         */
        public void displayBoard(){
            for(int i = 0; i < 9; i++){
                if(i % 3 == 0){
                    Console.WriteLine();
                }
                Console.Write(theBoard[i] + " ");
            }
            Console.WriteLine();
        }
    }
}