# Use the official .NET Core SDK as a build image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory inside the container
WORKDIR /src

# Copy the solution file and restore dependencies
COPY . .
RUN dotnet restore 
RUN dotnet clean
RUN dotnet build


# Copy the entire solution directory
# COPY . .

# Build the application (replace YourProjectName with the actual project name)
RUN dotnet publish -c Release -o /app MyJourneyToWork/MyJourneyToWork.csproj

# Use the official .NET Core runtime as a base image
FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base

# Set the working directory inside the container
WORKDIR /app

# Copy the published files from the build image
COPY --from=build /app .

# Define the entry point for the application
ENTRYPOINT ["dotnet", "MyJourneyToWork.dll"]
