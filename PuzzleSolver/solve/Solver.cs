using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolver
{
    internal class Solver
    {
        public int numberOfMovesHamming(int n, int[] arr)
        {
            //return number of steps to reach goal 
            // throw new NotImplementedException();
            Point point = new Point();
            int[,] matrix = arrToMatrix(arr, point);

            Board b = new Board(matrix, n, point);

            if (isSolvable(arr, matrix, n))
            {
                b = solveAStar(b, 0);
                return b.getStateDepth();
            }
            else
            {
                return -1;
            }


        }

        public int numberOfMovesManhattan(int n, int[] arr)
        {
            //return number of steps to reach goal 
            // throw new NotImplementedException();
            Point point = new Point();
            int[,] matrix = arrToMatrix(arr, point);
            Board b = new Board(matrix, n, point);



            if (isSolvable(arr, matrix, n))
            {
                b = solveAStar(b, 1);
                return b.getStateDepth();
            }
            else
            {
                return -1;
            }


        }

        public int numberOfMovesBFS(int n, int[] arr)
        {
            //return number of steps to reach goal 
            // throw new NotImplementedException();
            Point point = new Point();
            int[,] matrix = arrToMatrix(arr, point);
            Board b = new Board(matrix, n, point);



            if (isSolvable(arr, matrix, n))
            {
                b = BFS(b);
                return b.getStateDepth();
            }
            else
            {
                return -1;
            }
        }

        public int[,] createMatrix(int n, int[] arr)
        {
            //return matrix 
            throw new NotImplementedException();
        }

        public int[,] arrToMatrix(int[] arr, Point point)
        {
            int n = (int)Math.Sqrt(arr.Length);
            int[,] matrix = new int[n, n];
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {

                    matrix[i, j] = arr[count];
                    count++;

                    if (matrix[i, j] == 0)
                    {
                        point.i = i;
                        point.j = j;
                    }
                }
            }

            return matrix;
        }








        public bool isSolvable(int[] arr, int[,] matrix, int n)
        {
            if (n % 2 == 0)
            {
                //even
                if (getIndex(matrix, n) % 2 == 0 && getInv(arr) % 2 != 0)
                {
                    return true;
                }

                if (getIndex(matrix, n) % 2 != 0 && getInv(arr) % 2 == 0)
                {
                    return true;
                }


            }
            else
            {
                //odd 
                if (getInv(arr) % 2 == 0)
                {
                    return true;
                }
            }

            return false;
        }


        public int getInv(int[] arr)
        {
            //int[] arr1 = {1 ,2 ,3,6 ,4 ,7,5, 8 ,0 };
            int invCount = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == 0 || arr[j] == 0)
                    {
                        continue;
                    }

                    if (arr[j] < arr[i])
                    {
                        invCount++;
                    }
                }
            }

            return invCount;
        }



        public int getIndex(int[,] matrix, int n)
        {


            int x = -1;
            for (int i = n - 1; i >= 0; i--)
                for (int j = n - 1; j >= 0; j--)
                    if (matrix[i, j] == 0)
                        x = n - i;

            return x;
        }


        public Board solveAStar(Board state, int type)
        {

            //  PriorityQueue<Board, int> openList = new PriorityQueue<Board, int>();
            HashSet<int> closeList = new HashSet<int>();

            priorityqueue openList = new priorityqueue();
            state.setStateDepth(0);
            state.setParent(state);
            int totalState = state.getStateDepth() + state.getManhattanDistance();
            state.setTotalDest(totalState);

            openList.enqueue(state);

            Board currentState = null;
            int c = 0;
            while (openList.count() > 0)
            {
                currentState = openList.dequeue();
                currentState.gridToHash();

                closeList.Add(currentState.hashCode);

                c++;
                if (currentState.getTotalDest() == currentState.getStateDepth())
                {
                    break;
                }

                currentState.neighboors(ref openList, ref closeList, type);

            }
            Console.WriteLine(c);
            FinalBoard.finalState = currentState;
            return currentState;
        }

        public Board BFS(Board state)
        {
            HashSet<int> closeList = new HashSet<int>();

            Queue<Board> openList = new Queue<Board>();
            state.setStateDepth(0);
            state.setParent(state);
            //  int totalState = state.getStateDepth() + state.getHammingDistance();
            //  state.setTotalDest(totalState);

            openList.Enqueue(state);

            Board currentState = null;

            while (openList.Count > 0)
            {
                currentState = openList.Dequeue();
                currentState.gridToHash();
                closeList.Add(currentState.hashCode);


                if (currentState.getHammingDistance() == 0)
                {
                    break;
                }

                List<Board> successors = currentState.neighboors();

                foreach (var successor in successors)
                {
                    successor.setStateDepth(currentState.getStateDepth() + 1);
                    if (closeList.Contains(successor.hashCode))
                    {
                        continue;
                    }
                    // successor.setParent(currentState);
                    //int total = successor.getStateDepth() + successor.getHammingDistance();
                    // successor.setTotalDest(total);

                    openList.Enqueue(successor);
                }

            }
            return currentState;

        }
        static void printMatrix(int[,] matrixx, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrixx[i, j] + " ");
                }
                Console.WriteLine();
            }
        }


    }
}
