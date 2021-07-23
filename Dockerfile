FROM mcr.microsoft.com/mssql/server:2019-latest AS build
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=R00trootroot

WORKDIR /tmp

RUN /opt/mssql/bin/sqlservr --accept-eula & sleep 10 

