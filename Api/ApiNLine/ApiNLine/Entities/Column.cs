using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiNLine.Entities
{
    public class Column
    {
        private int columnNumber;
        private string chipColor;
        private string winner;

        public int ColumnNumber { get => columnNumber; set => columnNumber = value; }
        public string ChipColor { get => chipColor; set => chipColor = value; }
        public string Winner { get => winner; set => winner = value; }

        public Column(int columnNumber, string chipColor, string winner)
        {
            this.columnNumber = columnNumber;
            this.chipColor = chipColor;
            this.winner = winner;
        }
    }
}