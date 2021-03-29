FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["WikipediaChallenge.ConsoleUI/WikipediaChallenge.ConsoleUI.csproj", "WikipediaChallenge.ConsoleUI/"]
COPY ["WikipediaChallenge.ApplicationCore/WikipediaChallenge.ApplicationCore.csproj", "WikipediaChallenge.ApplicationCore/"]
COPY ["WikipediaChallenge.Domain/WikipediaChallenge.Domain.csproj", "WikipediaChallenge.Domain/"]
RUN dotnet restore "WikipediaChallenge.ConsoleUI/WikipediaChallenge.ConsoleUI.csproj"
COPY . .
WORKDIR "/src/WikipediaChallenge.ConsoleUI"
RUN dotnet build "WikipediaChallenge.ConsoleUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WikipediaChallenge.ConsoleUI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WikipediaChallenge.ConsoleUI.dll"]