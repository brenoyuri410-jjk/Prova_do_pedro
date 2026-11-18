# Calendário de Rolês — Apresentação

## Problema
Organizar rolês exige registrar informações básicas, como título, data, horário e dinheiro necessário. Sem uma API simples, esses dados ficam dispersos e podem existir conflitos de agenda.

## Solução
O projeto oferece uma API REST para cadastrar e listar rolês. Os dados ficam em memória, em uma `List<Hangout>`, sem banco de dados, facilitando testes e demonstrações.

Endpoints disponíveis:

- `GET /hangouts`: lista os rolês cadastrados.
- `POST /hangouts`: cadastra um rolê e retorna `201 Created`.

## Arquitetura
O projeto é uma aplicação única ASP.NET Core Web API, organizada em:

- `Models/Hangout.cs`: representa um rolê com `Id`, `Title`, `Date`, `Time` e `MoneyNeeded`.
- `Controllers/HangoutsController.cs`: recebe as requisições HTTP e chama o serviço.
- `Services/HangoutService.cs`: mantém a lista em memória, aplica as regras e cadastra ou lista rolês.
- `Program.cs`: registra o serviço como `Singleton` e configura os controllers.

Fluxo principal: `Controller → Service → List<Hangout>`.

## Regras de negócio
O `POST /hangouts` retorna:

- `400 Bad Request` quando o título está vazio, a data está no passado, o horário não está no formato `HH:mm` ou o dinheiro necessário é negativo.
- `409 Conflict` quando já existe um rolê no mesmo dia e horário.
- `201 Created` quando o cadastro é válido.

Essas regras impedem dados básicos inválidos e conflitos de agenda.

## Como os documentos guiaram o Copilot
Os quatro arquivos em `Senac_prova_do_pedraaaaao/Docs/` definiram o escopo da implementação:

- `ARCHITECTURE.md`: orientou a separação entre Models, Controllers e Services, além do uso de lista em memória.
- `STACK.md`: definiu a plataforma ASP.NET Core e as ferramentas do projeto.
- `BUSINESS_RULES.md`: especificou as validações do cadastro e o conflito de data e horário.
- `SPEC.md`: definiu os endpoints `GET /hangouts` e `POST /hangouts`, com o formato dos dados.

Assim, o Copilot usou a documentação como contrato para criar somente os componentes necessários.

## Como rodar
Na raiz do projeto, execute:

```powershell
cd Senac_prova_do_pedraaaaao
dotnet restore
dotnet run --urls http://localhost:5088
```

Com a aplicação em execução, use `Senac_prova_do_pedraaaaao/Hangouts.http` no Visual Studio para testar as requisições GET e POST.

> Os documentos orientadores mencionam .NET 8, enquanto o projeto atualmente está configurado com `net10.0` no arquivo `.csproj`.
