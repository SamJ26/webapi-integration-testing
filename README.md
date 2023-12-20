# Integrationt testing in .NET

Sample project showing how to do integration testing of ASP.NET Core web API with real database using [Testcontainers](https://testcontainers.com/) package.

Requirements:

- .NET 8
- Docker daemon

## Linux trobleshooting

There were some issues related to linux user permissions and docker usage.

## Auto discovery did not detect a Docker host

This issue is caused by insufficient permissions to access `var/run/docker.sock` which is used for communication with docker daemon. 

Solution:

- Add user which is used to execute the tests to the docker group: `sudo usermod -aG docker $USER`
- Reboot computer
- Check if required user belogns to `docker` group: `groups $USER`
- Run a simple docker command without sudo to ensure you have proper access (e.g. `docker ps`)
- Now you should be able to run the test with current user using `dotnet test`
