# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Packages.props", "."]
COPY ["Directory.Build.props", "."]
COPY ["src/RecipeManagement.WebAPI/RecipeManagement.WebAPI.csproj", "src/RecipeManagement.WebAPI/"]
COPY ["src/RecipeManagement.Application/RecipeManagement.Application.csproj", "src/RecipeManagement.Application/"]
COPY ["src/RecipeManagement.Contracts/RecipeManagement.Contracts.csproj", "src/RecipeManagement.Contracts/"]
COPY ["src/RecipeManagement.SharedKernel/RecipeManagement.SharedKernel.csproj", "src/RecipeManagement.SharedKernel/"]
COPY ["src/RecipeManagement.Domain/RecipeManagement.Domain.csproj", "src/RecipeManagement.Domain/"]
COPY ["src/RecipeManagement.Infrastructure/RecipeManagement.Infrastructure.csproj", "src/RecipeManagement.Infrastructure/"]
COPY ["src/RecipeManagement.WebAPI.Contracts/RecipeManagement.WebAPI.Contracts.csproj", "src/RecipeManagement.WebAPI.Contracts/"]
RUN dotnet restore "./src/RecipeManagement.WebAPI/RecipeManagement.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/RecipeManagement.WebAPI"
RUN dotnet build "./RecipeManagement.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RecipeManagement.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RecipeManagement.WebAPI.dll"]