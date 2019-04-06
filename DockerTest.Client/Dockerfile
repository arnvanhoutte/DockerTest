FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src

FROM node:10.15 as node-build
WORKDIR /web
COPY ClientApp .
RUN npm install
RUN npm run build:prod

FROM build as publish
WORKDIR /src
COPY . .
RUN dotnet publish DockerTest.Client.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
COPY --from=node-build /web/dist ClientApp/dist
ENTRYPOINT ["dotnet", "DockerTest.Client.dll"]
