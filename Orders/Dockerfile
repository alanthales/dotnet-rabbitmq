FROM mcr.microsoft.com/dotnet/core/sdk:3.0-alpine AS build
WORKDIR /app

COPY . ./
RUN dotnet publish Orders -c Release -o Orders/out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-alpine AS runtime
WORKDIR /app
COPY --from=build /app/Orders/out ./

ENTRYPOINT ["dotnet", "Orders.dll"]
