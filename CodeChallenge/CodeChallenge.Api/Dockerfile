# Base image
FROM dtr.wpnops.net/docker/images/dotnet/core:runtime

# Image description
LABEL MANTAINER="cibot"
LABEL PROJECT_NAME="CodeChallenge"
LABEL PROJECT_NAMESPACE="version1"
LABEL DOCKERFILE_DATE="2018-09-13"
LABEL DOTNET_VERSION="2.2"

# Project runtime configuration
WORKDIR /app

COPY publish .

HEALTHCHECK --interval=5s --timeout=3s CMD curl -X GET http://localhost:5000

ENTRYPOINT ["dotnet" , "CodeChallenge.Api.dll"]
