FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ante-up/ante-up.csproj", "ante-up/"]
RUN dotnet restore "ante-up/ante-up.csproj"
COPY . .
WORKDIR "/src/ante-up"
RUN dotnet build "ante-up.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ante-up.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ante-up.dll"]
