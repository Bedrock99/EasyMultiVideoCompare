@echo off
echo Kompiliere EasyMultiVideoCompare.sln...
FOR /F "tokens=2* skip=2" %%a in ('reg query "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\devenv.exe"') do SET vsPath=%%b

@echo on
%vsPath% "..\EasyMultiVideoCompare.sln" /Rebuild "Release"
@echo off

if %errorlevel%==0 (
	echo EasyMultiVideoCompare erfolgreich kompiliert!
) else (
    echo EasyMultiVideoCompare konnte nicht kompiliert werden!
)

echo Erstelle Setup...
@echo on
"C:\Program Files (x86)\Inno Setup 6\ISCC.exe" "Setup.iss"
@echo off
if %errorlevel%==0 (
	echo EasyMultiVideoCompare Setup erfolgreich erstellt!
) else (
    echo EasyMultiVideoCompare Setup konnte nicht erstellt werden!
)
pause