using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiNLine.Entities
{
    public class Board
    {
        private int game;
        private List<Row> rows;       

        public int Game { get => game; set => game = value; }
        public List<Row> Rows { get => rows; set => rows = value; }

        public Board(int game)
        {
            Game = game;
            Rows = new List<Row>();
        }


    }
}