FROM mcr.microsoft.com/dotnet/sdk:10.0 as build

WORKDIR /src

COPY ["ProductApi.csproj","./"]

RUN dotnet restore "ProductApi.csproj"  

COPY . .

RUN dotnet publish "ProductApi.csproj" -c Release -o /app/publish /p:UseAppHost=false


FROM mcr.microsoft.com/dotnet/aspnet:10.0 As final

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENV ASPNETCORE_HTTP_PORTS=8080

ENTRYPOINT ["dotnet", "ProductApi.dll"]

