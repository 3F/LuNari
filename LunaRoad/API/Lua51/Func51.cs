/*
 * The MIT License (MIT)
 * 
 * Copyright (c) 2016  Denis Kuzmin <entry.reg@gmail.com>
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
using net.r_eg.LunaRoad.Types;

namespace net.r_eg.LunaRoad.API.Lua51
{
    internal abstract class Func51: LuaX, ILua51
    {
        public virtual LuaVersion Version
        {
            get {
                return LuaVersion.Lua51;
            }
        }
        
        /// <summary>
        /// Lua provides a registry, a pre-defined table that can be used by any C code to store whatever Lua value it needs to store. 
        /// This table is always located at pseudo-index LUA_REGISTRYINDEX.
        /// (global const from lua.h as property)
        /// </summary>
        public int LUA_REGISTRYINDEX { get { return -10000; } }

        /// <summary>
        /// The environment of the running C function is always at pseudo-index LUA_ENVIRONINDEX.
        /// (global const from lua.h as property)
        /// </summary>
        public int LUA_ENVIRONINDEX { get { return -10001; } }

        /// <summary>
        /// The thread environment (where global variables live) is always at pseudo-index LUA_GLOBALSINDEX.
        /// (global const from lua.h as property)
        /// </summary>
        public int LUA_GLOBALSINDEX { get { return -10002; } }
        
        /// <summary>
        /// [-n, +1, m] void lua_pushcclosure (lua_State *L, lua_CFunction fn, int n);
        /// 
        /// Pushes a new C closure onto the stack.
        /// When a C function is created, it is possible to associate some values with it, thus creating a C closure;
        /// these values are then accessible to the function whenever it is called. 
        /// 
        /// To associate values with a C function, first these values should be pushed onto the stack 
        /// (when there are multiple values, the first value is pushed first). 
        /// Then lua_pushcclosure is called to create and push the C function onto the stack, 
        /// with the argument n telling how many values should be associated with the function. 
        /// 
        /// lua_pushcclosure also pops these values from the stack.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="fn"></param>
        /// <param name="n">The maximum value is 255.</param>
        public void pushcclosure(LuaState L, LuaCFunction fn, int n)
        {
            bind<Action<LuaState, LuaCFunction, int>>("pushcclosure")(L, fn, n);
        }

        /// <summary>
        /// [-1, +0, e] void lua_setfield (lua_State *L, int index, const char *k);
        /// 
        /// Does the equivalent to t[k] = v, where t is the value at the given valid index and v is the value at the top of the stack.
        /// This function pops the value from the stack.As in Lua, this function may trigger a metamethod for the "newindex" event.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="index"></param>
        /// <param name="k"></param>
        public void setfield(LuaState L, int index, string k)
        {
            bind<Action<LuaState, int, string>>("setfield")(L, index, k);
        }

        /// <summary>
        /// [-1, +0, e] void lua_setglobal (lua_State *L, const char *name);
        /// 
        /// Pops a value from the stack and sets it as the new value of global name. 
        /// 
        /// Note: 
        /// It is defined as a macro: 
        ///     #define lua_setglobal(L,s)   lua_setfield(L, LUA_GLOBALSINDEX, s)
        ///     
        ///  but it exists as part of Lua API in official documentation to v5.1, so we also cover this
        /// </summary>
        /// <param name="L"></param>
        /// <param name="name"></param>
        public virtual void setglobal(LuaState L, string name)
        {
            setfield(L, LUA_GLOBALSINDEX, name);
        }

        /// <summary>
        /// [-0, +0, -] lua_Number lua_tonumber (lua_State *L, int index);
        /// 
        /// Converts the Lua value at the given acceptable index to the C type lua_Number:
        ///   * typedef double lua_Number; - By default, it is double, but that can be changed.
        ///     
        /// The Lua value must be a number or a string convertible to a number; otherwise, lua_tonumber returns 0. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="index">Lua value at the given acceptable index.</param>
        /// <returns></returns>
        public LuaNumber tonumber(LuaState L, int index)
        {
            return bind<Func<LuaState, int, LuaNumber>>("tonumber")(L, index);
        }

        /// <summary>
        /// [-0, +0, m] const char *lua_tolstring (lua_State *L, int index, size_t *len);
        /// 
        /// Converts the Lua value at the given acceptable index to a C string. 
        /// If len is not NULL, it also sets *len with the string length. 
        /// The Lua value must be a string or a number; otherwise, the function returns NULL. 
        /// If the value is a number, then lua_tolstring also changes the actual value in the stack to a string. 
        /// (This change confuses lua_next when lua_tolstring is applied to keys during a table traversal.)
        /// </summary>
        /// <param name="L"></param>
        /// <param name="index">Lua value at the given acceptable index.</param>
        /// <param name="len">string length</param>
        /// <returns>
        /// a fully aligned pointer to a string inside the Lua state. 
        /// This string always has a zero ('\0') after its last character (as in C), but can contain other zeros in its body. 
        /// Because Lua has garbage collection, there is no guarantee that the pointer returned by lua_tolstring will be valid 
        /// after the corresponding value is removed from the stack.
        /// </returns>
        public CharPtr tolstring(LuaState L, int index, out size_t len)
        {
            return bind<FuncOut3<LuaState, int, size_t, IntPtr>>("tolstring")(L, index, out len);
        }

        /// <summary>
        /// [-0, +1, -] void lua_pushnumber (lua_State *L, lua_Number n);
        /// 
        /// Pushes a number with value n onto the stack.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n">value of number</param>
        public void pushnumber(LuaState L, LuaNumber n)
        {
            bind<Action<LuaState, LuaNumber>>("pushnumber")(L, n);
        }

        /// <summary>
        /// [-0, +1, m] void lua_pushstring (lua_State *L, const char *s);
        /// 
        /// Pushes the zero-terminated string pointed to by s onto the stack. 
        /// Lua makes (or reuses) an internal copy of the given string, so the memory at s can be freed or reused immediately after the function returns. 
        /// The string cannot contain embedded zeros; it is assumed to end at the first zero. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="s"></param>
        /// <internalWarning>
        ///     v5.2 uses another return-type. We can't override this ! 
        ///     Thus please note and be careful, do not use this inside other API-methods !
        /// </internalWarning>
        public virtual void pushstring(LuaState L, string s)
        {
            bind<Action<LuaState, string>>("pushstring")(L, s);
        }

        /// <summary>
        /// [-?, +?, -] void lua_settop (lua_State *L, int index);
        /// 
        /// Accepts any acceptable index, or 0, and sets the stack top to this index. 
        /// If the new top is larger than the old one, then the new elements are filled with nil. 
        /// If index is 0, then all stack elements are removed.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="index"></param>
        public void settop(LuaState L, int index)
        {
            bind<Action<LuaState, int>>("settop")(L, index);
        }

        /// <summary>
        /// [-0, +0, -] int lua_gettop (lua_State *L);
        /// 
        /// Returns the index of the top element in the stack. 
        /// Because indices start at 1, this result is equal to the number of elements in the stack (and so 0 means an empty stack).
        /// </summary>
        /// <param name="L"></param>
        /// <returns>the index of the top element in the stack.</returns>
        public int gettop(LuaState L)
        {
            return bind<Func<LuaState, int>>("gettop")(L);
        }

        /// <summary>
        /// [-0, +1, -] void lua_pushvalue (lua_State *L, int index);
        /// 
        /// Pushes a copy of the element at the given valid index onto the stack. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="index"></param>
        public void pushvalue(LuaState L, int index)
        {
            bind<Action<LuaState, int>>("pushvalue")(L, index);
        }

        /// <summary>
        /// [-0, +1, e] void lua_getfield (lua_State *L, int index, const char *k);
        /// 
        /// Pushes onto the stack the value t[k], where t is the value at the given valid index. 
        /// As in Lua, this function may trigger a metamethod for the "index" event.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="index"></param>
        /// <param name="k"></param>
        /// <internalWarning>
        ///     v5.3 uses another return-type. We can't override this ! 
        ///     Thus please note and be careful, do not use this inside other API-methods !
        /// </internalWarning>
        public virtual void getfield(LuaState L, int index, string k)
        {
            bind<Action<LuaState, int, string>>("getfield")(L, index, k);
        }

        /// <summary>
        /// [-2, +0, e] void lua_settable (lua_State *L, int index);
        /// 
        /// Does the equivalent to t[k] = v, 
        /// where t is the value at the given valid index, v is the value at the top of the stack, 
        /// and k is the value just below the top.
        /// 
        /// This function pops both the key and the value from the stack. 
        /// As in Lua, this function may trigger a metamethod for the "newindex" event.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="index"></param>
        public void settable(LuaState L, int index)
        {
            bind<Action<LuaState, int>>("settable")(L, index);
        }
    }
}
