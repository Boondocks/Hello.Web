#===========================================================
# We'll use this to build the .NET Core code.
#===========================================================
FROM microsoft/dotnet:sdk AS core-build-step

#copy the code to the image
COPY ./src/ /build/

#move to the build directory
WORKDIR /build/

#restore and publish the bloody api
RUN dotnet publish \
    --runtime ubuntu.16.04-x64 \
	--framework netcoreapp2.0 \
	--source https://api.nuget.org/v3/index.json \
	/build/Hello.Web/Hello.Web.csproj

#===========================================================
# Now start making the actual image
#===========================================================
FROM microsoft/dotnet:runtime
	
#copy the built files over to the device.
COPY --from=core-build-step /build/Hello.Web/bin/Debug/netcoreapp2.0/ubuntu.16.04-x64/publish/ /opt/hello/

#Expose the web port
EXPOSE 80

#move to our application folder
WORKDIR /opt/hello/

#start up the application
CMD ["dotnet", "Hello.Web.dll"]