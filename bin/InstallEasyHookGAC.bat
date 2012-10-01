@ECHO ###########################################################
@ECHO #                                                         #
@ECHO # Assuming solution location of C:\Projects\Direct3D9Hook #
@ECHO #                                                         #
@ECHO #    (must be run as administrator to install to GAC)     #
@ECHO #                                                         #
@ECHO ###########################################################
@ECHO off
pause

gac.exe /i "EasyHook.dll"
pause