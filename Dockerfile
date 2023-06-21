FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App


COPY *.sln .
COPY ["API/API.csproj", "API/"]
COPY ["Core/Core.csproj", "Core/"]
COPY ["Infraestructura/Infraestructura.csproj", "Infraestructura/"]

RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /App
COPY --from=build-env /App/out .

EXPOSE 80

ENTRYPOINT [ "dotnet", "API.dll" ]

CMD ASPNETCORE_URLS=https://*:$PORT dotnet API.dll