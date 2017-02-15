using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using net.r_eg.Conari.Exceptions;
using net.r_eg.LunaRoad;
using net.r_eg.LunaRoad.API.Lua51;
using net.r_eg.LunaRoad.API.Lua52;

namespace net.r_eg.LunaRoadTest
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
        //[ExpectedException(typeof(ArgumentException))]
        public void loadTest2()
        {
            new _Lua();

            try {
                new Lua("");
                Assert.Fail("2");
            }
            catch(Exception ex) { Assert.IsTrue(ex.GetType() == typeof(ArgumentException), ex.GetType().ToString()); }
        }

        /// <summary>
        /// [high to low]
        /// To pass, we shouldn't see InvalidCastException
        /// </summary>
        [TestMethod]
        public void castingTest1()
        {
            var cfg = new LuaConfig() { LazyLoading = true };

            using(var l = new Lua<ILua52>(cfg)) {
                var a = (ILua51)l.API;
                var b = l.v<ILua51>();
            }

            using(ILua l = new Lua<ILua52>(cfg)) {
                var a = (ILua51)l.U;
                var b = l.v<ILua51>();
            }
        }

        /// <summary>
        /// [low to high]
        /// To pass, we shouldn't see InvalidCastException
        /// </summary>
        [TestMethod]
        public void castingTest2()
        {
            var cfg = new LuaConfig() { LazyLoading = true };

            using(ILua l = new Lua<ILua51>(cfg)) {
                var a = (ILua52)l.U; // because l.U contains latest ILuaN
                var b = l.v<ILua52>(); // because it recreates initial bridge
            }

            using(var l = new Lua<ILua51>(cfg)) {
                var a = (ILua52)l.U; // because l.U contains latest ILuaN
                var b = l.v<ILua52>(); // because it recreates initial bridge
            }
        }

        /// <summary>
        /// [low to high]
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void castingTest3()
        {
            var cfg = new LuaConfig() { LazyLoading = true };

            using(var l = new Lua<ILua51>(cfg)) {
                var a = (ILua52)l.API; // std. l.API contains the initialized 51
            }
        }

        /// <summary>
        /// between ILua
        /// To pass, we shouldn't see InvalidCastException
        /// </summary>
        [TestMethod]
        public void castingTest4()
        {
            var cfg = new LuaConfig() { LazyLoading = true };

            using(ILua l = new Lua<ILua51>(cfg)) {
                var a = ((Lua<ILua51>)l).API;
            }

            using(ILua l = new Lua<ILua52>(cfg)) {
                var a = ((Lua<ILua52>)l).API;
            }
        }

        [TestMethod]
        public void funcNameTest1()
        {
            var l = new _Provider();

            try {
                l.procName("");
                Assert.Fail("1");
            }
            catch(Exception ex) { Assert.IsTrue(ex.GetType() == typeof(ArgumentException), ex.GetType().ToString()); }

            try {
                l.procName(null);
                Assert.Fail("2");
            }
            catch(Exception ex) { Assert.IsTrue(ex.GetType() == typeof(ArgumentException), ex.GetType().ToString()); }
        }
    }
}
