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
using System.Runtime.InteropServices;
using net.r_eg.Conari;
using net.r_eg.Conari.Core;

namespace net.r_eg.LuNari
{
    /// <summary>
    /// Lua via Conari engine [DLR version]
    /// Requires full name to requested lua function by default (IConfig).
    /// </summary>
    public sealed class LuaD: ConariX, IConari, API.IBinder
    {
        private const CallingConvention __v_conv = CallingConvention.Cdecl;

        public override CallingConvention Convention
        {
            get => __v_conv;
            set => throw new NotSupportedException();
        }

        /// <summary>
        /// Initialize Lua via Conari engine [DLR version].
        /// </summary>
        /// <param name="cfg">Custom configuration. Module cannot be overridden.</param>
        public LuaD(IConfig cfg)
            : base(cfg, __v_conv, null)
        {

        }

        /// <summary>
        /// Initialize Lua via Conari engine [DLR version].
        /// </summary>
        /// <param name="lib">The Lua library.</param>
        public LuaD(string lib)
            : this((LuaConfig)lib)
        {

        }
    }
}