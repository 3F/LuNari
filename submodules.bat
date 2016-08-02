@echo off

echo. checking submodules ...

if not exist "Conari" goto restore
REM ...

goto exit

:restore

echo.
echo. We detected that you need to update git submodules.
echo. We already do it automatically. Solution of VS IDE is also should be updated after ending of this process by the action via `Sln-Opened` event. If not, please reopen .sln file again.
echo.
echo. Please wait...
echo.

git submodule update --init --recursive 2>nul || goto err_gitNotFound

REM Where to find... TODO:
REM HKEY_LOCAL_MACHINE\SOFTWARE\GitForWindows
REM HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Git_is1
REM HKEY_CURRENT_USER\SOFTWARE\TortoiseGit

goto exit

:err_gitNotFound

echo.  1>&2
echo. `git` was not found or something went wrong. Check your connection and env. variable `PATH`. Or get submodules manually: 1>&2
echo.     1. Use command `git submodule update --init --recursive` 1>&2
echo.     2. Or clone initially with recursive option: `git clone --recursive ...` 1>&2
echo.  1>&2

:exit