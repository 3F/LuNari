/*
 * The MIT License (MIT)
 * 
 * Copyright (c) 2016-2017  Denis Kuzmin <entry.reg@gmail.com>
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

namespace net.r_eg.LunaRoad.Rt_
{
    /// <summary>
    /// This used to avoid problem with overriding, when child uses another return-type.
    /// Other variants:
    /// * Just replace method only in child object ('new' keyword) - but for this way be careful, it cannot be really overridden. 
    ///   However for our case it also a correct variant ! It was before with `internalWarning` tags.
    /// * Or, avoid classic horizontal inheritance. For example, the Mixin and Traits should help :)
    /// </summary>
    public struct LuaState
    {
        private LunaRoad.LuaState luaState;

        public static implicit operator LunaRoad.LuaState(LuaState lsv)
        {
            return lsv.luaState;
        }

        public static implicit operator IntPtr(LuaState lsv)
        {
            return lsv.luaState;
        }

        public static implicit operator LuaState(LunaRoad.LuaState L)
        {
            return new LuaState(L);
        }

        public static implicit operator LuaState(IntPtr ptr)
        {
            return new LuaState(ptr);
        }

        public LuaState(LunaRoad.LuaState L)
        {
            luaState = L;
        }
    }
}
