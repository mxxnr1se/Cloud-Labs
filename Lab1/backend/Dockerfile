FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-env

COPY ./API /src/API/
COPY ./BLL /src/BLL
COPY ./DAL /src/DAL
COPY ./Shared /src/Shared

WORKDIR /src/API

RUN dotnet restore
RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime

WORKDIR /app

COPY --from=build-env /publish .

ENV COMPlus_EnableDiagnostics=0

EXPOSE 8080

ENTRYPOINT ["dotnet", "API.dll"]
