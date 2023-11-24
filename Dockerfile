# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:8.0 as build-env
WORKDIR /NutritionApi
COPY NutritionApi/*.csproj .
RUN dotnet restore
COPY NutritionApi .
RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime
WORKDIR /publish
COPY --from=build-env /publish .
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "NutritionApi.dll"]