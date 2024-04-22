#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OptixTechnicalTest.csproj", "."]
RUN dotnet restore "./OptixTechnicalTest.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "OptixTechnicalTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OptixTechnicalTest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OptixTechnicalTest.dll"]

FROM node:16
WORKDIR /Frontend/MoviesWebpage/src/app
COPY . /app
EXPOSE 8080
CMD [ "npm", "run", "serve" ]