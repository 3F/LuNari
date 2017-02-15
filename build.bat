@echo off

set reltype=%1
set _gnt=tools/gnt
set _msbuild=tools/msbuild

if "%reltype%"=="" (
    set reltype=Release
)

call submodules "Conari/Conari.sln" || goto err

call %_gnt% /p:wpath="%cd%" /p:ngconfig="packages.config" /nologo /v:m /m:4 || goto err

call %_msbuild% -notamd64 "LunaRoad.sln" /v:normal /l:"packages\vsSBE.CI.MSBuild\bin\CI.MSBuild.dll" /m:4 /t:Rebuild /p:Configuration=%reltype% || goto err

goto exit

:err

echo. Build failed. 1>&2

:exit