# Coding Challenge
## Objective
The Wikimedia Foundation provides all pageviews for Wikipedia site since 2015. 
These pageviews can be download in gzip format, and are aggregated per hour per page.
The Hourly Dump is around 50 mb, and the unzipped file is between 100 MB and 250 MB.

Technical documentation of the service: [Wikimedia Documentation](https://wikitech.wikimedia.org/wiki/Analytics/Data_Lake/Traffic/Pageviews)

Sample Link: [Wikimedia Dumps 2015](https://dumps.wikimedia.org/other/pageviews/2015/2015-05/)

## Building with

- .Net Core 3.1 (C#)
- XUnit for testing.
- Docker.

## Principles 
- SOLID

## Architecture
- Drive Domain Design(DDD)

## Docker
- First of all , lest publish our app, running this command ,
it's necesary stay in this folder ./Wikipedia Challenge.Console.

```
dotnet publish -c Release
```
- After this, we can build the docker image.

- Create the docker image.
```
docker build -t wkchallenge-image -f Dockerfile .
```
- Run the container.
```
docker run -it --memory="4g" wkchallenge-image
```


https://github.com/ItsHectorMontes/WikipediaChallenge/blob/main/Assets/DockerWorking.JPG















