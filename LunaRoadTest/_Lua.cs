using net.r_eg.LunaRoad;

namespace net.r_eg.LunaRoadTest
{
    internal sealed class _Lua: Lua
    {
        public _Lua()
            : base(new LuaConfig("") { LazyLoading = true })
        {

        }
    }
}
