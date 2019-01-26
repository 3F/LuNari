using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using net.r_eg.LuNari.API;
using net.r_eg.LuNari.API.Lua51;

namespace net.r_eg.LuNariTest.API
{
    [TestClass]
    public class BridgeTest
    {
        [TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        public void providerTest1()
        {
            try {
                new Bridge<ILua51>(null);
                Assert.Fail("1");
            }
            catch(Exception ex) { Assert.IsTrue(ex.GetType() == typeof(ArgumentException), ex.GetType().ToString()); }

            var bridge = new Bridge<ILua51>(new _Provider());
        }
    }
}
