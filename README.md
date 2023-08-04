[![.NET](https://github.com/prateekchaplot/TeamsService/actions/workflows/dotnet.yml/badge.svg)](https://github.com/prateekchaplot/TeamsService/actions/workflows/dotnet.yml)

# Teams Service Microservice

This repository contains a microservice that provides a Teams Service, allowing clients to query team lists, team members, and their details. It also supports adding and removing teams and team members.

## Table of Contents

- [Teams Service Microservice](#teams-service-microservice)
  - [Table of Contents](#table-of-contents)
  - [Folder Structure](#folder-structure)
  - [Getting Started](#getting-started)
  - [Usage](#usage)
  - [Tests](#tests)
  - [Contributing](#contributing)
  - [License](#license)

## Folder Structure
The repository follows a well-organized structure to ensure clarity and maintainability:
```
.github
    workflows
        dotnet.yml
src
    TeamsService
        Controllers
            MembersController
            TeamsController
        Models
            Member
            Team
        Persistence
            ITeamRepository
            MemoryTeamRepository
test
    IntegrationTests
    UnitTests

```

## Getting Started

To get started with the Teams Service microservice, follow these steps:

1. Clone this repository: `git clone https://github.com/prateekchaplot/TeamsService.git`
2. Navigate to the project directory: `cd TeamsService/src/TeamsService`
3. Build the project: `dotnet build`
4. Run the microservice: `dotnet run --project src/TeamsService`

## Usage

- Query team lists: Use the `TeamsController` to retrieve a list of teams.
- Query team members: Use the `MembersController` to retrieve information about team members.
- Add teams: Utilize the `TeamsController` to add new teams.
- Add team members: Use the `MembersController` to add new team members.
- Remove teams and members: Implement deletion using the appropriate controllers.

## Tests

This repository includes both unit tests and integration tests:

- To run unit tests: Navigate to the `test/UnitTests` directory and run `dotnet test`.
- To run integration tests: Navigate to the `test/IntegrationTests` directory and run `dotnet test`.

## Contributing

Contributions to this microservice are welcome. To contribute, follow these steps:

1. Fork this repository.
2. Create a new branch: `git checkout -b feature/new-feature`.
3. Make your changes and commit them: `git commit -m "Add new feature"`.
4. Push to the branch: `git push origin feature/new-feature`.
5. Open a pull request.

## License

This project is licensed under the [MIT License](LICENSE).
