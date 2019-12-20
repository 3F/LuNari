# [LuNari](https://github.com/3F/LuNari)

[![](./LuNari/Resources/LuNari.png)](https://github.com/3F/LuNari)

🗦🌔 ***LuNari*** is [Lua](https://www.lua.org) for .NET on [Conari engine](https://github.com/3F/Conari)

All actual Lua versions, like: Lua 5.4, 5.3, 5.2, 5.1, ...

[![Build status](https://ci.appveyor.com/api/projects/status/c016k5fdc3lm4191/branch/master?svg=true)](https://ci.appveyor.com/project/3Fs/lunari-0b02o/branch/master)
[![release-src](https://img.shields.io/github/release/3F/LuNari.svg)](https://github.com/3F/LuNari/releases/latest)
[![NuGet package](https://img.shields.io/nuget/v/LuNari.svg)](https://www.nuget.org/packages/LuNari/) 
[![License](https://img.shields.io/badge/License-MIT-74A5C2.svg)](https://github.com/3F/LuNari/blob/master/LICENSE)

[![Build history](https://buildstats.info/appveyor/chart/3Fs/lunari-0b02o?buildCount=15&includeBuildsFromPullRequest=true&showStats=true)](https://ci.appveyor.com/project/3Fs/lunari-0b02o/history)

## Why LuNari ?

Most popular features that will be adapted to your needs on the fly.

🔍 Easy to start:

```csharp
using(var l = new Lua<ILua53>("Lua.dll")) { // ILua51, ILua52, ILua53, ...
    // ...
}
```

🚀 Awesome speed:

Based on the fast versions of Conari engine with caching of 0x29 opcodes (Calli). [[?](https://github.com/3F/Conari#why-conari-)]


🔨 Its amazing dynamic features:

```csharp
using(dynamic l = new LuaD("Lua.dll"))
{
    // Lua now is yours ~
    IntPtr L = l.luaL_newstate<LuaState>();
    var num  = l.lua_tonumber<LuaNumber>(L, 1);
}
```

🍱 Damn customizable:

```csharp
var l = new Lua<ILua52>("Lua52.dll");

    l.API.pushcclosure(L, onProc, 0);
    l.bind<Action<LuaState, LuaCFunction, int>>("pushcclosure")(L, onProc, 0);
    l.v<ILua53>().pushcclosure(L, onProc, 0);
    ...
```

🔖 Modern **.NET Core**

LuNari is ready for .NET Core starting from 1.6. Its awesome dynamic features are also available even for [.NET Standard **2.0**](https://github.com/3F/Conari/issues/13).


🌚 Unlimited extensible features:

Since this works through [Conari](https://github.com/3F/Conari), you can access to all newest features of the Lua immediately after introducing this in draft. Just use it without waiting for release.


## 🗸 License

The [MIT License (MIT)](https://github.com/3F/LuNari/blob/master/LICENSE)

```
Copyright (c) 2016,2017,2019  Denis Kuzmin < entry.reg@gmail.com > GitHub/3F
```

[ [ ☕ Donate ](https://3F.github.com/Donation/) ]

LuNari contributors: https://github.com/3F/LuNari/graphs/contributors

We're waiting for your awesome contributions!

## Take a look closer

There are several ways to use LuNari: API-layer and binding at runtime (DLR, Lambda expressions)

### Dynamic features /DLR

This does not require neither our API(see below) nor something other from you at all. We will generate all your needs **automatically at runtime!** 

This is possible because of [Conari](https://github.com/3F/Conari). Thus, do whatever you want:

```csharp
// all this will be generated at runtime, i.e. you can use all of what you need from Lua as you like:
d.pushcclosure(L, onProc, 0);
d.setglobal(L, "onKeyDown");
...
LuaNumber num = d.tonumber<LuaNumber>(L, 7);
```

### Lambda expressions

You also can use your custom binding for what you need:

```csharp
using(ILua l = new Lua("Lua52.dll"))
{
    l.bind<Action<LuaState, LuaCFunction, int>>("pushcclosure")(L, onProc, 0);
    l.bind<Action<LuaState, string>>("setglobal")(L, "onKeyDown");
    //or any exported function like: bindFunc<...>("_full_name_")
    ...
    LuaNumber num = l.bind<Func<LuaState, int, LuaNumber>>("tonumber")(L, 7);
}
```

### API Layer

Standardized way that covers an original [Lua](https://www.lua.org) features. 5.3, 5.2, 5.1, ...

```csharp
using(var l = new Lua<ILua53>("Lua53.dll"))
{
    l.API.pushcclosure(L, onProc, 0); // ILua53 lua = l.API
    l.API.setglobal(L, "onKeyDown");
}
```

Unified API level between different versions:

```csharp
Lua<ILua53> l;
...
// to avoid ambiguity if exists: l.U as ILua51 ~
l.U.arith(L, LUA_OPSUB);
l.U.pop(L, 1);
```

Other lightweight access to specific:

```csharp
// any direction, for example: v5.2 <-> v5.1
l.v<ILua51>().pushcclosure(L, onProc, 0);

// from the higher version to the lower, for example: v5.2 -> v5.1
((ILua51)l.API).pushcclosure(L, onProc, 0);
```

## Something else

Powerful work with several libraries:

```csharp
using(var lSpec = new Lua("SpecLua.dll"))
{
    using(ILua l = new Lua<ILua52>("Lua52.dll"))
    {
        // ...
    }
}
```

Additional types:

```csharp

size_t len;
CharPtr name = lua.tolstring(L, 1, out len);
...
string myName += name; // (IntPtr)name; .Raw; .Ansi; .Utf8; ...
...
LuaNumber mv = lua.tonumber(L, 2);
```

Lazy loading:

```csharp
using(var l = new Lua<ILua51>(
                    new LuaConfig("Lua51.dll") {
                        LazyLoading = true
                    }))
{
    ...
}
```

and more!

## How to Get LuNari

* NuGet: [![LuNari](https://img.shields.io/nuget/v/LuNari.svg)](https://www.nuget.org/packages/LuNari/) 
    * Old packages before 1.5: [LunaRoad](https://www.nuget.org/packages/LunaRoad/)
* [GetNuTool](https://github.com/3F/GetNuTool): `msbuild gnt.core /p:ngpackages="LuNari"` or **[gnt](https://3f.github.io/GetNuTool/releases/latest/gnt/)** /p:ngpackages="LuNari"
* [GitHub Releases](https://github.com/3F/LuNari/releases) [ [latest](https://github.com/3F/LuNari/releases/latest) ]
* CI builds: [`CI /artifacts`](https://ci.appveyor.com/project/3Fs/lunari-0b02o/history) ( [old CI](https://ci.appveyor.com/project/3Fs/lunari/history) ) or find `🎲 CI build` on [GitHub Releases](https://github.com/3F/LuNari/releases) page.

## Roadmap

LuNari already provides flexible binding at runime. That is, as you can see above, you already can do anything between different versions via lambda-functions and DLR features.
However, an important goal of this project is also to provide a fully compatible API layer for more comfortable work with any popular Lua versions like: Lua 5.1, 5.2, 5.3 ...

## Contribute

Extend our API layer or improve all of what you want. It's completely transparent with our flexible architecture.

Here's how to extend API: [in a few steps (Wiki)](https://github.com/3F/LuNari/wiki/API.Dev). Please use [Pull Requests](https://help.github.com/articles/creating-a-pull-request/) if you ready to contribute.

The Application Program Interface of Lua:

* [v5.1](https://www.lua.org/manual/5.1/manual.html#3)
* [v5.2](https://www.lua.org/manual/5.2/manual.html#4)
* [v5.3](https://www.lua.org/manual/5.3/manual.html#4)
* [v5.4](https://www.lua.org/manual/5.4/) *( preview )*

## How to Build LuNari

Our build was based on [vssbe](https://github.com/3F/vsSolutionBuildEvent) scripts. 

You don't need to do anything else, just navigate to root directory of this project, and:

```bat
.\build Debug
```

**Or** please use v1.14+ plugin for [Visual Studio](https://visualstudiogallery.msdn.microsoft.com/0d1dbfd7-ed8a-40af-ae39-281bfeca2334/)