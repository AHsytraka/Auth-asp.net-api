#Dockerfile
#SDK
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

#copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

#copy everything else and build
COPY . .
RUN dotnet publish -c Release -o out

#build runtime image
#RUNTIME
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .

#run the app on container startup
ENTRYPOINT ["dotnet", "Auth-Jwt.dll"]