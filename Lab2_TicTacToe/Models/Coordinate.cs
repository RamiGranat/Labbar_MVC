using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2_TicTacToe.Models
{
    public class Coordinate
    {

        public int ID { get; set; }
        public char sign { get; set; }

        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public bool DisableButton { get; set; }
    }
}