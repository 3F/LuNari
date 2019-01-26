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

namespace net.r_eg.LuNari
{
    public struct LuaState
    {
        /// <summary>
        /// Pointer to lua_State struct
        /// </summary>
        /// <remarks>
        /// v5.1:
        ///    GCObject *next; 
        ///    lu_byte tt; 
        ///    lu_byte marked;
        ///    lu_byte status;
        ///    StkId top;  // first free slot in the stack
        ///    StkId base;  // base of current function
        ///    global_State *l_G;
        ///    CallInfo *ci;  // call info for current function
        ///    const Instruction *savedpc;  // `savedpc' of current function
        ///    StkId stack_last;  // last free slot in the stack
        ///    StkId stack;  // stack base
        ///    CallInfo *end_ci;  // points after end of ci array*/
        ///    CallInfo *base_ci;  // array of CallInfo's
        ///    int stacksize;
        ///    int size_ci;  // size of array `base_ci'
        ///    unsigned short nCcalls;  // number of nested C calls
        ///    unsigned short baseCcalls;  // nested C calls when resuming coroutine
        ///    lu_byte hookmask;
        ///    lu_byte allowhook;
        ///    int basehookcount;
        ///    int hookcount;
        ///    lua_Hook hook;
        ///    TValue l_gt;  // table of globals
        ///    TValue env;  // temporary place for environments
        ///    GCObject *openupval;  // list of open upvalues in this stack
        ///    GCObject *gclist;
        ///    struct lua_longjmp *errorJmp;  // current error recover point
        ///    ptrdiff_t errfunc;  // current error handling function (stack index)
        /// </remarks>
        private IntPtr ptr;

        public static implicit operator IntPtr(LuaState state)
        {
            return state.ptr;
        }

        public static implicit operator LuaState(IntPtr ptr)
        {
            return new LuaState(ptr);
        }

        public LuaState(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }
}
