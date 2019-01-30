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

namespace net.r_eg.LuNari.API.Lua53
{
    /// <summary>
    /// lua.h,v 1.331 2016/05/30 15:53:28 roberto Exp $
    /// Lua.org, PUC-Rio, Brazil (http://www.lua.org)
    /// 
    /// the 'some useful macros' should be provided by ILua interface.
    /// </summary>
    public class LuaH: Lua52.LuaH
    {
        /// <summary>
        /// lua.h const data for Lua 5.3
        /// </summary>
        protected LuaH() { }

        /*
        ** Comparison and arithmetic functions
        */
                        /* ORDER TM, ORDER OP */

        /// <summary>
        ///  performs modulo (%)
        /// </summary>
        public new const int LUA_OPMOD  = 3;

        /// <summary>
        ///  performs exponentiation (^)
        /// </summary>
        public new const int LUA_OPPOW  = 4;

        /// <summary>
        /// performs float division (/)
        /// </summary>
        public new const int LUA_OPDIV  = 5;

        /// <summary>
        /// performs floor division (//)
        /// </summary>
        public const int LUA_OPIDIV     = 6;

        /// <summary>
        ///  performs bitwise AND (&)
        /// </summary>
        public const int LUA_OPBAND     = 7;

        /// <summary>
        ///  performs bitwise OR (|)
        /// </summary>
        public const int LUA_OPBOR      = 8;

        /// <summary>
        /// performs bitwise exclusive OR (~)
        /// </summary>
        public const int LUA_OPBXOR     = 9;

        /// <summary>
        /// performs left shift (&lt;&lt;)
        /// </summary>
        public const int LUA_OPSHL      = 10;

        /// <summary>
        /// performs right shift (&gt;&gt;)
        /// </summary>
        public const int LUA_OPSHR      = 11;

        /// <summary>
        /// performs mathematical negation (unary -)
        /// </summary>
        public new const int LUA_OPUNM  = 12;

        /// <summary>
        /// performs bitwise NOT (~)
        /// </summary>
        public const int LUA_OPBNOT     = 13;

    }
}
