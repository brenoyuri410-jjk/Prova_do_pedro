# Calendário de Rolês

API REST simples para cadastrar e listar rolês, com armazenamento em memória.

## Funcionalidades

- Cadastro de rolês com `POST /hangouts`.
- Listagem com `GET /hangouts`.
- Validação de título, data, horário e dinheiro necessário.
- Bloqueio de dois rolês no mesmo dia e horário.
- Respostas `400` para dados inválidos e `409` para duplicidade.

## Tecnologias

- ASP.NET Core Web API
- .NET 10 (`net10.0`)
- Controllers
- OpenAPI
- Lista em memória

## Estrutura

```text
Senac_prova_do_pedraaaaao/
├── Controllers/
├── Models/
├── Services/
├── Docs/
└── Hangouts.http
```

A documentação de apresentação está em [`docs/APRESENTACAO.md`](docs/APRESENTACAO.md). Os documentos que orientaram o desenvolvimento estão em [`Senac_prova_do_pedraaaaao/Docs/`](Senac_prova_do_pedraaaaao/Docs/).

## Como executar

No PowerShell:

```powershell
dotnet restore .\Senac_prova_do_pedraaaaao\Senac_prova_do_pedraaaaao.csproj
dotnet run --project .\Senac_prova_do_pedraaaaao\Senac_prova_do_pedraaaaao.csproj --urls http://localhost:5088
```

Depois, abra `Senac_prova_do_pedraaaaao/Hangouts.http` no Visual Studio e execute as requisições GET e POST.

## Exemplo de cadastro

```json
{
  "title": "Cinema",
  "date": "2026-06-20",
  "time": "19:30",
  "moneyNeeded": 35.00
}
```
