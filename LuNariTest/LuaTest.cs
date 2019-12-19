using System;
using net.r_eg.Conari.Exceptions;
using net.r_eg.LuNari;
using net.r_eg.LuNari.API;
using net.r_eg.LuNari.API.Lua51;
using net.r_eg.LuNari.API.Lua52;
using Xunit;

namespace LuNariTest
{
    public class LuaTest
    {
        private const string STUB_LIB_NAME = "__ThisIsNotRealLuaLib";

        [Fact]
        public void loadTest1()
        {
            Assert.Throws<ArgumentNullException>(() => new Lua(null));

            Assert.Throws<LoadLibException>(() => new Lua(STUB_LIB_NAME));

            Assert.Throws<ArgumentNullException>(() => new Lua(string.Empty));
        }

        /// <summary>
        /// [high to low]
        /// To pass, we shouldn't see InvalidCastException
        /// </summary>
        [Fact]
        public void castingTest1()
        {
            var cfg = new LuaConfig() { LazyLoading = true };

            using(var l = new Lua<ILua52>(cfg)) 
            {
                Assert.Equal(LuaVersion.Lua52, l.API.Version);

                Assert.Equal(LuaVersion.Lua52, ((ILua51)l.API).Version);

                Assert.Equal(LuaVersion.Lua51, (l.v<ILua51>()).Version);
            }
        }

        /// <summary>
        /// [high to low]
        /// To pass, we shouldn't see InvalidCastException
        /// </summary>
        [Fact]
        public void castingTest2()
        {
            var cfg = new LuaConfig() { LazyLoading = true };

            using(ILua l = new Lua<ILua52>(cfg)) 
            {
                Assert.Equal(LuaVersion.Lua53, ((ILua51)l.U).Version); // because l.U contains latest ILuaN

                Assert.Equal(LuaVersion.Lua51, (l.v<ILua51>()).Version);
            }
        }

        /// <summary>
        /// [low to high]
        /// To pass, we shouldn't see InvalidCastException
        /// </summary>
        [Fact]
        public void castingTest3()
        {
            var cfg = new LuaConfig() { LazyLoading = true };

            using(ILua l = new Lua<ILua51>(cfg)) 
            {
                Assert.Equal(LuaVersion.Lua53, ((ILua52)l.U).Version); // because l.U contains latest ILuaN

                Assert.Equal(LuaVersion.Lua52, (l.v<ILua52>()).Version); // because it recreates initial bridge
            }
        }

        /// <summary>
        /// [low to high]
        /// </summary>
        [Fact]
        public void castingTest4()
        {
            var cfg = new LuaConfig() { LazyLoading = true };

            using(var l = new Lua<ILua51>(cfg)) 
            {
                Assert.Throws<InvalidCastException>(() => (ILua52)l.API); // std. l.API contains the initialized 51
            }
        }

        /// <summary>
        /// between ILua
        /// To pass, we shouldn't see InvalidCastException
        /// </summary>
        [Fact]
        public void castingTest5()
        {
            var cfg = new LuaConfig() { LazyLoading = true };

            using(ILua l = new Lua<ILua51>(cfg)) 
            {
                Assert.Equal(LuaVersion.Lua51, (((Lua<ILua51>)l).API).Version);
            }

            using(ILua l = new Lua<ILua52>(cfg)) 
            {
                Assert.Equal(LuaVersion.Lua52, (((Lua<ILua52>)l).API).Version);
            }
        }

        [Fact]
        public void funcNameTest1()
        {
            var l = new StubLua();

            Assert.Throws<ArgumentException>(() => l.procName(string.Empty));

            Assert.Throws<ArgumentException>(() => l.procName(null));
        }
    }
}
