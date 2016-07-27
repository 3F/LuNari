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

using net.r_eg.LunaRoad.Types;

namespace net.r_eg.LunaRoad.API.Lua53
{
    public interface ILua53: ILevel
    {
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
        /// 
        /// When n is zero, this function creates a light C function, which is just a pointer to the C function. 
        /// In that case, it never raises a memory error. 
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
        ///  * typedef ... lua_Number; - By default this type is double, but that can be changed to a single float or a long double. 
        ///    (See LUA_FLOAT_TYPE in luaconf.h)
        /// </summary>
        /// <param name="L"></param>
        /// <param name="index">Lua value at the given index.</param>
        /// <returns></returns>
        LuaNumber tonumber(LuaState L, int index);

        /// <summary>
        /// [-0, +0, m] const char *lua_tolstring (lua_State *L, int index, size_t *len);
        /// 
        /// Converts the Lua value at the given index to a C string. 
        /// If len is not NULL, it sets *len with the string length. 
        /// The Lua value must be a string or a number; otherwise, the function returns NULL. 
        /// If the value is a number, then lua_tolstring also changes the actual value in the stack to a string. 
        /// (This change confuses lua_next when lua_tolstring is applied to keys during a table traversal.) 
        /// 
        /// lua_tolstring returns a pointer to a string inside the Lua state. 
        /// This string always has a zero ('\0') after its last character (as in C), 
        /// but can contain other zeros in its body. 
        /// 
        /// Because Lua has garbage collection, there is no guarantee that the pointer returned by lua_tolstring 
        /// will be valid after the corresponding Lua value is removed from the stack. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="index">Lua value at the given acceptable index.</param>
        /// <param name="len">string length</param>
        /// <returns></returns>
        CharPtr tolstring(LuaState L, int index, out size_t len);

        /// <summary>
        /// [-0, +1, -] void lua_pushnumber (lua_State *L, lua_Number n);
        /// 
        /// Pushes a number with value n onto the stack.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n">value of number</param>
        void pushnumber(LuaState L, LuaNumber n);

        /// <summary>
        /// [-0, +1, m] const char *lua_pushstring (lua_State *L, const char *s);
        /// 
        /// Pushes the zero-terminated string pointed to by s onto the stack. 
        /// Lua makes (or reuses) an internal copy of the given string, 
        /// so the memory at s can be freed or reused immediately after the function returns.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="s">If s is NULL, pushes nil and returns NULL.</param>
        /// <returns>a pointer to the internal copy of the string.</returns>
        CharPtr pushstring(Rt_.LuaState L, string s);

        /// <summary>
        /// [-?, +?, -] void lua_settop (lua_State *L, int index);
        /// 
        /// Accepts any index, or 0, and sets the stack top to this index. 
        /// If the new top is larger than the old one, then the new elements are filled with nil. 
        /// If index is 0, then all stack elements are removed.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="index"></param>
        void settop(LuaState L, int index);

        /// <summary>
        /// [-0, +0, -] int lua_gettop (lua_State *L);
        /// 
        /// Returns the index of the top element in the stack. 
        /// Because indices start at 1, this result is equal to the number of elements in the stack; in particular, 0 means an empty stack. 
        /// </summary>
        /// <param name="L"></param>
        /// <returns>the index of the top element in the stack.</returns>
        int gettop(LuaState L);

        /// <summary>
        /// [-0, +1, -] void lua_pushvalue (lua_State *L, int index);
        /// 
        /// Pushes a copy of the element at the given index onto the stack.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="index"></param>
        void pushvalue(LuaState L, int index);

        /// <summary>
        /// [-0, +1, e] int lua_getfield (lua_State *L, int index, const char *k);
        /// 
        /// Pushes onto the stack the value t[k], where t is the value at the given index. 
        /// As in Lua, this function may trigger a metamethod for the "index" event.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="index"></param>
        /// <param name="k"></param>
        int getfield(Rt_.LuaState L, int index, string k);

        /// <summary>
        /// [-2, +0, e] void lua_settable (lua_State *L, int index);
        /// 
        /// Does the equivalent to t[k] = v, 
        /// where t is the value at the given index, v is the value at the top of the stack, 
        /// and k is the value just below the top.
        /// 
        /// This function pops both the key and the value from the stack. 
        /// As in Lua, this function may trigger a metamethod for the "newindex" event.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="index"></param>
        void settable(LuaState L, int index);

        /// <summary>
        /// [-2, +0, m] void lua_rawset (lua_State *L, int index);
        /// 
        /// Similar to lua_settable, but does a raw assignment (i.e., without metamethods).
        /// </summary>
        /// <param name="L"></param>
        /// <param name="index"></param>
        void rawset(LuaState L, int index);

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
        void rawseti(LuaState L, int index, LuaInteger i);

        /// <summary>
        /// [-1, +1, -] void lua_rawget (lua_State *L, int index);
        /// 
        /// Similar to lua_gettable, but does a raw access (i.e., without metamethods).
        /// </summary>
        /// <param name="L"></param>
        /// <param name="index"></param>
        int rawget(Rt_.LuaState L, int index);

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
        int rawgeti(LuaState L, int index, LuaInteger n);

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
        int gettable(Rt_.LuaState L, int index);

        /// <summary>
        /// [-(nargs + 1), +nresults, e] void lua_call (lua_State *L, int nargs, int nresults);
        /// 
        /// Calls a function.
        /// 
        /// To call a function you must use the following protocol: 
        /// first, the function to be called is pushed onto the stack; then, the arguments to the function are pushed in direct order; 
        /// that is, the first argument is pushed first.
        /// 
        /// Finally you call lua_call; nargs is the number of arguments that you pushed onto the stack. 
        /// All arguments and the function value are popped from the stack when the function is called. 
        /// The function results are pushed onto the stack when the function returns.
        /// 
        /// The number of results is adjusted to nresults, unless nresults is LUA_MULTRET. 
        /// In this case, all results from the function are pushed. 
        /// Lua takes care that the returned values fit into the stack space, but it does not ensure any extra space in the stack. 
        /// The function results are pushed onto the stack in direct order (the first result is pushed first), 
        /// so that after the call the last result is on the top of the stack. 
        /// 
        /// Any error inside the called function is propagated upwards (with a longjmp).
        /// </summary>
        /// <param name="L"></param>
        /// <param name="nargs"></param>
        /// <param name="nresults"></param>
        void call(LuaState L, int nargs, int nresults);

        /// <summary>
        /// [-(nargs + 1), +(nresults|1), –] int lua_pcall (lua_State *L, int nargs, int nresults, int msgh);
        /// 
        /// Calls a function in protected mode.
        /// 
        /// Both nargs and nresults have the same meaning as in lua_call. 
        /// If there are no errors during the call, lua_pcall behaves exactly like lua_call. 
        /// However, if there is any error, lua_pcall catches it, pushes a single value on the stack (the error object), 
        /// and returns an error code. Like lua_call, lua_pcall always removes the function and its arguments from the stack. 
        /// 
        /// In case of runtime errors, this function will be called with the error object and 
        /// its return value will be the object returned on the stack by lua_pcall. 
        /// 
        /// Typically, the message handler is used to add more debug information to the error object, 
        /// such as a stack traceback. Such information cannot be gathered after the return of lua_pcall, 
        /// since by then the stack has unwound. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="nargs"></param>
        /// <param name="nresults"></param>
        /// <param name="msgh">
        /// If msgh is 0, then the error object returned on the stack is exactly the original error object. 
        /// Otherwise, msgh is the stack index of a message handler. (This index cannot be a pseudo-index.) 
        /// </param>
        /// <returns>
        /// The lua_pcall function returns one of the following codes (defined in lua.h): 
        ///     * LUA_OK (0): success.
        ///     * LUA_ERRRUN: a runtime error.
        ///     * LUA_ERRMEM: memory allocation error. For such errors, Lua does not call the message handler.
        ///     * LUA_ERRERR: error while running the message handler.
        ///     * LUA_ERRGCMM: error while running a __gc metamethod. (This error typically has no relation with the function being called.)
        /// </returns>
        int pcall(LuaState L, int nargs, int nresults, int msgh);

        /// <summary>
        /// [-0, +1, -] void lua_pushnil (lua_State *L);
        /// 
        /// Pushes a nil value onto the stack. 
        /// </summary>
        /// <param name="L"></param>
        void pushnil(LuaState L);

        /// <summary>
        /// [-0, +1, -] void lua_pushinteger (lua_State *L, lua_Integer n);
        /// 
        /// Pushes a number with value n onto the stack.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        void pushinteger(LuaState L, LuaInteger n);

        /// <summary>
        /// [-n, +0, -] void lua_pop (lua_State *L, int n);
        /// 
        /// Pops n elements from the stack.
        /// 
        /// Note: 
        /// It is defined as a macro: 
        ///     #define lua_pop(L,n)    lua_settop(L, -(n)-1)
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        void pop(LuaState L, int n);

        /// <summary>
        /// [-0, +1, e] int lua_getglobal (lua_State *L, const char *name);
        /// 
        /// Pushes onto the stack the value of the global name. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="name"></param>
        /// <returns>Returns the type of that value.</returns>
        int getglobal(Rt_.LuaState L, string name);

        /// <summary>
        /// [-0, +0, -] int lua_type (lua_State *L, int index);
        /// 
        /// Returns the type of the value in the given valid index, 
        /// or LUA_TNONE for a non-valid (but acceptable) index.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="index"></param>
        /// <returns>
        /// The types returned by lua_type are coded by the following constants defined in lua.h: 
        /// LUA_TNIL (0), LUA_TNUMBER, LUA_TBOOLEAN, LUA_TSTRING, LUA_TTABLE, LUA_TFUNCTION, LUA_TUSERDATA, 
        /// LUA_TTHREAD, and LUA_TLIGHTUSERDATA.
        /// </returns>
        int type(LuaState L, int index);
    }
}
