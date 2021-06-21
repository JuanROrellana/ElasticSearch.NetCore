# Summary
This is a template of an ASP Dotnet API integrated with Kibana for dashboard and ElasticSearch for logging.
The Kibana and ElasticSearch Services are set up with Docker-Compose.

### Running the app
Execute all the commands on the root application.
Setting up Kibana and ElasticSearch with Docker-Compose:

```
docker-compose up
```

Running the Dotnet API:
```
dotnet watch run
```

Send logs to ElasticSearch:
```
curl -X GET "https://localhost:5001/WeatherForecast" -H  "accept: */*"
```

URL for Kibana Dashboard:
```
http://localhost:5601/app/home#/
```
