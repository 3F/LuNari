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

namespace net.r_eg.LunaRoad.API.Lua52
{
    public interface ILua52: ILevel
    {
        /// <summary>
        /// [-n, +1, e] void lua_pushcclosure (lua_State *L, lua_CFunction fn, int n);
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
        /// 
        /// When n is zero, this function creates a light C function, which is just a pointer to the C function. 
        /// In that case, it never throws a memory error. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="fn"></param>
        /// <param name="n">The maximum value is 255.</param>
        void pushcclosure(LuaState L, LuaCFunction fn, int n);

        /// <summary>
        /// [-1, +0, e] void lua_setfield (lua_State *L, int index, const char *k);
        /// 
        /// Does the equivalent to t[k] = v, where t is the value at the given index and v is the value at the top of the stack.
        /// This function pops the value from the stack. As in Lua, this function may trigger a metamethod for the "newindex" event.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="index"></param>
        /// <param name="k"></param>
        void setfield(LuaState L, int index, string k);

        /// <summary>
        /// [-1, +0, e] void lua_setglobal (lua_State *L, const char *name);
        /// 
        /// Pops a value from the stack and sets it as the new value of global name.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="name"></param>
        void setglobal(LuaState L, string name);

        /// <summary>
        /// [-0, +0, –] lua_Number lua_tonumber (lua_State *L, int index);
        /// 
        /// Equivalent to lua_tonumberx with isnum equal to NULL.
        /// lua_Number:
        ///  * typedef double lua_Number; - By default, it is double, but that can be changed.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="index">Lua value at the given index.</param>
        /// <returns></returns>
        double tonumber(LuaState L, int index);
    }
}
