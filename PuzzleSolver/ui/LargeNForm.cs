using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleSolver.ui
{
    public partial class LargeNForm : Form
    {
        public string executionTime;
        public int numberOfMovements;
        public string movementsString;
        public LargeNForm(string exeTime, int numberOfMovements, string movementsChart)
        {
            this.executionTime = exeTime;
            this.numberOfMovements = numberOfMovements;
            this.movementsString = movementsChart;
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Home b = new Home();
            b.Visible = true;
        }

        private void LargeNForm_Load(object sender, EventArgs e)
        {
            this.label1.Text = "Execution Time: " + executionTime + " ms";
            this.label2.Text = "Number Of Movements: " + numberOfMovements;
            //this.label3.Text = "Solvable? Yes";
            this.label4.Text = "Movements: \n\n " + movementsString;
        }
    }
}
