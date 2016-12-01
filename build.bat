@echo off

set msbuild=tools/msbuild

call submodules "Conari/Conari.sln" || goto err

call %msbuild% gnt.core /p:ngconfig="packages.config" /nologo /v:m /m:4
call %msbuild% "LunaRoad.sln" /verbosity:normal /l:"packages\vsSBE.CI.MSBuild\bin\CI.MSBuild.dll" /m:4 /t:Rebuild /p:Configuration=Release

goto exit

:err

echo. Build failed. 1>&2

:exit