using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolver
{
    internal class Board
    {
        public int[,] matrix;
        public int N;
        public int stateDepth;
        public Board parent;
        public char blankMove;
        public Point emptySpace;
        public int totalDest;

        public int hashCode;


        public Board(int[,] matrix, int N, Point p)
        {
            this.matrix = matrix;
            this.N = N;
            this.emptySpace = p;
        }


        public Board(int[,] matrix, int N)
        {
            this.matrix = matrix;
            this.N = N;

        }

        public void setTotalDest(int totalDest)
        {
            this.totalDest = totalDest;
        }

        public int getTotalDest()
        {
            return this.totalDest;
        }

        public void setParent(Board parent)
        {
            this.parent = parent;
        }

        public Board getParent()
        {
            return this.parent;
        }


        public int[,] getMatrix() { return this.matrix; }




        public void setStateDepth(int stateDepth)
        {
            this.stateDepth = stateDepth;
        }

        public int getStateDepth()
        {
            return this.stateDepth;
        }

        public int getHammingDistance()
        {
            int hamming = 0;
            int count = -1;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    count++;
                    if (matrix[i, j] == 0)
                        continue;
                    if ((matrix[i, j] - 1) != count)
                        hamming++;

                }
            }

            return hamming;
        }

        public int getManhattanDistance()
        {

            int manhattanDistanceSum = 0;
            for (int x = 0; x < N; x++)
                for (int y = 0; y < N; y++)
                {
                    int value = matrix[x, y];
                    if (value != 0)
                    {
                        int targetX = (value - 1) / N;
                        int targetY = (value - 1) % N;
                        int dx = x - targetX;
                        int dy = y - targetY;
                        manhattanDistanceSum += Math.Abs(dx) + Math.Abs(dy);
                    }
                }
            return manhattanDistanceSum;


        }


        

        public void neighboors(ref priorityqueue openList, ref HashSet<int> closeList, int type)
        {
            int row = emptySpace.i;
            int col = emptySpace.j;
            List<Board> boards = new List<Board>();

            for (int i = 0; i < 4; i++)
            {
                int temp = -1;
                char move = ' ';
                int[,] mat = new int[N, N];
                mat = (int[,])matrix.Clone();
                //up  0 
                //down 1
                //right 2 
                // left 3
                try
                {
                    int x = -1, y = -1;
                    if (i == 0)
                    {
                        temp = mat[row - 1, col];
                        mat[row - 1, col] = mat[row, col];
                        mat[row, col] = temp;
                        x = row - 1;
                        y = col;
                        move = 'U';
                    }
                    else if (i == 1)
                    {
                        temp = mat[row + 1, col];
                        mat[row + 1, col] = mat[row, col];
                        mat[row, col] = temp;
                        x = row + 1;
                        y = col;
                        move = 'D';

                    }
                    else if (i == 2)
                    {
                        temp = mat[row, col + 1];
                        mat[row, col + 1] = mat[row, col];
                        mat[row, col] = temp;
                        x = row;
                        y = col + 1;
                        move = 'R';

                    }
                    else if (i == 3)
                    {
                        temp = mat[row, col - 1];
                        mat[row, col - 1] = mat[row, col];
                        mat[row, col] = temp;
                        x = row;
                        y = col - 1;
                        move = 'L';

                    }

                    if (parent.emptySpace.i == x && parent.emptySpace.j == y)
                    {
                        continue;
                    }
                    else
                    {
                        Point p = new Point(x, y);
                        Board b = new Board(mat, N, p);

                        b.gridToHash();

                        if (closeList.Contains(b.hashCode))
                        {
                            continue;
                        }

                        b.setParent(this);
                        b.blankMove = move;
                        b.setStateDepth(this.getStateDepth() + 1);
                        //0 hamming
                        //1 manhattan
                        int total;
                        if (type == 0)
                        {
                            total = b.getStateDepth() + b.getHammingDistance();
                        }
                        else
                        {
                            total = b.getStateDepth() + b.getManhattanDistance();

                        }
                        b.setTotalDest(total);


                        openList.enqueue(b);
                    }
                }
                catch
                {
                    continue;
                }
            }
            // return boards;
        }


        public List<Board> neighboors()
        {
            int row = emptySpace.i;
            int col = emptySpace.j;
            List<Board> boards = new List<Board>();

            for (int i = 0; i < 4; i++)
            {
                int temp = -1;
                char move = ' ';
                int[,] mat = new int[N, N];
                mat = (int[,])matrix.Clone();
                //up  0 
                //down 1
                //right 2 
                // left 3
                try
                {
                    int x = -1, y = -1;
                    if (i == 0)
                    {
                        temp = mat[row - 1, col];
                        mat[row - 1, col] = mat[row, col];
                        mat[row, col] = temp;
                        x = row - 1;
                        y = col;
                        move = 'U';
                    }
                    else if (i == 1)
                    {
                        temp = mat[row + 1, col];
                        mat[row + 1, col] = mat[row, col];
                        mat[row, col] = temp;
                        x = row + 1;
                        y = col;
                        move = 'D';

                    }
                    else if (i == 2)
                    {
                        temp = mat[row, col + 1];
                        mat[row, col + 1] = mat[row, col];
                        mat[row, col] = temp;
                        x = row;
                        y = col + 1;
                        move = 'R';

                    }
                    else if (i == 3)
                    {
                        temp = mat[row, col - 1];
                        mat[row, col - 1] = mat[row, col];
                        mat[row, col] = temp;
                        x = row;
                        y = col - 1;
                        move = 'L';

                    }

                    if (parent.emptySpace.i == x && parent.emptySpace.j == y)
                    {
                        continue;
                    }
                    else
                    {
                        Point p = new Point(x, y);
                        Board b = new Board(mat, N, p);

                        b.setParent(this);
                        b.blankMove = move;
                        b.setStateDepth(this.getStateDepth() + 1);
                        //0 hamming
                        //1 manhattan
                        //int total;
                        /* if (type == 0)
                         {
                             total = b.getStateDepth() + b.getHammingDistance();
                         }
                         else
                         {
                             total = b.getStateDepth() + b.getManhattanDistance();

                         }*/
                        // b.setTotalDest(total);

                        boards.Add(b);
                    }
                }
                catch
                {
                    continue;
                }
            }
            return boards;
        }



        public void gridToHash()
        {
            int hash = 193;
            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < N; col++)
                {
                    hash = hash * 59 + (matrix[row, col]);

                }
            }


            hashCode = hash;
        }

    }
}


