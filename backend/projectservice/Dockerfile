FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-env

COPY ./projectservice /src/projectservice/
COPY ./BLL /src/BLL
COPY ./DAL /src/DAL
COPY ./DBContext /src/DBContext
COPY ./Entities /src/Entities
COPY ./Shared /src/Shared

WORKDIR /src/projectservice

RUN dotnet restore
RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime

WORKDIR /app

COPY --from=build-env /publish .

ENV COMPlus_EnableDiagnostics=0

EXPOSE 8080

ENTRYPOINT ["dotnet", "projectservice.dll"]
