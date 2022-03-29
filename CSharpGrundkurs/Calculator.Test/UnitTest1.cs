using CalculationLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Calculator.Test
{
    [TestClass]
    public class UnitTest1
    {
        MyCalculator myCalculator;
        
        
        [ClassInitialize]
        public void Initialize()
        {
            myCalculator = new MyCalculator();
        }

        [TestMethod]
        public void TestMethod1()
        {
            int a = 11;
            int b = 12;

            Assert.AreEqual(myCalculator.Addieren(a, b), 23);
        }
    }
}
