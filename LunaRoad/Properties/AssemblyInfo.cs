using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using net.r_eg.LunaRoad;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Lua C API for .NET [ github.com/3F/LunaRoad ]")]
[assembly: AssemblyDescription("LunaRoad")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("LunaRoad")]
[assembly: AssemblyCopyright("entry.reg@gmail.com")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// friendly assemblies
[assembly: InternalsVisibleTo("LunaRoadTest, PublicKey=002400000480000094000000060200000024000052534131000400000100010013224edc96bef3" +
                                                      "a150fcff282af16abf503647200e69724148c64f6d6b7ae8b2251052892dd5a0a5d41c6f9f161a" +
                                                      "f799e9e94db8bbfa07440c7ada5f0f31de3e7b3d9374bc48839d39592d7c33c8813114f9a467d4" +
                                                      "77af6a3eb99fbc5a66084c667046ceac3b962add0a4e87a916fea3c6977ed0e51df496eb3caba8" +
                                                      "dc32cd92")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("7D9B802F-C175-47A8-AEB4-606EC6B44CC2")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
[assembly: AssemblyVersion(LunaRoadVersion.numberString + ".*")]
//[assembly: AssemblyVersion("1.0.0.0")]
//[assembly: AssemblyFileVersion("1.0.0.0")]
