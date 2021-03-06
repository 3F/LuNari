﻿/*
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

using net.r_eg.Conari.Core;
using net.r_eg.LuNari.API.Lua51;
using net.r_eg.LuNari.API.Lua52;
using net.r_eg.LuNari.API.Lua53;

namespace net.r_eg.LuNari.API
{
    internal sealed class Bridge<TAPI>: LuaFuncN, IAPI<TAPI>, ILuaCommon, ILua51, ILua52, ILua53 
        where TAPI: ILevel
    {
        public TAPI Lua
        {
            get
            {
                var type = typeof(TAPI);

                if(type == typeof(ILua51)) {
                    return (TAPI)(ILevel)new Impl51(provider);
                }

                if(type == typeof(ILua52)) {
                    return (TAPI)(ILevel)new Impl52(provider);
                }

                //if(type == typeof(ILua53)) {
                //    return (TAPI)(ILevel)new Impl53(provider);
                //}

                return (TAPI)(ILevel)this;
            }
        }

        public Bridge(IProvider provider)
        {
            setProvider(provider);
        }
    }
}
