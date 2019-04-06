FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY DockerTest.FileUpload/DockerTest.FileUpload.csproj DockerTest.FileUpload/
RUN dotnet restore DockerTest.FileUpload/DockerTest.FileUpload.csproj
COPY . .
WORKDIR /src/DockerTest.FileUpload
RUN dotnet build DockerTest.FileUpload.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish DockerTest.FileUpload.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DockerTest.FileUpload.dll"]
