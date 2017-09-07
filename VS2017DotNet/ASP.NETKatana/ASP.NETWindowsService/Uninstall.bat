@ECHO OFF

echo Uninstalling ASP.NETWindowsService...
c:\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe /u /LogFile= /LogToConsole=true ASP.NETWindowsService.exe
pause