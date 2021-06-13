using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Spider.unit.tests
{
    [TestClass]
    public class SpiderUnitTest
    {

        [TestMethod]
        public async Task Scan1Leg_testAsync()
        {
            string[] dna = { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };
            int totalSecuencies = 0;
            int N = dna[0].Length;

            await Task.Run(() =>
            {
                var taskResult = DomainLogic.Spider.Scan1Leg(dna, N);
                totalSecuencies += taskResult.Result;
            });

            Assert.AreEqual(1, totalSecuencies);
        }
        [TestMethod]
        public async Task Scan2Legs_testAsync()
        {
            string[] dna = { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };
            int N = dna[0].Length;

            var task= DomainLogic.Spider.Scan2Legs(dna, N);

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
                var taskResult = DomainLogic.Spider.Scan3Legs(dna, N);
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
                var taskResult = DomainLogic.Spider.Scan4Legs(dna, N);
                totalSecuencies += taskResult.Result;
            });

            Assert.AreEqual(0, totalSecuencies);
        }
    }
}
