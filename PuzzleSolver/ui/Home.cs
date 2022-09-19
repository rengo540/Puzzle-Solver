using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleSolver.ui
{
    public partial class Home : Form
    {
        int size;
        int[] arr;

        public Home()
        {
            InitializeComponent();
        }

        private void openfileBtn_Click(object sender, EventArgs e)
        {
            Solver solver = new Solver();

            string path = "";
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
            }

            size = FileManager.getN(path);
            arr = FileManager.getArr(path, size);

        }

        private void sovleBtn_Click(object sender, EventArgs e)
        {
            Solver solver = new Solver();
            if (checkBox1.Checked)
            {
                if (size == 3 && HammingButton.Checked == true)
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    int numberOfMoves = solver.numberOfMovesHamming(size, arr);
                    sw.Stop();
                    string executionTimeAstar = sw.Elapsed.ToString();


                    /* sw = Stopwatch.StartNew();
                     numberOfMoves = solver.numberOfMovesBFS(size, arr);
                     sw.Stop();
                     string executionTimeBFS = sw.Elapsed.ToString();*/

                    if (numberOfMoves == -1)
                    {
                        MessageBox.Show("UnSolvable Puzzle");
                    }
                    else
                    {
                        List<Board> movements = new List<Board>();
                        movements.Add(FinalBoard.finalState);
                        for (int i = 1; i <= numberOfMoves; i++)
                        {
                            movements.Add(movements[i - 1].getParent());
                        }
                        this.Visible = false;
                        Puzzle8Form f = new Puzzle8Form(movements, true, executionTimeAstar);
                        f.Visible = true;
                    }

                }
                else if (size == 3 && ManhattanButton.Checked == true)
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    int numberOfMoves = solver.numberOfMovesManhattan(size, arr);
                    sw.Stop();
                    string executionTimeAstar = sw.Elapsed.ToString();


                    /* sw = Stopwatch.StartNew();
                     numberOfMoves = solver.numberOfMovesBFS(size, arr);
                     sw.Stop();
                     string executionTimeBFS = sw.Elapsed.ToString();*/

                    if (numberOfMoves == -1)
                    {
                        MessageBox.Show("UnSolvable Puzzle");
                    }
                    else
                    {
                        List<Board> movements = new List<Board>();
                        movements.Add(FinalBoard.finalState);
                        for (int i = 1; i <= numberOfMoves; i++)
                        {
                            movements.Add(movements[i - 1].getParent());
                        }
                        this.Visible = false;
                        Puzzle8Form f = new Puzzle8Form(movements, true, executionTimeAstar);
                        f.Visible = true;
                    }
                }
                else if (size != 3 && ManhattanButton.Checked == true)
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    int numberOfMoves = solver.numberOfMovesManhattan(size, arr);
                    sw.Stop();

                    string executionTime = sw.Elapsed.ToString();
                    if (numberOfMoves == -1)
                    {
                        MessageBox.Show("UnSolvable Puzzle");
                    }
                    else
                    {
                        List<Board> movements = new List<Board>();
                        string movementsCharts = "";
                        movements.Add(FinalBoard.finalState);
                        movementsCharts += FinalBoard.finalState.blankMove;
                        for (int i = 1; i <= numberOfMoves; i++)
                        {
                            movements.Add(movements[i - 1].getParent());
                            movementsCharts += movements[i - 1].blankMove;
                        }
                        // This Part to reverse string
                        char[] charArray = movementsCharts.ToCharArray();
                        Array.Reverse(charArray);
                        movementsCharts = new string(charArray);
                        movementsCharts = movementsCharts.Substring(0, movementsCharts.Length - 1);


                        //Console.WriteLine(movementsCharts);
                        this.Visible = false;
                        LargeNForm f = new LargeNForm(executionTime, numberOfMoves, movementsCharts);
                        f.Visible = true;
                    }

                }
                else if (size != 3 && HammingButton.Checked == true)
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    int numberOfMoves = solver.numberOfMovesHamming(size, arr);
                    sw.Stop();

                    string executionTime = sw.Elapsed.ToString();
                    if (numberOfMoves == -1)
                    {
                        MessageBox.Show("UnSolvable Puzzle");
                    }
                    else
                    {
                        List<Board> movements = new List<Board>();
                        string movementsCharts = "";
                        movements.Add(FinalBoard.finalState);
                        movementsCharts += FinalBoard.finalState.blankMove;
                        for (int i = 1; i <= numberOfMoves; i++)
                        {
                            movements.Add(movements[i - 1].getParent());
                            movementsCharts += movements[i - 1].blankMove;
                        }
                        // This Part to reverse string
                        char[] charArray = movementsCharts.ToCharArray();
                        Array.Reverse(charArray);
                        movementsCharts = new string(charArray);
                        movementsCharts = movementsCharts.Substring(0, movementsCharts.Length - 1);


                        //Console.WriteLine(movementsCharts);
                        this.Visible = false;
                        LargeNForm f = new LargeNForm(executionTime, numberOfMoves, movementsCharts);
                        f.Visible = true;
                    }
                }
            }
            else if (checkBox2.Checked)
            {
                if (size == 3)
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    int numberOfMoves = solver.numberOfMovesBFS(size, arr);
                    sw.Stop();
                    string executionTimeBFS = sw.Elapsed.ToString();

                    if (numberOfMoves == -1)
                    {
                        MessageBox.Show("UnSolvable Puzzle");
                    }
                    else
                    {
                        List<Board> movements = new List<Board>();
                        movements.Add(FinalBoard.finalState);
                        for (int i = 1; i <= numberOfMoves; i++)
                        {
                            movements.Add(movements[i - 1].getParent());
                        }
                        this.Visible = false;
                        Puzzle8Form f = new Puzzle8Form(movements, true, executionTimeBFS);
                        f.Visible = true;
                    }
                }
                else
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    int numberOfMoves = solver.numberOfMovesBFS(size, arr);
                    sw.Stop();

                    string executionTime = sw.Elapsed.ToString();
                    if (numberOfMoves == -1)
                    {
                        MessageBox.Show("UnSolvable Puzzle");
                    }
                    else
                    {
                        List<Board> movements = new List<Board>();
                        string movementsCharts = "";
                        movements.Add(FinalBoard.finalState);
                        movementsCharts += FinalBoard.finalState.blankMove;
                        for (int i = 1; i <= numberOfMoves; i++)
                        {
                            movements.Add(movements[i - 1].getParent());
                            movementsCharts += movements[i - 1].blankMove;
                        }
                        // This Part to reverse string
                        char[] charArray = movementsCharts.ToCharArray();
                        Array.Reverse(charArray);
                        movementsCharts = new string(charArray);
                        movementsCharts = movementsCharts.Substring(0, movementsCharts.Length - 1);


                        //Console.WriteLine(movementsCharts);
                        this.Visible = false;
                        LargeNForm f = new LargeNForm(executionTime, numberOfMoves, movementsCharts);
                        f.Visible = true;
                    }

                }

            }
        }
            private void button1_Click(object sender, EventArgs e)
            {
                Solver solver = new Solver();
                Stopwatch sw = Stopwatch.StartNew();
                int numberOfMoves = solver.numberOfMovesBFS(size, arr);
                sw.Stop();


            }
    }
 } 

