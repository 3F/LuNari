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

namespace net.r_eg.LuNari.API.Lua52
{
    /// <summary>
    /// lua.h,v 1.285.1.4 2015/02/21 14:04:50 roberto Exp $
    /// Lua.org, PUC-Rio, Brazil (http://www.lua.org)
    /// 
    /// the 'some useful macros' should be provided by ILua interface.
    /// </summary>
    public class LuaH: Lua51.LuaH
    {
        /// <summary>
        /// lua.h const data for Lua 5.2
        /// </summary>
        protected LuaH() { }

        /* thread status */

        /// <summary>
        /// Error while running a __gc metamethod.
        /// </summary>
        public const int LUA_ERRGCMM        = 5;

        /// <summary>
        /// Error while running the message handler.
        /// </summary>
        public new const int LUA_ERRERR     = 6;

        /* predefined values in the registry */

        /// <summary>
        /// At this index the registry has the main thread of the state.
        /// </summary>
        public const int LUA_RIDX_MAINTHREAD    = 1;

        /// <summary>
        /// At this index the registry has the global environment.
        /// </summary>
        public const int LUA_RIDX_GLOBALS       = 2;
        public const int LUA_RIDX_LAST          = LUA_RIDX_GLOBALS;

        /*
        ** Comparison and arithmetic functions
        */
                                /* ORDER TM */

        /// <summary>
        /// Performs addition (+)
        /// </summary>
        public const int LUA_OPADD  = 0;

        /// <summary>
        /// Performs subtraction (-)
        /// </summary>
        public const int LUA_OPSUB  = 1;

        /// <summary>
        /// Performs multiplication (*)
        /// </summary>
        public const int LUA_OPMUL  = 2;

        /// <summary>
        /// Performs division (/)
        /// </summary>
        public const int LUA_OPDIV  = 3;

        /// <summary>
        /// Performs modulo (%)
        /// </summary>
        public const int LUA_OPMOD  = 4;

        /// <summary>
        /// Performs exponentiation (^)
        /// </summary>
        public const int LUA_OPPOW  = 5;

        /// <summary>
        /// Performs mathematical negation (unary -)
        /// </summary>
        public const int LUA_OPUNM  = 6;

        /// <summary>
        /// Compares for equality (==)
        /// </summary>
        public const int LUA_OPEQ   = 0;

        /// <summary>
        /// Compares for less than (&lt;)
        /// </summary>
        public const int LUA_OPLT   = 1;

        /// <summary>
        /// Compares for less or equal (&lt;=)
        /// </summary>
        public const int LUA_OPLE   = 2;


        /*
        ** garbage-collection function and options
        */

        public const int LUA_GCSETMAJORINC  = 8;

        /// <summary>
        /// Returns a boolean that tells whether the collector is running 
        /// (i.e., not stopped).
        /// </summary>
        public const int LUA_GCISRUNNING    = 9;

        /// <summary>
        /// Changes the collector to generational mode.
        /// </summary>
        public const int LUA_GCGEN          = 10;

        /// <summary>
        /// Changes the collector to incremental mode. 
        /// This is the default mode.
        /// </summary>
        public const int LUA_GCINC          = 11;

        /*
        ** =======================================================================
        ** Debug API
        ** =======================================================================
        */

        /*
        ** Event codes
        */

        public const int LUA_HOOKTAILCALL   = 4;

    }
}
