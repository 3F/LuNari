/*
 * The MIT License (MIT)
 * 
 * Copyright (c) 2016,2017,2019  Denis Kuzmin < entry.reg@gmail.com > :: github.com/3F
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
*/

using System;
using net.r_eg.Conari.Types;
using net.r_eg.LuNari.API.Lua51;

namespace net.r_eg.LuNari.API.Lua52
{
    internal abstract class Func52: Func51, ILua52
    {
        public override LuaVersion Version
        {
            get {
                return LuaVersion.Lua52;
            }
        }

        /// <summary>
        /// [-1, +0, e] void lua_setglobal (lua_State *L, const char *name);
        /// 
        /// Pops a value from the stack and sets it as the new value of global name.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="name"></param>
        public override void setglobal(LuaState L, string name)
        {
            bind<Action<LuaState, string>>("setglobal")(L, name);
        }

        /// <summary>
        /// [-0, +1, e] const char *lua_pushstring (lua_State *L, const char *s);
        /// 
        /// Pushes the zero-terminated string pointed to by s onto the stack. 
        /// Lua makes (or reuses) an internal copy of the given string, 
        /// so the memory at s can be freed or reused immediately after the function returns.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="s">If s is NULL, pushes nil and returns NULL.</param>
        /// <returns>a pointer to the internal copy of the string.</returns>
        public CharPtr pushstring(Rt_.LuaState L, string s)
        {
            return bind<Func<Rt_.LuaState, string, IntPtr>>("pushstring")(L, s);
        }

        /// <summary>
        /// [-0, +1, e] void lua_getglobal (lua_State *L, const char *name);
        /// 
        /// Pushes onto the stack the value of the global name.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="name"></param>
        public override void getglobal(LuaState L, string name)
        {
            bind<Action<LuaState, string>>("getglobal")(L, name);
        }
    }
}
