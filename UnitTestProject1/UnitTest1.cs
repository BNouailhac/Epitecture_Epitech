using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using System.Collections.ObjectModel;
using System.IO;
using System.Diagnostics;
using System.Net;
using epicture;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private const int Expected = 0;
        [TestMethod]
        public void TestMethod1()
        {
           // epicture.MainWindow test_class = new MainWindow();
            int i = 0;
            Assert.AreEqual(Expected, i);
        }   
    }
}
