set "SRVNAME=InstantJob"
set "SRVPROJ=Web\InstantJob.Api"
set "WEBNAME=instant-job"

set "WWWROOT=srv\%SRVNAME%\%SRVPROJ%\wwwroot"
set "WEBBUILD=web\%WEBNAME%\build"

cd web\%WEBNAME%\
call npm install
call npm run-script build
cd ..\..

IF EXIST %WWWROOT% (
    FOR /D %%p IN ("%WWWROOT%\*.*") DO rmdir "%%p" /S /Q
    del %WWWROOT%\*.* /F /Q
)

IF NOT EXIST %WWWROOT% (
	MKDIR %WWWROOT%
)

xcopy /e /v %WEBBUILD% %WWWROOT%