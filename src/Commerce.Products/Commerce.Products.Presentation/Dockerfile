# Usa a imagem oficial do SDK do .NET Core para compilar o aplicativo
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copia os arquivos do projeto para o cont�iner
COPY . .

# Restaura as depend�ncias e compila o aplicativo
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Cria uma imagem m�nima para executar o aplicativo
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Exponha a porta em que o aplicativo ser� executado
EXPOSE 80
EXPOSE 443

# Inicie o aplicativo quando o cont�iner for iniciado
ENTRYPOINT ["dotnet", "Commerce.Products.Presentation.dll"]
