using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using epicture;

namespace epicture_unitest
{
    [TestClass]
    public class UnitTest1
    {
        private const int Expected = 0;
        [TestMethod]
        public void TestMethod1()
        {
            epicture.MainWindow test_class = new MainWindow();
            test_class.Start_imgur("f7a587fdaf84afa", "91b0fe46d92a877fdc8c1d2017f77aee5126569f");
            Assert.AreEqual(Expected, test_class.test);
        }
    }
}
