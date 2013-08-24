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
            SudokuGrid = GetTwoDimensionalTextBoxArray(GetOneDimensionalTextBoxArray(this));
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

        public TextBox[,] GetTwoDimensionalTextBoxArray(TextBox[] array)
        {
            TextBox[,] array2d = new TextBox[9, 9];

            int arrayCount = 0;
            for (int row = 0; row < 9; row++)
            {
                for (int column = 0; column < 9; column++)
                {
                    if (arrayCount < 81)
                    {
                        array2d[row, column] = array[arrayCount];
                        ++arrayCount;
                    }
                }
            }
            return array2d;
        }


       

        private void StartButton_Click(object sender, EventArgs e)
        {
            isGameStarted = true;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            if (!isGameStarted)
            {
                MessageBox.Show("The game has not been started yet.");
                return;
            }
            bool reset = MessageBox.Show("Are you sure you want to reset the game?", "Reset Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            if (reset)
            {
                foreach (TextBox textBox in SudokuGrid)
                {
                    textBox.Text = "";
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void propertyGrid1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
