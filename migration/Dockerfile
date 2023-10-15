FROM amd64/alpine:latest

WORKDIR /migrations

COPY ./migration/seed.sql .

RUN apk upgrade --no-cache && \
    apk add --no-cache mysql-client

CMD mysql -h $DB_ENDPOINT -u $DB_USER -p$DB_PASSWORD --verbose TaskTrackingSystem < seed.sql
