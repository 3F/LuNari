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

namespace net.r_eg.LuNari.API.Lua51
{
    /// <summary>
    /// lua.h,v 1.218.1.7 2012/01/13 20:36:20 roberto Exp $
    /// Lua.org, PUC-Rio, Brazil (http://www.lua.org)
    /// 
    /// the 'some useful macros' should be provided by ILua interface.
    /// </summary>
    public class LuaH
    {
        /// <summary>
        /// lua.h const data for Lua 5.1
        /// </summary>
        protected LuaH() { }

        /// <summary>
        /// Mark for precompiled code (`esc`Lua)
        /// </summary>
        public const string LUA_SIGNATURE = "\x1bLua";

        /// <summary>
        /// Option for multiple returns in `lua_pcall' and `lua_call'
        /// </summary>
        public const int LUA_MULTRET = -1;

        /*
        ** pseudo-indices
        */

        /// <summary>
        /// Lua provides a registry, a pre-defined table that can be used by any C code to store whatever Lua value it needs to store. 
        /// This table is always located at pseudo-index LUA_REGISTRYINDEX.
        /// (global const from lua.h as property)
        /// </summary>
        public const int LUA_REGISTRYINDEX = -10000;

        /// <summary>
        /// The environment of the running C function is always at pseudo-index LUA_ENVIRONINDEX.
        /// (global const from lua.h as property)
        /// </summary>
        public const int LUA_ENVIRONINDEX = -10001;

        /// <summary>
        /// The thread environment (where global variables live) is always at pseudo-index LUA_GLOBALSINDEX.
        /// (global const from lua.h as property)
        /// </summary>
        public const int LUA_GLOBALSINDEX = -10002;

        /* thread status; 0 is OK */

        /// <summary>
        /// No errors.
        /// </summary>
        public const int LUA_OK         = 0; //+

        public const int LUA_YIELD      = 1;

        /// <summary>
        /// A runtime error.
        /// </summary>
        public const int LUA_ERRRUN     = 2;

        /// <summary>
        /// Syntax error during pre-compilation.
        /// </summary>
        public const int LUA_ERRSYNTAX  = 3;

        /// <summary>
        /// Memory allocation error. 
        /// For such errors, Lua does not call the error handler function.
        /// </summary>
        public const int LUA_ERRMEM     = 4;

        /// <summary>
        /// Error while running the error handler function.
        /// </summary>
        public const int LUA_ERRERR     = 5;

        /*
        ** basic types
        */

        /// <summary>
        /// Non-valid (but acceptable).
        /// </summary>
        public const int LUA_TNONE = -1;

        public const int LUA_TNIL           = 0;
        public const int LUA_TBOOLEAN       = 1;
        public const int LUA_TLIGHTUSERDATA = 2;
        public const int LUA_TNUMBER        = 3;
        public const int LUA_TSTRING        = 4;
        public const int LUA_TTABLE         = 5;
        public const int LUA_TFUNCTION      = 6;
        public const int LUA_TUSERDATA      = 7;
        public const int LUA_TTHREAD        = 8;

        /*
        ** garbage-collection function and options
        */

        /// <summary>
        /// Stops the garbage collector.
        /// </summary>
        public const int LUA_GCSTOP         = 0;

        /// <summary>
        /// Restarts the garbage collector.
        /// </summary>
        public const int LUA_GCRESTART      = 1;

        /// <summary>
        /// Performs a full garbage-collection cycle.
        /// </summary>
        public const int LUA_GCCOLLECT      = 2;

        /// <summary>
        /// Returns the current amount of memory (in Kbytes) in use by Lua.
        /// </summary>
        public const int LUA_GCCOUNT        = 3;

        /// <summary>
        /// Returns the remainder of dividing the current amount of bytes 
        /// of memory in use by Lua by 1024.
        /// </summary>
        public const int LUA_GCCOUNTB       = 4;

        /// <summary>
        /// Performs an incremental step of garbage collection.
        /// </summary>
        public const int LUA_GCSTEP         = 5;

        /// <summary>
        /// Sets data as the new value for the pause of the collector.
        /// </summary>
        public const int LUA_GCSETPAUSE     = 6;

        /// <summary>
        /// Sets data as the new value for the step multiplier of the collector.
        /// </summary>
        public const int LUA_GCSETSTEPMUL   = 7;

        /*
        ** =======================================================================
        ** Debug API
        ** =======================================================================
        */

        /*
        ** Event codes
        */

        public const int LUA_HOOKCALL       = 0;
        public const int LUA_HOOKRET        = 1;
        public const int LUA_HOOKLINE       = 2;
        public const int LUA_HOOKCOUNT      = 3;
        public const int LUA_HOOKTAILRET    = 4;

        /*
        ** Event masks
        */

        public const int LUA_MASKCALL   = 1 << LUA_HOOKCALL;
        public const int LUA_MASKRET    = 1 << LUA_HOOKRET;
        public const int LUA_MASKLINE   = 1 << LUA_HOOKLINE;
        public const int LUA_MASKCOUNT  = 1 << LUA_HOOKCOUNT;
    }
}
