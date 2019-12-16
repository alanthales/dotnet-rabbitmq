FROM mcr.microsoft.com/dotnet/core/sdk:3.0-alpine AS build
WORKDIR /app

COPY . ./
RUN dotnet publish Bartender -c Release -o Bartender/out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-alpine AS runtime
WORKDIR /app
COPY --from=build /app/Bartender/out ./

ENTRYPOINT ["dotnet", "Bartender.dll"]
