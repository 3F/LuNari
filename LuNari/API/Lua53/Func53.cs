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
using net.r_eg.LuNari.API.Lua52;
using net.r_eg.LuNari.Types;

namespace net.r_eg.LuNari.API.Lua53
{
    internal abstract class Func53: Func52, ILua53
    {
        public override LuaVersion Version
        {
            get {
                return LuaVersion.Lua53;
            }
        }

        /// <summary>
        /// [-0, +1, –] void lua_pushcfunction (lua_State *L, lua_CFunction f);
        /// 
        /// Pushes a C function onto the stack. This function receives a pointer to a C function 
        /// and pushes onto the stack a Lua value of type function that, when called, invokes the corresponding C function.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="f"></param>
        public override void pushcfunction(LuaState L, LuaCFunction f)
        {
            bind<Action<LuaState, LuaCFunction>>("pushcfunction")(L, f);
        }

        /// <summary>
        /// [-0, +1, e] int lua_getfield (lua_State *L, int index, const char *k);
        /// 
        /// Pushes onto the stack the value t[k], where t is the value at the given index. 
        /// As in Lua, this function may trigger a metamethod for the "index" event.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="index"></param>
        /// <param name="k"></param>
        public int getfield(_.LuaState L, int index, string k)
        {
            return bind<Func<LuaState, int, string, int>>("getfield")(L, index, k);
        }

        /// <summary>
        /// [-1, +0, m] void lua_rawseti (lua_State *L, int index, lua_Integer i);
        /// 
        /// Does the equivalent of t[i] = v, where t is the table at the given index 
        /// and v is the value at the top of the stack.
        /// 
        /// This function pops the value from the stack. 
        /// The assignment is raw, that is, it does not invoke the __newindex metamethod.  
        /// </summary>
        /// <param name="L"></param>
        /// <param name="index"></param>
        /// <param name="i"></param>
        public void rawseti(LuaState L, int index, LuaInteger i)
        {
            bind<Action<LuaState, int, LuaInteger>>("rawseti")(L, index, i);
        }

        /// <summary>
        /// [-1, +1, -] void lua_rawget (lua_State *L, int index);
        /// 
        /// Similar to lua_gettable, but does a raw access (i.e., without metamethods).
        /// </summary>
        /// <param name="L"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public int rawget(_.LuaState L, int index)
        {
            return bind<Func<LuaState, int, int>>("rawget")(L, index);
        }

        /// <summary>
        /// [-0, +1, -] int lua_rawgeti (lua_State *L, int index, lua_Integer n);
        /// 
        /// Pushes onto the stack the value t[n], where t is the table at the given index. 
        /// The access is raw, that is, it does not invoke the __index metamethod.  
        /// </summary>
        /// <param name="L"></param>
        /// <param name="index"></param>
        /// <param name="n"></param>
        /// <returns>the type of the pushed value.</returns>
        public int rawgeti(LuaState L, int index, LuaInteger n)
        {
            return bind<Func<LuaState, int, LuaInteger, int>>("rawgeti")(L, index, n);
        }

        /// <summary>
        /// [-1, +1, e] int lua_gettable (lua_State *L, int index);
        /// 
        /// Pushes onto the stack the value t[k], where t is the value at the given index 
        /// and k is the value at the top of the stack.
        /// 
        /// This function pops the key from the stack, pushing the resulting value in its place. 
        /// As in Lua, this function may trigger a metamethod for the "index" event.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="index"></param>
        /// <returns>the type of the pushed value.</returns>
        public int gettable(_.LuaState L, int index)
        {
            return bind<Func<LuaState, int, int>>("rawgeti")(L, index);
        }

        /// <summary>
        /// [-0, +1, e] void lua_getglobal (lua_State *L, const char *name);
        /// 
        /// Pushes onto the stack the value of the global name. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="name"></param>
        /// <returns>Returns the type of that value.</returns>
        public int getglobal(_.LuaState L, string name)
        {
            return bind<Func<LuaState, string, int>>("getglobal")(L, name);
        }
    }
}
