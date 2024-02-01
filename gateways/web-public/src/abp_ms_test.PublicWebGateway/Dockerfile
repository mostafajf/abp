FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_URLS=http://+:80;https://+:443

FROM mycompanyname/abp_ms_test-base:1.0 AS build
WORKDIR /src

COPY . .
WORKDIR "/src/gateways/web-public/src/abp_ms_test.PublicWebGateway"
RUN dotnet publish -c Release -o /app

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "abp_ms_test.PublicWebGateway.dll"]