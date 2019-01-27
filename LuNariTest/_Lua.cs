using net.r_eg.LuNari;

namespace net.r_eg.LuNariTest
{
    internal sealed class _Lua: Lua
    {
        public _Lua()
            : base(new LuaConfig("") { LazyLoading = true })
        {

        }
    }
}
