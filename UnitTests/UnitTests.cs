using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameDayApp;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        private static DateName dateName = new DateName();
        private static string[] names = new string[] { };
       

        [TestMethod]
        public void CorrectFormatTest()
        {           
           names = DateInput.ProcessDate("2.9");
           Assert.IsTrue(names.Length > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void NotExistingDateTest()
        {
            names = DateInput.ProcessDate("31.12");            
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TriggerDataErrorTest()
        {
            names = DateInput.ProcessDate("22.999");            
        }
    }
}
