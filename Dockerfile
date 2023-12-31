FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app


COPY *.sln .
COPY ["API/API.csproj", "API/"]
COPY ["Core/Core.csproj", "Core/"]
COPY ["Infraestructura/Infraestructura.csproj", "Infraestructura/"]

RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build-env /app/out .

# Expose port 80
EXPOSE 8081

ENTRYPOINT [ "dotnet", "API.dll" ]

CMD ASPNETCORE_URLS=https://*:$PORT dotnet API.dll