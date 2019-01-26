@echo off

echo Checking submodules ...

set _dep=%1

if "%_dep%"=="" (
    echo Incorrect command.
    goto exit
)


if not exist "%_dep%" goto restore
REM ...

goto exit

:restore

echo.
echo. Whoops, you need to update git submodules.
echo. But we'll update this automatically.
echo.
echo. Please wait...
echo.

git submodule update --init --recursive 2>nul || goto gitNotFound

:: Where to find... TODO:
:: HKEY_LOCAL_MACHINE\SOFTWARE\GitForWindows
:: HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Git_is1
:: HKEY_CURRENT_USER\SOFTWARE\TortoiseGit

goto exit

:gitNotFound

if not exist ".git" (
    echo.  1>&2
    echo To restore submodules via Git scm you should have a `.git` folder, but we can't find this. 1>&2
    echo Unfortunately you should get this manually, or try to clone initially with recursive option: `git clone --recursive ...` 1>&2
    exit /B 3
)

echo.  1>&2
echo. `git` was not found or something went wrong. Check your connection and env. variable `PATH`. Or get submodules manually: 1>&2
echo.     1. Use command `git submodule update --init --recursive` 1>&2
echo.     2. Or clone initially with recursive option: `git clone --recursive ...` 1>&2
echo.  1>&2

exit /B 2

:exit

exit /B 0