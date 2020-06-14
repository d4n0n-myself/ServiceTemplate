WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
COPY . .
WORKDIR "/Template.Web"
RUN dotnet build  "Template.Web.csproj" -c Release --source "https://api.nuget.org/v3/index.json" -o /app

FROM build AS publish
RUN dotnet publish "Template.Web.csproj" -c Release -o /app

FROM publish AS final
WORKDIR /app
COPY --from=publish /app .
WORKDIR /app

ENTRYPOINT ["dotnet", "Template.Web.dll"]