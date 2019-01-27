# LuNari

[![](./LuNari/Resources/LuNari.png)](https://github.com/3F/LuNari)

[Lua](https://www.lua.org) for .NET on [Conari engine](https://github.com/3F/Conari)

Provides *support** for all popular versions, like: 5.4, 5.3, 5.2, 5.1, ...

↳ *A few ways: API-layer and binding at runtime (DLR, Lambda expressions) with any Lua functions;*

[![Build status](https://ci.appveyor.com/api/projects/status/94y78phdvkoi5oda/branch/master?svg=true)](https://ci.appveyor.com/project/3Fs/lunaroad/branch/master)
[![release-src](https://img.shields.io/github/release/3F/LuNari.svg)](https://github.com/3F/LuNari/releases/latest)
[![License](https://img.shields.io/badge/License-MIT-74A5C2.svg)](https://github.com/3F/LuNari/blob/master/LICENSE)
[![NuGet package](https://img.shields.io/nuget/v/LuNari.svg)](https://www.nuget.org/packages/LuNari/) 

**Easy to start**:

```csharp
using(var l = new Lua<ILua51>("Lua.dll")) { // ILua51, ILua52, ILua53, ...
    // l. { request anything to Lua }
}
```

## License

The [MIT License (MIT)](https://github.com/3F/LuNari/blob/master/LICENSE)

```
Copyright (c) 2016,2017,2019  Denis Kuzmin < entry.reg@gmail.com > :: github.com/3F
```

[![Donate](https://www.paypalobjects.com/en_US/i/btn/btn_donate_SM.gif) ☕](https://3F.github.io/Donation/) 

## There are several methods to use LuNari

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

and **more!**


## How to Get

* NuGet PM: `Install-Package LuNari`
* [GetNuTool](https://github.com/3F/GetNuTool): `msbuild gnt.core /p:ngpackages="LuNari"` or [gnt](https://3f.github.io/GetNuTool/releases/latest/gnt/) /p:ngpackages="LuNari"
* NuGet Commandline: `nuget install LuNari`
* [/releases](https://github.com/3F/LuNari/releases) [ [latest](https://github.com/3F/LuNari/releases/latest) ]
* [Nightly builds](https://ci.appveyor.com/project/3Fs/LuNari/history) (`/artifacts` page). It can be unstable or not work at all. Use this only for tests of latest changes.
    * Artifacts [older than 6 months](https://www.appveyor.com/docs/packaging-artifacts/#artifacts-retention-policy) you can also find as `Pre-release` with mark `🎲 Nightly build` on [GitHub Releases](https://github.com/3F/LuNari/releases) page.


## Roadmap

LuNari already provides flexible binding at runime. That is, as you can see above, you already can do anything between different versions via lambda-functions and DLR features.
However, the main goal for this project is to provide fully compatible API layer for more comfortable work with any popular Lua version like: 5.1, 5.2, 5.3 ...

## Contribute

Extend our API layer or improve all of what you want. It's completely transparent with our flexible architecture.

Here's how to extend API: [in a few steps (Wiki)](https://github.com/3F/LuNari/wiki/API)

If you ready to contribute, please use [Pull Requests](https://help.github.com/articles/creating-a-pull-request/) (please through non-master branches). Other ways like .patch files are possible, but it may take more time to review the changes.

*Also note: if it's not a simple binding to cover API, please provide related unit-tests. Thanks.*

The Application Program Interface of Lua:

* [v5.1](https://www.lua.org/manual/5.1/manual.html#3)
* [v5.2](https://www.lua.org/manual/5.2/manual.html#4)
* [v5.3](https://www.lua.org/manual/5.3/manual.html#4)
* [v5.4](https://www.lua.org/manual/5.4/) *( preview )*

## How to Build

Use command:

```
.\build Debug
```

*This will generate Zip & NuGet packages as `LuNari.<version>.nupkg` etc.*

**Please note:** current repository contains [git submodules](https://git-scm.com/book/en/Git-Tools-Submodules). Our build-scripts will restore this automatically instead of you:

* Inside IDE by [vsSBE](https://visualstudiogallery.msdn.microsoft.com/0d1dbfd7-ed8a-40af-ae39-281bfeca2334/) v0.12.8+
* With msbuild tools by `submodules.bat`. 

But just a note, how to do it manually:

* For initial cloning repo:

```
git clone --recursive https://github.com/3F/LuNari.git
```

* For already cloned:

```
git submodule update --init --recursive
```
