using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoundMeasuringREST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundMeasuringREST.Tests
{
    [TestClass()]
    public class Service1Tests
    {
        [TestMethod()]
        public void GetAllMeasurmentsTest()
        {
            Service1 p = new Service1();
            var q = p.GetAllMeasurments();
            var u = q.Count;
            Assert.AreEqual(0,u);
        }

        [TestMethod()]
        public void GetAverageTest()
        {
            Service1 p = new Service1();
            Assert.AreEqual(27,p.GetAverage());
        }

        [TestMethod()]
        public void DeleteMeasurementsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CurrentMeasurmentTest()
        {
            Assert.Fail();
        }
    }
}