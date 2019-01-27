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
    public sealed class LuaH
    {
        /// <summary>
        /// mark for precompiled code (`esc`Lua)
        /// </summary>
        public const string LUA_SIGNATURE = "\033Lua";

        /// <summary>
        /// Option for multiple returns in `lua_pcall' and `lua_call'
        /// </summary>
        public const int LUA_MULTRET = -1;

        /* thread status */

        public const int LUA_OK         = 0;
        public const int LUA_YIELD      = 1;
        public const int LUA_ERRRUN     = 2;
        public const int LUA_ERRSYNTAX  = 3;
        public const int LUA_ERRMEM     = 4;
        public const int LUA_ERRGCMM    = 5;
        public const int LUA_ERRERR     = 6;

        /*
        ** basic types
        */

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

        /* predefined values in the registry */

        public const int LUA_RIDX_MAINTHREAD    = 1;
        public const int LUA_RIDX_GLOBALS       = 2;
        public const int LUA_RIDX_LAST          = LUA_RIDX_GLOBALS;

        /*
        ** Comparison and arithmetic functions
        */

        public const int LUA_OPADD  = 0; /* ORDER TM */
        public const int LUA_OPSUB  = 1;
        public const int LUA_OPMUL  = 2;
        public const int LUA_OPDIV  = 3;
        public const int LUA_OPMOD  = 4;
        public const int LUA_OPPOW  = 5;
        public const int LUA_OPUNM  = 6;

        public const int LUA_OPEQ   = 0;
        public const int LUA_OPLT   = 1;
        public const int LUA_OPLE   = 2;


        /*
        ** garbage-collection function and options
        */

        public const int LUA_GCSTOP         = 0;
        public const int LUA_GCRESTART      = 1;
        public const int LUA_GCCOLLECT      = 2;
        public const int LUA_GCCOUNT        = 3;
        public const int LUA_GCCOUNTB       = 4;
        public const int LUA_GCSTEP         = 5;
        public const int LUA_GCSETPAUSE     = 6;
        public const int LUA_GCSETSTEPMUL   = 7;
        public const int LUA_GCSETMAJORINC  = 8;
        public const int LUA_GCISRUNNING    = 9;
        public const int LUA_GCGEN          = 10;
        public const int LUA_GCINC          = 11;

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
        public const int LUA_HOOKTAILCALL   = 4;

        /*
        ** Event masks
        */

        public const int LUA_MASKCALL   = 1 << LUA_HOOKCALL;
        public const int LUA_MASKRET    = 1 << LUA_HOOKRET;
        public const int LUA_MASKLINE   = 1 << LUA_HOOKLINE;
        public const int LUA_MASKCOUNT  = 1 << LUA_HOOKCOUNT;
    }
}
