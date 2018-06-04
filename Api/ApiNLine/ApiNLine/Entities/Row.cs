using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiNLine.Entities
{
    public class Row
    {
        private int rowNumber;
        private List<Column> columns;

        public int RowNumber { get => rowNumber; set => rowNumber = value; }
        public List<Column> Columns { get => columns; set => columns = value; }

        public Row(int rowNumber)
        {
            this.rowNumber = rowNumber;
            this.columns = new List<Column>();
        }
    }
}