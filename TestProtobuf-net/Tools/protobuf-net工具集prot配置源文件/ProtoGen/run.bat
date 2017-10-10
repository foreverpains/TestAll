rem protogen.exe -i:protos\ReturnMessage.proto -o:cs\ReturnMessage.cs
rem protogen.exe -i:protos\Login.proto -o:cs\Login.cs

@echo off  
rem 查找文件  
for /f "delims=" %%i in ('dir /b ".\protos\*.proto"') do echo %%i  
rem 转cpp  for /f "delims=" %%i in ('dir /b/a "*.proto"') do protoc -I=. --cpp_out=. %%i  
for /f "delims=" %%i in ('dir /b/a ".\protos\*.proto"') do protogen.exe -i:protos\%%i -o:cs\%%~ni.cs  
pause  