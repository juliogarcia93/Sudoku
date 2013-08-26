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
        public string[,] SolvedSudokuGrid;
        bool isGameStarted;
        bool handlersOn;
        public Sudoku()
        {
            InitializeComponent();
            SudokuGrid = GetTwoDimensionalTextBoxArray(this);
            SolvedSudokuGrid = new string[9, 9];
            handlersOn = true;
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
                            if (handlersOn)
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
            if (handlersOn)
            {
                TextBox source = SudokuGrid[row, column];
                for (int i = 0; i < 9; i++)
                {
                    TextBox textbox = SudokuGrid[i, column];
                    if (i != row)
                    {
                        if (source.Text == textbox.Text && !string.IsNullOrWhiteSpace(source.Text))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                string source = SolvedSudokuGrid[row, column];
                for (int i = 0; i < 9; i++)
                {
                    string currentText = SolvedSudokuGrid[i, column];
                    if (i != row)
                    {
                        if (source == currentText && !string.IsNullOrWhiteSpace(source))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }

        public bool CheckRow(int row, int column)
        {
            if (handlersOn)
            {
                TextBox source = SudokuGrid[row, column];
                for (int j = 0; j < 9; j++)
                {
                    TextBox textbox = SudokuGrid[row, j];
                    if (j != column)
                    {
                        if (source.Text == textbox.Text && !string.IsNullOrWhiteSpace(source.Text))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                string source = SolvedSudokuGrid[row, column];
                for (int j = 0; j < 9; j++)
                {
                    string currentText = SolvedSudokuGrid[row, j];
                    if (j != column)
                    {
                        if (source == currentText && !string.IsNullOrWhiteSpace(source))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }

        public bool CheckBox(int row, int column)
        {
            if (handlersOn)
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
                                if (row != i || column != j)
                                {
                                    if (source.Text == textbox.Text && !string.IsNullOrWhiteSpace(source.Text))
                                        return false;
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
                                if (row != i || column != j)
                                {
                                    if (source.Text == textbox.Text && !string.IsNullOrWhiteSpace(source.Text))
                                        return false;
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
                                if (row != i || column != j)
                                {
                                    if (source.Text == textbox.Text && !string.IsNullOrWhiteSpace(source.Text))
                                        return false;
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
                                if (row != i || column != j)
                                {
                                    if (source.Text == textbox.Text && !string.IsNullOrWhiteSpace(source.Text))
                                        return false;
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
                                if (row != i || column != j)
                                {
                                    if (source.Text == textbox.Text && !string.IsNullOrWhiteSpace(source.Text))
                                        return false;
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
                                if (row != i || column != j)
                                {
                                    if (source.Text == textbox.Text && !string.IsNullOrWhiteSpace(source.Text))
                                        return false;
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
                                if (row != i || column != j)
                                {
                                    if (source.Text == textbox.Text && !string.IsNullOrWhiteSpace(source.Text))
                                        return false;
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
                                if (row != i || column != j)
                                {
                                    if (source.Text == textbox.Text && !string.IsNullOrWhiteSpace(source.Text))
                                        return false;
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
                                if (row != i || column != j)
                                {
                                    if (source.Text == textbox.Text && !string.IsNullOrWhiteSpace(source.Text))
                                        return false;
                                }
                            }
                        }
                        break;
                    default:
                        return false;
                }
                return true;
            }
            else
            {
                string source = SolvedSudokuGrid[row, column];
                SudokuTextBox information = SudokuGrid[row, column].Tag as SudokuTextBox;
                switch (information.BoxIndex)
                {
                    case 0:
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                string currentText = SolvedSudokuGrid[i, j];
                                if (row != i || column != j)
                                {
                                    if (source == currentText && !string.IsNullOrWhiteSpace(source))
                                        return false;
                                }
                            }
                        }
                        break;

                    case 1:
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 3; j < 6; j++)
                            {
                                string currentText = SolvedSudokuGrid[i, j];
                                if (row != i || column != j)
                                {
                                    if (source == currentText && !string.IsNullOrWhiteSpace(source))
                                        return false;
                                }
                            }
                        }
                        break;

                    case 2:
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 6; j < 9; j++)
                            {
                                string currentText = SolvedSudokuGrid[i, j];
                                if (row != i || column != j)
                                {
                                    if (source == currentText && !string.IsNullOrWhiteSpace(source))
                                        return false;
                                }
                            }
                        }
                        break;

                    case 3:
                        for (int i = 3; i < 6; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                string currentText = SolvedSudokuGrid[i, j];
                                if (row != i || column != j)
                                {
                                    if (source == currentText && !string.IsNullOrWhiteSpace(source))
                                        return false;
                                }
                            }
                        }
                        break;
                    case 4:
                        for (int i = 3; i < 6; i++)
                        {
                            for (int j = 3; j < 6; j++)
                            {
                                string currentText = SolvedSudokuGrid[i, j];
                                if (row != i || column != j)
                                {
                                    if (source == currentText && !string.IsNullOrWhiteSpace(source))
                                        return false;
                                }
                            }
                        }
                        break;
                    case 5:
                        for (int i = 3; i < 6; i++)
                        {
                            for (int j = 6; j < 9; j++)
                            {
                                string currentText = SolvedSudokuGrid[i, j];
                                if (row != i || column != j)
                                {
                                    if (source == currentText && !string.IsNullOrWhiteSpace(source))
                                        return false;
                                }
                            }
                        }
                        break;

                    case 6:
                        for (int i = 6; i < 9; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                string currentText = SolvedSudokuGrid[i, j];
                                if (row != i || column != j)
                                {
                                    if (source == currentText && !string.IsNullOrWhiteSpace(source))
                                        return false;
                                }
                            }
                        }
                        break;
                    case 7:
                        for (int i = 6; i < 9; i++)
                        {
                            for (int j = 3; j < 6; j++)
                            {
                                string currentText = SolvedSudokuGrid[i, j];
                                if (row != i || column != j)
                                {
                                    if (source == currentText && !string.IsNullOrWhiteSpace(source))
                                        return false;
                                }
                            }
                        }
                        break;

                    case 8:
                        for (int i = 6; i < 9; i++)
                        {
                            for (int j = 6; j < 9; j++)
                            {
                                string currentText = SolvedSudokuGrid[i, j];
                                if (row != i || column != j)
                                {
                                    if (source == currentText && !string.IsNullOrWhiteSpace(source))
                                        return false;
                                }
                            }
                        }
                        break;
                    default:
                        return false;
                }
                return true;
            }
            
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

        public bool isComplete()
        {
            foreach (TextBox textbox in SudokuGrid)
            {
                if (string.IsNullOrWhiteSpace(textbox.Text))
                    return false;
            }
            return true;
        }

        public void ClearNumber(string number)
        {
            foreach(TextBox textbox in SudokuGrid)
            {
                if (textbox.Text == number)
                    textbox.Text = "";
            }
        }

        public BoxIndexes GetIndexesForBox(int boxIndex)
        {
            Random randomNumberGenerator = new Random();
            int boxRow;
            int boxColumn;
            switch (boxIndex)
            {
                case 0:
                    boxRow = randomNumberGenerator.Next(0,3);
                    boxColumn = randomNumberGenerator.Next(0,3);
                    break;
                case 1:
                    boxRow = randomNumberGenerator.Next(0,3);
                    boxColumn = randomNumberGenerator.Next(3,6);
                    break;
                case 2:
                    boxRow = randomNumberGenerator.Next(0,3);
                    boxColumn = randomNumberGenerator.Next(6,9);
                    break;
                case 3:
                    boxRow = randomNumberGenerator.Next(3,6);
                    boxColumn = randomNumberGenerator.Next(0,3);
                    break;
                case 4:
                    boxRow = randomNumberGenerator.Next(3,6);
                    boxColumn = randomNumberGenerator.Next(3,6);
                    break;
                case 5:
                    boxRow = randomNumberGenerator.Next(3,6);
                    boxColumn = randomNumberGenerator.Next(6,9);
                    break;
                case 6:
                    boxRow = randomNumberGenerator.Next(6,9);
                    boxColumn = randomNumberGenerator.Next(0,3);
                    break;
                case 7:
                    boxRow = randomNumberGenerator.Next(6,9);
                    boxColumn = randomNumberGenerator.Next(3,6);
                    break;
                case 8:
                    boxRow = randomNumberGenerator.Next(6,9);
                    boxColumn = randomNumberGenerator.Next(6, 9);
                    break;
                default:
                    boxRow = -1;
                    boxColumn = -1;
                    break;
            }
            return new BoxIndexes() { Row = boxRow, Column = boxColumn };
        }

        public bool CompleteSudokuPuzzle(int row, int column)
        {
            int number = 1;
            if (SolvedSudokuGrid[row, column] == "")
            {
                do
                {
                    SolvedSudokuGrid[row, column] = number.ToString();
                    if (CheckEntry(row, column) == true)
                    {
                        ++column;
                        if (column == 9)
                        {
                            column = 0;
                            ++row;
                            if (row == 9)
                            {
                                return true;
                            }
                        }
                        if (CompleteSudokuPuzzle(row, column) == true)
                        {
                            return true;
                        }
                        else
                        {
                            --column;
                            if (column < 0)
                            {
                                column = 8;
                                --row;
                            }
                        }
                    }
                    ++number;
                } while (number < 10);
                SolvedSudokuGrid[row, column] = "";
                return false;
            }
            else
            {
                ++column;
                if (column == 9)
                {
                    column = 0;
                    ++row;
                    if (row == 8)
                    {
                        return true;
                    }
                }
                return CompleteSudokuPuzzle(row, column);
            }
            
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            handlersOn = false;
            SolvedSudokuGrid = new string[9, 9];
            for (int row = 0; row < 9; row++)
            {
                for (int column = 0; column < 9; column++)
                {
                    SolvedSudokuGrid[row, column] = SudokuGrid[row, column].Text;
                }
            }

            bool complete = CompleteSudokuPuzzle(0, 0);

            for (int row = 0; row < 9; row++)
            {
                for (int column = 0; column < 9; column++)
                {
                    SudokuGrid[row, column].Text = SolvedSudokuGrid[row, column];
                }
            }
            handlersOn = true;
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
