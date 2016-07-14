﻿/*
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

using System.Diagnostics.CodeAnalysis;
using net.r_eg.LunaRoad.API;

namespace net.r_eg.LunaRoad
{
    public class Lua: Lua<API.Lua51.ILua51>
    {
        /// <param name="lib">The Lua library.</param>
        public Lua(string lib) 
            : base(lib)
        {

        }
    }

    [SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly", Justification = "Bug. False positive. The IDisposable is already implemented correctly !")]
    public class Lua<TAPI>: Provider, ILua, ILoader, IProvider, IBinder/*, IDisposable*/
        where TAPI : ILevel
    {
        /// <summary>
        /// Current API version.
        /// </summary>
        public TAPI API
        {
            get;
            protected set;
        }

        /// <summary>
        /// Unspecified common interface to Lua C API Functions
        /// </summary>
        public ILuaCommon U
        {
            get {
                return (ILuaCommon)API;
            }
        }

        /// <summary>
        /// Gets specific API version.
        /// </summary>
        /// <typeparam name="T">type of API version.</typeparam>
        /// <returns></returns>
        public T v<T>() where T : ILevel
        {
            return (T)(ILevel)API;
        }

        /// <param name="lib">The Lua library.</param>
        public Lua(string lib)
        {
            load(lib);
            API = new API.Bridge<TAPI>(this).Lua;
        }
    }
}
