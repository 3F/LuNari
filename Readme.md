# LunaRoad

Lua C API for .NET


[![Build status](https://ci.appveyor.com/api/projects/status/yh1pnuhaqk8h334h/branch/master?svg=true)](https://ci.appveyor.com/project/3Fs/LunaRoad/branch/master)
[![NuGet package](https://img.shields.io/nuget/v/LunaRoad.svg)](https://www.nuget.org/packages/LunaRoad/) 

Easy to start:

```csharp
using(var l = new Lua<ILua51>("Lua51.dll")) {
    // ...
}
```

Flexible binding with **any exported function of library**, even if it's not provided today:

```csharp
// custom binding:
using(ILua l = new Lua("Lua52.dll")) {
    l.bind<Action<LuaState, LuaCFunction, int>>("pushcclosure")(L, onProc, 0);
    l.bind<Action<LuaState, string>>("setglobal")(L, "onKeyDown");
    //or any exported function like: bindFunc<...>("_full_name_")
    ...
    double num = l.bind<Func<LuaState, int, double>>("tonumber")(L, 7);
}

// API layer:
using(var l = new Lua<ILua53>("Lua53.dll")) {
    l.API.pushcclosure(L, onProc, 0); // ILua53 lua = l.API
    l.API.setglobal(L, "onKeyDown");
}
```

Unified API level for work between different versions:

```csharp
Lua<ILua53> l;
...
l.U.arith(L, LUA_OPSUB);
l.U.pop(L, 1);
```

and light access to specific:

```csharp
((ILua51)l.API).pushcclosure(L, onProc, 0);
l.v<ILua51>().pushcclosure(L, onProc, 0);
```

Powerful work with several libraries:

```csharp
using(var lSpec = new Lua("SpecLib.dll")) {
    using(ILua l = new Lua<ILua52>("Lua52.dll")) {
        //...
    }
}
```

and more ...

----


## License

The [MIT License (MIT)](https://github.com/3F/LunaRoad/blob/master/LICENSE) - be a ~free~ and open

##

### How to Get

Available variants:

* NuGet PM: `Install-Package LunaRoad`
* [GetNuTool](https://github.com/3F/GetNuTool): `msbuild gnt.core /p:ngpackages="LunaRoad"` or [gnt](https://github.com/3F/GetNuTool/releases/download/v1.5/gnt.bat) /p:ngpackages="LunaRoad"
* NuGet Commandline: `nuget install LunaRoad`
* [/releases](https://github.com/3F/LunaRoad/releases) ( [latest](https://github.com/3F/LunaRoad/releases/latest) )
* [Nightly builds](https://ci.appveyor.com/project/3Fs/LunaRoad/history) (`/artifacts` page). But remember: It can be unstable or not work at all. Use this for tests of latest changes.


### Roadmap

LunaRoad is already provides powerful and flexible binding. And as you can see above, you already may work between different versions via lambda-functions.
However, we also want to provide fully compatible API layer for more comfortable work with Lua 5.1, 5.2, 5.3 ...


### How to Contribute

Extend our API layer or improve all of what you want. It easy and completely transparent with our flexible architecture.

If you ready to contribute, just use the pull requests or send .patch file. If it's not a simple binding to cover API, please also provide a correct unit-tests.

The Application Program Interface of Lua:

* [v5.1](https://www.lua.org/manual/5.1/manual.html#3)
* [v5.2](https://www.lua.org/manual/5.2/manual.html#4)
* [v5.3](https://www.lua.org/manual/5.3/manual.html#4)