using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using net.r_eg.LunaRoad;
using net.r_eg.LunaRoad.Exceptions;

namespace net.r_eg.LunaRoadTes
{
    [TestClass]
    public class LuaTest
    {
        private const string STUB_LIB_NAME = "__ThisIsNotRealLuaLib";

        [TestMethod]
        public void loadTest1()
        {
            try {
                new Lua(null);
                Assert.Fail("1");
            }
            catch(Exception ex) { Assert.IsTrue(ex.GetType() == typeof(ArgumentException), ex.GetType().ToString()); }

            try {
                new Lua(STUB_LIB_NAME);
                Assert.Fail("2");
            }
            catch(Exception ex) { Assert.IsTrue(ex.GetType() == typeof(LoadLibException), ex.GetType().ToString()); }
            
        }

        [TestMethod]
        public void funcNameTest1()
        {
            var l = new Provider();

            try {
                l.funcName("");
                Assert.Fail("1");
            }
            catch(Exception ex) { Assert.IsTrue(ex.GetType() == typeof(ArgumentException), ex.GetType().ToString()); }

            try {
                l.funcName(null);
                Assert.Fail("2");
            }
            catch(Exception ex) { Assert.IsTrue(ex.GetType() == typeof(ArgumentException), ex.GetType().ToString()); }
        }
    }
}
