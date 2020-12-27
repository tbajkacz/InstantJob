set "SRVNAME=InstantJob"
set "SRVPROJ=Web\InstantJob.Api"
set "WEBNAME=instant-job"

cd srv\
call infra-up

cd %SRVNAME%\%SRVPROJ%\

dotnet run -c Release

cd ..\..\..\..