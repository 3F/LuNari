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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using net.r_eg.LunaRoad.API;

namespace net.r_eg.LunaRoad
{
    public class Lua: Lua<API.Lua51.ILua51>
    {
        public Lua(LuaConfig cfg) 
            : base(cfg)
        {

        }

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
        private Dictionary<Type, ILevel> cacheL = new Dictionary<Type, ILevel>();

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
                return (ILuaCommon)bridge<ILuaN>();
            }
        }

        /// <summary>
        /// Gets specific API version.
        /// </summary>
        /// <typeparam name="T">type of API version.</typeparam>
        /// <returns></returns>
        public T v<T>() where T : ILevel
        {
            return ((IAPI<T>)bridge<T>()).Lua;
        }

        public Lua(LuaConfig cfg)
        {
            if(cfg.LazyLoading) {
                Library = new Link(cfg.LibName);
            }
            else {
                load(cfg.LibName);
            }

            API = v<TAPI>();
        }
        
        /// <param name="lib">The Lua library.</param>
        public Lua(string lib)
            : this((LuaConfig)lib)
        {

        }

        protected T bridge<T>() where T : ILevel
        {
            var type = typeof(T);

            if(!cacheL.ContainsKey(type)) {
                cacheL[type] = new API.Bridge<T>(this);
            }

            return (T)cacheL[type];
        }
    }
}
