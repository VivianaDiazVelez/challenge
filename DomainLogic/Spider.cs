using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainLogic
{
    public static class Spider
    {
        //PUBLIC METHODS//
        public async static Task<int> Scan1Leg(string[] dna, int N)
        {
            Console.WriteLine("Running Scan1Leg");
            string[] subdna = new List<string>(dna).GetRange(N - 4, 4).ToArray();
            return await Count1LegAsync(subdna, N);
        }
        public async static Task<int> Scan2Legs(string[] dna, int N)
        {
            Console.WriteLine("Running Scan2Legs");
            return await Count2LegsAsync(dna, N);
        }
        public async static Task<int> Scan3Legs(string[] dna, int N)
        {
            Console.WriteLine("Running Scan3Legs");
            return await Count3LegsAsync(dna, N);

        }
        public async static Task<int> Scan4Legs(string[] dna, int N)
        {
            Console.WriteLine("Running Scan4Legs");
            var taskResult = Count4LegsAsync(dna, N);
            await taskResult;
            Console.WriteLine("Scan4Legs Completed");
            return taskResult.Result;
        }
        //iNTERNAL METHODS//
        internal async static Task<int> Count1LegAsync(string[] subdna, int N)
        {
            int count = 0;

            foreach (var row in subdna)
            {
                for (int col = 0; col < N - 3; col++)
                {
                    char leter = row[col];
                    string sequence = new(leter, 4);
                    string horizontal = row.Substring(col, 4);

                    count += Count1leg(sequence, horizontal);

                    if (count >= 2)
                    {
                        return count;
                    }
                }
            }
            return count;
        }
        internal async static Task<int> Count2LegsAsync(string[] dna, int N)
        {
            int count = 0;

            for (int row = 0; row < N - 3; row++)
            {
                string rowSequence = dna[row];
                string[] subdna = new List<string>(dna).GetRange(row, 4).ToArray();

                for (int col = N - 3; col < N; col++)
                {
                    char leter = rowSequence[col];
                    string sequence = new(leter, 4);

                    count += Count2Legs(col, sequence, subdna);

                    if (count >= 2)
                    {
                        return count;
                    }
                }
            }
            return count;
        }
        internal async static Task<int> Count3LegsAsync(string[] dna, int N)
        {
            int count = 0;

            for (int row = 0; row < N - 3; row++)
            {
                string rowSequence = dna[row];
                string[] subdna = new List<string>(dna).GetRange(row, 4).ToArray();

                for (int col = 0; col < 3; col++)
                {
                    char leter = rowSequence[col];
                    string sequence = new(leter, 4);
                    string horizontal = rowSequence.Substring(col, 4);

                    count += Count3Legs(col, sequence, horizontal, subdna);

                    if (count >= 2)
                    {
                        return count;
                    }
                }
            }
            return count;
        }
        internal async static Task<int> Count4LegsAsync(string[] dna, int N)
        {
            int count = 0;

            for (int row = 0; row < N - 3; row++)
            {
                string rowSequence = dna[row];
                string[] subdna = new List<string>(dna).GetRange(row, 4).ToArray();

                for (int col = 3; col < N - 3; col++)
                {
                    char leter = rowSequence[col];
                    string sequence = new(leter, 4);
                    string horizontal = rowSequence.Substring(col, 4);

                    count += Count4Legs(col, sequence, horizontal, subdna);

                    if (count >= 2)
                    {
                        return count;
                    }
                }
            }
            return count;
        }
        internal static int Count1leg(string sequence, string horizontal)
        {
            int count = 0;
            count += CountHorizontal(sequence, horizontal);

            return count;
        }
        internal static int Count2Legs(int startIndex, string sequence, string[] subDna)
        {
            int count = 0;
            count += CountVertical(startIndex, sequence, subDna);
            count += CountLeftDiagonal(startIndex, sequence, subDna);

            return count;
        }
        internal static int Count3Legs(int startIndex, string sequence, string horizontal, string[] subDna)
        {
            int count = 0;
            count += CountHorizontal(sequence, horizontal);
            count += CountVertical(startIndex, sequence, subDna);
            count += CountRightDiagonal(startIndex, sequence, subDna);

            return count;
        }
        internal static int Count4Legs(int startIndex, string sequence, string horizontal, string[] subDna)
        {
            int count = 0;
            count += CountHorizontal(sequence, horizontal);
            count += CountVertical(startIndex, sequence, subDna);
            count += CountRightDiagonal(startIndex, sequence, subDna);
            count += CountLeftDiagonal(startIndex, sequence, subDna);

            return count;
        }
        internal static int CountHorizontal(string sequence, string horizontal)
        {
            return horizontal.Equals(sequence) ? 1 : 0;
        }
        internal static int CountVertical(int startIndex, string sequence, string[] dna)
        {
            string[] verticalSequence = {
                        dna[0].Substring(startIndex, 1),
                        dna[1].Substring(startIndex, 1),
                        dna[2].Substring(startIndex, 1),
                        dna[3].Substring(startIndex, 1)
                    };

            string vertical = string.Concat(verticalSequence);
            return vertical.Equals(sequence) ? 1 : 0;
        }
        internal static int CountRightDiagonal(int startIndex, string sequence, string[] dna)
        {
            string[] diagonalSequence = {
                        dna[0].Substring(startIndex, 1),
                        dna[1].Substring(startIndex+1, 1),
                        dna[2].Substring(startIndex+2, 1),
                        dna[3].Substring(startIndex+3, 1)
                    };

            string diagonal = string.Concat(diagonalSequence);
            return diagonal.Equals(sequence) ? 1 : 0;
        }
        internal static int CountLeftDiagonal(int startIndex, string sequence, string[] dna)
        {
            string[] diagonalSequence = {
                        dna[0].Substring(startIndex, 1),
                        dna[1].Substring(startIndex-1, 1),
                        dna[2].Substring(startIndex-2, 1),
                        dna[3].Substring(startIndex-3, 1)
                    };

            string diagonal = string.Concat(diagonalSequence);
            return diagonal.Equals(sequence) ? 1 : 0;
        }
    }
}
