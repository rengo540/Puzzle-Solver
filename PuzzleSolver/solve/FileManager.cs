using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolver
{
    class FileManager
    {
       


        public static int getN(string FilePath)
        {
            string LineOfN = System.IO.File.ReadAllText(FilePath);
            var result = LineOfN.Split(new[] { '\n' });
            return int.Parse(result[0]);
        }

        public static int[] getArr(string FilePath, int N)
        {
            string text = System.IO.File.ReadAllText(FilePath);
            List<string> result = text.Split(new[] { '\n' }).ToList();

            int[] valuesArr = new int[N * N];
            int index = 0;
            for (int i = 1; i < result.Count; i++)
            {
                List<string> valuesString = result[i].Split(new[] { ' ', '\r' }).ToList();
                foreach (string val in valuesString)
                {
                    try
                    {
                        valuesArr[index] = int.Parse(val);
                        index++;
                    }
                    catch
                    {
                        continue;
                    }
                }

            }

            return valuesArr;
        }


    }
}