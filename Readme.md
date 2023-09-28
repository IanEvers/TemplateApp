# Template App

This repository serves as an example of how to write plugins for the BlackBird platform.

## Actions

Actions represent specific tasks or operations that can be executed within our platform. To find the available actions and their implementation details, navigate to the `Actions` directory in the codebase.

In this directory, you will find file with list of actions.

## Webhooks

Webhooks enable the Template App to communicate with external services or applications in real-time. When specific events occur, our platform will send HTTP POST requests to the defined webhook endpoints. To view and manage the webhooks, go to the `Webhooks` directory in the codebase. You can also find `Handlers` and `Payloads` there. Handlers are used to manage webhook subscription when bird is created/deleted. Payloads represent webhook response data.

## Connections

Connections in the Template App are used to establish and manage connections to external services or APIs. They provide the necessary authentication and authorization details for interacting with these services securely. To explore existing connections or add new ones, head to the `Connections` directory and open the `ConnectionDefinition.cs` file.
In `OAuth` folder you can see OAuth management services. `OAuth2AuthorizeService` is responsible for building OAuth url for user authorization and `OAuth2TokenService` is used for managing user OAuth credentials.