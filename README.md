## PojectCosmosTask

**ProjectCosmosTask** is an .NET REST Api witten in C# Layered Arhitecture using Azure Cosmos DB for database.

To run this project clone this repository and populate **appsettings.json** with Azure Cosmos DB key.

### List of endpoints

| Endpoint  | REST Method | Description |
| --- | --- | --- |
| /api/projects  | GET | Returns all projects |
| /api/projects/:id  | GET  | Returns project by specific Id |
| /api/projects/:id/tasks  | GET  | Return all tasks for specific project |
| /api/projects/:projectId/tasks/:taskId | GET  | Return specific task from project |
