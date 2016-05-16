using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2_TicTacToe.Models
{
    public class GameModel
    {
        public static int InitializeBoard(List<Coordinate> tiles)
        {
            int horizontal = 8;
            int vertical = 3;
            for (int i = 0; i < horizontal; i++)
            {
                for (int j = 0; j < vertical; j++)
                {
                    tiles.Add(new Coordinate { XCoordinate = i, YCoordinate = j, sign = ' ' });
                }
            }
            for (int j = 0; j < 8; j++)
            {
                tiles[j].ID = j;
            }
            return horizontal;
        }
        public static string CheckForWinner(char checkForWin)
        {
            if (CheckForDiagonalWin(checkForWin) || CheckForVerticalWin(checkForWin) || CheckForHorizontalWin(checkForWin))
            {
                if (checkForWin == 'X')
                {
                    ResetTile();
                    return "You are the winner!";
                }

                if (checkForWin == 'O')
                {
                    ResetTile();
                    return "You lost, the computer won...";
                }
            }
            if (CheckForTie())
            {
                ResetTile();
                return "It's a tie! No one wins!";
            }
            return String.Empty;
        }
        public static bool CheckForDiagonalWin(char checkForSign)
        {
            if (Tiles.TileCoordinates[0].sign == checkForSign && Tiles.TileCoordinates[4].sign == checkForSign && Tiles.TileCoordinates[8].sign == checkForSign)
            {
                return true;
            }
            if (Tiles.TileCoordinates[2].sign == checkForSign && Tiles.TileCoordinates[4].sign == checkForSign && Tiles.TileCoordinates[6].sign == checkForSign)
            {
                return true;
            }
            return false;

        }
        public static bool CheckForVerticalWin(char checkForSign)
        {
            for (int i = 0; i < 3; i++)
            {
                if (Tiles.TileCoordinates[i].sign == checkForSign && Tiles.TileCoordinates[i + 3].sign == checkForSign && Tiles.TileCoordinates[i + 6].sign == checkForSign)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool CheckForHorizontalWin(char checkForSign)
        {
            for (int i = 0; i < 9; i++)
            {
                if (Tiles.TileCoordinates[i].sign == checkForSign && Tiles.TileCoordinates[i + 1].sign == checkForSign && Tiles.TileCoordinates[i + 2].sign == checkForSign)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool CheckForTie()
        {
            int counter = 0;
            foreach (var coordinate in Tiles.TileCoordinates)
            {
                if (coordinate.sign == 'O' || coordinate.sign == 'X')
                    counter++;
            }

            if (counter == 9)
                return true;
            return false;
        }

        public static int ComputerPlay()
        {
            if (Tiles.TileCoordinates[4].sign == '5')
                return 5;
            return RandomFreeSquare();
        }
        public static void ChangeCoordinate(int id, char sign)
        {
            for (int i = 0; i < Tiles.TileCoordinates.Count; i++)
            {
                if (Tiles.TileCoordinates[i].ID == id)
                {
                    Tiles.TileCoordinates[i].sign = sign;
                }
            }
        }
        public static string RunGameLogic(string send)
        {
            ChangeCoordinate(int.Parse(send), 'X');
            string message = CheckForWinner('X');
            if (message.Length > 0)
                return message;

            ChangeCoordinate(ComputerPlay(), 'O');
            message = CheckForWinner('O');
            if (message.Length > 0)
            {
                return message;
            }
            return message;
        }
        public static int RandomFreeSquare()
        {
            List<int> freeSquares = new List<int>();
            foreach (var coordinate in Tiles.TileCoordinates)
            {
                if(coordinate.sign != 'X' && coordinate.sign != 'O')
                {
                    freeSquares.Add(coordinate.ID);
                }
            }
            Random randomNr = new Random();
            int squareId = randomNr.Next(0, freeSquares.Count - 1);
            return freeSquares[squareId];
        }
        public static void ResetTile()
        {
            Tiles.TileCoordinates = new List<Coordinate>();
            for (int i = 0; i < 9; i++)
            {
                Tiles.TileCoordinates.Add(new Coordinate() { ID = i, sign = char.Parse(i.ToString()), DisableButton = false });
            }
        }
    }
}