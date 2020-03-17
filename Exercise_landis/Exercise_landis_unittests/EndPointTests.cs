using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise_landis;
using Exercise_landis.Control;
using Exercise_landis.Model;
using System.Collections.Generic;

namespace Exercise_landis_unittests
{
    [TestClass]
    public class EndPointTests
    {
        [TestMethod]
        public void ValidParameterInIsInputValidState()
        {
            int state = 2;

            EndPoint endPoint = new EndPoint();

            bool result = endPoint.IsInputValidState(state);

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void InvalidParameterInIsInputValidState()
        {
            int state = 5;

            EndPoint endPoint = new EndPoint();

            bool result = endPoint.IsInputValidState(state);

            Assert.IsFalse(result);

        }

        [TestMethod]
        public void NumberInIsNumber()
        {
            string value = "12";

            EndPoint endPoint = new EndPoint();

            bool result = endPoint.IsNumber(value, false);

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void CharactersInIsNumber()
        {
            string value = "xml";

            EndPoint endPoint = new EndPoint();

            bool result = endPoint.IsNumber(value, false);

            Assert.IsFalse(result);

        }

    }
}
