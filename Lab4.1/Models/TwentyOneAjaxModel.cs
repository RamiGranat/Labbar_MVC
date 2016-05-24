using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4._1.Models
{
    public class TwentyOneAjaxModel
    {
        public static int CurrentNumber { get; set; }
        public static void SetStartPlayer()
        {
            if (RandomNumber() == 1)
                CurrentNumber = RandomNumber();
        }
        public static int RandomNumber()
        {
            Random randomNumber = new Random();
            return randomNumber.Next() % 2 == 0 ? 1 : 2;
        }
        public static int UpdateNumber { get; set; }
        public static void ComputerPlay()
        {
            if (CurrentNumber > 18)
            {
                CurrentNumber += 2;
            }
            else if (CurrentNumber > 10 && CurrentNumber % 2 == 0)
            {
                CurrentNumber += 2;
            }
            else if (CurrentNumber > 10)
            {
                CurrentNumber++;
            }
            else
            {
                CurrentNumber += RandomNumber();
            }
        }
        public static string HandleGameResults()
        {
            string playerResult = TwentyOneAjaxModel.IsGameOver("player");
            if (playerResult.Length > 0)
            {
                CurrentNumber = 0;
                return playerResult;
            }
            TwentyOneAjaxModel.ComputerPlay();
            string computerResult = TwentyOneAjaxModel.IsGameOver("computer");
            if (computerResult.Length > 0)
            {
                CurrentNumber = 0;
                return computerResult;
            }
            return string.Empty;
        }
        public static string ErroMessage(string errorMessage)
        {
            string error = errorMessage;
            return error;
        }
        public static string IsGameOver(string turn)
        {
            if (CurrentNumber >= 21)
            {
                if (turn == "player")
                {
                    return "You won! Congratulations!";
                }
                else if (turn == "computer")
                {
                    return "The AI won! Your actions have shamed mankind";

                }
                else return string.Empty;
            }
            else return string.Empty;
        }
    }
}