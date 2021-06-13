using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagnetoApp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spider.unit.tests
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void Scan1leg_test()
        //{
        //    string sequence = "AAAA";
        //    string horizontal1 = "AAAA";
        //    string horizontal2 = "ATAA";

        //   int value1= MagnetoApp.Spider.Scan1leg(sequence, horizontal1);
        //   int value2= MagnetoApp.Spider.Scan1leg(sequence, horizontal2);

        //    Assert.AreEqual(1, value1);
        //    Assert.AreEqual(0, value2);
        //}
        //[TestMethod]
        //public void CountVertical_test()
        //{
        //    string sequence = "AAAA";
        //    string[] dna = { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG" };
        //    string[] dna2 = { "ATGCGA", "AAGTGC", "ATATGT", "AGAAGG" };
        //    int startIndex = 0;
        //    int value1 = MagnetoApp.Spider.CountVertical(startIndex, sequence, dna);
        //    int value2 = MagnetoApp.Spider.CountVertical(startIndex, sequence, dna2);


        //    Assert.AreEqual(0, value1);
        //    Assert.AreEqual(1, value2);
        //}

        //[TestMethod]
        //public void CountLeftDiagonal_test()
        ////{
        //    string sequence = "GGGG";
        //    string[] dna = { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG" };
        //    string[] dna2 = { "ATGGGA", "CAGTGC", "TGATGT", "GGAAGG" };
        //    int startIndex = 3; 
        //    int value1 = MagnetoApp.Spider.CountLeftDiagonal(startIndex, sequence, dna);
        //    int value2 = MagnetoApp.Spider.CountLeftDiagonal(startIndex, sequence, dna2);

        //    Assert.AreEqual(0, value1);
        //    Assert.AreEqual(1, value2);
        //}
        //[TestMethod]
        //public void CountRightDiagonal_test()
        //{
        //    string sequence = "AAAA";
        //    string[] dna = { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG" };
        //    string[] dna2 = { "ATGGGA", "CAGTGC", "TGATGT", "GGTTGG" };
        //    int startIndex = 0;
        //    int value1 = MagnetoApp.Spider.CountRightDiagonal(startIndex, sequence, dna);
        //    int value2 = MagnetoApp.Spider.CountRightDiagonal(startIndex, sequence, dna2);

        //    Assert.AreEqual(1, value1);
        //    Assert.AreEqual(0, value2);
        //}
        //[TestMethod]
        //public void Sundna_test()
        //{
        //    string[] dna = { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };
        //    int N = dna[0].Length;
        //    //int totalSecuencies = 0;

        //    for (int i = 0; i < N; i++)
        //    {
        //        string[] subDna = new List<string>(dna).GetRange(i, 4).ToArray();
        //    }
        //}

        //[TestMethod]
        //public void IsMutant_true_test()
        //{
        //    string[] dna = { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };
        //    bool isMutant = MagnetoApp.Scanner.IsMutant(dna);

        //    Assert.AreEqual(true, isMutant);
        //}
        //[TestMethod]
        //public void IsMutant_false_test()
        //{
        //    string[] dna = { "ATGCGA", "CAGTGC", "TTATTT", "AGACGG", "GCGTCA", "TCACTG" };
        //    bool isMutant = MagnetoApp.Scanner.IsMutant(dna);

        //    Assert.AreEqual(false, isMutant);
        //}

        [TestMethod]
        public async Task Scan1Leg_testAsync()
        {
            string[] dna = { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };
            int totalSecuencies = 0;
            int N = dna[0].Length;

            await Task.Run(() =>
            {
                var taskResult = MagnetoApp.Spider.Scan1Leg(dna, N);
                totalSecuencies += taskResult.Result;
            });

            Assert.AreEqual(1, totalSecuencies);
        }
        [TestMethod]
        public async Task Scan2Legs_testAsync()
        {
            string[] dna = { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };
            int N = dna[0].Length;

            var task= MagnetoApp.Spider.Scan2Legs(dna, N);

            await task;

            Assert.AreEqual(1, task.Result);
        }
        [TestMethod]
        public async Task Scan3Legs_testAsync()
        {
            string[] dna = { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };
            int totalSecuencies = 0;
            int N = dna[0].Length;

            await Task.Run(() =>
            {
                var taskResult = MagnetoApp.Spider.Scan3Legs(dna, N);
                totalSecuencies += taskResult.Result;
            });

            Assert.AreEqual(1, totalSecuencies);
        }
        [TestMethod]
        public async Task Scan4Legs_testAsync()
        {
            string[] dna = { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };
            int totalSecuencies = 0;
            int N = dna[0].Length;

            await Task.Run(() =>
            {
                var taskResult = MagnetoApp.Spider.Scan4Legs(dna, N);
                totalSecuencies += taskResult.Result;
            });

            Assert.AreEqual(0, totalSecuencies);
        }


    }
}
