# Use the official .NET SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy only the .csproj file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy all files and publish the application
COPY . ./
RUN dotnet publish -c Release -o out

# Use the official .NET runtime image for running the app
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Expose the port the app runs on
EXPOSE 80

# Command to run the application
ENTRYPOINT ["dotnet", "WebCodeFirst.dll"]
