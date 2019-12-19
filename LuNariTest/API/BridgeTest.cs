using System;
using net.r_eg.LuNari.API;
using net.r_eg.LuNari.API.Lua51;
using Xunit;

namespace LuNariTest.API
{
    public class BridgeTest
    {
        [Fact]
        public void providerTest1()
        {
            Assert.Throws<ArgumentException>(() => 
            {
                new Bridge<ILua51>(null);
            });
        }

        [Fact]
        public void providerTest2()
        {
            var l = new Bridge<ILua51>(new StubLua());
            Assert.NotNull(l.Lua);
            Assert.Equal(LuaVersion.Lua53, l.Version);
        }
    }
}
