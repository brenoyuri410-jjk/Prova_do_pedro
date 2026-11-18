# Calendário de Rolês — Arquitetura

Projeto único em ASP.NET Core Web API .NET 8.

- `Controllers/`: recebe as requisições HTTP e chama os Services.
- `Models/`: define as entidades e os dados dos rolês.
- `Services/`: aplica as regras e guarda os rolês em uma lista em memória.

Fluxo: `Controller → Service → lista em memória`.