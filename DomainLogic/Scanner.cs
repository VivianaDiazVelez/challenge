using System;
using System.Threading.Tasks;

namespace DomainLogic
{
    public static class Scanner
    {
        public async static Task<bool> IsMutant(string[] dna)
        {
            int N = dna[0].Length;
            int totalSecuencies = 0;

            await Task.Run(() =>
            {
                var task = Spider.Scan1Leg(dna, N);
                totalSecuencies += task.Result;
            });
            if (totalSecuencies >= 2)
            {
                return true;
            }
            await Task.Run(() =>
            {
                var task = Spider.Scan2Legs(dna, N);
                totalSecuencies += task.Result;
            });
            if (totalSecuencies >= 2)
            {
                return true;
            }
            await Task.Run(() =>
            {
                var task = Spider.Scan3Legs(dna, N);
                totalSecuencies += task.Result;
            });
            if (totalSecuencies >= 2)
            {
                return true;
            }
            await Task.Run(() =>
            {
                var task = Spider.Scan4Legs(dna, N);
                totalSecuencies += task.Result;
            });

            return totalSecuencies >= 2 ? true : false;

        }
    }
}
