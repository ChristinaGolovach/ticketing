#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Ticketing.Api/Ticketing.Api.csproj", "Ticketing.Api/"]
COPY ["src/Modules/Events/Modules.Events.Api/Modules.Events.Api.csproj", "src/Modules/Events/Modules.Events.Api/"]
COPY ["src/Modules/Events/Modules.Events.Core/Modules.Events.Core.csproj", "src/Modules/Events/Modules.Events.Core/"]
COPY ["src/Shared/Ticketing.Shared.Core/Ticketing.Shared.Core.csproj", "src/Shared/Ticketing.Shared.Core/"]
COPY ["src/Shared/Ticketing.Shared.Data/Ticketing.Shared.Data.csproj", "src/Shared/Ticketing.Shared.Data/"]
COPY ["src/Shared/Ticketing.Shared.Infrastructure/Ticketing.Shared.Infrastructure.csproj", "src/Shared/Ticketing.Shared.Infrastructure/"]
COPY ["src/Modules/Events/Modules.Events.Data/Modules.Events.Data.csproj", "src/Modules/Events/Modules.Events.Data/"]
COPY ["src/Modules/Events/Modules.Events.Infrastructure/Modules.Events.Infrastructure.csproj", "src/Modules/Events/Modules.Events.Infrastructure/"]
COPY ["src/Modules/Events/Modules.Events.ModuleApi/Modules.Events.ModuleApi.csproj", "src/Modules/Events/Modules.Events.ModuleApi/"]
COPY ["src/Shared/Ticketing.Shared.Messaging/Ticketing.Shared.Messaging.csproj", "src/Shared/Ticketing.Shared.Messaging/"]
COPY ["src/Modules/Orders/Modules.Orders.Api/Modules.Orders.Api.csproj", "src/Modules/Orders/Modules.Orders.Api/"]
COPY ["src/Modules/Orders/Modules.Orders.Core/Modules.Orders.Core.csproj", "src/Modules/Orders/Modules.Orders.Core/"]
COPY ["src/Modules/Orders/Modules.Orders.Infrastructure/Modules.Orders.Infrastructure.csproj", "src/Modules/Orders/Modules.Orders.Infrastructure/"]
COPY ["src/Modules/Orders/Modules.Orders.Data/Modules.Orders.Data.csproj", "src/Modules/Orders/Modules.Orders.Data/"]
COPY ["src/Modules/Orders/Modules.Orders.ModuleApi/Modules.Orders.ModuleApi.csproj", "src/Modules/Orders/Modules.Orders.ModuleApi/"]
COPY ["src/Modules/Payments/Modules.Payments.Api/Modules.Payments.Api.csproj", "src/Modules/Payments/Modules.Payments.Api/"]
COPY ["src/Modules/Payments/Modules.Payments.Core/Modules.Payments.Core.csproj", "src/Modules/Payments/Modules.Payments.Core/"]
COPY ["src/Modules/Payments/Modules.Payments.Data/Modules.Payments.Data.csproj", "src/Modules/Payments/Modules.Payments.Data/"]
COPY ["src/Modules/Payments/Modules.Payments.Infrastructure/Modules.Payments.Infrastructure.csproj", "src/Modules/Payments/Modules.Payments.Infrastructure/"]
COPY ["src/Modules/Payments/Modules.Payments.ModuleApi/Modules.Payments.ModuleApi.csproj", "src/Modules/Payments/Modules.Payments.ModuleApi/"]
COPY ["src/Modules/Users/Modules.Users.Data/Modules.Users.Data.csproj", "src/Modules/Users/Modules.Users.Data/"]
RUN dotnet restore "./Ticketing.Api/Ticketing.Api.csproj"
COPY . .
WORKDIR "/src/Ticketing.Api"
RUN dotnet build "./Ticketing.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Ticketing.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ticketing.Api.dll"]