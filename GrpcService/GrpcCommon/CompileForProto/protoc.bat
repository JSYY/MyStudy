%~d0
cd %~p0

set FolderName=%~dp0
for /f "delims=\" %%a in ('dir /b /a-d /o-d "%FolderName%\*.proto"') do (
  echo %%a
  protoc.exe --csharp_out=.\ %%a
)

pause

