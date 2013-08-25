using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Sudoku : Form
    {
        public TextBox[,] SudokuGrid;
        bool isGameStarted;
        public Sudoku()
        {
            InitializeComponent();
            SudokuGrid = GetTwoDimensionalTextBoxArray(this);
        }

        public TextBox[] GetOneDimensionalTextBoxArray(Form form)
        {
            List<TextBox> result=new List<TextBox>();
            foreach(Control ctrl in layoutPanel.Controls)
            {
                if(ctrl is TextBox)
                {
                    TextBox textbox = (TextBox)ctrl;
                    result.Add(textbox);
                }
            }
            return result.ToArray();
        }

        public TextBox[,] GetTwoDimensionalTextBoxArray(Form form)
        {
            TextBox[] array = GetOneDimensionalTextBoxArray(form);
            TextBox[,] array2d = new TextBox[9, 9];

            int arrayCount = 0;
            for (int row = 0; row < 9; row++)
            {
                for (int column = 0; column < 9; column++)
                {
                    if (arrayCount < 81)
                    {
                        int boxIndex = GetBoxIndex(row, column);
                        array[arrayCount].Tag = new SudokuTextBox() { Row = row, Column = column, BoxIndex = boxIndex };
                        array2d[row, column] = array[arrayCount];
                        array2d[row, column].TextChanged += (sender, EventArgs) =>
                        {
                            TextBox textbox = sender as TextBox;
                            SudokuTextBox information = textbox.Tag as SudokuTextBox;
                            bool passed = CheckEntry(information.Row, information.Column);
                            if (!passed)
                            {
                                SudokuGrid[information.Row, information.Column].ForeColor = Color.Red;
                            }
                            else
                            {
                                SudokuGrid[information.Row, information.Column].ForeColor = Color.Black;
                            }

                        };
                        ++arrayCount;
                    }
                }
            }
            return array2d;
        }


        public bool CheckColumn(int row, int column)
        {
            TextBox source = SudokuGrid[row, column];
            for ( int i = 0; i < 9; i++)
            {
                TextBox textbox = SudokuGrid[i, column];
                if (source.Text == textbox.Text && i != row)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckRow(int row, int column)
        {
            TextBox source = SudokuGrid[row, column];
            for (int i = 0; i < 9; i++)
            {
                TextBox textbox = SudokuGrid[row, i];
                if (source.Text == textbox.Text && i != column)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckBox(int row, int column)
        {
            TextBox source = SudokuGrid[row, column];
            SudokuTextBox information = source.Tag as SudokuTextBox;
            switch (information.BoxIndex)
            {
                case 0:
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            TextBox textbox = SudokuGrid[i, j];
                            if (source.Text == textbox.Text && i != row && j != column)
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                    }
                    break;

                case 1:
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 3; j < 6; j++)
                        {
                            TextBox textbox = SudokuGrid[i, j];
                            if (source.Text == textbox.Text && i != row && j != column)
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                    }
                    break;

                case 2:
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 6; j < 9; j++)
                        {
                            TextBox textbox = SudokuGrid[i, j];
                            if (source.Text == textbox.Text && i != row && j != column)
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                    }
                    break;

                case 3:
                    for (int i = 3; i < 6; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            TextBox textbox = SudokuGrid[i, j];
                            if (source.Text == textbox.Text && i != row && j != column)
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                    }
                    break;
                case 4:
                    for (int i = 3; i < 6; i++)
                    {
                        for (int j = 3; j < 6; j++)
                        {
                            TextBox textbox = SudokuGrid[i, j];
                            if (source.Text == textbox.Text && i != row && j != column)
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                    }
                    break;
                case 5:
                    for (int i = 3; i < 6; i++)
                    {
                        for (int j = 6; j < 9; j++)
                        {
                            TextBox textbox = SudokuGrid[i, j];
                            if (source.Text == textbox.Text && i != row && j != column)
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                    }
                    break;

                case 6:
                    for (int i = 6; i < 9; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            TextBox textbox = SudokuGrid[i, j];
                            if (source.Text == textbox.Text && i != row && j != column)
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                    }
                    break;
                case 7:
                    for (int i = 6; i < 9; i++)
                    {
                        for (int j = 3; j < 6; j++)
                        {
                            TextBox textbox = SudokuGrid[i, j];
                            if (source.Text == textbox.Text && i != row && j != column)
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                    }
                    break;

                case 8:
                    for (int i = 6; i < 9; i++)
                    {
                        for (int j = 6; j < 9; j++)
                        {
                            TextBox textbox = SudokuGrid[i, j];
                            if (source.Text == textbox.Text && i != row && j != column)
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                    }
                    break;
                default:
                    return false;
            }
            return false;
            
        }

        public bool CheckEntry(int row, int column)
        {
            bool rowPassed = CheckRow(row, column);
            bool columnPassed = CheckColumn(row, column);
            bool boxPassed = CheckBox(row, column);
            
            if (rowPassed && columnPassed && boxPassed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetBoxIndex(int row, int column)
        {
            if (row == 0 || row == 1 || row == 2 )
            {
                if (column == 0 || column == 1 || column == 2)
                {
                    return 0;
                }
                if (column == 3 || column == 4 || column == 5)
                {
                    return 1;
                }
                if (column == 6 || column == 7 || column == 8)
                {
                    return 2;
                }
            }
            if ( row == 3 || row == 4 || row == 5 )
            {
                if (column == 0 || column == 1 || column == 2)
                {
                    return 3;
                }
                if (column == 3 || column == 4 || column == 5)
                {
                    return 4;
                }
                if (column == 6 || column == 7 || column == 8)
                {
                    return 5;
                }
            }
            if (row == 6 || row == 7 || row == 8)
            {
                if (column == 0 || column == 1 || column == 2)
                {
                    return 6;
                }
                if (column == 3 || column == 4 || column == 5)
                {
                    return 7;
                }
                if (column == 6 || column == 7 || column == 8)
                {
                    return 8;
                }
            }
            return -1;
        }

       

        private void StartButton_Click(object sender, EventArgs e)
        {
            isGameStarted = true;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            //if (!isGameStarted)
            //{
            //    MessageBox.Show("The game has not been started yet.");
            //    return;
            //}
            bool reset = MessageBox.Show("Are you sure you want to reset the game?", "Reset Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            if (reset)
            {
                foreach (TextBox textBox in SudokuGrid)
                {
                    textBox.Text = "";
                }
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void Sudoku_Load(object sender, EventArgs e)
        {
            //SudokuGrid = GetTwoDimensionalTextBoxArray(sender as Form);
        }
    }
}
