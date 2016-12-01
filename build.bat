@echo off

set msbuild=tools/msbuild

call submodules "Conari/Conari.sln" || goto err

call %msbuild% gnt.core /p:ngconfig="packages.config" /nologo /v:m /m:4
call "packages\vsSBE.CI.MSBuild\bin\CI.MSBuild" "LunaRoad.sln" /verbosity:normal /m:4 /t:Rebuild /p:Configuration=Release

goto exit

:err

echo. Build failed. 1>&2

:exit