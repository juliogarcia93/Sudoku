using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public class SudokuTextBox : TextBox
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public int BoxIndex { get; set; }
    }
}
