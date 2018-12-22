@echo off

rem ��ǰbat������
echo ==================begin========================

cls 

SET Redis_PATH=%~d0

SET Redis_DIR=%~dp0

%color 0a% 

TITLE Redis ������� Power By ��β�� (http://yanweidie.cnblogs.com)

CLS 

ECHO. 

ECHO. * * Redis ������� Power By ��β�� (http://yanweidie.cnblogs.com)  *  

ECHO. 

:MENU 

ECHO. * Redis ����list *  

tasklist|findstr /i "redis-server.exe"

ECHO. 

    ECHO.  [1] ����Redis  

    ECHO.  [2] �ر�Redis  

    ECHO.  [3] ����Redis 

    ECHO.  [4] �� �� 

ECHO. 

 
ECHO.������ѡ����Ŀ�����:

set /p ID=

    IF "%id%"=="1" GOTO start 

    IF "%id%"=="2" GOTO stop 

    IF "%id%"=="3" GOTO restart 

    IF "%id%"=="4" EXIT

PAUSE 

 

:start 

    call :startRedis

    GOTO MENU

 

:stop 

    call :shutdownRedis

    GOTO MENU

 

:restart 

    call :shutdownRedis

    call :startRedis

    GOTO MENU

 

:shutdownRedis

    ECHO. 

    ECHO.�ر�Redis...... 

    taskkill /F /IM redis-server.exe > nul

    ECHO.OK,�ر�����Redis ����

    goto :eof

 

:startRedis

    ECHO. 

    ECHO.����Redis...... 

    IF NOT EXIST "%Redis_DIR%redis-server.exe" ECHO "%Redis_DIR%redis-server.exe"������ 

 

    %Redis_PATH% 

 

    cd "%Redis_DIR%" 

 

    IF EXIST "%Redis_DIR%redis-server.exe" (

        echo "start '' redis-server.exe"

        start /b redis-server.exe redis.conf

    )

    ECHO.OK

    goto :eof