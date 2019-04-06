FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY DockerTest.Blog/DockerTest.Blog.csproj DockerTest.Blog/
RUN dotnet restore DockerTest.Blog/DockerTest.Blog.csproj
COPY . .
WORKDIR /src/DockerTest.Blog
RUN dotnet build DockerTest.Blog.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish DockerTest.Blog.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DockerTest.Blog.dll"]
