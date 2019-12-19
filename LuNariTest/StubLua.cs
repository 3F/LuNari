using net.r_eg.LuNari;

namespace LuNariTest
{
    internal sealed class StubLua: Lua
    {
        public StubLua()
            : base(new LuaConfig("") { LazyLoading = true })
        {

        }
    }
}
