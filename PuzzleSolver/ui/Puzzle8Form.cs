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
    public partial class Puzzle8Form : Form
    {
        int time = -1;
        bool manhattan;
        List<Board> movements;
        string executionTime;
        string executionTimeBFS;

        public Puzzle8Form(dynamic m, bool manhat, string exeTimeAStar)
        {
            this.movements = m;
            this.manhattan = manhat;
            this.executionTime = exeTimeAStar;
            this.executionTimeBFS = executionTimeBFS;
            InitializeComponent();
            timer1.Start();
        }

        private void Puzzle8Form_Load(object sender, EventArgs e)
        {
            this.label11.Text = "Number Of Movements: " + (movements.Count() - 1).ToString();
            //this.label13.Text = manhattan ? "Using Manhattan Distance" : "Using Hamming Distance";
            this.label14.Text = "Execution Time:\n" + executionTime ;
          //  this.label13.Text = "Execution Time BFS:\n" + executionTimeBFS;
            int numberOfMovements = movements.Count() - 1;

            this.label1.Text = movements[numberOfMovements].matrix[0, 0].ToString();
            this.label2.Text = movements[numberOfMovements].matrix[0, 1].ToString();
            this.label3.Text = movements[numberOfMovements].matrix[0, 2].ToString();
            this.label4.Text = movements[numberOfMovements].matrix[1, 0].ToString();
            this.label5.Text = movements[numberOfMovements].matrix[1, 1].ToString();
            this.label6.Text = movements[numberOfMovements].matrix[1, 2].ToString();
            this.label7.Text = movements[numberOfMovements].matrix[2, 0].ToString();
            this.label8.Text = movements[numberOfMovements].matrix[2, 1].ToString();
            this.label9.Text = movements[numberOfMovements].matrix[2, 2].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label10.Visible = false;
            time = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int n = movements.Count - 1;
            if (time >= 0 && time <= n)
            {
                label12.Text = "Movement Number: " + (time).ToString();

                this.label1.Text = movements[n - time].matrix[0, 0].ToString();
                this.label2.Text = movements[n - time].matrix[0, 1].ToString();
                this.label3.Text = movements[n - time].matrix[0, 2].ToString();
                this.label4.Text = movements[n - time].matrix[1, 0].ToString();
                this.label5.Text = movements[n - time].matrix[1, 1].ToString();
                this.label6.Text = movements[n - time].matrix[1, 2].ToString();
                this.label7.Text = movements[n - time].matrix[2, 0].ToString();
                this.label8.Text = movements[n - time].matrix[2, 1].ToString();
                this.label9.Text = movements[n - time].matrix[2, 2].ToString();
                time++;
            }



        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Home b = new Home();
            b.Visible = true;
            //Main_Form f = new Main_Form();
            //f.Visible = true;

        }
    }
}
